namespace Gu.Inject
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    internal static class DefaultTypeMap
    {
        private static readonly IReadOnlyList<Type> Empty = new Type[0];
        private static readonly ConcurrentDictionary<Type, List<Type>> Map = CreateMap();

        internal static IReadOnlyList<Type> GetMapped(Type type)
        {
            if (Map.TryGetValue(type, out List<Type> mapped))
            {
                return mapped;
            }

            if (type.IsGenericType)
            {
                var typeDefinition = type.GetGenericTypeDefinition();
                if (Map.TryGetValue(typeDefinition, out mapped))
                {

                }
            }

            return Empty;
        }

        private static ConcurrentDictionary<Type, List<Type>> CreateMap()
        {
            var map = new Dictionary<Type, List<Type>>();
            // var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.GetName().Name.Contains("Inject")).ToArray();
            foreach (var assembly in assemblies)
            {
                foreach (var type in assembly.GetTypes())
                {
                    if (type.IsValueType ||
                        type.IsStatic())
                    {
                        continue;
                    }

                    if (type.IsInterface || type.IsAbstract)
                    {
                        if (!map.ContainsKey(type))
                        {
                            map[type] = new List<Type>();
                        }

                        continue;
                    }

                    foreach (var @interface in type.GetInterfaces())
                    {
                        if (!map.TryGetValue(@interface, out List<Type> types))
                        {
                            map[@interface] = types = new List<Type>();
                        }

                        types.Add(type);
                    }
                }
            }

            return new ConcurrentDictionary<Type, List<Type>>(map);
        }
    }
}