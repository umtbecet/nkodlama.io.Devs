using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Model : Entity
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }

        public virtual Product? Product { get; set; }

        public Model()
        {

        }

        public Model(int id,int productId, string name, decimal price, string imageUrl):this()
        {
            Id= id;  
            ProductId= productId;
            Name = name;
            Price = price;
            ImageUrl = imageUrl;
            
        }
    }
}
