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

            return cache.GetOrAdd(type, CreateMapped);
        }

        internal static void Initialize(Assembly root, bool recursive = true)
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

                cache = Create(root, recursive);
            }
        }

        private static List<Type> CreateMapped(Type type)
        {
            if (type.IsGenericType)
            {
                var typeDefinition = type.GetGenericTypeDefinition();
                if (cache.TryGetValue(typeDefinition, out List<Type> mappeds))
                {
                    var mappedTypes = new List<Type>(mappeds.Count);
                    foreach (var mapped in mappeds)
                    {
                        mappedTypes.Add(
                            mapped.IsGenericTypeDefinition
                                ? mapped.MakeGenericType(type.GenericTypeArguments)
                                : mapped);
                    }

                    cache.TryAdd(type, mappedTypes);
                    return mappedTypes;
                }
            }

            return new List<Type>(0);
        }

        private static ConcurrentDictionary<Type, List<Type>> Create(Assembly root, bool recursive)
        {
            var map = new Dictionary<Type, List<Type>>();
            var assemblies = recursive
                ? RecursiveAssemblies(root)
                : (IEnumerable<Assembly>)new[] { root };
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
                        MapInterfaceOrBase(type, @interface, map);
                    }

                    var baseType = type.BaseType;
                    while (baseType != null &&
                        baseType != typeof(object))
                    {
                        MapInterfaceOrBase(type, baseType, map);
                        baseType = baseType.BaseType;
                    }
                }
            }

            return new ConcurrentDictionary<Type, List<Type>>(map);
        }

        private static void MapInterfaceOrBase(Type type, Type interfaceOrBase, Dictionary<Type, List<Type>> map)
        {
            if (type.IsAbstract)
            {
                return;
            }

            if (interfaceOrBase.IsGenericType)
            {
                interfaceOrBase = interfaceOrBase.GetGenericTypeDefinition();
            }

            if (!map.TryGetValue(interfaceOrBase, out List<Type> types))
            {
                map[interfaceOrBase] = types = new List<Type>();
            }

            if (!types.Contains(type))
            {
                types.Add(type);
            }
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