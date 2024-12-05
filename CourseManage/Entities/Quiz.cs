using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseManage.Entities;

public class Quiz
{
    [Key]
    public int QuizId { get; set; }
        
    [Required]
    [StringLength(100, ErrorMessage = "Tên bài kiểm tra không được vượt quá 100 ký tự.")]
    public string Title { get; set; }
        
    [StringLength(500, ErrorMessage = "Mô tả không được vượt quá 500 ký tự.")]
    public string Description { get; set; }
        
    [Required]
    [Range(0, 100, ErrorMessage = "Điểm tối đa phải nằm trong khoảng 0 đến 100.")]
    public int MaxScore { get; set; }
        
    [DataType(DataType.DateTime)]
    public DateTime StartDate { get; set; }
        
    [DataType(DataType.DateTime)]
    public DateTime EndDate { get; set; }
        
    public int CoureId { get; set; }
    [ForeignKey("CoureId")]
    public virtual Course Course { get; set; }
    
    [Required]
    public bool IsActive { get; set; }
        
    // Liên kết một-nhiều tới bảng Question
    public ICollection<Question> Questions { get; set; }
}