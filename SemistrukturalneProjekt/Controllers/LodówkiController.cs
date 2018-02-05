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
    public class LodówkiController : Controller
    {
        // GET: Lodówki
        [ActionName("Index")]
        public async Task<ActionResult> IndexAsync()
        {
            var items = await DocumentDBRepository<Lodówki>.GetItemsAsync(d => d.Rodzaj == "Lodówka");
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
        public async Task<ActionResult> CreateAsync(Lodówki item)
        {

            if (ModelState.IsValid)
            {
                await DocumentDBRepository<Lodówki>.CreateItemAsync(item);
                await DBCounter.Licznik();
                return RedirectToAction("Index");
            }

            return View(item);
        }
        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(Lodówki item)
        {
            if (ModelState.IsValid)
            {
                await DocumentDBRepository<Lodówki>.UpdateItemAsync(item.Id, item);
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

            Lodówki item = await DocumentDBRepository<Lodówki>.GetItemAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }


        [ActionName("Delete")]
        public async Task<ActionResult> DeleteAsync(Lodówki item)
        {
            var item_doc = await DocumentDBRepository<Lodówki>.GetItemAsync(item.Id);
            return View(item_doc);
        }
        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirm(Lodówki item)
        {
            if (item != null)
            {
                await DocumentDBRepository<Lodówki>.DeleteItemAsync(item.Id, item);
                await DBCounter.Licznik();
                return RedirectToAction("Index");
            }
            return View();
        }



    }
}