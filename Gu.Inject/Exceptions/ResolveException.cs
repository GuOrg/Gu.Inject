namespace Gu.Inject
{
    using System;
    using System.Text;

    public class ResolveException : Exception
    {
        private readonly Type type;

        public ResolveException(Type type, Exception inner)
            : base(CreateMessage(type, inner), inner)
        {
            this.type = type;
        }

        public ResolveException(Type type, string message)
            : base(message, null)
        {
            this.type = type;
        }

        private static string CreateMessage(Type type, Exception inner)
        {
            var builder = new StringBuilder();
            builder.AppendLine($"{type.PrettyName()}(");
            foreach (var line in inner.Message.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                builder.AppendLine($"  {line}");
            }

            return builder.ToString();
        }
    }
}
