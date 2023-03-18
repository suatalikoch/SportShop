﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    [PrimaryKey(nameof(UserId), nameof(ProductId))]
    public class Cart
    {
        [ForeignKey(nameof(UserId))]
        public int UserId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public int ProductId { get; set; }
    }
}
