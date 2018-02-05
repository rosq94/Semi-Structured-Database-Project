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
    public class WirówkiController : Controller
    {
        // GET: Wirówki
        [ActionName("Index")]
        public async Task<ActionResult> IndexAsync()
        {
            var items = await DocumentDBRepository<Wirówki>.GetItemsAsync(d => d.Rodzaj == "Wirówka");
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
        public async Task<ActionResult> CreateAsync(Wirówki item)
        {

            if (ModelState.IsValid)
            {
                await DocumentDBRepository<Wirówki>.CreateItemAsync(item);
                await DBCounter.Licznik();
                return RedirectToAction("Index");
            }

            return View(item);
        }
        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(Wirówki item)
        {
            if (ModelState.IsValid)
            {
                await DocumentDBRepository<Wirówki>.UpdateItemAsync(item.Id, item);
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

            Wirówki item = await DocumentDBRepository<Wirówki>.GetItemAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }


        [ActionName("Delete")]
        public async Task<ActionResult> DeleteAsync(Wirówki item)
        {
            var item_doc = await DocumentDBRepository<Wirówki>.GetItemAsync(item.Id);
            return View(item_doc);
        }
        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirm(Wirówki item)
        {
            if (item != null)
            {
                await DocumentDBRepository<Wirówki>.DeleteItemAsync(item.Id, item);
                await DBCounter.Licznik();
                return RedirectToAction("Index");
            }
            return View();
        }



    }
}