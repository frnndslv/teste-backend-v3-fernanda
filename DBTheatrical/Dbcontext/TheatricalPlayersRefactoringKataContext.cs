

using Microsoft.EntityFrameworkCore;
using TheatricalPlayersRefactoringKata;

public class TheatricalPlayersRefactoringKataContext : DbContext
{


    public DbSet<Invoice> Invoice { get; set; }
    public DbSet<Performance> Performance { get; set; }
    public DbSet<Play> Play { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseMySQL("server=localhost;port=3306;database=TheatricalPlayersAPI;user=root;password=152436");
    }

}