using Microsoft.EntityFrameworkCore;
using Presupuesto.Models;

namespace Presupuesto.UnitTests
{
    public static class DbContextMocker
    {
        public static PresupuestoContext GetPresupuestoDbContext(string dbName)
        {
            var options = new DbContextOptionsBuilder<PresupuestoContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            var dbContext = new PresupuestoContext(options);

            dbContext.Seed();

            return dbContext;
        }
    }
}
