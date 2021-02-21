using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MyWebstore.Data;
using MyWebstore.Models;

namespace MyWebstore.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the MyWebstoreUser class
    public class MyWebstoreUser : IdentityUser
    {
        public ICollection<ShoppingCart> ShoppingCart;
    }
}
