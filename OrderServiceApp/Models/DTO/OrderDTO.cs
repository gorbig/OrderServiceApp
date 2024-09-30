using System.ComponentModel.DataAnnotations;

namespace OrderServiceApp.Models.DTO;


public class OrderDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Customer name is required.")]
    [StringLength(100, ErrorMessage = "Customer name cannot be longer than 100 characters.")]
    public string CustomerName { get; set; }

    [Required(ErrorMessage = "Total amount is required.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Total amount must be greater than 0.")]
    public decimal TotalAmount { get; set; }
}