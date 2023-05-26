using AutoMapper;
using System;
using Cars.Application.Interfaces;
using Cars.Application.Common.Mappings;
using Cars.Persistence;
using Xunit;

namespace Cars.Tests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public CarsDbContext Context;
        public IMapper Mapper;

        public QueryTestFixture()
        {
            Context = CarsContextFactory.Create();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssemblyMappingProfile(
                    typeof(ICarsDbContext).Assembly));
            });
            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            CarsContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
