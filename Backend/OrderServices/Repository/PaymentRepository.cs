using OrderServices.Data;
using OrderServices.Models;
using OrderServices.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OrderServices.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly OrderDbContext _db;
        public PaymentRepository(OrderDbContext db)
        {
            _db = db;
        }
        public async Task<Payment?> GetPaymentByIdAsync(int id)
        {
            return await _db.Payments.Include(p => p.Order).FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<Payment?> GetPaymentByOrderIdAsync(int orderId)
        {
            return await _db.Payments
                .Include(payment => payment.Order)
                .FirstOrDefaultAsync(payment => payment.OrderId == orderId);
        }
        public async Task CreatePaymentAsync(Payment payment)
        {
            await _db.Payments.AddAsync(payment);
            await _db.SaveChangesAsync();
        }
        public async Task CompletePaymentAsync(Payment payment,Order order)
        {
            await using var transaction = await _db.Database.BeginTransactionAsync();

            try
            {
                _db.Payments.Update(payment);
                _db.Orders.Update(order);

                await _db.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
