using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDistributer
{
    public class PlanOrder
    {

        public PlanOrder()
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
            Console.WriteLine("Plan making order");
            await Task.Delay(TimeSpan.FromSeconds(3));
            Console.WriteLine("Plan made order");

            return 10;
        }
    }
}
