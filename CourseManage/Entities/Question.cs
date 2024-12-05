using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseManage.Entities;

public class Question
{
    [Key]
    public int QuestionId { get; set; }

    [Required]
    [StringLength(500, ErrorMessage = "Nội dung câu hỏi không được vượt quá 500 ký tự.")]
    public string Content { get; set; }

    public ICollection<Answer> Answers { get; set; }

    public int CorrectAnswerId { get; set; }

    public int QuizId { get; set; }
    [ForeignKey("QuizId")]
    public virtual Quiz Quiz { get; set; }

    public Question()
    {
        Answers = new List<Answer>();
    }
}