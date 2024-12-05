using CourseManage.Entities;

namespace CourseManage.Interfaces;

public interface IPlatformService
{
    Task<IEnumerable<Platform>> GetAllPlatformAsync();
    Task<Platform> GetPlatformByIdAsync(int id); 
    Task CreatePlatformAsync(Platform platform);
    Task<bool> UpdatePlatformAsync(int id, Platform platform); 
    Task<bool> DeletePlatformAsync(int id);
}