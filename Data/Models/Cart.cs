using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        private ICollection<Product> Products { get; set; }
    }
}
