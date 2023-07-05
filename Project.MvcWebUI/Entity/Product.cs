using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace Project.MvcWebUI.Entity
{
    public class Product
    {
        public int Id { get; set; }

        [DisplayName("Ürün Adı")]
        public string Name { get; set; }

        [DisplayName("Ürün Açıklaması")]
        public string Description { get; set; }

        public  double Price { get; set; }

        public int Stock { get; set; }
        public string Image { get; set; }

        public bool IsHome { get; set; }
        public bool IsApproved { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}