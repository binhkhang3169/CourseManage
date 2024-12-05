using System.Linq.Expressions;
using CourseManage.Interfaces;
using Path = CourseManage.Entities.Path;

namespace CourseManage.Services;

public class PathService : IPathService
{
    private readonly IUnitOfWork _unitOfWork;

    public PathService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Path>> GetAllWithIncludesAsync(params Expression<Func<Path, object>>[] includes)
    {
        return await _unitOfWork.Paths.GetAllWithIncludesAsync(includes);
    }

    public async Task<IEnumerable<Path>> GetAllPathAsync()
    {
        return await _unitOfWork.Paths.GetAllAsync();
    }

    public async Task<Path> GetPathByIdAsync(int id)
    {
        return await _unitOfWork.Paths.GetByIdAsync(id);
    }

    public async Task CreatePathAsync(Path path)
    {
        await _unitOfWork.Paths.AddAsync(path);
        await _unitOfWork.SaveAsync();
    }

    public async Task<bool> UpdatePathAsync(int id, Path path)
    {
        var existingPath = await _unitOfWork.Paths.GetByIdAsync(id);
        if (existingPath == null)
        {
            return false;
        }
        
        await _unitOfWork.Paths.UpdateAsync(existingPath);
        await _unitOfWork.SaveAsync();
        
        return true;
    }

    public async Task<bool> DeletePathAsync(int id)
    {
        var existingPath = await _unitOfWork.Paths.GetByIdAsync(id);
        if (existingPath == null)
        {
            return false;
        }
        
        await _unitOfWork.Answers.DeleteAsync(id);
        await _unitOfWork.SaveAsync();
        
        return true;
    }
}