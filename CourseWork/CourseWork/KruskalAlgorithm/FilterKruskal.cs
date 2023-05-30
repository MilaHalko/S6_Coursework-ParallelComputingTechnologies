using CourseWork.Graphs;

namespace CourseWork.KruskalAlgorithm;

public class FilterKruskal : IKruskalAlgorithm
{
    public List<Edge> CalculateMST(Graph graph)
    {
        List<Edge> result = new List<Edge>();

        var edges = graph.Edges;
        edges.Sort(); // Sort edges in ascending order
        int verticesCount = graph.VerticesCount;

        Subset[] subsets = new Subset[verticesCount];
        for (int v = 0; v < verticesCount; v++)
        {
            subsets[v] = new Subset()
            {
                Parent = v,
                Rank = 0
            };
        }

        Parallel.ForEach(edges, (edge, state) =>
        {
            int x = graph.Find(subsets, edge.Source);
            int y = graph.Find(subsets, edge.Destination);

            if (x != y)
            {
                graph.Union(subsets, x, y);
                result.Add(edge);
            }
            else
            {
                state.Break(); // Skip remaining edges since they will be filtered out
            }
        });

        return result;
    }
}