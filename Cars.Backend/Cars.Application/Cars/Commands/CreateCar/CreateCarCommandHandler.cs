using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Cars.Application.Interfaces;
using Cars.Domain;

namespace Cars.Application.Cars.Commands.CreateCar
{
    public class CreateCarCommandHandler
        :IRequestHandler<CreateCarCommand, Guid>
    {
        private readonly ICarsDbContext _dbContext;

        public CreateCarCommandHandler(ICarsDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateCarCommand request,
            CancellationToken cancellationToken)
        {
            var car = new Car
            {
                UserId = request.UserId,
                Title = request.Title,
                Details = request.Details,
                Country = request.Country,
                UsageBenzin= request.UsageBenzin,
                SerialNumber = request.SerialNumber,
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                EditDate = null
            };

            await _dbContext.Car.AddAsync(car, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return car.Id;
        }
    }
}
