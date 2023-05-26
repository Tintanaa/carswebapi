using System;
using Cars.Persistence;

namespace Cars.Tests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly CarsDbContext Context;

        public TestCommandBase()
        {
            Context = CarsContextFactory.Create();
        }

        public void Dispose()
        {
            CarsContextFactory.Destroy(Context);
        }
    }
}
