using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyWebstore.Data;
using MyWebstore.Models;

namespace MyWebstore.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly MyWebstoreContext _context;
        protected readonly StoreViewModel storeViewModel;
        protected readonly CartViewModel cartViewModel;
        public int CartItemAmount { get; set; }
        public BaseController(MyWebstoreContext context) : base() {
            _context = context;
            storeViewModel = new StoreViewModel();
            cartViewModel = new CartViewModel();

            storeViewModel.CartItemAmount = _context.CartItem.ToList().Count();
            cartViewModel.CartItemAmount = _context.CartItem.ToList().Count();
        }
    }
}