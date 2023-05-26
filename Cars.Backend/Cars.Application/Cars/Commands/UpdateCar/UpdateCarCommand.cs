using System;
using MediatR;

namespace Cars.Application.Cars.Commands.UpdateCar
{
    public class UpdateCarCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string Country { get; set; }
        public int UsageBenzin { get; set; }
        public int SerialNumber { get; set; }
    }
}
