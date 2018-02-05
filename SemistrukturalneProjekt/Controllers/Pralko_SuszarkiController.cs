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
    public class Pralko_SuszarkiController : Controller
    {
        // GET: Pralko_Suszarki
        [ActionName("Index")]
        public async Task<ActionResult> IndexAsync()
        {
            var items = await DocumentDBRepository<Pralko_Suszarki>.GetItemsAsync(d => d.Rodzaj == "Pralko-Suszarka");
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
        public async Task<ActionResult> CreateAsync(Pralko_Suszarki item)
        {

            if (ModelState.IsValid)
            {
                await DocumentDBRepository<Pralko_Suszarki>.CreateItemAsync(item);
                await DBCounter.Licznik();
                return RedirectToAction("Index");
            }

            return View(item);
        }
        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(Pralko_Suszarki item)
        {
            if (ModelState.IsValid)
            {
                await DocumentDBRepository<Pralko_Suszarki>.UpdateItemAsync(item.Id, item);
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

            Pralko_Suszarki item = await DocumentDBRepository<Pralko_Suszarki>.GetItemAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }


        [ActionName("Delete")]
        public async Task<ActionResult> DeleteAsync(Pralko_Suszarki item)
        {
            var item_doc = await DocumentDBRepository<Pralko_Suszarki>.GetItemAsync(item.Id);
            return View(item_doc);
        }
        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirm(Pralko_Suszarki item)
        {
            if (item != null)
            {
                await DocumentDBRepository<Pralko_Suszarki>.DeleteItemAsync(item.Id, item);
                await DBCounter.Licznik();
                return RedirectToAction("Index");
            }
            return View();
        }



    }
}