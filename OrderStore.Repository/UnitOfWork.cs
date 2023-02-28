using OrderStore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderStore.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDBContext _context;

        public IOrderRepository Orders { get; }
        public IProductRepository Products { get; }

        public UnitOfWork(ApplicationDBContext context,
            IOrderRepository orderRepository,
            IProductRepository productRepository)
        {
            _context = context;
            Orders = orderRepository;
            Products = productRepository;
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing) { _context.Dispose(); }
        }
    }
}
