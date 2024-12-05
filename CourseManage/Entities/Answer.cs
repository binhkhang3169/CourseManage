using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace CourseManage.Entities;

public class Answer
{
    [Key]
    public int AnswerId { get; set; }

    [Required]
    [StringLength(200, ErrorMessage = "Nội dung đáp án không được vượt quá 200 ký tự.")]
    public string Content { get; set; }

    public int QuestionId { get; set; }
    [ForeignKey("QuestionId")]
    public virtual Question Question { get; set; }
}