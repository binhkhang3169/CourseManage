using CourseManage.Entities;
using CourseManage.Interfaces;
using Microsoft.CodeAnalysis.Elfie.Serialization;

namespace CourseManage.Services;

public class PaymentInformationService:IPaymentInformationService
{
    private readonly IUnitOfWork _unitOfWork;

    public PaymentInformationService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<PaymentInformation>> GetAllPaymentInformationAsync()
    {
        return await _unitOfWork.PaymentInformations.GetAllAsync();
    }

    public async Task<PaymentInformation> GetPaymentInformationByIdAsync(int id)
    {
        return await _unitOfWork.PaymentInformations.GetByIdAsync(id);
    }

    public async Task CreatePaymentInformationAsync(PaymentInformation paymentInformation)
    {
        await _unitOfWork.PaymentInformations.AddAsync(paymentInformation);
        await _unitOfWork.SaveAsync();
    }

    public async Task<bool> UpdatePaymentInformationAsync(int id, PaymentInformation paymentInformation)
    {
        var existingPaymentInformation = await _unitOfWork.PaymentInformations.GetByIdAsync(id);
        if (existingPaymentInformation == null)
        {
            return false;
        }
        
        await _unitOfWork.PaymentInformations.UpdateAsync(paymentInformation);
        await _unitOfWork.SaveAsync();
        return true;
    }

    public async Task<bool> DeletePaymentInformationAsync(int id)
    {
        var existingPaymentInformation = await _unitOfWork.PaymentInformations.GetByIdAsync(id);
        if (existingPaymentInformation == null)
        {
            return false;
        }
        
        await _unitOfWork.PaymentInformations.DeleteAsync(id);
        await _unitOfWork.SaveAsync();
        return true;
    }
}