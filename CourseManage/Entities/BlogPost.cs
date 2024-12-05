using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CourseManage.Entities{
    public class BlogPost
    {
        [Key]
        public int BlogPostId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        public string Content { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [ForeignKey("UserId")]
        public virtual AppUser User { get; set; }
    }
}
