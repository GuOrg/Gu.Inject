namespace Gu.Inject.Tests.Types
{
    public static class Graph2
    {
        public class Node1
        {
            public Node1(Node2 node2)
            {
                this.Node2 = node2;
            }

            public Node2 Node2 { get; }
        }

        public class Node2
        {
        }
    }
}