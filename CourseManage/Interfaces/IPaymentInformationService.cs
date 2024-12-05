using CourseManage.Entities;

namespace CourseManage.Interfaces;

public interface IPaymentInformationService
{
    Task<IEnumerable<PaymentInformation>> GetAllPaymentInformationAsync();
    Task<PaymentInformation> GetPaymentInformationByIdAsync(int id); 
    Task CreatePaymentInformationAsync(PaymentInformation paymentInformation);
    Task<bool> UpdatePaymentInformationAsync(int id, PaymentInformation paymentInformation); 
    Task<bool> DeletePaymentInformationAsync(int id);
}