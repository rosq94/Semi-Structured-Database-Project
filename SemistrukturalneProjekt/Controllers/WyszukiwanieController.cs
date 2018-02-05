using SemistrukturalneProjekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SemistrukturalneProjekt.Controllers
{
    public class WyszukiwanieController : Controller
    {
        // GET: Wyszukiwanie
        [ActionName("Kuchnie")]
        public async Task<ActionResult> Kuchnie()
        {
            return View(Session["items"]);
        }

        [ActionName("Lodówki")]
        public async Task<ActionResult> Lodówki()
        {
            return View(Session["items"]);
        }

        [ActionName("Miksery")]
        public async Task<ActionResult> Miksery()
        {
            return View(Session["items"]);
        }

        [ActionName("Pralko_Suszarki")]
        public async Task<ActionResult> Pralko_Suszarki()
        {
            return View(Session["items"]);
        }

        [ActionName("Wirówki")]
        public async Task<ActionResult> Wirówki()
        {
            return View(Session["items"]);
        }

        [ActionName("Zamrażarki")]
        public async Task<ActionResult> Zamrażarki()
        {
            return View(Session["items"]);
        }

        [ActionName("Szukaj")]
        public async Task<ActionResult> CreateAsync()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Szukaj")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Wyszukiwanie item)
        {
            if (ModelState.IsValid)
            {
                if (item.Wybór == "Kuchnie")
                {
                    var items = await DocumentDBRepository<Kuchnie>.GetItemsAsync(d => d.Rodzaj == "Kuchnia" && d.Generals.Cena <= item.Cena && d.Generals.Kolor == item.Kolor);
                    Session["items"] = items;
                    return RedirectToAction("Kuchnie");
                }
                if (item.Wybór == "Lodówki")
                {
                    var items = await DocumentDBRepository<Lodówki>.GetItemsAsync(d => d.Rodzaj == "Lodówka" && d.Lodówki_Zamrażarki.Generals.Cena <= item.Cena && d.Lodówki_Zamrażarki.Generals.Kolor == item.Kolor);
                    Session["items"] = items;
                    return RedirectToAction("Lodówki");
                }
                if (item.Wybór == "Miksery")
                {
                    var items = await DocumentDBRepository<Miksery>.GetItemsAsync(d => d.Rodzaj == "Mikser" && d.Generals.Cena <= item.Cena && d.Generals.Kolor == item.Kolor);
                    Session["items"] = items;
                    return RedirectToAction("Miksery");
                }
                if (item.Wybór == "Pralko_Suszarki")
                {
                    var items = await DocumentDBRepository<Pralko_Suszarki>.GetItemsAsync(d => d.Rodzaj == "Pralko-Suszarka" && d.Pralki.Generals.Cena <= item.Cena && d.Pralki.Generals.Kolor == item.Kolor);
                    Session["items"] = items;
                    return RedirectToAction("Pralko_Suszarki");
                }
                if (item.Wybór == "Wirówki")
                {
                    var items = await DocumentDBRepository<Wirówki>.GetItemsAsync(d => d.Rodzaj == "Wirówka" && d.Pralki.Generals.Cena <= item.Cena && d.Pralki.Generals.Kolor == item.Kolor);
                    Session["items"] = items;
                    return RedirectToAction("Wirówki");
                }
                if (item.Wybór == "Zamrażarki")
                {
                    var items = await DocumentDBRepository<Zamrażarki>.GetItemsAsync(d => d.Rodzaj == "Zamrażarka" && d.Lodówki_Zamrażarki.Generals.Cena <= item.Cena && d.Lodówki_Zamrażarki.Generals.Kolor == item.Kolor);
                    Session["items"] = items;
                    return RedirectToAction("Zamrażarki");
                }

            }
            return View(item);
        }
    }
}