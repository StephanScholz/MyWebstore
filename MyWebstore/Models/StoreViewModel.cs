using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebstore.Models
{
    public class StoreViewModel : ViewModelBase
    {
        public IEnumerable<StoreItem> StoreItemList { get; set; }
        public StoreItem CurrentStoreItem { get; set; }
    }
}
