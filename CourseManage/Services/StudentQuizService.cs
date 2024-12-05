using System.Linq.Expressions;
using CourseManage.Entities;
using CourseManage.Interfaces;

namespace CourseManage.Services;

public class StudentQuizService:IStudentQuizService
{
    private readonly IUnitOfWork _unitOfWork;

    public StudentQuizService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<StudentQuiz>> GetAllWithIncludesAsync(params Expression<Func<StudentQuiz, object>>[] includes)
    {
        return await _unitOfWork.StudentQuizzes.GetAllWithIncludesAsync(includes);
    }

    public async Task<IEnumerable<StudentQuiz>> GetAllStudentQuizAsync()
    {
        return await _unitOfWork.StudentQuizzes.GetAllAsync();
    }

    public async Task<StudentQuiz> GetStudentQuizByIdAsync(int id)
    {
        return await _unitOfWork.StudentQuizzes.GetByIdAsync(id);
    }

    public async Task CreateStudentQuizAsync(StudentQuiz studentQuiz)
    {
        await _unitOfWork.StudentQuizzes.AddAsync(studentQuiz);
        await _unitOfWork.SaveAsync();
    }

    public async Task<bool> UpdateStudentQuizAsync(int id, StudentQuiz studentQuiz)
    {
        var existing = await _unitOfWork.StudentQuizzes.GetByIdAsync(id);
        if (existing == null)
        {
            return false;
        }
        
        await _unitOfWork.StudentQuizzes.UpdateAsync(studentQuiz);
        await _unitOfWork.SaveAsync();

        return true;
    }

    public async Task<bool> DeleteStudentQuizAsync(int id)
    {
        var existing = await _unitOfWork.StudentQuizzes.GetByIdAsync(id);
        if (existing == null)
        {
            return false;
        }
        
        await _unitOfWork.StudentQuizzes.DeleteAsync(id);
        await _unitOfWork.SaveAsync();

        return true;
    }
}