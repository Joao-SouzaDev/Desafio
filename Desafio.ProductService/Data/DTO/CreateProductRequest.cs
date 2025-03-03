using System.ComponentModel.DataAnnotations;

namespace Desafio.ProductService.Data.DTO
{
    public class CreateProductRequest
    {
        [Required]
        public string? Name { get;  set; }
        public string? Description { get; set; }
        [Required]
        public decimal Price { get;  set; }
        public Guid ProductOwnerId { get; set; }
    }
}
