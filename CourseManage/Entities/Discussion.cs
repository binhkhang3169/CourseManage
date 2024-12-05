using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CourseManage.Entities{
    public class Discussion
    {
        [Key]
        public int DiscussionId { get; set; }

        public int? InstructorId { get; set; }
        public int? StudentId { get; set; }

        public int? CourseId { get; set; }
        public int? LessonId { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        public string Content { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [ForeignKey("InstructorId")]
        public virtual Instructor Instructor { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }

        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }

        [ForeignKey("LessonId")]
        public virtual Lesson Lesson { get; set; }

        public virtual ICollection<DiscussionReply> DiscussionReplies { get; set; }

        public Discussion()
        {
            DiscussionReplies = new List<DiscussionReply>();
        }
        [NotMapped]
        public string UserId
        {
            get
            {
                if (Student != null) return Student.UserId;
                if (Instructor != null) return Instructor.UserId;
                return null;
            }
        }[NotMapped]
        public string GetName
        {
            get
            {
                if (Student != null) return Student.Name;
                if (Instructor != null) return Instructor.Name;
                return null;
            }
        }[NotMapped]
        public string GetAvatar
        {
            get
            {
                if (Student != null) return Student.Avatar;
                if (Instructor != null) return Instructor.Avatar;
                return null;
            }
        }
    }
}
