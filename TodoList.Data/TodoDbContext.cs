using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TodoList.Data.Entities;
using TodoList.Data.EntityConfigurations;

namespace TodoList.Data
{
    public class TodoDbContext : DbContext
    {
        IConfiguration configuration;
        private string connectionString = "Server=localhost;Port=5432;Database=myDataBase;User Id=admin;Password=string;";
        public TodoDbContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        }

        protected override  void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {//I need to improve this so it uses the appsettings.json
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            IConfiguration configuration = configurationBuilder.Build();

            optionsBuilder.UseNpgsql(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<TodoEntity>(new TodoConfig());
            modelBuilder.ApplyConfiguration<UserEntity>(new UserConfig());
        }

        public virtual DbSet<TodoEntity> Todo { get; set; }
        public virtual DbSet<UserEntity> User { get; set; } 

    }
}
