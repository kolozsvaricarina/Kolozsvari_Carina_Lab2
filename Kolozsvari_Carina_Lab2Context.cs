using Microsoft.EntityFrameworkCore;

public class Kolozsvari_Carina_Lab2Context(DbContextOptions<Kolozsvari_Carina_Lab2Context> options) : DbContext(options)
{
    public DbSet<Kolozsvari_Carina_Lab2.Models.Book> Book { get; set; } = default!;
    public DbSet<Kolozsvari_Carina_Lab2.Models.Publisher> Publisher { get; set; } = default!;
    public DbSet<Kolozsvari_Carina_Lab2.Models.Author> Author { get; set; } = default!;

    public DbSet<Kolozsvari_Carina_Lab2.Models.Category> Category { get; set; } = default!;
}
