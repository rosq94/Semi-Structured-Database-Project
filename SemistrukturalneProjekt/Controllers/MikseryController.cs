using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Threading.Tasks;
using SemistrukturalneProjekt.Models;
using System.IO;

namespace SemistrukturalneProjekt.Controllers
{
    public class MikseryController : Controller
    {
        UpdateCounterController up = new UpdateCounterController();
        // GET: Miksery
        [ActionName("Index")]
        public async Task<ActionResult> IndexAsync()
        {
            var items = await DocumentDBRepository<Miksery>.GetItemsAsync(d => d.Rodzaj == "Mikser");                      
            return View(items);
        }
        [ActionName("Create")]
        public async Task<ActionResult> CreateAsync()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Miksery item)
        {

            if (ModelState.IsValid)
            {
                await DocumentDBRepository<Miksery>.CreateItemAsync(item);
                await DBCounter.Licznik();
                return RedirectToAction("Index");
            }

            return View();
        }
        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(Miksery item)
        {
            if (ModelState.IsValid)
            {
                await DocumentDBRepository<Miksery>.UpdateItemAsync(item.Id, item);
                return RedirectToAction("Index");
            }

            return View(item);
        }

        [ActionName("Edit")]
        public async Task<ActionResult> EditAsync(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Miksery item = await DocumentDBRepository<Miksery>.GetItemAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }


        [ActionName("Delete")]
        public async Task<ActionResult> DeleteAsync(Miksery item)
        {
            var item_doc = await DocumentDBRepository<Miksery>.GetItemAsync(item.Id);          
            return View(item_doc);
        }
        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirm(Miksery item)
        {
            if (item != null)
            {
                await DocumentDBRepository<Miksery>.DeleteItemAsync(item.Id, item);
                await DBCounter.Licznik();
                return RedirectToAction("Index");
            }
            return View();
        }



    }
}