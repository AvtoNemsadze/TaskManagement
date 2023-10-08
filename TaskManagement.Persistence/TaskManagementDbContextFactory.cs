using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace TaskManagement.Persistence
{
    public class TaskManagementDbContextFactory : IDesignTimeDbContextFactory<TaskManagementDbContext>
    {
        public TaskManagementDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsetings.json")
            .Build();

            var builder = new DbContextOptionsBuilder<TaskManagementDbContext>();
            var connectionString = configuration.GetConnectionString("TaskManagementConnectionString");

            builder.UseSqlServer(connectionString);

            return new TaskManagementDbContext(builder.Options);
        }
    }
}
