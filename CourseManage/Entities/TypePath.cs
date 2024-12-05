using System.ComponentModel.DataAnnotations;

namespace CourseManage.Entities;

public class TypePath
{
    [Key]
    public int TypePathId { get; set; }
    public string Path { get; set; }
}