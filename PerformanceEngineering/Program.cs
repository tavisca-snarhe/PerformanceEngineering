using System;
using BenchmarkDotNet.Running;

namespace PerformanceEngineering
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<PerformanceTest>();
            Console.ReadKey(true);
        }
    }

}