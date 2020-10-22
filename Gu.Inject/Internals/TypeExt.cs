namespace Gu.Inject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Helpers for <see cref="Type"/>.
    /// </summary>
    internal static class TypeExt
    {
        private static readonly Dictionary<Type, string> Map = new Dictionary<Type, string>
        {
            { typeof(bool), "bool" },
            { typeof(byte), "byte" },
            { typeof(char), "char" },
            { typeof(decimal), "decimal" },
            { typeof(double), "double" },
            { typeof(float), "float" },
            { typeof(int), "int" },
            { typeof(long), "long" },
            { typeof(object), "object" },
            { typeof(sbyte), "sbyte" },
            { typeof(short), "short" },
            { typeof(string), "string" },
            { typeof(uint), "uint" },
            { typeof(ulong), "ulong" },
        };

        /// <summary>
        /// Returns nicely formatted type names for generic types.
        /// </summary>
        internal static string PrettyName(this Type type)
        {
            if (Map.TryGetValue(type, out var mapped))
            {
                return mapped;
            }

            if (type.IsGenericType)
            {
                var arguments = string.Join(", ", type.GenericTypeArguments.Select(PrettyName));

                if (type.DeclaringType != null)
                {
                    return $"{type.DeclaringType.PrettyName()}.{type.Name.Split('`').First()}<{arguments}>";
                }

                return $"{type.Name.Split('`').First()}<{arguments}>";
            }

            if (type.DeclaringType != null)
            {
                return $"{type.DeclaringType.PrettyName()}.{type.Name}";
            }

            return type.Name;
        }
    }
}