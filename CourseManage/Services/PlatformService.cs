using CourseManage.Entities;
using CourseManage.Interfaces;

namespace CourseManage.Services;

public class PlatformService:IPlatformService
{
    private readonly IUnitOfWork _unitOfWork;

    public PlatformService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    
    public async Task<IEnumerable<Platform>> GetAllPlatformAsync()
    {
        return await _unitOfWork.Platforms.GetAllAsync();
    }

    public async Task<Platform> GetPlatformByIdAsync(int id)
    {
        return await _unitOfWork.Platforms.GetByIdAsync(id);
    }

    public async Task CreatePlatformAsync(Platform platform)
    {
        await _unitOfWork.Platforms.AddAsync(platform);
        await _unitOfWork.SaveAsync();
    }

    public async Task<bool> UpdatePlatformAsync(int id, Platform platform)
    {
        var existingPlatform = await _unitOfWork.Platforms.GetByIdAsync(id);
        if (existingPlatform == null)
        {
            return false;
        }
        
        await _unitOfWork.Platforms.UpdateAsync(platform);
        await _unitOfWork.SaveAsync();
        
        return true;
    }

    public async Task<bool> DeletePlatformAsync(int id)
    {
        var existingPlatform = await _unitOfWork.Platforms.GetByIdAsync(id);
        if (existingPlatform == null)
        {
            return false;
        }
        
        await _unitOfWork.Platforms.DeleteAsync(id);
        await _unitOfWork.SaveAsync();
        
        return true;
    }
}