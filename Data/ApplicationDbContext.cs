

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Web_Parkovka_Project.Model;

namespace Web_Parkovka_Project.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        //Конструктор, который принимает параметры конфигурации базы данных.
        // — Передаёт эти параметры в базовый класс DbContext с помощью : base(options).
        // — Это позволяет настраивать подключение к базе через Dependency Injection.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //  Database.Migrate(); // Автоматически применяет миграции и создаёт базу, если её нет
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<ParkingSpot> ParkingSpots { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }



        }

    }
