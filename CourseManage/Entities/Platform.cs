using System.ComponentModel.DataAnnotations;

namespace CourseManage.Entities{
    public class Platform
    {
        [Key]
        public int PlatformId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public Platform()
        {
            Courses = new List<Course>();
        }
    }
}
