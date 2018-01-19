using System;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace ListAsync
{
    public class Feeder
    {
        const int AmoutWritingThreads = 10;

        //--------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------

        private ItemContainer<int> _itemContainer;
        private ActionBlock<int> _actionBlock;

        //--------------------------------------------------------------------------------------------------------------------------------------

        volatile int _id;

        //--------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------

        public Feeder(ItemContainer<int> itemContainer, CancellationToken token)
        {
            _itemContainer = itemContainer;
            _actionBlock = new ActionBlock<int>((Action<int>)WritingOp,
                new ExecutionDataflowBlockOptions { BoundedCapacity = AmoutWritingThreads, MaxDegreeOfParallelism = 100, CancellationToken = token });
            _id = 0;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------

        public async Task<bool> WriteAll()
        {
            await Task.Yield();

            for (int i = 0; i < int.MaxValue; i++)
            {
                var result = _actionBlock.Post(Interlocked.Increment(ref _id));
                if (result == false)
                {
                     int x = 0;
                }
            }

            await _actionBlock.Completion;

            return true;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------


        private async void WritingOp(int item)
        {
            //Console.WriteLine($"Item - {item} was writting");
            await _itemContainer.Insert(item);
        }

    }
}
