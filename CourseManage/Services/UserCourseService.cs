using System.Linq.Expressions;
using CourseManage.Entities;
using CourseManage.Interfaces;
using Microsoft.CodeAnalysis.Elfie.Serialization;

namespace CourseManage.Services;

public class UserCourseService : IUserCourseService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserCourseService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<UserCourse>> GetAllWithIncludesAsync(params Expression<Func<UserCourse, object>>[] includes)
    {
        return await _unitOfWork.UserCourses.GetAllWithIncludesAsync(includes);
    }

    public async Task<IEnumerable<UserCourse>> GetAllUserCourseAsync()
    {
        return await _unitOfWork.UserCourses.GetAllAsync();
    }

    public async Task<UserCourse> GetUserCourseByIdAsync(int id)
    {
        return await _unitOfWork.UserCourses.GetByIdAsync(id);
    }

    public async Task CreateUserCourseAsync(UserCourse userCourse)
    {
        await _unitOfWork.UserCourses.AddAsync(userCourse);
        await _unitOfWork.SaveAsync();
    }

    public async Task<bool> UpdateUserCourseAsync(int id, UserCourse userCourse)
    {
        var existingUserCourse = await _unitOfWork.UserCourses.GetByIdAsync(id);
        if (existingUserCourse == null)
        {
            return false;
        }

        await _unitOfWork.UserCourses.UpdateAsync(userCourse);
        await _unitOfWork.SaveAsync();

        return true;
    }

    public async Task<bool> DeleteUserCourseAsync(int id)
    {
        var existingUserCourse = await _unitOfWork.UserCourses.GetByIdAsync(id);
        if (existingUserCourse == null)
        {
            return false;
        }

        await _unitOfWork.UserCourses.DeleteAsync(id);
        await _unitOfWork.SaveAsync();

        return true;
    }
}