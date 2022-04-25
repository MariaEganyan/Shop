using Shop.Interfaces;
using Shop.Models;

namespace Shop.Services
{
    public class CostumerService : ICostumerService
    {
        private readonly TestContext _context;
        public CostumerService()
        {
            _context = new TestContext();
        }
        public void AddCostumer(CostumerDto costumer)
        {
            using (var context =_context)
            {
                var c = new Costumer()
                {
                    Costumerid = costumer.Costumerid,
                    Name = costumer.Name,
                };
                context.Costumers.Add(c);
                context.SaveChanges();
            }
        }

        public void DeletCostumerById(int id)
        {
            using(var context = _context)
            {
                var costumers = from c in context.Costumers
                                select new CostumerDto()
                                {
                                    Name = c.Name,
                                    Costumerid = c.Costumerid,
                                };
                var cost = costumers.FirstOrDefault(c=>c.Costumerid==id);
                if (cost == null)
                {
                    throw new Exception("Tath costumer is not found");
                }
                else 
                {
                    var c = new Costumer()
                    {
                        Name = cost.Name,
                        Costumerid = cost.Costumerid,
                    };
                    context.Costumers.Remove(c);
                    context.SaveChanges();
                }
               
            }
        }

        public IEnumerable<CostumerDto> GetCostumers()
        {
            using(var context = _context)
            {
                var costumers = from c in context.Costumers
                                select new CostumerDto()
                                {
                                    Name = c.Name,
                                    Costumerid = c.Costumerid,
                                };
                return costumers;
            }
        }
    }
}
