using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace ListAsync
{


    public class Reader
    {
        const int AmoutReadingThreads = 3;

        //--------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------

        private ItemContainer<int> _itemContainer;
        private ActionBlock<int> _actionBlock;

        //--------------------------------------------------------------------------------------------------------------------------------------

        volatile int _id;

        //--------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------

        public Reader(ItemContainer<int> itemContainer, CancellationToken token)
        {
            _itemContainer = itemContainer;
            _actionBlock = new ActionBlock<int>((Action<int>)WritingOp, new ExecutionDataflowBlockOptions { BoundedCapacity = 1, MaxDegreeOfParallelism = 1, CancellationToken = token });
            _id = 0;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------

        public async Task<bool> ReadAll()
        {
            await Task.Yield();

            for (int i = 0; i < int.MaxValue; i++)
            {
                await _actionBlock.SendAsync(0);
            }

            return true;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------

        private async void WritingOp(int item)
        {
            var result = await _itemContainer.Dequeue();

            Console.WriteLine($"Item no {result} was received!");
        }


    }
}
