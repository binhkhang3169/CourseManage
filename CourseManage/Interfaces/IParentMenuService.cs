using CourseManage.Entities;

namespace CourseManage.Interfaces;

public interface IParentMenuService
{
    Task<IEnumerable<ParentMenu>> GetAllParentMenuAsync();
    Task<ParentMenu> GetParentMenuByIdAsync(int id); 
    Task CreateParentMenuAsync(ParentMenu parentMenu);
    Task<bool> UpdateParentMenuAsync(int id, ParentMenu parentMenu); 
    Task<bool> DeleteParentMenuAsync(int id);
}