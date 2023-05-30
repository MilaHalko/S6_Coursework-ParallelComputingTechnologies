namespace CourseWork.Graphs;

public class Graph
{
    private int V;
    private List<Edge> _edges;
    
    public List<Edge> Edges => _edges;
    public int VerticesCount => V;

    public Graph(int v)
    {
        V = v;
        _edges = new List<Edge>();
    }
    
    public void Clear()
    {
        _edges.Clear();
    }

    public void AddEdge(int source, int destination, int weight)
    {
        Edge edge = new Edge()
        {
            Source = source,
            Destination = destination,
            Weight = weight
        };
        _edges.Add(edge);
    }

    public int Find(Subset[] subsets, int i)
    {
        if (subsets[i].Parent != i)
            subsets[i].Parent = Find(subsets, subsets[i].Parent);
        return subsets[i].Parent;
    }

    public void Union(Subset[] subsets, int x, int y)
    {
        int xRoot = Find(subsets, x);
        int yRoot = Find(subsets, y);

        if (subsets[xRoot].Rank < subsets[yRoot].Rank)
            subsets[xRoot].Parent = yRoot;
        else if (subsets[xRoot].Rank > subsets[yRoot].Rank)
            subsets[yRoot].Parent = xRoot;
        else
        {
            subsets[yRoot].Parent = xRoot;
            subsets[xRoot].Rank++;
        }
    }
}