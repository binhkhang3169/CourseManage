using CourseManage.Entities;
using CourseManage.Interfaces;

namespace CourseManage.Services;

public class MenuService:IMenuService
{
    private readonly IUnitOfWork _unitOfWork;

    public MenuService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<Menu>> GetAllMenuAsync()
    {
        return await _unitOfWork.Menus.GetAllAsync();
    }

    public async Task<Menu> GetMenuByIdAsync(int id)
    {
        return await _unitOfWork.Menus.GetByIdAsync(id);
    }

    public async Task CreateMenuAsync(Menu menu)
    {
        await _unitOfWork.Menus.AddAsync(menu);
        await _unitOfWork.SaveAsync();
    }

    public async Task<bool> UpdateMenuAsync(int id, Menu menu)
    {
        var existing = await _unitOfWork.Menus.GetByIdAsync(id);
        if (existing == null)
        {
            return false;
        } 
        
        await _unitOfWork.Menus.UpdateAsync(menu);
        await _unitOfWork.SaveAsync();
        return true;
    }

    public async Task<bool> DeleteMenuAsync(int id)
    {
        var existing = await _unitOfWork.Menus.GetByIdAsync(id);
        if (existing == null)
        {
            return false;
        }
        
        await _unitOfWork.Menus.DeleteAsync(id);
        await _unitOfWork.SaveAsync();
        return true;
    }
}