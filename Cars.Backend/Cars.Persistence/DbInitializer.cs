namespace Cars.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(CarsDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
