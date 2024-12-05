
using System.ComponentModel.DataAnnotations;

namespace CourseManage.Entities{
    public class Topic
    {
        [Key]
        public int TopicId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Instructor> Instructors { get; set; }

        public Topic()
        {
            Courses = new List<Course>();
            Instructors = new List<Instructor>();
        }
    }
}
