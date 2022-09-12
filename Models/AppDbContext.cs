using Microsoft.EntityFrameworkCore;

namespace Spotify.Models;
public class AppDbContext : DbContext {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base (options) { }

    public DbSet<Reggaeton> Reggaetons { get; set; }
    public DbSet<Bachata> Bachatas { get; set; }
    public DbSet<Salsa> Salsas { get; set; }
}
