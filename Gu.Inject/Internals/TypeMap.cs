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
                if (cache.TryGetValue(typeDefinition, out var mappeds))
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
            map.MapTypes(root.GetTypes());
            if (recursive)
            {
                var assemblies = root.RecursiveReferencedAssemblies();
                foreach (var assembly in assemblies)
                {
                    if (assembly == root)
                    {
                        continue;
                    }

                    map.MapTypes(assembly.GetExportedTypes());
                }
            }

            return new ConcurrentDictionary<Type, List<Type>>(map);
        }

        private static void MapTypes(this Dictionary<Type, List<Type>> map, IEnumerable<Type> types)
        {
            foreach (var type in types)
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
                    MapInterfaceOrBase(map, type, @interface);
                }

                var baseType = type.BaseType;
                while (baseType != null &&
                       baseType != typeof(object))
                {
                    MapInterfaceOrBase(map, type, baseType);
                    baseType = baseType.BaseType;
                }
            }
        }

        private static void MapInterfaceOrBase(Dictionary<Type, List<Type>> map, Type type, Type interfaceOrBase)
        {
            if (type.IsAbstract)
            {
                return;
            }

            if (interfaceOrBase.IsGenericType)
            {
                interfaceOrBase = interfaceOrBase.GetGenericTypeDefinition();
            }

            if (!map.TryGetValue(interfaceOrBase, out var types))
            {
                map[interfaceOrBase] = types = new List<Type>();
            }

            if (!types.Contains(type))
            {
                types.Add(type);
            }
        }

        private static HashSet<Assembly> RecursiveReferencedAssemblies(this Assembly assembly, HashSet<Assembly>? assemblies = null)
        {
            assemblies ??= new HashSet<Assembly>();
            if (assemblies.Add(assembly))
            {
                foreach (var referencedAssemblyName in assembly.GetReferencedAssemblies())
                {
                    var referencedAssembly = AppDomain.CurrentDomain.GetAssemblies()
                                                                    .SingleOrDefault(x => x.GetName() == referencedAssemblyName);

                    if (referencedAssembly is null)
                    {
                        try
                        {
                            referencedAssembly = AppDomain.CurrentDomain.Load(referencedAssemblyName);
                        }
                        catch
                        {
                            // IO can always go wrong.
                        }
                    }

                    if (referencedAssembly is { })
                    {
                        RecursiveReferencedAssemblies(referencedAssembly, assemblies);
                    }
                }
            }

            return assemblies;
        }
    }
}