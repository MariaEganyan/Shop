using Shop.Models;

namespace Shop.Interfaces
{
    public interface IOrderService
    {
        void AddOrder(OorderDto order);
        IEnumerable<OorderDto> GetOrders();
    }
}
