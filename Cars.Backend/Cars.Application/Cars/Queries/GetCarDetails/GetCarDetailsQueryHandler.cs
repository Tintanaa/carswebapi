using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Cars.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Cars.Application.Common.Exceptions;
using Cars.Domain;

namespace Cars.Application.Cars.Queries.GetCarDetails
{
    public class GetCarDetailsQueryHandler
        : IRequestHandler<GetCarDetailsQuery, CarDetailsVm>
    {
        private readonly ICarsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCarDetailsQueryHandler(ICarsDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<CarDetailsVm> Handle(GetCarDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Car
                .FirstOrDefaultAsync(car =>
                car.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Car), request.Id);
            }

            return _mapper.Map<CarDetailsVm>(entity);
        }
    }
}
