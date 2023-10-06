using GogoDriverWeb.Models;
using GogoWeb.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GogoWeb.Data;

public class GogoWebContext : IdentityDbContext<GogoWebUser>
{
    public GogoWebContext(DbContextOptions<GogoWebContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<ModePaiement> ModePaiements { get; set; }

    public virtual DbSet<Paiement> Paiements { get; set; }

    public virtual DbSet<Plainte> Plaintes { get; set; }

    public virtual DbSet<Reservation> Reservtions { get; set; }

    public virtual DbSet<So> Sos { get; set; }

    public virtual DbSet<TypeReservation> TypeReservations { get; set; }

    public virtual DbSet<TypeVehicule> TypeVehicules { get; set; }

    public virtual DbSet<Vehicule> Vehicules { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
