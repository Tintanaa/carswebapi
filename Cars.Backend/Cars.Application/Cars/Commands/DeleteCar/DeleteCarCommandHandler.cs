using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Cars.Application.Interfaces;
using Cars.Application.Common.Exceptions;
using Cars.Domain;

namespace Cars.Application.Cars.Commands.DeleteCar
{
    public class DeleteCarCommandHandler
        : IRequestHandler<DeleteCarCommand>
    {
        private readonly ICarsDbContext _dbContext;

        public DeleteCarCommandHandler(ICarsDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteCarCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Car
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Car), request.Id);
            }

            _dbContext.Car.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
