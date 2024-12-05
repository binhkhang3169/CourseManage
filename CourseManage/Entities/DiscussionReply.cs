using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CourseManage.Entities{
    public class DiscussionReply
    {
        [Key]
        public int DiscussionReplyId { get; set; }

        [Required]
        public int DiscussionId { get; set; }

        public int? InstructorId { get; set; }
        public int? StudentId { get; set; }

        public string Content { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [ForeignKey("DiscussionId")]
        public virtual Discussion Discussion { get; set; }

        [ForeignKey("InstructorId")]
        public virtual Instructor? Instructor { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student? Student { get; set; }
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
