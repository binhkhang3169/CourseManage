using System.Linq.Expressions;
using System.Security.AccessControl;
using CourseManage.Interfaces;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;

namespace CourseManage.Services;

public class CourseService:ICourseService
{
    private readonly IUnitOfWork _unitOfWork;

    public CourseService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Entities.Course>> GetAllCourseAsync()
    {
        return await _unitOfWork.Courses.GetAllAsync();
    }
    public async Task<IEnumerable<Entities.Course>> GetWithFilterAndIncludesAsync(
        Expression<Func<Entities.Course, bool>> filter,
        params Expression<Func<Entities.Course, object>>[] includes)
    {
        return await _unitOfWork.Courses.GetWithFilterAndIncludesAsync(filter, includes);
    }

    public async Task<IEnumerable<Entities.Course>> GetAllWithIncludesAsync(params Expression<Func<Entities.Course, object>>[] includes)
    {
        return await _unitOfWork.Courses.GetAllWithIncludesAsync(includes);
    }

    public async Task<Entities.Course> GetCourseByIdAsync(int id)
    {
        return await _unitOfWork.Courses.GetByIdAsync(id);
    }

    public async Task CreateCourseAsync(Entities.Course course)
    {
        await _unitOfWork.Courses.AddAsync(course);
        await _unitOfWork.SaveAsync();
    }

    public async Task<bool> UpdateCourseAsync(int id,Entities.Course course)
    {
        var existingCourse = await _unitOfWork.Courses.GetByIdAsync(id);
        if (existingCourse == null)
        {
            return false;
        }
        await _unitOfWork.Courses.UpdateAsync(course);
        await _unitOfWork.SaveAsync();
        return false;
    }

    public async Task<bool> DeleteCourseAsync(int id)
    {
        var existingCourse = await _unitOfWork.Courses.GetByIdAsync(id);
        if (existingCourse == null)
        {
            return false;
        }
        
        await _unitOfWork.Courses.DeleteAsync(id);
        await _unitOfWork.SaveAsync();
        return true;
    }
    
    
}