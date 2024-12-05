
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace CourseManage.Entities{
    public class Student
    {
            [Key]
            public int StudentId { get; set; }
        
            
            [ForeignKey("AppUser")]
            public string UserId { get; set; }
            public string Name { get; set; }
            public string? LinkFacebook { get; set; }
            public string? LinkTwitter { get; set; }
            public string? Avatar { get; set; }
            public string? Role { get; set; }
            public string? School { get; set; }
            public virtual AppUser AppUser { get; set; }
            public virtual ICollection<Discussion> DiscussionsStarted { get; set; }
            public virtual ICollection<DiscussionReply> DiscussionReplies { get; set; }
            public virtual ICollection<FeedBack> FeedBacks { get; set; }
            public virtual ICollection<StudentQuiz> StudentQuizzes { get; set; }
            public virtual ICollection<StudentPath> StudentPaths { get; set; }

            public Student()
            {
                DiscussionsStarted = new List<Discussion>();
                DiscussionReplies = new List<DiscussionReply>();
                FeedBacks = new List<FeedBack>();
                StudentPaths = new List<StudentPath>();
                StudentQuizzes = new List<StudentQuiz>();
            }
        }
    }    


