using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    internal class Favourites
    {
        [Key]
        public int Id { get; set; }

        private ICollection<Product> Products { get; set; }
    }
}
