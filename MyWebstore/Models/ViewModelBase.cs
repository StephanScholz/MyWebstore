using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebstore.Models
{
    public abstract class ViewModelBase : PageModel
    {
        public int CartItemAmount { get; set; }
    }
}
