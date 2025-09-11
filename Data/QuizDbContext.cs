using Microsoft.EntityFrameworkCore;

public class QuizDbContext : DbContext
{
    public QuizDbContext(DbContextOptions<QuizDbContext> options) : base(options)
    { }

    public DbSet<CatPersona> CatPersonas { get; set; }
    public DbSet<QuizQuestion> QuizQuestions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Config primary keys
        modelBuilder.Entity<CatPersona>()
            .HasKey(cp => cp.Id);

        modelBuilder.Entity<QuizQuestion>()
            .HasKey(qq => qq.Id);

        base.OnModelCreating(modelBuilder);
    }
}