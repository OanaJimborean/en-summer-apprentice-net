using AutoMapper;
using EndavaNetApp.Model.Dto;
using EndavaNetApp.Models;
using EndavaNetApp.Models.Dto;
using EndavaNetApp.Repositories;
using EndavaNetApp.RepositoriesImpl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EndavaNetApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly TicketManagementSystemContext _ticketManagementSystemContext;
        private readonly IOrderRepository _orderRepository;
        private readonly ITicketCategoryRepository _ticketCategoryRepository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private EventController _eventController;
        private OrderDto orderDto;
        private Order order;

        public OrderController(IOrderRepository orderRepository, IMapper mapper, ITicketCategoryRepository ticketCategoryRepository, ILogger<OrderController> logger)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _ticketCategoryRepository = ticketCategoryRepository;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<OrderDto>> GetAll()
        {
            var orders = _orderRepository.GetAll();

            var dtoOrder = orders.Select(o => new OrderDto()
            {
                OrderID = o.Orderid,
                OrderedAt = o.OrderedAt,
                NumberOfTickets = o.NumberOfTickets,
                TotalPrice = o.TotalPrice
            });

            return Ok(dtoOrder);
        }

        [HttpGet]
        public async Task<ActionResult<OrderDto>> GetByID(int id)
        {
            var @order = await _orderRepository.GetById(id);

            /*if (@order == null)
            {
                return NotFound();
            }*/

            var orderDto = _mapper.Map<OrderDto>(@order);

            return Ok(orderDto);
        }



        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var orderEntity = await _orderRepository.GetById(id);
            if (orderEntity == null)
            {
                return NotFound();
            }
            _orderRepository.Delete(orderEntity);
            return NoContent();
        }


        [HttpPatch]
        public async Task<ActionResult<OrderPatchDto>> Patch(OrderPatchDto orderPatch)
        {
            var orderEntity = await _orderRepository.GetById(orderPatch.OrderID);
            if (orderEntity == null)
            {
                return NotFound();
            }

            if (orderPatch.TicketCategoryid != 0)
            {
                var ticketCategory = await _ticketCategoryRepository.GetById((int)orderPatch.TicketCategoryid);

                if (ticketCategory == null)
                {
                    return NotFound("Ticket category not found");
                }



                float totalPrice = (float)(ticketCategory.Price * orderPatch.NumberOfTickets);
                orderEntity.TotalPrice = totalPrice;
            }
            else
            {
                return NotFound("Ticket category ID is missing or invalid");
            }



            _mapper.Map(orderPatch, orderEntity);
            _orderRepository.Update(orderEntity);
            return Ok(orderEntity);
        }
    }
}
