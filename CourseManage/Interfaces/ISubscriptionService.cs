using CourseManage.Entities;

namespace CourseManage.Interfaces;

public interface ISubscriptionService
{
    Task<IEnumerable<Subscription>> GetAllSubscriptionAsync();
    Task<Subscription> GetSubscriptionByIdAsync(int id); 
    Task CreateSubscriptionAsync(Subscription subscription);
    Task<bool> UpdateSubscriptionAsync(int id, Subscription subscription); 
    Task<bool> DeleteSubscriptionAsync(int id);
}