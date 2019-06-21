// ReSharper disable UnusedParameter.Local
// ReSharper disable UnusedMember.Global
// ReSharper disable EmptyConstructor
namespace Gu.Inject.Benchmarks.Types
{
    using System.Collections.Generic;
    using System.Linq;

    public static class Graph50
    {
        public class Node1 : INode
        {
            public Node1(
                Node2 node2,
                Node7 node7,
                Node10 node10,
                Node16 node16,
                Node18 node18,
                Node24 node24,
                Node26 node26,
                Node27 node27,
                Node29 node29,
                Node32 node32)
            {
                this.Children = new INode[]
                {
                    node2,
                    node7,
                    node10,
                    node16,
                    node18,
                    node24,
                    node26,
                    node27,
                    node29,
                    node32,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node2 : INode
        {
            public Node2(
                Node4 node4,
                Node8 node8,
                Node16 node16,
                Node48 node48)
            {
                this.Children = new INode[]
                {
                    node4,
                    node8,
                    node16,
                    node48,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node3 : INode
        {
            public Node3(
                Node33 node33)
            {
                this.Children = new INode[]
                {
                    node33,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node4 : INode
        {
            public Node4(
                Node8 node8,
                Node32 node32,
                Node36 node36)
            {
                this.Children = new INode[]
                {
                    node8,
                    node32,
                    node36,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node5 : INode
        {
            public Node5(
                Node30 node30)
            {
                this.Children = new INode[]
                {
                    node30,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node6 : INode
        {
            public Node6(
                Node18 node18,
                Node30 node30)
            {
                this.Children = new INode[]
                {
                    node18,
                    node30,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node7 : INode
        {
            public Node7(
                Node35 node35,
                Node49 node49)
            {
                this.Children = new INode[]
                {
                    node35,
                    node49,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node8 : INode
        {
            public Node8()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node9 : INode
        {
            public Node9(
                Node18 node18)
            {
                this.Children = new INode[]
                {
                    node18,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node10 : INode
        {
            public Node10()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node11 : INode
        {
            public Node11(
                Node22 node22)
            {
                this.Children = new INode[]
                {
                    node22,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node12 : INode
        {
            public Node12(
                Node24 node24,
                Node48 node48)
            {
                this.Children = new INode[]
                {
                    node24,
                    node48,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node13 : INode
        {
            public Node13(
                Node39 node39)
            {
                this.Children = new INode[]
                {
                    node39,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node14 : INode
        {
            public Node14(
                Node28 node28)
            {
                this.Children = new INode[]
                {
                    node28,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node15 : INode
        {
            public Node15(
                Node30 node30)
            {
                this.Children = new INode[]
                {
                    node30,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node16 : INode
        {
            public Node16()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node17 : INode
        {
            public Node17()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node18 : INode
        {
            public Node18()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node19 : INode
        {
            public Node19()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node20 : INode
        {
            public Node20()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node21 : INode
        {
            public Node21()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node22 : INode
        {
            public Node22()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node23 : INode
        {
            public Node23()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node24 : INode
        {
            public Node24(
                Node48 node48)
            {
                this.Children = new INode[]
                {
                    node48,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node25 : INode
        {
            public Node25()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node26 : INode
        {
            public Node26()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node27 : INode
        {
            public Node27()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node28 : INode
        {
            public Node28()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node29 : INode
        {
            public Node29()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node30 : INode
        {
            public Node30()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node31 : INode
        {
            public Node31()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node32 : INode
        {
            public Node32()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node33 : INode
        {
            public Node33()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node34 : INode
        {
            public Node34()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node35 : INode
        {
            public Node35()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node36 : INode
        {
            public Node36()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node37 : INode
        {
            public Node37()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node38 : INode
        {
            public Node38()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node39 : INode
        {
            public Node39()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node40 : INode
        {
            public Node40()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node41 : INode
        {
            public Node41()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node42 : INode
        {
            public Node42()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node43 : INode
        {
            public Node43()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node44 : INode
        {
            public Node44()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node45 : INode
        {
            public Node45()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node46 : INode
        {
            public Node46()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node47 : INode
        {
            public Node47()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node48 : INode
        {
            public Node48()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node49 : INode
        {
            public Node49()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }
    }
}
