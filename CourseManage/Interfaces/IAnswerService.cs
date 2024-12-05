using CourseManage.Entities;

namespace CourseManage.Interfaces;

public interface IAnswerService
{
    Task<IEnumerable<Answer>> GetAllAnswerAsync();
    Task<Answer> GetAnswerByIdAsync(int id); 
    Task CreateAnswerAsync(Answer answer);
    Task<bool> UpdateAnswerAsync(int id, Answer answer); 
    Task<bool> DeleteAnswerAsync(int id);
}