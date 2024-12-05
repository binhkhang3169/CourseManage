using CourseManage.Entities;
using CourseManage.Interfaces;

namespace CourseManage.Services;

public class DiscussionReplyService:IDiscussionReplyService
{
    
    private readonly IUnitOfWork _unitOfWork;

    public DiscussionReplyService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<DiscussionReply>> GetAllDiscussionReplyAsync()
    {
        return await _unitOfWork.DiscussionReplies.GetAllAsync();
    }

    public async Task<DiscussionReply> GetDiscussionReplyByIdAsync(int id)
    {
        return await _unitOfWork.DiscussionReplies.GetByIdAsync(id);
    }

    public async Task CreateDiscussionReplyAsync(DiscussionReply discussionReply)
    {
        await _unitOfWork.DiscussionReplies.AddAsync(discussionReply);
        await _unitOfWork.SaveAsync();
    }

    public async Task<bool> UpdateDiscussionReplyAsync(int id, DiscussionReply discussionReply)
    {
        var existingDiscussionReply = await _unitOfWork.DiscussionReplies.GetByIdAsync(id);
        if (existingDiscussionReply == null)
        {
            return false;
        }
        
        await _unitOfWork.DiscussionReplies.UpdateAsync(discussionReply);
        await _unitOfWork.SaveAsync();
        return true;
    }

    public async Task<bool> DeleteDiscussionReplyAsync(int id)
    {
        var exitingDiscussionReply = await _unitOfWork.DiscussionReplies.GetByIdAsync(id);
        if (exitingDiscussionReply == null)
        {
            return false;
        }

        await _unitOfWork.DiscussionReplies.DeleteAsync(id);
        await _unitOfWork.SaveAsync();
        return true;
    }
}