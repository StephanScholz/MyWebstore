using MyWebstore.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebstore.Models
{
    public class User_ShoppingCart
    {
        public int Id { get; set; }
        public MyWebstoreUser User { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
    }
}
