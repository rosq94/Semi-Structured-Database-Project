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
    public class UpdateCounterController : Controller
    {
        // GET: UpdateCounter
        public static int MikseryCount { get; set; }
        [ActionName("Update")]
        public async Task<ActionResult> UpdateAsync(string nazwa, int Dodawanie1_Usuwanie0)
        {

            //if (await DocumentDBRepository<Counter>.GetItemAsync("01234") == null)
            //{
            //    Counter c = new Counter();
            //    c.CzyIstniejeLicznik = true;
            //    c.Id = "01234";
            //    c.KuchnieCount = 0;
            //    c.LodówkiCount = 0;
            //    c.MikseryCount = 0;
            //    c.Pralko_SuszarkiCount = 0;
            //    c.WirówkiCount = 0;
            //    c.ZamrażarkiCount = 0;
            //    await DocumentDBRepository<Counter>.CreateItemAsync(c);
            //    MikseryCount = c.MikseryCount;
            //    return View();
                
            //}
            //else
            //{
            //    switch (nazwa)
            //    {
            //        case "Miksery": if (Dodawanie1_Usuwanie0 == 1)
            //            { c.MikseryCount += 1; await DocumentDBRepository<Counter>.UpdateItemAsync("01234", c); }
            //            else if (Dodawanie1_Usuwanie0 == 0)
            //            { c.MikseryCount -= 1; await DocumentDBRepository<Counter>.UpdateItemAsync("01234", c); }
            //            break;
            //        default:
            //            break;
            //    }
            //}

            //ViewBag.MikseryCount = c.MikseryCount.ToString();
            return View();
        }
    }
}