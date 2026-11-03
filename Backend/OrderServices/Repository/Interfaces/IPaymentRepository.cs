using OrderServices.Models;

namespace OrderServices.Repository.Interfaces
{
    public interface IPaymentRepository
    {
        Task<Payment?> GetPaymentByIdAsync(int id);
        Task<Payment?> GetPaymentByOrderIdAsync(int orderId);
        Task CreatePaymentAsync(Payment payment);
        Task CompletePaymentAsync(Payment payment, Order order);
    }
}
