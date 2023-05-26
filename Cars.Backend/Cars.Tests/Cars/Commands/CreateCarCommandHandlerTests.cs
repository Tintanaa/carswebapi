using Microsoft.EntityFrameworkCore;
using Notes.Application.Notes.Commands.CreateNote;
using Notes.Tests.Common;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Notes.Tests.Notes.Commands
{
    public class CreateCarCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateCarCommandHandler_Success()
        {
            // Arrange
            var handler = new CreateCarCommandHandler(Context);
            var carName = "car name";
            var carDetails = "car details";

            // Act
            var carId = await handler.Handle(
                new CreateCarCommand
                {
                    Title = carName,
                    Details = carDetails,
                    UserId = CarsContextFactory.UserAId
                },
                CancellationToken.None);

            // Assert
            Assert.NotNull(
                await Context.Car.SingleOrDefaultAsync(car =>
                    car.Id == carId && car.Title == carName &&
                    car.Details == carDetails));
        }
    }
}
