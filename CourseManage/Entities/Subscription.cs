using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CourseManage.Entities{
    public class Subscription
    {
        [Key]
        public int SubscriptionId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int SubscriptionTypeId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }


        [ForeignKey("UserId")]
        public virtual Student Student { get; set; }

        [ForeignKey("SubscriptionTypeId")]
        public virtual SubscriptionType SubscriptionType { get; set; }
    }
}
