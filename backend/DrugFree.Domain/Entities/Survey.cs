using System.ComponentModel.DataAnnotations;

namespace DrugFree.Domain.Entities;

public class Survey : BaseEntity
{
    [Required]
    public string Title { get; set; } = null!;
    
    public string? Description { get; set; }
    
    [Required]
    public SurveyType Type { get; set; }
    
    [Required]
    public int MinAge { get; set; }
    
    [Required]
    public int MaxAge { get; set; }
    
    // Navigation properties
    public ICollection<SurveyQuestion> Questions { get; set; } = new List<SurveyQuestion>();
    public ICollection<SurveyResult> Results { get; set; } = new List<SurveyResult>();
}

public class SurveyQuestion : BaseEntity
{
    [Required]
    public string Question { get; set; } = null!;
    
    public int Order { get; set; }
    
    public Guid SurveyId { get; set; }
    public Survey Survey { get; set; } = null!;
}

public class SurveyResult : BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    
    public Guid SurveyId { get; set; }
    public Survey Survey { get; set; } = null!;
    
    public decimal Score { get; set; }
    
    public string? Notes { get; set; }
}

public enum SurveyType
{
    ASSIST,
    CRAFFT
} 