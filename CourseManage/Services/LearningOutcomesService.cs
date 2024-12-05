using CourseManage.Entities;
using CourseManage.Interfaces;
using Org.BouncyCastle.Tls;

namespace CourseManage.Services;

public class LearningOutcomesService:ILearningOutcomesService
{
    private readonly IUnitOfWork _unitOfWork;

    public LearningOutcomesService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<LearningOutcomes>> GetAllLearningOutcomesAsync()
    {
        return  await _unitOfWork.LearningOutcomes.GetAllAsync();
    }

    public async Task<LearningOutcomes> GetLearningOutcomesByIdAsync(int id)
    {
        return  await _unitOfWork.LearningOutcomes.GetByIdAsync(id);
    }

    public async Task CreateLearningOutcomesAsync(LearningOutcomes learningOutcomes)
    {
        await _unitOfWork.LearningOutcomes.AddAsync(learningOutcomes);
        await _unitOfWork.SaveAsync();
    }

    public async Task<bool> UpdateLearningOutcomesAsync(int id, LearningOutcomes learningOutcomes)
    {
        var existingLearningOutcomes = await _unitOfWork.LearningOutcomes.GetByIdAsync(id);
        if (existingLearningOutcomes == null)
        {
            return false;
        }
        await _unitOfWork.LearningOutcomes.UpdateAsync(learningOutcomes);
        await _unitOfWork.SaveAsync();
        return true;
    }

    public async Task<bool> DeleteLearningOutcomesAsync(int id)
    {
        var existingLearningOutcomes = await _unitOfWork.LearningOutcomes.GetByIdAsync(id);
        if (existingLearningOutcomes == null)
        {
            return false;
        }
        
        await _unitOfWork.LearningOutcomes.DeleteAsync(id);
        await _unitOfWork.SaveAsync();
        return true;
    }
}