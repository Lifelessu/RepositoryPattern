using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RepositoryPattern_Relationship_.Data;
using RepositoryPattern_Relationship_.Interface;
using RepositoryPattern_Relationship_.Models;
using RepositoryPattern_Relationship_.Repository;

namespace RepositoryPattern_Relationship_.Controllers
{
    public class SellerController : Controller
    {
        private readonly IItemRepository _item;
        private readonly ISellerRepository _seller;
        private readonly ApplicationDbContext _context;
        public SellerController(IItemRepository item,ISellerRepository seller, ApplicationDbContext context)
        {
            _item = item;
            _seller = seller;
            _context = context;
        }
        public async Task <IActionResult> Index()
        {
            var item = await _item.GetItems();
            var seller = await _seller.GetSellers();

            var viewModel = new ViewModel
            {   
                Items = item.ToList(),
                Sellers = seller.ToList()
            };

            return View(viewModel);
        }

        [HttpGet]
        public async Task <IActionResult>Dropdown()
        {

            var items = await _context.Items.ToListAsync();
            ViewBag.SellerItems = items;

            var model = new ViewModel
            {
                Items = items
            };

            return View(model);
        }

        public async Task <IActionResult>AddItem(AddSellerItem obj)
        {
            if(ModelState.IsValid)
            {
                var seller = new Seller()
                {
                    FirstName = obj.FirstName,
                    LastName = obj.LastName, 
                };

                await _seller.CreationSeller(seller);

                var item = new Item()
                {
                    SellerId = seller.SellerId,
                    ItemName = obj.ItemName,
                    Description = obj.Description
                };

                await _item.CreationItem(item);
                return RedirectToAction("Index");
            }

            return View(obj);
        }


        [HttpGet]
        public async Task<IActionResult> EditItem(int id)
        {
            var item = await _item.FindItemId(id);
            var getSeller = await _seller.GetSellerId(id);

            if (getSeller == null)
            {
                return NotFound();
            }
            var model = new ModifyItem()
            {
                ItemName = item.ItemName,
                Description = item.Description, 
                SellerId = getSeller.SellerId,
                FirstName = getSeller.FirstName,
                LastName = getSeller.LastName
            };


            return View(model);

        }


        [HttpPost]
        public async Task<IActionResult> EditItem(ModifyItem model, int id)
        {

            if (ModelState.IsValid)
            {
                var seller = await _seller.GetSellerId(id);
                var item = await _item.FindItemId(id);

                if (seller == null)
                {
                    return NotFound("seller not found");
                }

                if (item == null)
                {
                    return NotFound("item not found");
                }

                item.ItemName = model.ItemName;
                item.Description = model.Description;
                seller.FirstName = model.FirstName;
                seller.LastName = model.LastName;

                await _seller.UpdateSeller(seller);
                await _item.UpdateItem(item);

                return RedirectToAction("Index");
            }
            return View(model);

        }

        [HttpGet]
        public async Task <IActionResult> DeleteItem(int id)
        {
            var item = await _item.FindItemId(id);
            var seller = await _seller.GetSellerId(id);

            if(item == null)
            {
                return NotFound("Item Model Not Found");
            }

            if(seller == null)
            {
                return NotFound("Seller Model Not Found");
            }

            var model = new ModifyItem
            {
                FirstName = seller.FirstName,
                LastName = seller.LastName,
                ItemName = item.ItemName,
                Description = item.Description
            };

            return View(model);
        }

        [HttpPost]
        public async Task <IActionResult> DeleteItem(ModifyItem model, int id)
        {
            if(ModelState.IsValid)
            {
                var seller = await _seller.GetSellerId(id);
                
                if(seller == null)
                {
                    return NotFound("seller was not found");
                }

                //seller.SellerId = model.SellerId;
                await _seller.DeleteSeller(seller);

                return RedirectToAction("Index");
            }

            return View(model);
        }
        
    }
}
