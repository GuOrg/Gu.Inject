// ReSharper disable UnusedMember.Global
namespace Gu.Inject.Benchmarks
{
    using System;
    using System.Collections.Concurrent;
    using BenchmarkDotNet.Attributes;

    [MemoryDiagnoser]
    public class Caching
    {
        private static readonly ConcurrentQueue<Node> Cache = new ConcurrentQueue<Node>();

        static Caching()
        {
            Cache.Enqueue(new Node(typeof(Caching)));
            Cache.Enqueue(new Node(typeof(Caching)));
            Cache.Enqueue(new Node(typeof(Caching)));
        }

        [Benchmark(Baseline = true)]
        public object New()
        {
            return new Node(typeof(Caching));
        }

        [Benchmark]
        public object TryDequeueEnqueue()
        {
            if (Cache.TryDequeue(out Node result))
            {
                Cache.Enqueue(result);
                return result;
            }

            throw new InvalidOperationException();
        }

        private class Node
        {
            private readonly Type type;
            private readonly Node previous;

            public Node(Type type)
                : this(type, null)
            {
            }

            private Node(Type type, Node previous)
            {
                this.type = type;
                this.previous = previous;
            }

            public Node Next(Type type) => new Node(type, this);

            public bool Contains(Type type)
            {
                if (this.type == type)
                {
                    return true;
                }

                return this.previous?.Contains(type) == true;
            }
        }
    }
}