using CourseManage.Entities;

namespace CourseManage.Interfaces;

public interface IStudentService
{
    Task<IEnumerable<Student>> GetAllStudentAsync();
    Task<Student> GetStudentByIdAsync(int id); 
    Task CreateStudentAsync(Student student);
    Task<bool> UpdateStudentAsync(int id, Student student); 
    Task<bool> DeleteStudentAsync(int id);
}