using Microsoft.EntityFrameworkCore;

namespace ReservationsApp.Data.Reservations
{
    public class ReservationsContext(DbContextOptions<ReservationsContext> options) : DbContext(options)
    {
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ReservationConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
