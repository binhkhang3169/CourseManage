using CourseManage.Entities;
using CourseManage.Interfaces;

namespace CourseManage.Services;

public class SubscriptionTypeService:ISubscriptionTypeService
{
    private readonly IUnitOfWork _unitOfWork;

    public SubscriptionTypeService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<SubscriptionType>> GetAllSubscriptionTypeAsync()
    {
        return await _unitOfWork.SubscriptionTypes.GetAllAsync();
    }

    public async Task<SubscriptionType> GetSubscriptionTypeByIdAsync(int id)
    {
        return await _unitOfWork.SubscriptionTypes.GetByIdAsync(id);
    }

    public async Task CreateSubscriptionTypeAsync(SubscriptionType subscriptionType)
    {
        await _unitOfWork.SubscriptionTypes.AddAsync(subscriptionType);
        await _unitOfWork.SaveAsync();
    }

    public async Task<bool> UpdateSubscriptionTypeAsync(int id, SubscriptionType subscriptionType)
    {
        var existingSubscriptionType = await _unitOfWork.SubscriptionTypes.GetByIdAsync(id);
        if (existingSubscriptionType == null)
        {
            return false;
        }
        
        await _unitOfWork.SubscriptionTypes.UpdateAsync(subscriptionType);
        await _unitOfWork.SaveAsync();
        
        return true;
    }

    public async Task<bool> DeleteSubscriptionTypeAsync(int id)
    {
        var existingSubscriptionType = await _unitOfWork.SubscriptionTypes.GetByIdAsync(id);
        if (existingSubscriptionType == null)
        {
            return false;
        }
        
        await _unitOfWork.SubscriptionTypes.DeleteAsync(id);
        await _unitOfWork.SaveAsync();
        
        return true;
    }
}