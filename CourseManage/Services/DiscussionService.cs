using System.Linq.Expressions;
using CourseManage.Entities;
using CourseManage.Interfaces;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace CourseManage.Services;

public class DiscussionService:IDiscussionService
{
    
    private readonly IUnitOfWork _unitOfWork;

    public DiscussionService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Discussion>> GetAllWithIncludesAsync(params Expression<Func<Discussion, object>>[] includes)
    {
        return await _unitOfWork.Discussions.GetAllWithIncludesAsync(includes);
    }

    public async Task<IEnumerable<Discussion>> GetAllDiscussionAsync()
    {
        return await _unitOfWork.Discussions.GetAllAsync();
    }

    public async Task<Discussion> GetDiscussionByIdAsync(int id)
    {
        return await _unitOfWork.Discussions.GetByIdAsync(id);
    }

    public async Task CreateDiscussionAsync(Discussion discussion)
    {
        await _unitOfWork.Discussions.AddAsync(discussion);
        await _unitOfWork.SaveAsync();
    }

    public async Task<bool> UpdateDiscussionAsync(int id, Discussion discussion)
    {
        var existingDiscussion = await _unitOfWork.Discussions.GetByIdAsync(id);
        if (existingDiscussion == null)
        {
            return false;
        }
        
        await _unitOfWork.Discussions.UpdateAsync(discussion);
        await _unitOfWork.SaveAsync();
        return true;
    }

    public async Task<bool> DeleteDiscussionAsync(int id)
    {
        var existingDiscussion = await _unitOfWork.Discussions.GetByIdAsync(id);
        if (existingDiscussion == null)
        {
            return false;
        }

        await _unitOfWork.Discussions.DeleteAsync(id);
        await _unitOfWork.SaveAsync();
        return true;
    }
}