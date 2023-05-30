// See https://aka.ms/new-console-template for more information


using System.Diagnostics;
using BenchmarkDotNet.Running;
using CourseWork.Benchmarks;
using CourseWork.Graphs;
using CourseWork.KruskalAlgorithm;

//BenchmarkRunner.Run<KruskalaBenchmark>();

// KruskalaBenchmark benchmark = new KruskalaBenchmark();
// benchmark.Setup();
// Stopwatch stopwatch = new Stopwatch();
// stopwatch.Start();
// benchmark.ParallelSortingKruskal();
// stopwatch.Stop();
// System.Console.WriteLine(stopwatch.ElapsedMilliseconds);

Graph graph = new Graph(4);

// Adding edges to the graph
graph.AddEdge(0, 1, 10);
graph.AddEdge(0, 2, 6);
graph.AddEdge(0, 3, 5);
graph.AddEdge(1, 3, 15);
graph.AddEdge(2, 3, 4);

Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();

SequentialKruskal sequentialKruskal = new SequentialKruskal();
List<Edge> result = sequentialKruskal.CalculateMST(graph);

ParallelSortingKruskal parallelSortingKruskal = new ParallelSortingKruskal();
List<Edge> resultPSK = parallelSortingKruskal.CalculateMST(graph);

FilterKruskal filterKruskal = new FilterKruskal();
List<Edge> resultFK = filterKruskal.CalculateMST(graph);

stopwatch.Stop();
// Console.WriteLine($"ParallelSortingKruskal: {stopwatch.ElapsedMilliseconds} ms");

Console.Out.WriteLine("SequentialKruskal:");
foreach(Edge edge in result)
{
    Console.WriteLine($"{edge.Source} -- {edge.Destination} == {edge.Weight}");
}

Console.Out.WriteLine("");

Console.Out.WriteLine("ParallelSortingKruskal:");
foreach(Edge edge in resultPSK)
{
    Console.WriteLine($"{edge.Source} -- {edge.Destination} == {edge.Weight}");
}

Console.Out.WriteLine("\nFilterKruskal:");
foreach(Edge edge in resultFK)
{
    Console.WriteLine($"{edge.Source} -- {edge.Destination} == {edge.Weight}");
}