using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.ProductService.Models
{
    public class ProductOwner
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public ICollection<Product> Products { get; set; }
        public ProductOwner()
        {

        }
        public ProductOwner(Guid userId)
        {
            Id = Guid.NewGuid();
            UserId = userId;
        }
    }
}
