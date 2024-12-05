using System.Linq.Expressions;
using CourseManage.Entities;

namespace CourseManage.Interfaces;

public interface IStudentPathService
{
    
    Task<IEnumerable<StudentPath>> GetAllWithIncludesAsync(params Expression<Func<StudentPath, object>>[] includes);

    Task<IEnumerable<StudentPath>> GetAllStudentPathAsync();
    Task<StudentPath> GetStudentPathByIdAsync(int id); 
    Task CreateStudentPathAsync(StudentPath studentPath);
    Task<bool> UpdateStudentPathAsync(int id, StudentPath studentPath); 
    Task<bool> DeleteStudentPathAsync(int id);
}