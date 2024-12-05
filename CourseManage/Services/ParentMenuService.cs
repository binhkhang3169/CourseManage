using CourseManage.Entities;
using CourseManage.Interfaces;

namespace CourseManage.Services;

public class ParentMenuService:IParentMenuService
{
    private readonly IUnitOfWork _unitOfWork;

    public ParentMenuService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<ParentMenu>> GetAllParentMenuAsync()
    {
        return await _unitOfWork.ParentMenus.GetAllAsync();
    }

    public async Task<ParentMenu> GetParentMenuByIdAsync(int id)
    {
        return await _unitOfWork.ParentMenus.GetByIdAsync(id);
    }

    public async Task CreateParentMenuAsync(ParentMenu parentMenu)
    {
        await _unitOfWork.ParentMenus.AddAsync(parentMenu);
        await _unitOfWork.SaveAsync();
    }

    public async Task<bool> UpdateParentMenuAsync(int id, ParentMenu parentMenu)
    {
        var existingParentMenu = await _unitOfWork.ParentMenus.GetByIdAsync(id);
        if (existingParentMenu == null)
        {
            return false;
        }

        await _unitOfWork.ParentMenus.UpdateAsync(parentMenu);
        await _unitOfWork.SaveAsync();
        return true;
    }

    public async Task<bool> DeleteParentMenuAsync(int id)
    {
        var existingParentMenu = await _unitOfWork.ParentMenus.GetByIdAsync(id);
        if (existingParentMenu == null)
        {
            return false;
        }

        await _unitOfWork.ParentMenus.DeleteAsync(id);
        await _unitOfWork.SaveAsync();
        return true;
    }
}