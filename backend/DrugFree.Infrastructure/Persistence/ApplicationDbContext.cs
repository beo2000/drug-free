using Microsoft.EntityFrameworkCore;
using DrugFree.Domain.Entities;

namespace DrugFree.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Course> Courses { get; set; } = null!;
    public DbSet<Chapter> Chapters { get; set; } = null!;
    public DbSet<CourseEnrollment> CourseEnrollments { get; set; } = null!;
    public DbSet<Survey> Surveys { get; set; } = null!;
    public DbSet<SurveyQuestion> SurveyQuestions { get; set; } = null!;
    public DbSet<SurveyResult> SurveyResults { get; set; } = null!;
    public DbSet<Consultation> Consultations { get; set; } = null!;
    public DbSet<Program> Programs { get; set; } = null!;
    public DbSet<ProgramParticipation> ProgramParticipations { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Configure global query filters
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
            {
                var parameter = Expression.Parameter(entityType.ClrType, "e");
                var property = Expression.Property(parameter, nameof(BaseEntity.IsDeleted));
                var condition = Expression.Equal(property, Expression.Constant(false));
                var lambda = Expression.Lambda(condition, parameter);

                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
            }
        }

        // Configure relationships and constraints
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<CourseEnrollment>()
            .HasOne(ce => ce.User)
            .WithMany(u => u.CourseEnrollments)
            .HasForeignKey(ce => ce.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Consultation>()
            .HasOne(c => c.Member)
            .WithMany()
            .HasForeignKey(c => c.MemberId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Consultation>()
            .HasOne(c => c.Consultant)
            .WithMany()
            .HasForeignKey(c => c.ConsultantId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Program>()
            .HasOne(p => p.Manager)
            .WithMany()
            .HasForeignKey(p => p.ManagerId)
            .OnDelete(DeleteBehavior.Restrict);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
} 