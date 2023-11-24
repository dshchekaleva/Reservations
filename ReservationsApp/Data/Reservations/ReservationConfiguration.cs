using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ReservationsApp.Data.Reservations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder
            .HasKey(x => x.Id);

            builder.Property(a => a.UserId)
            .IsRequired();

            builder.Property(a => a.ReservationStart)
            .IsRequired();

            builder.Property(a => a.ReservationLength)
            .IsRequired()
            .HasDefaultValue(1);
        }
    }
}
