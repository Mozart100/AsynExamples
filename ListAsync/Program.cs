using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace ListAsync
{
    class Program
    {
        static void Main(string[] args)
        {
            var cancellationTokenSource = new CancellationTokenSource();
            var itemContainer = new ItemContainer<int>(cancellationTokenSource.Token);

            var feader = new Feeder(itemContainer, cancellationTokenSource.Token);
            var reader = new Reader(itemContainer, cancellationTokenSource.Token);

            var feaderTask = feader.WriteAll();
            var readerTask = reader.ReadAll();


            Console.ReadLine();

            cancellationTokenSource.Cancel();

            Task.WhenAll(feaderTask, readerTask);

            Console.WriteLine("Program has finished successfully");
        }
    }







}
