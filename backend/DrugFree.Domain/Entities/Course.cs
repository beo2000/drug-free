using System.ComponentModel.DataAnnotations;

namespace DrugFree.Domain.Entities;

public class Course : BaseEntity
{
    [Required]
    public string Title { get; set; } = null!;
    
    public string? Description { get; set; }
    
    [Required]
    public int MinAge { get; set; }
    
    [Required]
    public int MaxAge { get; set; }
    
    public string? ThumbnailUrl { get; set; }
    
    // Navigation properties
    public ICollection<Chapter> Chapters { get; set; } = new List<Chapter>();
    public ICollection<CourseEnrollment> Enrollments { get; set; } = new List<CourseEnrollment>();
}

public class Chapter : BaseEntity
{
    [Required]
    public string Title { get; set; } = null!;
    
    public string? Content { get; set; }
    
    public string? VideoUrl { get; set; }
    
    public int Order { get; set; }
    
    public Guid CourseId { get; set; }
    public Course Course { get; set; } = null!;
}

public class CourseEnrollment : BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    
    public Guid CourseId { get; set; }
    public Course Course { get; set; } = null!;
    
    public decimal FinalScore { get; set; }
    
    public bool IsCompleted { get; set; }
    
    public DateTime? CompletedAt { get; set; }
} 