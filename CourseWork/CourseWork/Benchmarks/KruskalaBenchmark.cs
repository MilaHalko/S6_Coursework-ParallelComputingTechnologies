using BenchmarkDotNet.Attributes;
using CourseWork.Graphs;
using CourseWork.KruskalAlgorithm;

namespace CourseWork.Benchmarks;

[MemoryDiagnoser(), MinIterationCount(3), MaxIterationCount(4)]
public class KruskalaBenchmark
{
    [Params(10,100,500,1000,1500,2000,2500)]
    public int VerticesCount = 1000;

    private Graph _graph1;
    private Graph _graph2;
    private Graph _graph3;
    
    [IterationSetup]
    public void Setup()
    {
        _graph1 = new Graph(VerticesCount);
        _graph2 = new Graph(VerticesCount);
        _graph3 = new Graph(VerticesCount);
        for (int i = 0; i < VerticesCount; i++)
        {
            for (int j = i+1; j < VerticesCount; j++)
            {
                //if (Random.Shared.NextDouble() > 0.6)
                //{
                    _graph1.AddEdge(i, j, Random.Shared.Next(1, 100));
                    _graph2.AddEdge(i, j, Random.Shared.Next(1, 100));
                    _graph3.AddEdge(i, j, Random.Shared.Next(1, 100));
                // _graph1.AddEdge(i, j, Random.Shared.Next(1, 100));
                //}
            }
        }
    }

    // [IterationCleanup]
    // public void CleanUp()
    // {
    //     for (int i = 0; i < VerticesCount; i++)
    //     {
    //         for (int j = i+1; j < VerticesCount; j++)
    //         {
    //             //if (Random.Shared.NextDouble() > 0.6)
    //             //{
    //             _graph1.Clear();
    //             _graph2.Clear();
    //             _graph3.Clear();
    //             _graph1.AddEdge(i, j, Random.Shared.Next(1, 100));
    //             _graph2.AddEdge(i, j, Random.Shared.Next(1, 100));
    //             _graph3.AddEdge(i, j, Random.Shared.Next(1, 100));
    //             // _graph1.AddEdge(i, j, Random.Shared.Next(1, 100));
    //             //}
    //         }
    //     }
    // }

    [Benchmark]
    public void SequentialKruskal()
    {
        SequentialKruskal sequentialKruskal = new SequentialKruskal();
        sequentialKruskal.CalculateMST(_graph1);
    }
    
    [Benchmark]
    public void ParallelSortingKruskal()
    {
        ParallelSortingKruskal parallelSortingKruskal = new ParallelSortingKruskal();
        parallelSortingKruskal.CalculateMST(_graph2);
    }
    
    [Benchmark]
    public void FilterKruskal()
    {
        FilterKruskal parallelKruskal = new FilterKruskal();
        parallelKruskal.CalculateMST(_graph3);
    }

}