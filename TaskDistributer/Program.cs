using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDistributer
{
    class Program
    {
        static  void Main(string[] args)
        {
            var stopWatch = Stopwatch.StartNew();

            var manager = new WorkManager();
            var result =  manager.DoArrangment().Result;
            stopWatch.Stop();

            Console.WriteLine(result);
            Console.WriteLine($"Result finisedh after {stopWatch.Elapsed}");
            Console.WriteLine("Please any key to finish.");

            Console.ReadLine();

        }
    }

    public interface IStartStopComponent
    {
        void Start();
    }







}
