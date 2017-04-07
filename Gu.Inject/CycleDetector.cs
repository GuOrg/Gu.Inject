namespace Gu.Inject
{
    using System.Collections.Generic;
    using System.Linq;

    internal class CycleDetector<T>
    {
        private readonly HashSet<T> visited = new HashSet<T>();
        private readonly Stack<T> order = new Stack<T>();

        public bool HasCycle => this.visited.Contains(this.order.Peek());

        public void Add(T value)
        {
            if (this.order.Count > 0)
            {
                this.visited.Add(this.order.Peek());
            }

            this.order.Push(value);
        }

        public void RemoveLast()
        {
            var last = this.order.Pop();
            if (this.order.Count > 0)
            {
                this.visited.Remove(this.order.Peek());
            }
        }

        public IEnumerable<T> GetElements()
        {
            return this.order.Reverse();
        }
    }
}
