using CourseManage.Entities;
using CourseManage.Interfaces;

namespace CourseManage.Services;

public class QuizService:IQuizService
{
    private readonly IUnitOfWork _unitOfWork;

    public QuizService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Quiz>> GetAllQuizAsync()
    {
        return await _unitOfWork.Quizzes.GetAllAsync();
    }

    public async Task<Quiz> GetQuizByIdAsync(int id)
    {
        return await _unitOfWork.Quizzes.GetByIdAsync(id);
    }

    public async Task CreateQuizAsync(Quiz quiz)
    {
        await _unitOfWork.Quizzes.AddAsync(quiz);
        await _unitOfWork.SaveAsync();
    }

    public async Task<bool> UpdateQuizAsync(int id, Quiz quiz)
    {
        var existing = await _unitOfWork.Quizzes.GetByIdAsync(id);
        if (existing == null)
        {
            return false;
        }
        await _unitOfWork.Quizzes.UpdateAsync(quiz);
        await _unitOfWork.SaveAsync();
        return true;
    }

    public async Task<bool> DeleteQuizAsync(int id)
    {
        var existing = await _unitOfWork.Quizzes.GetByIdAsync(id);
        if (existing == null)
        {
            return false;
        }
        await _unitOfWork.Quizzes.DeleteAsync(id);
        await _unitOfWork.SaveAsync();
        return true;
    }
}