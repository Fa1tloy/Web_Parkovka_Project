

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Web_Parkovka_Project.Model;

namespace Web_Parkovka_Project.Data
{
    public class ApplicationDbContext : DbContext
    {
        //Конструктор, который принимает параметры конфигурации базы данных.
        // — Передаёт эти параметры в базовый класс DbContext с помощью : base(options).
        // — Это позволяет настраивать подключение к базе через Dependency Injection.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //Database.Migrate(); // Автоматически применяет миграции и создаёт базу, если её нет
        }

        public DbSet<User> User { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<ParkingSpot> ParkingSpot { get; set; }
        public DbSet<Reservation> ParkingRecords { get; set; }

        ///связи между моделями
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasMany(u => u.Vehicles)
            .WithOne(v => v.Owner)
            .HasForeignKey(v => v.OwnerId);

            modelBuilder.Entity<Vehicle>()
            .HasMany(v => v.ParkedAtSpots)
            .WithOne(s => s.OccupiedBy)
            .HasForeignKey(s => s.VehicleId);

            modelBuilder.Entity<Reservation>()
            .HasOne(r => r.ReservedVehicle)
            .WithMany()
            .HasForeignKey(r => r.VehicleId);

            modelBuilder.Entity<Reservation>()
            .HasOne(r => r.ReservedSpot)
            .WithMany()
            .HasForeignKey(r => r.SpotId);
        }
    }
}
