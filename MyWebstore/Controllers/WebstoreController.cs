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

namespace MyWebstore.Controllers
{
    public class WebstoreController : BaseController
    {
        public WebstoreController(WebstoreContext context) : base(context) { }

        // GET: /Webstore/
        public async Task<IActionResult> Index()
        {
            storeViewModel.StoreItemList = await _context.StoreItem.ToListAsync();
            return View(storeViewModel);
        }

        // GET: /Webstore/Cart
         public async Task<IActionResult> Cart()
        {
            cartViewModel.CartItemList = await _context.CartItem.Include(x => x.StoreItem).ToListAsync();
            return View(cartViewModel);
        }

        // GET: /Webstore/Details
        public async Task<IActionResult> Details(int storeItemId)
        {
            storeViewModel.StoreItemList = await _context.StoreItem.ToListAsync();
            foreach(var item in storeViewModel.StoreItemList)
            {
                if (item.Id == storeItemId)
                {
                    StoreViewModel model = new StoreViewModel();
                    model.CurrentStoreItem = item;
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

            CreateCartItem(storeItemId, amount);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Cart));
        }

        private void CreateCartItem(int storeItemId, int amount)
        {
            // Query to get the StoreItem from the Model
            var storeItemList = from s in _context.StoreItem select s;
            storeItemList = storeItemList.Where(s => s.Id == storeItemId);

            // Query to get the CartItem
            var cartItemList = from c in _context.CartItem select c;
            cartItemList = cartItemList.Include(x => x.StoreItem).Where(c => c.StoreItem.Id == storeItemId);

            if (cartItemList.Any())
            {
                CartItem cartItem = cartItemList.First();
                cartItem.Amount += amount;
                _context.Update(cartItem);
            }
            else if (storeItemList.Any())
            {
                CartItem cartItem = new CartItem
                {
                    StoreItem = storeItemList.First(),
                    Amount = amount
                };
                _context.Add(cartItem);
            }
        }

        public async Task<IActionResult> DeleteCartItem(IFormCollection formObject)
        {
            int cartItemId = Int32.Parse(formObject["cartItemId"].ToString());
            int deleteAmount = Int32.Parse(formObject["CartItem.Amount"].ToString());

            var cartItem = await _context.CartItem.FindAsync(cartItemId);
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
