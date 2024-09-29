using OrderServiceApp.Models;

namespace OrderServiceApp.IServices;

public interface IOrderService
{
    Task<IEnumerable<Order>> GetAllOrdersAsync();
    Task<Order> GetOrderByIdAsync(int id);
    Task AddOrderAsync(Order order);
    Task UpdateOrderAsync(Order order);
    Task DeleteOrderAsync(int id);
    Task<bool> OrderExistsAsync(int id);
}