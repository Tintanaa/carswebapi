using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Notes.Application.Common.Exceptions;
using Notes.Application.Notes.Commands.DeleteCommand;
using Notes.Application.Notes.Commands.CreateNote;
using Notes.Tests.Common;
using Xunit;

namespace Notes.Tests.Notes.Commands
{
    public class DeleteCarCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteCarCommandHandler_Success()
        {
            // Arrange
            var handler = new DeleteCarCommandHandler(Context);

            // Act
            await handler.Handle(new DeleteCarCommand
            {
                Id = CarsContextFactory.NoteIdForDelete,
                UserId = CarsContextFactory.UserAId
            }, CancellationToken.None);

            // Assert
            Assert.Null(Context.Car.SingleOrDefault(note =>
                note.Id == CarsContextFactory.NoteIdForDelete));
        }

        [Fact]
        public async Task DeleteCarCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new DeleteCarCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteCarCommand
                    {
                        Id = Guid.NewGuid(),
                        UserId = CarsContextFactory.UserAId
                    },
                    CancellationToken.None));
        }

        [Fact]
        public async Task DeleteCarCommandHandler_FailOnWrongUserId()
        {
            // Arrange
            var deleteHandler = new DeleteCarCommandHandler(Context);
            var createHandler = new CreateCarCommandHandler(Context);
            var noteId = await createHandler.Handle(
                new CreateCarCommand
                {
                    Title = "CarTitle",
                    UserId = CarsContextFactory.UserAId
                }, CancellationToken.None);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await deleteHandler.Handle(
                    new DeleteCarCommand
                    {
                        Id = noteId,
                        UserId = CarsContextFactory.UserBId
                    }, CancellationToken.None));
        }
    }
}
