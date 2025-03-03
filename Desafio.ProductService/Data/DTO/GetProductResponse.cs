namespace Desafio.ProductService.Data.DTO
{
    public class GetProductResponse
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public decimal Price { get; set; }
        public Guid ProductOwnerId { get; set; }
    }
}
