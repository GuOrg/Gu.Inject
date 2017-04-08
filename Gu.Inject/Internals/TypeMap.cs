namespace Gu.Inject
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    internal static class TypeMap
    {
        private static readonly IReadOnlyList<Type> Empty = new Type[0];
        private static ConcurrentDictionary<Type, List<Type>> cache;

        internal static bool IsInitialized => cache != null;

        internal static IReadOnlyList<Type> GetMapped(Type type)
        {
            if (type.IsSealed)
            {
                return Empty;
            }

            if (cache.TryGetValue(type, out List<Type> mapped))
            {
                return mapped;
            }

            if (type.IsGenericType)
            {
                var typeDefinition = type.GetGenericTypeDefinition();
                if (cache.TryGetValue(typeDefinition, out mapped))
                {
                    mapped = mapped.Select(t => t.MakeGenericType(type.GenericTypeArguments))
                                   .ToList();
                    cache.TryAdd(type, mapped);
                    return mapped;
                }
            }

            return Empty;
        }

        internal static void Initialize(Assembly root)
        {
            if (cache != null)
            {
                return;
            }

            lock (Empty)
            {
                if (cache != null)
                {
                    return;
                }

                cache = Create(root);
            }
        }

        private static ConcurrentDictionary<Type, List<Type>> Create(Assembly root)
        {
            var map = new Dictionary<Type, List<Type>>();
            var assemblies = RecursiveAssemblies(root);
            foreach (var assembly in assemblies)
            {
                foreach (var type in assembly.GetTypes())
                {
                    if (type.IsValueType ||
                        type.IsStatic() ||
                        type.IsInterface)
                    {
                        continue;
                    }

                    var info = type.GetTypeInfo();
                    foreach (var @interface in info.ImplementedInterfaces)
                    {
                        MapInterface(type, @interface, map);
                    }

                    var baseType = type.BaseType;
                    if (baseType?.IsAbstract == true)
                    {
                        MapInterface(type, baseType, map);
                    }
                }
            }

            return new ConcurrentDictionary<Type, List<Type>>(map);
        }

        private static void MapInterface(Type type, Type @interface, Dictionary<Type, List<Type>> map)
        {
            if (type.IsAbstract)
            {
                return;
            }

            if (@interface.IsGenericType)
            {
                @interface = @interface.GetGenericTypeDefinition();
            }

            if (!map.TryGetValue(@interface, out List<Type> types))
            {
                map[@interface] = types = new List<Type>();
            }

            types.Add(type);
        }

        private static HashSet<Assembly> RecursiveAssemblies(Assembly assembly, HashSet<Assembly> assemblies = null)
        {
            assemblies = assemblies ?? new HashSet<Assembly>();
            if (assemblies.Add(assembly))
            {
                foreach (var referencedAssemblyName in assembly.GetReferencedAssemblies())
                {
                    var referencedAssembly = AppDomain.CurrentDomain.GetAssemblies()
                                                                    .SingleOrDefault(x => x.GetName() == referencedAssemblyName) ??
                                             AppDomain.CurrentDomain.Load(referencedAssemblyName);
                    RecursiveAssemblies(referencedAssembly, assemblies);
                }
            }

            return assemblies;
        }
    }
}