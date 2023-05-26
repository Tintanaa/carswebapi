using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Cars.Application.Interfaces;
using Cars.Application.Common.Exceptions;
using Cars.Domain;

namespace Cars.Application.Cars.Commands.UpdateCar
{
    public class UpdateCarCommandHandler
        : IRequestHandler<UpdateCarCommand>
    {
        private readonly ICarsDbContext _dbContext;

        public UpdateCarCommandHandler(ICarsDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateCarCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Car.FirstOrDefaultAsync(car =>
                    car.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Car), request.Id);
            }

            entity.Details = request.Details;
            entity.Title = request.Title;
            entity.Country = request.Country;
            entity.UsageBenzin = request.UsageBenzin;
            entity.SerialNumber = request.SerialNumber;
            entity.EditDate = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
