using Microsoft.EntityFrameworkCore;
using StudentCQRS.Models;

namespace StudentCQRS.Data;

public class StudentDbContext : DbContext
{
    private readonly IConfiguration _config;
    public StudentDbContext(DbContextOptions<StudentDbContext> options, IConfiguration configuration)
        : base(options)
    {
        _config = configuration;
    }

    public DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(_config.GetConnectionString("Default"));
    }
}
