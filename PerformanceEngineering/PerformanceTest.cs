using BenchmarkDotNet.Attributes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PerformanceEngineering
{
    [MemoryDiagnoser]
    public class PerformanceTest
    {
        int[] arrayList = new int[1000];
        List<int> listList = new List<int>();
        string stringString;
        StringBuilder stringBuilder = new StringBuilder();


        [Benchmark]
        public void ForLoopTest()
        {
            for(int i=0;i<arrayList.Length; i++)
            {
                int j = arrayList[i];
            }
        }

        [Benchmark]
        public void ForeachLoopTest()
        {
            foreach(var item in arrayList)
            {
                int j = item;
            }
        }

        [Benchmark]
        public void Stringtest()
        {
            for(int i=0; i<1000; i++)
            {
                stringString += "h";
            }
        }

        [Benchmark]
        public void StringBuildertest()
        {
            for (int i = 0; i < 1000; i++)
            {
                stringBuilder.Append("h");
            }
        }

        private async Task TaskWork()
        {
            await Task.Delay(10);
        }

        private void ThreadWork()
        {
            Thread.Sleep(10);
        }

        [Benchmark]
        public void ThreadTest()
        {
            for(int i=0;i<5;i++)
            {
                Thread thread = new Thread(ThreadWork);
                thread.Start();
                thread.Join();
            }
        }

        [Benchmark]
        public void TaskTest()
        {
            for(int i=0;i<5;i++)
            {
                Task.Run(async () =>
                        {
                            Task t = TaskWork();
                            await t;
                        }).GetAwaiter().GetResult();
            }
        }

        [Benchmark]
        public void ArrayTest()
        {
            for(int i=0;i<1000;i++)
            {
                arrayList[i] = 2 * i;
            }
        }

        [Benchmark]
        public void ListTest()
        {
            for(int i=0; i<1000; i++)
            {
                listList[i] = 2 * i;
            }
        }

        class SampleClass
        {
            public string name { get; set; }
            public int roll { get; set; }
        }


        struct SampleStruct
        {
            public string name { get; set; }
            public int roll { get; set; }
        }

        [Benchmark]
        public void ClassTest()
        {
            for (int i = 0; i < 100; i++)
            {
                var variable = new SampleClass();
                variable.name = "hello";
                variable.roll = i;
            }
        }

        [Benchmark]
        public void StructTest()
        {
            for (int i = 0; i < 100; i++)
            {
                var variable = new SampleStruct();
                variable.name = "hello";
                variable.roll = i;
            }
        }
    }

}