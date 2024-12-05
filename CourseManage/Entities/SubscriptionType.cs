using System.ComponentModel.DataAnnotations;

namespace CourseManage.Entities{
    public class SubscriptionType
    {
        [Key]
        public int SubscriptionTypeId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int Duration { get; set; } // Consider specifying units (e.g., days, months)

        public virtual ICollection<Subscription> Subscriptions { get; set; }

        public SubscriptionType()
        {
            Subscriptions = new List<Subscription>();
        }
    }

}
