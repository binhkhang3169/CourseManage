using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseManage.Entities;

public class StudentPath
{
    [Key] public int StudentPathId { get; set; }
    public int StudentId { get; set; }
    public int PathId { get;set; }
    public int? Rating { get; set; }
    public int? CourseId { get; set; }
    [ForeignKey("CourseId")] public virtual Course Course { get; set; }
    [ForeignKey("StudentId")] public virtual Student Student { get; set; }
    [ForeignKey("PathId")] public virtual Path Path { get; set; }
}