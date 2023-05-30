using CourseWork.Graphs;

namespace CourseWork.KruskalAlgorithm;

public class ParallelSortingKruskal : IKruskalAlgorithm
{
    public List<Edge> CalculateMST(Graph graph)
    {
        List<Edge> result = new List<Edge>();
        int i = 0;
        int e = 0;
        int verticesCount = graph.VerticesCount;

        List<Edge> edges = graph.Edges;
        var orderedEdges = edges.AsParallel().OrderBy(edge => edge.Weight);

        Subset[] subsets = new Subset[verticesCount];
        for (int v = 0; v < verticesCount; v++)
        {
            subsets[v] = new Subset()
            {
                Parent = v,
                Rank = 0
            };
        }

        // while ( e < verticesCount - 1 && i < orderedEdges.Count)
        // {
        //     Edge nextEdge = orderedEdges.;/*edges[i++];*//**/
        //     // var a = 
        //     int x = graph.Find(subsets, nextEdge.Source);
        //     int y = graph.Find(subsets, nextEdge.Destination);
        //
        //     if (x != y)
        //     {
        //         result.Add(nextEdge);
        //         graph.Union(subsets, x, y);
        //         e++;
        //     }
        // }

        foreach (var edge in orderedEdges)
        {
            // Edge nextEdge = orderedEdges.;/*edges[i++];*//**/
            // var a = 
            if (e < verticesCount - 1)
            {
                break;
            }
            int x = graph.Find(subsets, edge.Source);
            int y = graph.Find(subsets, edge.Destination);

            if (x != y)
            {
                result.Add(edge);
                graph.Union(subsets, x, y);
                e++;
            }
        }

        return result;
    }
}