namespace OrderServiceApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty; // Инициализация по умолчанию
        public decimal TotalAmount { get; set; }
    }
}