using Shop.Models;

namespace Shop.Interfaces
{
    public interface ICostumerService
    {
        IEnumerable<CostumerDto> GetCostumers();
        void AddCostumer(CostumerDto costumer);
        void DeletCostumerById(int id);
    }
}
