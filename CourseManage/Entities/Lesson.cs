using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CourseManage.Entities{
    public class Lesson
    {
        [Key]
        public int LessonId { get; set; }

        [Required]
        public int ChapterId { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        public string VideoUrl { get; set; }
        public string Description { get; set; }

        [Required]
        public int OrderLesson { get; set; }
        public double EstimateTime { get; set; }
        public bool IsDone { get; set; }

        [ForeignKey("ChapterId")]
        public virtual Chapter Chapter { get; set; }

        public virtual ICollection<Discussion> Discussions { get; set; }
        public virtual ICollection<UserLesson> UserLessons { get; set; }

        public Lesson()
        {
            Discussions = new List<Discussion>();
            UserLessons = new List<UserLesson>();
            IsDone = false;
        }
    }
}
