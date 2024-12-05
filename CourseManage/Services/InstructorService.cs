using System.Linq.Expressions;
using CourseManage.Entities;
using CourseManage.Interfaces;
using Humanizer;

namespace CourseManage.Services;

public class InstructorService:IInstructorService
{
    private readonly IUnitOfWork _unitOfWork;

    public InstructorService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<Instructor>> GetAllInstructorAsync()
    {
        return await _unitOfWork.Instructors.GetAllAsync();
    }

    public async Task<IEnumerable<Instructor>> GetAllWithIncludesAsync(params Expression<Func<Instructor, object>>[] includes)
    {
        return await _unitOfWork.Instructors.GetAllWithIncludesAsync(includes);
    }

    public async Task<Instructor> GetInstructorByIdAsync(int id)
    {
        return await _unitOfWork.Instructors.GetByIdAsync(id);
    }

    public async Task CreateInstructorAsync(Instructor instructor)
    {
        await _unitOfWork.Instructors.AddAsync(instructor);
        await _unitOfWork.SaveAsync();
    }

    public async Task<bool> UpdateInstructorAsync(int id, Instructor instructor)
    {
        var existingInstructor = await _unitOfWork.Instructors.GetByIdAsync(id);
        if (existingInstructor == null)
        {
            return false;
        }
        
        await _unitOfWork.Instructors.UpdateAsync(existingInstructor);
        await _unitOfWork.SaveAsync();
        return true;
    }

    public async Task<bool> DeleteInstructorAsync(int id)
    {
        var existingInstructor = await _unitOfWork.Instructors.GetByIdAsync(id);
        if (existingInstructor == null)
        {
            return false;
        }

        await _unitOfWork.Instructors.DeleteAsync(id);
        await _unitOfWork.SaveAsync();
        return true;
    }
}