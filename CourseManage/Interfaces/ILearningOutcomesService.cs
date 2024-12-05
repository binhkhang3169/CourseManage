using CourseManage.Entities;

namespace CourseManage.Interfaces;

public interface ILearningOutcomesService
{
    Task<IEnumerable<LearningOutcomes>> GetAllLearningOutcomesAsync();
    Task<LearningOutcomes> GetLearningOutcomesByIdAsync(int id); 
    Task CreateLearningOutcomesAsync(LearningOutcomes learningOutcomes);
    Task<bool> UpdateLearningOutcomesAsync(int id, LearningOutcomes learningOutcomes); 
    Task<bool> DeleteLearningOutcomesAsync(int id);
}