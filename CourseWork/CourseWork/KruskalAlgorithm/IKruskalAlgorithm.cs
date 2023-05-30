using CourseWork.Graphs;

namespace CourseWork.KruskalAlgorithm;

public interface IKruskalAlgorithm
{
    public List<Edge> CalculateMST(Graph graph);
    
    public static void PrintResult(Edge[] result, int e)
    {
        for (int i = 0; i < e; ++i)
            Console.WriteLine("{0} -- {1} == {2}", result[i].Source, result[i].Destination, result[i].Weight);
    }
}