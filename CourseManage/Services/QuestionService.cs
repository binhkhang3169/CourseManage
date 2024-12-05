using CourseManage.Entities;
using CourseManage.Interfaces;

namespace CourseManage.Services;

public class QuestionService:IQuestionService
{
    private readonly IUnitOfWork _unitOfWork;

    public QuestionService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Question>> GetAllQuestionAsync()
    {
        return await _unitOfWork.Questions.GetAllAsync();
    }

    public async Task<Question> GetQuestionByIdAsync(int id)
    {
        return await _unitOfWork.Questions.GetByIdAsync(id);
    }

    public async Task CreateQuestionAsync(Question question)
    {
        await _unitOfWork.Questions.AddAsync(question);
        await _unitOfWork.SaveAsync();
    }

    public async Task<bool> UpdateQuestionAsync(int id, Question question)
    {
        var existingQuestion = await _unitOfWork.Questions.GetByIdAsync(id);
        if (existingQuestion == null)
        {
            return false;
        }
        await _unitOfWork.Questions.UpdateAsync(question);
        await _unitOfWork.SaveAsync();
        return true;
    }
    
    public async Task<bool> DeleteQuestionAsync(int id)
    {
        var existingQuestion = await _unitOfWork.Questions.GetByIdAsync(id);
        if (existingQuestion == null)
        {
            return false;
        }
        await _unitOfWork.Questions.DeleteAsync(id);
        await _unitOfWork.SaveAsync();
        return true;
    }
}