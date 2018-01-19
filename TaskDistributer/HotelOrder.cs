using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDistributer
{
    public class HotelOrder
    {

        public HotelOrder()
        {

        }

        //--------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------

        public async Task<int> Order(int clientId)
        {

            var result = await Task.Run(() => MakingOrder(clientId));
            return result;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------

        private async Task<int> MakingOrder(int id)
        {
            Console.WriteLine("Hotel making order");
            await Task.Delay(TimeSpan.FromSeconds(5));
            Console.WriteLine("Hotel made order");


            return 10;
        }
    }
}
