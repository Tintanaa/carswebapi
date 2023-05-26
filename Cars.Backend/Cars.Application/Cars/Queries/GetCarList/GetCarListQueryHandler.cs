using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Cars.Application.Interfaces;

namespace Cars.Application.Cars.Queries.GetCarList
{
    public class GetCarListQueryHandler
        : IRequestHandler<GetCarListQuery, CarListVm>
    {
        private readonly ICarsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCarListQueryHandler(ICarsDbContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<CarListVm> Handle(GetCarListQuery request,
            CancellationToken cancellationToken)
        {
            var carsQuery = await _dbContext.Car
                .Where(car => car.UserId == request.UserId)
                .ProjectTo<CarLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new CarListVm { Cars = carsQuery };
        }
    }
}
