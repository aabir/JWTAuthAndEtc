using Microsoft.EntityFrameworkCore;
using OrderStore.Domain.Interfaces;
using OrderStore.Domain.Models;

namespace OrderStore.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly ApplicationDBContext _context;
        public OrderRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Order>> GetOrdersByOrderName(string orderName)
        {
            return await _context.Orders.Where(c => c.OrderDetails.Contains(orderName)).ToListAsync();
        }
    }
}
