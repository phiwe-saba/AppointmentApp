using AppointmentApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AppointmentApp.Data
{
    public class AppointmentDbContext: DbContext
    {
        public AppointmentDbContext(DbContextOptions<AppointmentDbContext> options) : base(options) { }

        public DbSet<City> Cities { get; set; }
    }
}
