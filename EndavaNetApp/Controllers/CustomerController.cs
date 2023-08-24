using EndavaNetApp.Model.Dto;
using EndavaNetApp.Models.Dto;
using EndavaNetApp.Models;
using EndavaNetApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace EndavaNetApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly TicketManagementSystemContext _ticketManagementSystemContext;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult<List<CustomerDto>> GetAll()
        {
            var customers = _customerRepository.GetAll();

            var dtoCustomers = customers.Select(c => new CustomerDto()
            {
                Customerid = c.Customerid,
                CustomerName = c.CustomerName ?? string.Empty,
                Email= c.Email
            });

            return Ok(dtoCustomers);
        }

        [HttpGet]
        public async Task<ActionResult<CustomerDto>> GetByID(int id)
        {
            var @customer = await _customerRepository.GetById(id);

            /*if (@customer == null)
            {
                return NotFound();
            }
*/
            var customerDto = _mapper.Map<CustomerDto>(@customer);

            return Ok(customerDto);
        }

        [HttpPatch]
        public async Task<ActionResult<CustomerPatchDto>> Patch(CustomerPatchDto customerPatchDto)
        {
            var customerEntity = await _customerRepository.GetById(customerPatchDto.Customerid);
            if (customerEntity == null)
            {
                return NotFound();
            }
            _mapper.Map(customerPatchDto, customerEntity);
            _customerRepository.Update(customerEntity);
            return Ok(customerEntity);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var customerEntity = await _customerRepository.GetById(id);
            if (customerEntity == null)
            {
                return NotFound();
            }
            _customerRepository.Delete(customerEntity);
            return NoContent();
        }
    }
}
