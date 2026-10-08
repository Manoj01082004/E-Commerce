using E_CommerceDTO.models;
using E_CommerceDTO.Repositories;

namespace E_CommerceBTO.Services
{
    public class OrderService
    {
        private readonly OrderRepository _orderRepo;
        private readonly CartItemRepository _cartItemRepo;
        private readonly UserRepository _userRepo;

        public OrderService(
            OrderRepository orderRepo,
            CartItemRepository cartItemRepo,
            UserRepository userRepo)
        {
            _orderRepo = orderRepo;
            _cartItemRepo = cartItemRepo;
            _userRepo = userRepo;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _orderRepo.GetAllOrdersAsync();
        }

        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            return await _orderRepo.GetOrderByIdAsync(id);
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId)
        {
            return await _orderRepo.GetOrdersByUserIdAsync(userId);
        }

        public async Task<Order?> CreateOrderFromCartAsync(int userId,string shippingAddress)
        {
            var user = await _userRepo.GetUserByIdAsync(userId);

            if (user is null)
            {
                return null;
            }

            var cartItems = await _cartItemRepo.GetCartItemsByUserIdAsync(userId);

            if (!cartItems.Any())
            {
                throw new InvalidOperationException("Cart is empty.");
            }

            var order = new Order
            {
                OrderNumber = GenerateOrderNumber(),
                UserId = userId,
                ShippingAddress = shippingAddress.Trim(),
                Status = OrderStatus.Pending
            };

            foreach (var cartItem in cartItems)
            {
                if (cartItem.Product is null)
                {
                    throw new InvalidOperationException(
                        $"Product with ID {cartItem.ProductId} was not found.");
                }

                if (!cartItem.Product.IsActive)
                {
                    throw new InvalidOperationException(
                        $"Product '{cartItem.Product.Name}' is not active.");
                }

                var orderItem = new OrderItem
                {
                    ProductId = cartItem.ProductId,
                    ProductName = cartItem.Product.Name,
                    UnitPrice = cartItem.Product.Price,
                    Quantity = cartItem.Quantity
                };

                order.OrderItems.Add(orderItem);
            }

            order.TotalAmount = order.OrderItems.Sum(orderItem =>
                orderItem.UnitPrice * orderItem.Quantity);

            await _orderRepo.CreateOrderFromCartAsync(order, cartItems);

            return order;
        }

        public async Task UpdateOrderAsync(Order order)
        {
            order.UpdatedAt = DateTime.UtcNow;

            await _orderRepo.UpdateOrderAsync(order);
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            var order = await _orderRepo.GetOrderByIdAsync(id);

            if (order is null)
            {
                return false;
            }

            await _orderRepo.DeleteOrderAsync(id);

            return true;
        }

        private static string GenerateOrderNumber()
        {
            var randomValue = Guid.NewGuid()
                .ToString("N")
                .Substring(0, 8)
                .ToUpperInvariant();

            return $"ORD-{DateTime.UtcNow:yyyyMMdd}-{randomValue}";
        }
    }
}