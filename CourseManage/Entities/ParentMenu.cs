using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseManage.Entities{
    public class ParentMenu
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Link { get; set; }

        [StringLength(255)]
        public string Meta { get; set; }

        public bool Hide { get; set; } = false;

        public int Order { get; set; }

        public DateTime DateBegin { get; set; } = DateTime.Now;

        [StringLength(255)]
        public string Icon { get; set; }

        [StringLength(255)]
        public string Span { get; set; }

        public ICollection<Menu> Menus { get; set; }
    }
}
