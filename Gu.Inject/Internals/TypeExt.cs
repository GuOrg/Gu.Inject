namespace Gu.Inject
{
    using System;
    using System.Linq;

    /// <summary>
    /// Helpers for <see cref="Type"/>.
    /// </summary>
    internal static class TypeExt
    {
        /// <summary>
        /// Returns nicely formatted type names for generic types.
        /// </summary>
        internal static string PrettyName(this Type type)
        {
            if (type == typeof(long))
            {
                return "long";
            }

            if (type == typeof(double))
            {
                return "double";
            }

            if (type == typeof(int))
            {
                return "int";
            }

            if (type == typeof(string))
            {
                return "string";
            }

            if (type == typeof(bool))
            {
                return "bool";
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