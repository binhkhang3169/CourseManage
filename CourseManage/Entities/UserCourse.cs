using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CourseManage.Entities{
    public class UserCourse
    {
        [Key] public int UserCourseId { get; set; }

        [Required] public int UserId { get; set; }

        [Required] public int CourseId { get; set; }

        public int? ChapterId { get; set; }
        public int? LessonId { get; set; }
        [ForeignKey("UserId")] public virtual Student Student { get; set; }

        [ForeignKey("CourseId")] public virtual Course Course { get; set; }
        [ForeignKey("ChapterId")] public virtual Chapter Chapter { get; set; }
        [ForeignKey("LessonId")] public virtual Lesson Lesson { get; set; }
    }
}