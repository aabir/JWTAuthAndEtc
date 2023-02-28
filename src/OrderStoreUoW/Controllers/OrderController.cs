using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderStore.Domain.Interfaces;

namespace OrderStoreUoW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet(nameof(GetOrders))]
        public async Task<IActionResult> GetOrders()
        {
            return Ok(await _unitOfWork.Orders.GetAll());
        }

        [HttpGet(nameof(GetOrderByName))]
        public async Task<IActionResult> GetOrderByName([FromQuery] string Genre)
        {
            return Ok(await _unitOfWork.Orders.GetOrdersByOrderName(Genre));
        }
    }
}
