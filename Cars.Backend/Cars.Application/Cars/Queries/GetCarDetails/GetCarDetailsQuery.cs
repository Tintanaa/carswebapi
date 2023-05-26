using System;
using MediatR;

namespace Cars.Application.Cars.Queries.GetCarDetails
{
    public class GetCarDetailsQuery : IRequest<CarDetailsVm>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
