using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using Cars.Application.Cars.Queries.GetCarList;
using Cars.Persistence;
using Cars.Tests.Common;
using Shouldly;
using Xunit;

namespace Notes.Tests.Notes.Queries
{
    [Collection("QueryCollection")]
    public class GetCarListQueryHandlerTests
    {
        private readonly CarsDbContext Context;
        private readonly IMapper Mapper;

        public GetCarListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetCarListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetCarListQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetCarListQuery
                {
                    UserId = CarsContextFactory.UserBId
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<CarListVm>();
            result.Cars.Count.ShouldBe(2);
        }
    }
}
