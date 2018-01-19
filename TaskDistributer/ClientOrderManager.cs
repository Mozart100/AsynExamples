using System.Threading.Tasks;

namespace TaskDistributer
{
    public struct ClientOrderInfo
    {
        private int _hotelId;
        private int _planOrder;


        public ClientOrderInfo(int hotelId, int planOrder)
        {
            _hotelId = hotelId;
            _planOrder = planOrder;
        }

        public int HotelId
        {
            get
            {
                return _hotelId;
            }
        }

        public int PlanOrder
        {
            get
            {
                return _planOrder;
            }


        }


        //--------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------

        public override string ToString()
        {
            return $"HotelId = {HotelId} && planTicketId = {PlanOrder}";
        }
    }

    public class ClientOrderManager

    {
        private HotelOrder _hotelOrder;
        private PlanOrder _planOrder;

        //--------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------

        public ClientOrderManager()
        {
            _planOrder = new PlanOrder();
            _hotelOrder = new HotelOrder();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------


        public async Task<ClientOrderInfo> Manage(int id)
        {

            var hotelTask = Task.Run(() => _hotelOrder.Order(id));
            var planTask  = Task.Run(() => _planOrder.Order(id));

            await Task.WhenAll(hotelTask, planTask);


            return new ClientOrderInfo(hotelTask.Result, planTask.Result);
            //return new ClientOrderInfo(await _hotelOrder.Order(id), await _planOrder.Order(id));
        }
    }
}
