using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseManage.Entities;

public class StudentQuiz
{
    [Key]
    public int StudentQuizId { get; set; }

    [Required]
    public int StudentId { get; set; }
    [ForeignKey("StudentId")]
    public virtual Student Student { get; set; }
    [Required]
    public int QuizId { get; set; }
    [ForeignKey("QuizId")]
    public virtual Quiz Quiz { get; set; }

    [Range(0, 100, ErrorMessage = "Điểm phải nằm trong khoảng 0 đến 100.")]
    public int Score { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime StartTime { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime EndTime { get; set; }
}