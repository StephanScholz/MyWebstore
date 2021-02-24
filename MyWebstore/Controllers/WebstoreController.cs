using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebstore.Data;
using MyWebstore.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using MyWebstore.Areas.Identity.Data;

namespace MyWebstore.Controllers
{
    public class WebstoreController : BaseController
    {
        private readonly UserManager<MyWebstoreUser> _userManager;
        public WebstoreController(UserManager<MyWebstoreUser> userManager, MyWebstoreContext context) : base(context) 
        {
            _userManager = userManager;
        }

        // GET: /Webstore/
        public async Task<IActionResult> Index()
        {
            storeViewModel.StoreItemList = await _context.StoreItems.ToListAsync();
            return View(storeViewModel);
        }

        // GET: /Webstore/Cart
         public async Task<IActionResult> Cart()
        {
            string userId = _userManager.GetUserId(User);

            List<ShoppingCart> cartList = new List<ShoppingCart>();

            // Check if cart for logged in user exists
            // if not, create entries in User_ShoppingCart and a new ShoppingCart (empty)
            cartList = await _context.ShoppingCarts
            .Where(w => w.User.Id == userId)
            .Include(x => x.StoreItem)
            .ToListAsync();
            
            return View(cartList);
        }

        // GET: /Webstore/Details
        public async Task<IActionResult> Details(int storeItemId)
        {
            storeViewModel.StoreItemList = await _context.StoreItems.ToListAsync();
            foreach(var item in storeViewModel.StoreItemList)
            {
                if (item.Id == storeItemId)
                {
                    StoreViewModel model = new StoreViewModel();
                    model.StoreItem = item;
                    return View(model);
                }
            }
            return View(new StoreItem());
        }

        // POST: /Webstore/Cart
        [HttpPost]
        public async Task<IActionResult> AddToShoppingCart(IFormCollection formObject)
        {
            // Getting the StoreItem Id from the form in the Index View
            int storeItemId = Int32.Parse(formObject["storeItemId"].ToString());
            // Getting the Amount from the form
            int amount = Int32.Parse(formObject["Amount"].ToString());

            var currentUser = await _userManager.GetUserAsync(User);
            CreateCartItem(storeItemId, amount, currentUser);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Cart));
        }

        private void CreateCartItem(int storeItemId, int amount, MyWebstoreUser user)
        {
            // Query to get the StoreItem from the Model
            var storeItem = _context.StoreItems
                .Where(s => s.Id == storeItemId)
                .FirstOrDefault();

            // Get the User Id
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Query to get the CartItem

            var cartItem = _context.ShoppingCarts
                .Where(z => z.User.Id == userId && z.StoreItem.Id == storeItem.Id)
                .FirstOrDefault();

            if (cartItem != default(ShoppingCart))
            {
                cartItem.Amount += amount;
                _context.Update(cartItem);
            }
            else
            {
                cartItem = new ShoppingCart
                {
                    StoreItem = storeItem,
                    Amount = amount,
                    User = user
                };
                _context.Add(cartItem);
            }
            
        }

        public async Task<IActionResult> DeleteCartItem(IFormCollection formObject)
        {
            var user = await _userManager.GetUserAsync(User);
            
            int cartItemId = Int32.Parse(formObject["cartItemId"].ToString());
            int deleteAmount = Int32.Parse(formObject["item.Amount"].ToString());

            var cartItem = await _context.ShoppingCarts
                .Where(x => x.User.Id == user.Id && x.StoreItem.Id == cartItemId)
                .FirstOrDefaultAsync();
            if (cartItem.Amount > deleteAmount)
            {
                cartItem.Amount -= deleteAmount;
                _context.Update(cartItem);
            }
            else
            {
                _context.Remove(cartItem);
            }
            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Cart));
        }
    }
}
