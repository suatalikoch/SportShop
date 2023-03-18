using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    [PrimaryKey(nameof(UserId), nameof(ProductId))]
    public class Favourite
    {
        [ForeignKey(nameof(UserId))]
        public int UserId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public int ProductId { get; set; }

        public override string ToString()
        {
            return $"{UserId} {ProductId}";
        }
    }
}
