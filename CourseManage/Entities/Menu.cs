using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseManage.Entities{
    public class Menu
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
        [StringLength(255)]
        public string Span { get; set; }

        public DateTime DateBegin { get; set; } = DateTime.Now;

        [StringLength(255)]
        public string Icon { get; set; }  // Biểu tượng cho menu
        [StringLength(255)]
        [Required(AllowEmptyStrings = true)]
        public string Badge { get; set; }  // Biểu tượng cho menu


        // Foreign Key - Reference to ParentMenu
        public int? ParentMenuId { get; set; }
        public ParentMenu ParentMenu { get; set; }
    }
}
