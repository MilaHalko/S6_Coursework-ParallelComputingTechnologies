// See https://aka.ms/new-console-template for more information


using System.Diagnostics;
using CourseWork;
using CourseWork.Graphs;
using CourseWork.KruskalAlgorithm;

int V = 1000; // Number of vertices

Graph graph = new Graph(V);

// Adding edges to the graph
// graph.AddEdge(0, 1, 10);
// graph.AddEdge(0, 2, 6);
// graph.AddEdge(0, 3, 5);
// graph.AddEdge(1, 3, 15);
// graph.AddEdge(2, 3, 4);

for (int i = 0; i < V; i++)
{
    for (int j = i+1; j < V; j++)
    {
        //if (Random.Shared.NextDouble() > 0.6)
        //{
            graph.AddEdge(i, j, Random.Shared.Next(1, 100));
        //}
    }
}

// graph.KruskalMST();
// graph.FilterKruskalMST();
// graph.Kruskal();
// graph.KruskalMSTParallel();

Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();
// ParallelSortingKruskal parallelSortingKruskal = new ParallelSortingKruskal();
// parallelSortingKruskal.CalculateMST(graph);

SequentialKruskal sequentialKruskal = new SequentialKruskal();
sequentialKruskal.CalculateMST(graph);
stopwatch.Stop();
Console.WriteLine($"ParallelSortingKruskal: {stopwatch.ElapsedMilliseconds} ms");