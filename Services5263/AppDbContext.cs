using Microsoft.EntityFrameworkCore;
using Services5263;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Guest> Guests { get; set; }
    public DbSet<Room> Rooms { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Guest>(entity =>
        {
            entity.HasKey(g => g.GuestId);

            entity.Property(g => g.FirstName)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(g => g.LastName)
                .IsRequired()
                .HasMaxLength(400);

            entity.Property(g => g.DOB)
                .IsRequired();

            entity.Property(g => g.Address)
                .IsRequired()
                .HasMaxLength(600);

            entity.Property(g => g.Nationality)
                .IsRequired();

            entity.Property(g => g.CheckInDate)
                .IsRequired();

            entity.Property(g => g.CheckOutDate)
                .IsRequired();
        });
    }
}

