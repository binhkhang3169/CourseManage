using CourseManage.Entities;

namespace CourseManage.Interfaces;

public interface ITopicService
{
    Task<IEnumerable<Topic>> GetAllTopicAsync();
    Task<Topic> GetTopicByIdAsync(int id); 
    Task CreateTopicAsync(Topic topic);
    Task<bool> UpdateTopicAsync(int id, Topic topic); 
    Task<bool> DeleteTopicAsync(int id);
}