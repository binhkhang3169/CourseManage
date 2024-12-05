using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CourseManage.Entities{
    public class UserLesson
    {
        [Key]
        public int UserLessonId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int LessonId { get; set; }

        [Required]
        public bool Completed { get; set; }

        [ForeignKey("UserId")]
        public virtual Student Student { get; set; }

        [ForeignKey("LessonId")]
        public virtual Lesson Lesson { get; set; }
    }
}
