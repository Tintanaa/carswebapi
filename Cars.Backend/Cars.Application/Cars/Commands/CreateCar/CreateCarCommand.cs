using System;
using MediatR;

namespace Cars.Application.Cars.Commands.CreateCar
{
    public class CreateCarCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string Country { get; set; }
        public int UsageBenzin { get; set; }
        public int SerialNumber { get; set; }
    }
}
