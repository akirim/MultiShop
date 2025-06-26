using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers;
using MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;

namespace MultiShop.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly GetAddressQueryHandler _getAddressQueryHandler;
        private readonly GetAddressByIdQueryHandler _getAddressByIdQueryHandler;
        private readonly CreateAddressCommandHanlder _createAddressCommandHandler;
        private readonly UpdateAddressCommandHandler _updateAddressCommandHandler;
        private readonly RemoveAddressCommandHandler _removeAddressCommandHandler;

        public AddressesController(RemoveAddressCommandHandler removeAddressCommandHandler)
        {
            _removeAddressCommandHandler = removeAddressCommandHandler;
        }

        public AddressesController(UpdateAddressCommandHandler updateAddressCommandHandler)
        {
            _updateAddressCommandHandler = updateAddressCommandHandler;
        }

        public AddressesController(CreateAddressCommandHanlder createAddressCommandHandler)
        {
            _createAddressCommandHandler = createAddressCommandHandler;
        }

        public AddressesController(GetAddressByIdQueryHandler getAddressByIdQueryHandler)
        {
            _getAddressByIdQueryHandler = getAddressByIdQueryHandler;
        }

        public AddressesController(GetAddressQueryHandler getAddressesQueryHandler)
        {
            _getAddressQueryHandler = getAddressesQueryHandler;
        }
        [HttpGet]
        public async Task<IActionResult> AddressList()
        {
            var values = await _getAddressQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddressById(int id)
        {
            var values = await _getAddressByIdQueryHandler.Handle(new GetAddressByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressCommand command)
        {
            await _createAddressCommandHandler.Handle(command);
            return Ok("Adres Başarıyla Eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAddress(UpdateAddressComand command)
        {
            await _updateAddressCommandHandler.Handle(command);
            return Ok("Adres Başarıyla Güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveAddress(int id)
        {
            await _removeAddressCommandHandler.Handle(new RemoveAddressComand(id));
            return Ok("Adres Başarıyla Silindi");
        }
    }
}
