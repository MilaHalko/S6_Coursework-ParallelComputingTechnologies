// See https://aka.ms/new-console-template for more information


using System.Diagnostics;
using BenchmarkDotNet.Running;
using CourseWork.Benchmarks;

BenchmarkRunner.Run<KruskalaBenchmark>();

// KruskalaBenchmark benchmark = new KruskalaBenchmark();
// benchmark.Setup();
// Stopwatch stopwatch = new Stopwatch();
// stopwatch.Start();
// benchmark.ParallelSortingKruskal();
// stopwatch.Stop();
// System.Console.WriteLine(stopwatch.ElapsedMilliseconds);