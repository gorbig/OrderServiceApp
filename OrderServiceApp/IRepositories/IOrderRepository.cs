using OrderServiceApp.Models;

namespace OrderServiceApp.IRepositories;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> GetAllAsync();
    Task<Order> GetByIdAsync(int id);
    Task AddAsync(Order order);
    Task UpdateAsync(Order order);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}