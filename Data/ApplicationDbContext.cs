

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

        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<ParkingSpot> ParkingSpots { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Настройка связей
            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.Owner)
                .WithMany(u => u.Vehicles)
                .HasForeignKey(v => v.OwnerId);

            modelBuilder.Entity<ParkingSpot>()
                .HasOne(p => p.OccupiedBy)
                .WithOne()
                .HasForeignKey<ParkingSpot>(p => p.VehicleId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.ReservedSpot)
                .WithMany()
                .HasForeignKey(r => r.SpotId);
        }
    }
}
