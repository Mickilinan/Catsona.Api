using Microsoft.EntityFrameworkCore;

public class QuizDbContext : DbContext
{
    public QuizDbContext(DbContextOptions<QuizDbContext> options) : base(options)
    { }

    public DbSet<CatPersona> CatPersonas { get; set; }
    public DbSet<QuizQuestion> QuizQuestions { get; set; }
}