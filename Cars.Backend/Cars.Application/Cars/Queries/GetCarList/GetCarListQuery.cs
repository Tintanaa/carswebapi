using System;
using MediatR;

namespace Cars.Application.Cars.Queries.GetCarList
{
    public class GetCarListQuery : IRequest<CarListVm>
    {
        public Guid UserId { get; set; }
    }
}
