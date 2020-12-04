// ReSharper disable All
namespace Gu.Inject.Tests.Types
{
    using System;

    public class StaticConstructor
    {
#pragma warning disable IDE0044 // Add readonly modifier
        private static int n;
#pragma warning restore IDE0044 // Add readonly modifier

        static StaticConstructor()
        {
            n++;
        }

        public StaticConstructor()
        {
            if (n != 1)
            {
                throw new InvalidOperationException($"Static constructor ran {n} times.");
            }
        }
    }
}
