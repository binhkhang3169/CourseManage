using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseManage.Entities;

public class Path
{
    [Key]
    public int PathId { get; set; }
    
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Avatar { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.Now;
    
    public int? TypePathId { get; set; }
    [ForeignKey("TypePathId")]
    public virtual TypePath? TypePath { get; set; }
    
    public virtual ICollection<Course> Courses { get; set; }

    public Path()
    {
        Courses = new List<Course>();
    }
}