using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebstore.Models
{
    public class CartViewModel : ViewModelBase
    {
        public IEnumerable<CartItem> CartItemList { get; set; }
        public decimal? PriceSum { get; set; }
        public CartItem CartItem { get; set; }
    }
}
