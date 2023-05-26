using System;
using MediatR;

namespace Cars.Application.Cars.Commands.DeleteCar
{
    public class DeleteCarCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
