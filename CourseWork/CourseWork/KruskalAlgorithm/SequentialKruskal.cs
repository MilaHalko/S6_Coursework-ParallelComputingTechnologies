using CourseWork.Graphs;

namespace CourseWork.KruskalAlgorithm;

public class SequentialKruskal : IKruskalAlgorithm
{
    public List<Edge> CalculateMST(Graph graph)
    {
        List<Edge> result = new List<Edge>();
        int i = 0;
        int e = 0;
        int verticesCount = graph.VerticesCount;

        List<Edge> edges = graph.Edges;
        edges.Sort();

        Subset[] subsets = new Subset[verticesCount];
        for (int v = 0; v < verticesCount; v++)
        {
            subsets[v] = new Subset()
            {
                Parent = v,
                Rank = 0
            };
        }

        while ( e < verticesCount - 1 && i < edges.Count)
        {
            Edge nextEdge = edges[i++];
            int x = graph.Find(subsets, nextEdge.Source);
            int y = graph.Find(subsets, nextEdge.Destination);

            if (x != y)
            {
                result.Add(nextEdge);
                graph.Union(subsets, x, y);
                e++;
            }
        }

        return result;
    }
}