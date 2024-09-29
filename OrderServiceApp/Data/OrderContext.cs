using Microsoft.EntityFrameworkCore;
using OrderServiceApp.Models;

namespace OrderServiceApp.Data;

public class OrderContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    
    public OrderContext(DbContextOptions<OrderContext> options) : base(options) { }
    
}