using MyWebstore.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebstore.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public MyWebstoreUser User { get; set; }
        public StoreItem StoreItem { get; set; }
        [Range(1, 10)]
        [Required]
        public int Amount { get; set; }
    }
}
