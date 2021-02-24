using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyWebstore.Data;
using MyWebstore.Models;

namespace MyWebstore.Controllers
{
    public class WebstoreAdminController : BaseController
    {
        public WebstoreAdminController(MyWebstoreContext context) : base(context) { }

        // GET: WebstoreAdmin
        public async Task<IActionResult> Index()
        {
            storeViewModel.StoreItemList = await _context.StoreItems.ToListAsync();
            return View(storeViewModel);
        }

        // GET: WebstoreAdmin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storeItem = await _context.StoreItems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (storeItem == null)
            {
                return NotFound();
            }

            return View(new StoreViewModel(storeItem));
        }

        // GET: WebstoreAdmin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WebstoreAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Price")] StoreItem storeItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(storeItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(new StoreViewModel(storeItem));
        }

        // GET: WebstoreAdmin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storeItem = await _context.StoreItems.FindAsync(id);
            if (storeItem == null)
            {
                return NotFound();
            }
            return View(new StoreViewModel(storeItem));
        }

        // POST: WebstoreAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Price")] StoreItem storeItem)
        {
            if (id != storeItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(storeItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StoreItemExists(storeItem.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(new StoreViewModel(storeItem));
        }

        // GET: WebstoreAdmin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storeItem = await _context.StoreItems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (storeItem == null)
            {
                return NotFound();
            }

            return View(new StoreViewModel(storeItem));
        }

        // POST: WebstoreAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Remove the storeItem from the table
            var storeItem = await _context.StoreItems.FindAsync(id);
            var scItems = await _context.ShoppingCarts
                .Where(x => x.StoreItem == storeItem)
                .ToListAsync();
            _context.ShoppingCarts.RemoveRange(scItems);
            _context.StoreItems.Remove(storeItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StoreItemExists(int id)
        {
            return _context.StoreItems.Any(e => e.Id == id);
        }
    }
}
