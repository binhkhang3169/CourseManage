using CourseManage.Entities;
using CourseManage.Interfaces;

namespace CourseManage.Services;

public class AnswerService:IAnswerService
{
    private readonly IUnitOfWork _unitOfWork;

    public AnswerService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<IEnumerable<Answer>> GetAllAnswerAsync()
    {
        return await _unitOfWork.Answers.GetAllAsync();
        
    }

    public async Task<Answer> GetAnswerByIdAsync(int id)
    {
        return await _unitOfWork.Answers.GetByIdAsync(id);
        
    }

    public async Task CreateAnswerAsync(Answer answer)
    {
        await _unitOfWork.Answers.AddAsync(answer);
        await _unitOfWork.SaveAsync();
    }

    public async Task<bool> UpdateAnswerAsync(int id, Answer answer)
    {
        var existingAnswer = await _unitOfWork.Answers.GetByIdAsync(id);
        if (existingAnswer == null)
            return false;

        await _unitOfWork.Answers.UpdateAsync(answer);
        await _unitOfWork.SaveAsync();
        return true;
    }

    public async Task<bool> DeleteAnswerAsync(int id)
    {
        var answer  = await _unitOfWork.Answers.GetByIdAsync(id);
        if (answer == null)
            return false;

        await _unitOfWork.Answers.DeleteAsync(id);
        await _unitOfWork.SaveAsync();
        return true;
    }
}