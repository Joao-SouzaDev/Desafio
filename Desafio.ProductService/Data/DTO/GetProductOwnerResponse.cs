namespace Desafio.ProductService.Data.DTO
{
    public class GetProductOwnerResponse
    {
        public Guid Id { get; private set; }
        public string UserName { get; private set; }
        public string Email { get; private set; }
    }
}
