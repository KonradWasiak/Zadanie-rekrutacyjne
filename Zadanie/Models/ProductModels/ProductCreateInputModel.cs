﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zadanie.Models.ProductModels
{
    public class ProductCreateInputModel
    {
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public decimal? Price { get; set; }

    }
}
