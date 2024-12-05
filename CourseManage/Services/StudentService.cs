using CourseManage.Entities;
using CourseManage.Interfaces;

namespace CourseManage.Services;

public class StudentService: IStudentService
{
    private readonly IUnitOfWork _unitOfWork;

    public StudentService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Student>> GetAllStudentAsync()
    {
        return await _unitOfWork.Students.GetAllAsync();
    }

    public async Task<Student> GetStudentByIdAsync(int id)
    {
        return await _unitOfWork.Students.GetByIdAsync(id);
    }

    public async Task CreateStudentAsync(Student student)
    {
        await _unitOfWork.Students.AddAsync(student);
        await _unitOfWork.SaveAsync();
    }

    public async Task<bool> UpdateStudentAsync(int id, Student student)
    {
        var existingStudent = await _unitOfWork.Students.GetByIdAsync(id);
        if (existingStudent == null)
        {
            return false;
        }
        
        await _unitOfWork.Students.UpdateAsync(student);
        await _unitOfWork.SaveAsync();
        
        return true;
    }

    public async Task<bool> DeleteStudentAsync(int id)
    {
        var existingStudent = await _unitOfWork.Students.GetByIdAsync(id);
        if (existingStudent == null)
        {
            return false;
        }

        await _unitOfWork.Students.DeleteAsync(id);
        await _unitOfWork.SaveAsync();
        
        return true;
    }
}