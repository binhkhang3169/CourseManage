using System.Linq.Expressions;
using CourseManage.Entities;
using Org.BouncyCastle.Crypto.Engines;

namespace CourseManage.Interfaces;

public interface IStudentQuizService
{
    Task<IEnumerable<StudentQuiz>> GetAllWithIncludesAsync(params Expression<Func<StudentQuiz, object>>[] includes);

    Task<IEnumerable<StudentQuiz>> GetAllStudentQuizAsync();
    Task<StudentQuiz> GetStudentQuizByIdAsync(int id); 
    Task CreateStudentQuizAsync(StudentQuiz studentQuiz);
    Task<bool> UpdateStudentQuizAsync(int id, StudentQuiz studentQuiz); 
    Task<bool> DeleteStudentQuizAsync(int id);
}