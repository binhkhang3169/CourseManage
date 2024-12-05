using CourseManage.Entities;
using CourseManage.Interfaces;

namespace CourseManage.Services;

public class UserLessonService:IUserLessonService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserLessonService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<UserLesson>> GetAllUserLessonAsync()
    {
        return await _unitOfWork.UserLessons.GetAllAsync();
    }

    public async Task<UserLesson> GetUserLessonByIdAsync(int id)
    {
        return await _unitOfWork.UserLessons.GetByIdAsync(id);
    }

    public async Task CreateUserLessonAsync(UserLesson userLesson)
    {
        await _unitOfWork.UserLessons.AddAsync(userLesson);
        await _unitOfWork.SaveAsync();
    }

    public async Task<bool> UpdateUserLessonAsync(int id, UserLesson userLesson)
    {
        var existingUserLesson = await _unitOfWork.UserLessons.GetByIdAsync(id);
        if (existingUserLesson == null)
        {
            return false;
        }
        
        await _unitOfWork.UserLessons.UpdateAsync(userLesson);
        await _unitOfWork.SaveAsync();

        return true;
    }

    public async Task<bool> DeleteUserLessonAsync(int id)
    {
        var existingUserLesson = await _unitOfWork.UserLessons.GetByIdAsync(id);
        if (existingUserLesson == null)
        {
            return false;
        }
        
        await _unitOfWork.UserLessons.DeleteAsync(id);
        await _unitOfWork.SaveAsync();

        return true; 
    }
}