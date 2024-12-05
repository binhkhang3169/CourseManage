using System.Linq.Expressions;
using CourseManage.Entities;
using CourseManage.Interfaces;

namespace CourseManage.Services;

public class FeedBackService: IFeedBackService
{
    private readonly IUnitOfWork _unitOfWork;

    public FeedBackService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<FeedBack>> GetAllFeedBackAsync()
    {
        return await _unitOfWork.FeedBacks.GetAllAsync();
    }

    public async Task<IEnumerable<FeedBack>> GetAllWithIncludesAsync(params Expression<Func<FeedBack, object>>[] includes)
    {
        return await _unitOfWork.FeedBacks.GetAllWithIncludesAsync(includes);
    }

    public async Task<FeedBack> GetFeedBackByIdAsync(int id)
    {
        return await _unitOfWork.FeedBacks.GetByIdAsync(id);
    }

    public async Task CreateFeedBackAsync(FeedBack feedBack)
    {
        await _unitOfWork.FeedBacks.AddAsync(feedBack);
        await _unitOfWork.SaveAsync();
    }

    public async Task<bool> UpdateFeedBackAsync(int id, FeedBack feedBack)
    {
        var existingFeedBack = await _unitOfWork.FeedBacks.GetByIdAsync(id);
        if (existingFeedBack == null)
        {
            return false;
        }
        
        await _unitOfWork.FeedBacks.UpdateAsync(feedBack);
        await _unitOfWork.SaveAsync();
        return true;
    }

    public async Task<bool> DeleteFeedBackAsync(int id)
    {
        var existingFeedBack = await _unitOfWork.FeedBacks.GetByIdAsync(id);
        if (existingFeedBack == null)
        {
            return false;
        }

        await _unitOfWork.FeedBacks.DeleteAsync(id);
        await _unitOfWork.SaveAsync();
        return true;
    }
}