using OrderStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderStore.Domain.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {

    }
}
