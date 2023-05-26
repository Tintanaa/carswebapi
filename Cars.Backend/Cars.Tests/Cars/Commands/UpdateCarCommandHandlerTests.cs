using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;
using Notes.Application.Notes.Commands.UpdateNote;
using Notes.Tests.Common;
using Xunit;

namespace Notes.Tests.Notes.Commands
{
    public class UpdateCarCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateCarCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateCarCommandHandler(Context);
            var updatedTitle = "new title";

            // Act
            await handler.Handle(new UpdateCarCommand
            {
                Id = CarsContextFactory.NoteIdForUpdate,
                UserId = CarsContextFactory.UserBId,
                Title = updatedTitle
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await Context.Car.SingleOrDefaultAsync(note =>
                note.Id == CarsContextFactory.NoteIdForUpdate &&
                note.Title == updatedTitle));
        }

        [Fact]
        public async Task UpdateCarCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateCarCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateCarCommand
                    {
                        Id = Guid.NewGuid(),
                        UserId = CarsContextFactory.UserAId
                    },
                    CancellationToken.None));
        }

        [Fact]
        public async Task UpdateCarCommandHandler_FailOnWrongUserId()
        {
            // Arrange
            var handler = new UpdateCarCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(
                    new UpdateCarCommand
                    {
                        Id = CarsContextFactory.NoteIdForUpdate,
                        UserId = CarsContextFactory.UserAId
                    },
                    CancellationToken.None);
            });
        }
    }
}
