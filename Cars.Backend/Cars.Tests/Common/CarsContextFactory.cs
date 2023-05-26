using System;
using Microsoft.EntityFrameworkCore;
using Cars.Domain;
using Cars.Persistence;

namespace Cars.Tests.Common
{
    public class CarsContextFactory
    {
        public static Guid UserAId = Guid.NewGuid();
        public static Guid UserBId = Guid.NewGuid();

        public static Guid NoteIdForDelete = Guid.NewGuid();
        public static Guid NoteIdForUpdate = Guid.NewGuid();

        public static CarsDbContext Create()
        {
            var options = new DbContextOptionsBuilder<CarsDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new CarsDbContext(options);
            context.Database.EnsureCreated();
            context.Car.AddRange(
                new Car
                {
                    CreationDate = DateTime.Today,
                    Details = "Details1",
                    EditDate = null,
                    Id = Guid.Parse("A6BB65BB-5AC2-4AFA-8A28-2616F675B825"),
                    Title = "Title1",
                    UserId = UserAId,
                    Country = "Germany",
                    UsageBenzin = 100,
                    SerialNumber = 567
                },
                new Car
                {
                    CreationDate = DateTime.Today,
                    Details = "Details2",
                    EditDate = null,
                    Id = Guid.Parse("909F7C29-891B-4BE1-8504-21F84F262084"),
                    Title = "Title2",
                    UserId = UserBId,
                    Country = "Brazil",
                    UsageBenzin = 10000,
                    SerialNumber = 1231
                },
                new Car
                {
                    CreationDate = DateTime.Today,
                    Details = "Details3",
                    EditDate = null,
                    Id = NoteIdForDelete,
                    Title = "Title3",
                    UserId = UserAId,
                    Country = "Rwanda",
                    UsageBenzin = 50000,
                    SerialNumber = 1231
                },
                new Car
                {
                    CreationDate = DateTime.Today,
                    Details = "Details4",
                    EditDate = null,
                    Id = NoteIdForUpdate,
                    Title = "Title4",
                    UserId = UserBId,
                    Country = "Russia",
                    UsageBenzin = 123,
                    SerialNumber = 321
                }
            );
            context.SaveChanges();
            return context;
        }

        public static void Destroy(CarsDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
