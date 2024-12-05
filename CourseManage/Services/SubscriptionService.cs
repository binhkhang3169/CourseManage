using CourseManage.Entities;
using CourseManage.Interfaces;

namespace CourseManage.Services;

public class SubscriptionService:ISubscriptionService
{
    private readonly IUnitOfWork _unitOfWork;

    public SubscriptionService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Subscription>> GetAllSubscriptionAsync()
    {
        return await _unitOfWork.Subscriptions.GetAllAsync();
    }

    public async Task<Subscription> GetSubscriptionByIdAsync(int id)
    {
        return await _unitOfWork.Subscriptions.GetByIdAsync(id);
    }

    public async Task CreateSubscriptionAsync(Subscription subscription)
    {
        await _unitOfWork.Subscriptions.AddAsync(subscription);
        await _unitOfWork.SaveAsync();
    }

    public async Task<bool> UpdateSubscriptionAsync(int id, Subscription subscription)
    {
        var existingSubscription = await _unitOfWork.Subscriptions.GetByIdAsync(id);
        if (existingSubscription == null)
        {
            return false;
        }
        
        await _unitOfWork.Subscriptions.UpdateAsync(subscription);
        await _unitOfWork.SaveAsync();
        
        return true;
    }

    public async Task<bool> DeleteSubscriptionAsync(int id)
    {
        var existingSubscription = await _unitOfWork.Subscriptions.GetByIdAsync(id);
        if (existingSubscription == null)
        {
            return false;
        }
        
        await _unitOfWork.Subscriptions.DeleteAsync(id);
        await _unitOfWork.SaveAsync();
        
        return true;
    }
}