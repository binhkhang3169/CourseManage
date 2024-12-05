using CourseManage.Entities;

namespace CourseManage.Interfaces;

public interface ISubscriptionTypeService
{
    Task<IEnumerable<SubscriptionType>> GetAllSubscriptionTypeAsync();
    Task<SubscriptionType> GetSubscriptionTypeByIdAsync(int id); 
    Task CreateSubscriptionTypeAsync(SubscriptionType subscriptionType);
    Task<bool> UpdateSubscriptionTypeAsync(int id, SubscriptionType subscriptionType); 
    Task<bool> DeleteSubscriptionTypeAsync(int id);
}