namespace Gu.Inject
{
    using System;
    using System.Linq;
    using System.Reflection;

    internal readonly struct Constructor
    {
        internal readonly ConstructorInfo ConstructorInfo;
        internal readonly ParameterInfo[]? Parameters;

        private Constructor(ConstructorInfo constructorInfo, ParameterInfo[]? parameters)
        {
            this.ConstructorInfo = constructorInfo;
            this.Parameters = parameters;
        }

        internal static Constructor Get(Type type)
        {
            var constructors = type.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (constructors.Length > 1)
            {
                var message = $"Type {type.PrettyName()} has more than one constructor.\r\n" +
                                     "Add a binding specifying which constructor to use.";
                throw new ResolveException(type, message);
            }

            var ctor = constructors[0];
            var parameters = ctor.GetParameters();
            if (parameters.Length == 0)
            {
                return new Constructor(ctor, null);
            }

            if (parameters.Last() is { CustomAttributes: { } attributes } &&
                attributes.Any(x => x.AttributeType == typeof(System.ParamArrayAttribute)))
            {
                var message = $"Type {type.PrettyName()} has params parameter which is not supported.\r\n" +
                              "Add a binding specifying how to create an instance.";
                throw new ResolveException(type, message);
            }

            return new Constructor(ctor, parameters);
        }
    }
}