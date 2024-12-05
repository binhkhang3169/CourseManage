using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseManage.Entities{
    public class PaymentInformation
    {
        [Key]
        public string UserId { get; set; }
        public string CreditNumber { get; set; }
        public bool AutoRenew { get; set; }
        [ForeignKey("UserId")]
        public AppUser User { get; set; }
    }
}
