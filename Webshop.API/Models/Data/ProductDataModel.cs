﻿using System.ComponentModel.DataAnnotations;

namespace Webshop.API.Models.Data
{
    public class ProductDataModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
