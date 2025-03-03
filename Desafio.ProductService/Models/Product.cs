using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.ProductService.Models
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string? Name { get; private set; }
        public string? Description { get; private set; }
        public string? ImageUrl { get; private set; }
        public decimal Price { get; private set; }
        public Guid ProductOwnerId { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public ProductOwner ProductOwner { get; private set; }

        // Constutor padrão para o Entity Framework
        public Product()
        {
            CreatedDate = DateTime.UtcNow;

        }
    }
}
