using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ListAsync
{
    public class ItemContainer<TItem> where TItem : struct
    {
        const int MaxCapacity = 20;

        //--------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------

        private ConcurrentQueue<TItem> _list;
        private CancellationToken _token;
        private object _lockedObject;
        volatile int _id;

        //--------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------

        public ItemContainer(CancellationToken token)
        {
            _token = token;
            _lockedObject = new object();
            _list = new ConcurrentQueue<TItem>();
            _id = 0;

        }

        //--------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------


        public async Task<bool> Insert(TItem item)
        {
            while (true)
            {
                
                //if (_list.Count == MaxCapacity)
                if (_id != MaxCapacity)
                {
                    Console.WriteLine("Delayed!!!");
                    await Task.Delay(TimeSpan.FromSeconds(1), _token);
                }
                else
                    break;

            }

            _id = Interlocked.Decrement(ref _id);

            try
            {
                _list.Enqueue(item);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public async Task<TItem> Dequeue()
        {
            while (true)
            {
                if (_list.Count == 0)
                {
                    await Task.Delay(TimeSpan.FromSeconds(1), _token);
                }
                else
                    break;
            }

            var value = default(TItem);
            _list.TryDequeue(out value);

            return value;
        }


        //--------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------

        //private async Task<int> Pause()
        //{
        //    while (true)
        //    {
        //        if (_list.Count == MaxCapacity)
        //        {
        //            await Task.Delay(TimeSpan.FromSeconds(1));
        //        }
        //        else
        //            break;
        //    }

        //}
    }
}
