using Shop.Interfaces;
using Shop.Models;

namespace Shop.Services
{
    public class OrderService : IOrderService
    {
        private readonly TestContext _context;
        public OrderService()
        {
            _context = new TestContext();
        }
        public void AddOrder(OorderDto order)
        {
            using (var context = _context)
            {
                var o = new Oorder()
                {
                    Costumerid = order.Costumerid,
                    Orderid = order.Orderid,
                };
                context.Oorders.Add(o);
                context.SaveChanges();
            }

        }

        public IEnumerable<OorderDto> GetOrders()
        {
            using(var context = _context)
            {
                var orders = from o in context.Oorders
                             select new OorderDto()
                             {
                                 Orderid = o.Orderid,
                                 Costumerid = o.Costumerid,
                             };
                return orders;
            }
        }
    }
}
