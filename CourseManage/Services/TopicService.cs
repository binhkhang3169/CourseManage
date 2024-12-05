using CourseManage.Entities;
using CourseManage.Interfaces;

namespace CourseManage.Services;

public class TopicService : ITopicService
{
    private readonly IUnitOfWork _unitOfWork;

    public TopicService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Topic>> GetAllTopicAsync()
    {
        return await _unitOfWork.Topics.GetAllAsync();
    }

    public async Task<Topic> GetTopicByIdAsync(int id)
    {
        return await _unitOfWork.Topics.GetByIdAsync(id);
    }

    public async Task CreateTopicAsync(Topic topic)
    {
        await _unitOfWork.Topics.AddAsync(topic);
        await _unitOfWork.SaveAsync();
    }

    public async Task<bool> UpdateTopicAsync(int id, Topic topic)
    {
        var existingTopic = await _unitOfWork.Topics.GetByIdAsync(id);
        if (existingTopic == null)
        {
            return false;
        }

        await _unitOfWork.Topics.UpdateAsync(topic);
        await _unitOfWork.SaveAsync();
        return true;
    }

    public async Task<bool> DeleteTopicAsync(int id)
    {
        var existingTopic = await _unitOfWork.Topics.GetByIdAsync(id);
        if (existingTopic == null)
        {
            return false;
        }

        await _unitOfWork.Topics.DeleteAsync(id);
        await _unitOfWork.SaveAsync();
        return true;
    }
}