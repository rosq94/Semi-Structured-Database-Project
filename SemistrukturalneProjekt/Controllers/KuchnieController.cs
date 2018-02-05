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
    public class KuchnieController : Controller
    {
        // GET: Kuchnie
        [ActionName("Index")]
        public async Task<ActionResult> IndexAsync()
        {
            var items = await DocumentDBRepository<Kuchnie>.GetItemsAsync(d => d.Rodzaj == "Kuchnia");
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
        public async Task<ActionResult> CreateAsync(Kuchnie item)
        {           
            if (ModelState.IsValid)
            {
                await DocumentDBRepository<Kuchnie>.CreateItemAsync(item);
                await DBCounter.Licznik();
                return RedirectToAction("Index");
            }

            return View(item);
        }
        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(Kuchnie item)
        {
            if (ModelState.IsValid)
            {
                await DocumentDBRepository<Kuchnie>.UpdateItemAsync(item.Id, item);
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

            Kuchnie item = await DocumentDBRepository<Kuchnie>.GetItemAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }


        [ActionName("Delete")]
        public async Task<ActionResult> DeleteAsync(Kuchnie item)
        {
            var item_doc = await DocumentDBRepository<Kuchnie>.GetItemAsync(item.Id);
            return View(item_doc);
        }
        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirm(Kuchnie item)
        {
            if (item != null)
            {
                await DocumentDBRepository<Kuchnie>.DeleteItemAsync(item.Id, item);
                await DBCounter.Licznik();
                return RedirectToAction("Index");
            }
            return View();
        }



    }
}