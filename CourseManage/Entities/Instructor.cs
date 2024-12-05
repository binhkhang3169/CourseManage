
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace CourseManage.Entities{
    public class Instructor
    {

        [Key]
        public int InstructorId { get; set; }
        
        [ForeignKey("AppUser")]
        public string UserId { get; set; }

        public string Name { get; set; }
        public string About { get; set; }
        public string LinkFacebook { get; set; }
        public string LinkTwitter { get; set; }
        public string Avatar { get; set; }
        public int? TopicId { get; set; }

        [ForeignKey("TopicId")]
        public virtual Topic PrimaryTopic { get; set; }

        public virtual AppUser AppUser { get; set; }
        
        public virtual ICollection<Course> CoursesInstructed { get; set; } // Courses where this user is the instructor
        public virtual ICollection<BlogPost> BlogPosts { get; set; }
        public virtual ICollection<Discussion> DiscussionsStarted { get; set; }
        public virtual ICollection<DiscussionReply> DiscussionReplies { get; set; }
        public Instructor()
        {
            BlogPosts = new List<BlogPost>();
            CoursesInstructed = new List<Course>();
        }
    }
}
