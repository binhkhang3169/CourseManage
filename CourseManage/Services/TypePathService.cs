using CourseManage.Entities;
using CourseManage.Interfaces;

namespace CourseManage.Services;

public class TypePathService : ITypePathService
{
    private readonly IUnitOfWork _unitOfWork;

    public TypePathService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<TypePath>> GetAllTypePathAsync()
    {
        return await _unitOfWork.TypePaths.GetAllAsync();
    }

    public async Task<TypePath> GetTypePathByIdAsync(int id)
    {
        return await _unitOfWork.TypePaths.GetByIdAsync(id);
    }

    public async Task CreateTypePathAsync(TypePath typePath)
    {
        await _unitOfWork.TypePaths.AddAsync(typePath);
        await _unitOfWork.SaveAsync();
    }

    public async Task<bool> UpdateTypePathAsync(int id, TypePath typePath)
    {
        var existingTypePath = await _unitOfWork.TypePaths.GetByIdAsync(id);
        if (existingTypePath == null)
        {
            return false;
        }

        await _unitOfWork.TypePaths.UpdateAsync(typePath);
        await _unitOfWork.SaveAsync();

        return true;
    }

    public async Task<bool> DeleteTypePathAsync(int id)
    {
        var existingTypePath = await _unitOfWork.TypePaths.GetByIdAsync(id);
        if (existingTypePath == null)
        {
            return false;
        }

        await _unitOfWork.TypePaths.DeleteAsync(id);
        await _unitOfWork.SaveAsync();

        return true;
    }
}