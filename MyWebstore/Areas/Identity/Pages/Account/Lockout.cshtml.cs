using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyWebstore.Models;

namespace MyWebstore.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LockoutModel : ViewModelBase
    {
        public void OnGet()
        {

        }
    }
}
