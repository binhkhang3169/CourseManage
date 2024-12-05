using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CourseManage.Data;
using Microsoft.CodeAnalysis.Scripting.Hosting;

namespace CourseManage.Entities{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        public string Description { get; set; }
        public string TrailerUrl { get; set; }
        [Required]
        public int InstructorId { get; set; }
        [Required]
        public int TopicId { get; set; }
        [Required]
        public int PlatformId { get; set; }
        [Required]
        public int? PathId {get; set;}
        public string Thumbnail { get; set; }
        public DateTime? Date { get; set; }

        public double? Duration { get; set; }
        [NotMapped]
        public double? AverageRating { get; set; }
        
        public DifficultCourse? DifficultCourse { get; set; }
        
        
        [ForeignKey("InstructorId")]
        public virtual Instructor Instructor { get; set; }

        [ForeignKey("TopicId")]
        public virtual Topic Topic { get; set; }

        [ForeignKey("PlatformId")]
        public virtual Platform Platform { get; set; }
        
        [ForeignKey("PathId")]
        public virtual Path? Path { get; set; }

        public virtual ICollection<Chapter> Chapters { get; set; }
        public virtual ICollection<FeedBack> FeedBacks { get; set; }
        public virtual ICollection<Discussion> Discussions { get; set; }
        public virtual ICollection<UserCourse> UserCourses { get; set; }
        public virtual ICollection<Quiz> Quizzes { get; set; }

        public virtual ICollection<LearningOutcomes> LearningOutcomes { get; set; }
        
        public Course()
        {
            Chapters = new List<Chapter>();
            Discussions = new List<Discussion>();
            UserCourses = new List<UserCourse>();
            Quizzes = new List<Quiz>();
            FeedBacks = new List<FeedBack>();
            LearningOutcomes = new List<LearningOutcomes>();
        }
    }
}
