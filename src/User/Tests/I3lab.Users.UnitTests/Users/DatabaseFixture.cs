using I3Lab.Users.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace I3lab.Users.Tests.Users
{
    public class DatabaseFixture : IDisposable
    {
        public UserContext DbContext { get; private set; }

        public DatabaseFixture()
        {
            // Настройка подключения к базе данных
            var options = new DbContextOptionsBuilder<UserContext>()
                .UseNpgsql("Host=postgres-db;Port=5432;Database=identity;Username=postgres;Password=postgres")
                .Options;

            DbContext = new UserContext(options);

            // Применение миграций
            DbContext.Database.Migrate();

            // Очистка и подготовка базы данных
            ClearDatabase();
        }

        private void ClearDatabase()
        {
            // Метод для очистки базы данных перед тестами
            DbContext.Users.RemoveRange(DbContext.Users);
            DbContext.SaveChanges();
        }

        public void Dispose()
        {
            // Освобождение ресурсов после выполнения всех тестов
            DbContext.Dispose();
        }
    }
}