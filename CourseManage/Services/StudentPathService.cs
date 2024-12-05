using System.Linq.Expressions;
using CourseManage.Entities;
using CourseManage.Interfaces;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace CourseManage.Services;

public class StudentPathService:IStudentPathService
{
    private readonly IUnitOfWork _unitOfWork;

    public StudentPathService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<StudentPath>> GetAllWithIncludesAsync(
        params Expression<Func<StudentPath, object>>[] includes)
    {
        return await _unitOfWork.StudentPaths.GetAllWithIncludesAsync(includes);
    }

    public async Task<IEnumerable<StudentPath>> GetAllStudentPathAsync()
    {
        return await _unitOfWork.StudentPaths.GetAllAsync();
    }

    public async Task<StudentPath> GetStudentPathByIdAsync(int id)
    {
        return await _unitOfWork.StudentPaths.GetByIdAsync(id);
    }

    public async Task CreateStudentPathAsync(StudentPath studentPath)
    {
        await _unitOfWork.StudentPaths.AddAsync(studentPath);
        await _unitOfWork.SaveAsync();
    }

    public async Task<bool> UpdateStudentPathAsync(int id, StudentPath studentPath)
    {
        var existingStudentPath = await _unitOfWork.StudentPaths.GetByIdAsync(id);
        if (existingStudentPath == null)
        {
            return false;
        }
        
        await _unitOfWork.StudentPaths.UpdateAsync(studentPath);
        await _unitOfWork.SaveAsync();
        
        return true;
    }

    public async Task<bool> DeleteStudentPathAsync(int id)
    {
        var existingStudentPath = await _unitOfWork.StudentPaths.GetByIdAsync(id);
        if (existingStudentPath == null)
        {
            return false;
        }
        
        await _unitOfWork.StudentPaths.DeleteAsync(id);
        await _unitOfWork.SaveAsync();
        
        return true;
    }
}