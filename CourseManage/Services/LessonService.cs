using System.Linq.Expressions;
using CourseManage.Entities;
using CourseManage.Interfaces;

namespace CourseManage.Services;

public class LessonService:ILessonService
{
    private readonly IUnitOfWork _unitOfWork;

    public LessonService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Lesson>> GetAllWithIncludesAsync(params Expression<Func<Lesson, object>>[] includes)
    {
        return await _unitOfWork.Lessons.GetAllWithIncludesAsync(includes);
    }

    public async Task<IEnumerable<Lesson>> GetAllLessonAsync()
    {
        return await _unitOfWork.Lessons.GetAllAsync();
    }

    public async Task<Lesson> GetLessonByIdAsync(int id)
    {
        return await _unitOfWork.Lessons.GetByIdAsync(id);
    }

    public async Task CreateLessonAsync(Lesson lesson)
    {
        await _unitOfWork.Lessons.AddAsync(lesson);
        await _unitOfWork.SaveAsync();
    }

    public async Task<bool> UpdateLessonAsync(int id, Lesson lesson)
    {
        var existingLesson = await _unitOfWork.Lessons.GetByIdAsync(id);
        if (existingLesson == null)
        {
            return false;
        }
        
        await _unitOfWork.Lessons.UpdateAsync(lesson);
        await _unitOfWork.SaveAsync();
        return true;
    }

    public async Task<bool> DeleteLessonAsync(int id)
    {
        var existingLesson = await _unitOfWork.Lessons.GetByIdAsync(id);
        if (existingLesson == null)
        {
            return false;
        }

        await _unitOfWork.Lessons.DeleteAsync(id);
        await _unitOfWork.SaveAsync();
        return true;
    }
}