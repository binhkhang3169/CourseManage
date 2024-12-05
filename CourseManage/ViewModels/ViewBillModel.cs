using CourseManage.Entities;

namespace CourseManage.ViewModels
{
    public class ViewBillModel
    {
        public SubscriptionType SubscriptionType { get; set; }
        public PaymentInformation PaymentInformation { get; set; }
        public Subscription Subscription { get; set; }
    }
}
