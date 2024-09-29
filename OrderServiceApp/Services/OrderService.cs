using OrderServiceApp.IRepositories;
using OrderServiceApp.IServices;
using OrderServiceApp.Models;

namespace OrderServiceApp.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<IEnumerable<Order>> GetAllOrdersAsync()
    {
        return await _orderRepository.GetAllAsync();
    }

    public async Task<Order> GetOrderByIdAsync(int id)
    {
        return await _orderRepository.GetByIdAsync(id);
    }

    public async Task AddOrderAsync(Order order)
    {
        await _orderRepository.AddAsync(order);
    }

    public async Task UpdateOrderAsync(Order order)
    {
        await _orderRepository.UpdateAsync(order);
    }

    public async Task DeleteOrderAsync(int id)
    {
        await _orderRepository.DeleteAsync(id);
    }

    public async Task<bool> OrderExistsAsync(int id)
    {
        return await _orderRepository.ExistsAsync(id);
    }
}