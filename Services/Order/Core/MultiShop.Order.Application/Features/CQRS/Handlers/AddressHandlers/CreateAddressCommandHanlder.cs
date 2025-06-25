using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class CreateAddressCommandHanlder
    {
        private readonly IRepository<Address> _repository;

        public CreateAddressCommandHanlder(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateAddressCommand createAddressCommand)
        {
            await _repository.CreatAsync(new Address
            {
                UserId = createAddressCommand.UserId,
                District = createAddressCommand.District,
                City = createAddressCommand.City,
                Detail = createAddressCommand.Detail
            });
        }
    }
}
