using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncEx1
{
    class Program
    {
        static  void Main(string[] args)
        {


            AsyncCalls2();
            //Print(5);  

            Console.ReadLine();

        }

        




        static async void AsyncCalls2()
        {
            Print(1);
            Task<int> task = AsyncCalls3();

            Print(4);
            int x = await task;
            Print(7); // same thread as in step 6

            Console.ReadLine();
            // return void
        } //

        static async Task<int> AsyncCalls3()
        {
            Print(2);
            int i = await Task.Run<int>(() =>
            {
                Print(3);
                Thread.Sleep(5000);
                Print(5);
                return 0;
            });
            Print(6);
            return i;  // same thread as in step 5, returning an INTEGER !!!
        } //


        //--------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------


        private static void Print(int xStep)
        {
            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss") + " step " + xStep + " , thread " + Thread.CurrentThread.ManagedThreadId);
        } //

        static async void AsyncCalls1()
        {
            Print(1);
            int i = await Task.Run<int>(() =>
            {
                Print(2);
               Thread.Sleep(5000);
                Print(3); return 0;
            });
            Print(4);  // same thread as in step 3

            //Console.ReadLine();
            // return void
        } //
    }
}
