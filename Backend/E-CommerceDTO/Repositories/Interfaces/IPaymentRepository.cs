using E_CommerceDTO.models;

namespace E_CommerceDTO.Repositories.Interfaces
{
    public interface IPaymentRepository
    {
        Task<Payment?> GetPaymentByIdAsync(int id);
        Task<Payment?> GetPaymentByOrderIdAsync(int orderId);
        Task CreatePaymentAsync(Payment payment);
        Task CompletePaymentAsync(Payment payment, Order order);
    }
}
