using OrderStore.Domain.Models;

namespace OrderStore.Domain.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByOrderName(string orderName);
    }
}
