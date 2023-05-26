using AutoMapper;
using System;
using System.Threading;
using System.Threading.Tasks;
using Notes.Application.Notes.Queries.GetNoteDetails;
using Notes.Persistence;
using Notes.Tests.Common;
using Shouldly;
using Xunit;

namespace Notes.Tests.Notes.Queries
{
    [Collection("QueryCollection")]
    public class GetCarDetailsQueryHandlerTests
    {
        private readonly CarsDbContext Context;
        private readonly IMapper Mapper;

        public GetCarDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetCarDetailsQueryHandler_Success()
        {
            // Arrange
            var handler = new GetCarDetailsQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetCarDetailsQuery
                {
                    UserId = CarsContextFactory.UserBId,
                    Id = Guid.Parse("909F7C29-891B-4BE1-8504-21F84F262084")
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<CarDetailsVm>();
            result.Title.ShouldBe("Title2");
            result.CreationDate.ShouldBe(DateTime.Today);
        }
    }
}
