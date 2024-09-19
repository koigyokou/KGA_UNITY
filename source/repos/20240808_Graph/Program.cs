namespace _20240808_Graph
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Graph<string> graph = new();

            GraphNode<string> a = graph.AddNode("0");
            GraphNode<string> b = graph.AddNode("1");
            GraphNode<string> c = graph.AddNode("2");
            GraphNode<string> d = graph.AddNode("3");
            GraphNode<string> e = graph.AddNode("4");
            GraphNode<string> f = graph.AddNode("5");
            GraphNode<string> g = graph.AddNode("6");
            GraphNode<string> h = graph.AddNode("7");

            graph.AddEdgeCycle(a, d);
            graph.AddEdgeCycle(b, d);
            graph.AddEdgeCycle(b, g);
            graph.AddEdgeCycle(c, g);
            graph.AddEdgeCycle(d, h);
            graph.AddEdgeCycle(f, h);
            graph.AddEdgeCycle(g, h);


            graph.PrintGraphInfo();

        }
    }
    public class GraphNode<T>
    {
        public T Value { get; set; }
        public List<GraphNode<T>> NeighborNodes { get; } = new();

        public GraphNode(T value)
        {
            Value = value;
        }
        public void PrintNeighborNodes()
        {
            Console.WriteLine($"{Value} 인접 노드");
            foreach ( var neighbor in NeighborNodes )
            {
                Console.WriteLine($"  ㄴ  {neighbor.Value}");
            }
        }
        public void AddEdge(GraphNode<T> node)
        {
            NeighborNodes.Add(node);
        }
        public void RemoveEdge(GraphNode<T> node)
        {
            NeighborNodes.Remove(node);
        }
    
    }
    public class Graph<T>
    {
        private List<GraphNode<T>> _nodes = new();

        public GraphNode<T> AddNode(T value)
        {
            GraphNode<T> node = new(value);
            _nodes.Add(node);
            return node;
        }
        public void AddEdge(GraphNode<T> from, GraphNode<T> to)
        {
            from.NeighborNodes.Add(to);
        }
        public void AddEdgeCycle(GraphNode<T> from, GraphNode<T> to)
        {
            from.NeighborNodes.Add(to);
            to.NeighborNodes.Add(from);
        }
        public void RemoveNode(GraphNode<T> node)
        {
            foreach( var n in _nodes )
            {
                n.RemoveEdge(node);
            }
            _nodes.Remove(node);
        }
        public void PrintGraphInfo()
        {
            Console.WriteLine("그래프 노드 구조 ---");
            foreach ( var n in _nodes )
            {
                n.PrintNeighborNodes();
            }
        }

    }
}
