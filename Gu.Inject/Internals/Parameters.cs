namespace Gu.Inject
{
    using System;
    using System.Collections.Concurrent;
    using System.Reflection;

    internal readonly struct Parameters
    {
        internal readonly ParameterInfo[] Infos;

        private static readonly ConcurrentDictionary<int, ConcurrentQueue<object?[]>> ArrayPool = new();

        private readonly ConcurrentQueue<object?[]> pool;

        internal Parameters(ParameterInfo[] infos)
        {
            this.Infos = infos;
            this.pool = ArrayPool.GetOrAdd(infos.Length, _ => new ConcurrentQueue<object?[]>());
        }

        internal object?[] Arguments => this.pool.TryDequeue(out var cached)
            ? cached
            : new object[this.Infos.Length];

        internal void Return(object?[] args)
        {
            Array.Clear(args, 0, args.Length);
            this.pool!.Enqueue(args);
        }
    }
}
