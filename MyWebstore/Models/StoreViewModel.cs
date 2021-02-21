using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebstore.Models
{
    public class StoreViewModel
    {
        public StoreViewModel(StoreItem item)
        {
            StoreItem = item;
        }
        public StoreViewModel() { }
        public IEnumerable<StoreItem> StoreItemList { get; set; }
        public StoreItem StoreItem { get; set; }
    }
}
