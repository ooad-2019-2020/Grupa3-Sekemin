using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sekemin.Data;
using Sekemin.Models;

namespace Sekemin.Controllers
{
    public class UpraviteljSobomZaZabavuController : Controller
    {
        private readonly BazaContext context;

        public UpraviteljSobomZaZabavuController(BazaContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        private List<ZahtjevSobaZaZabavu> postaviStudenta(List<ZahtjevSobaZaZabavu> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                var student = context.Student.FirstOrDefault(s => s.Id == list[i].StudentId);
                list[i].Student = student;
            }
            return list;
        }

        public IActionResult ObradaZahtjevaZaSobu()
        {
            var lista = postaviStudenta(context.ZahtjevSobaZaZabavu.ToList());
            return View(lista);
        }

        private ZahtjevSobaZaZabavu PostaviZahtjev(ZahtjevSobaZaZabavu zahtjev)
        {
            var student = context.Student.FirstOrDefault(s => s.Id == zahtjev.StudentId);
            zahtjev.Student = student;
            return zahtjev;
        }

        public IActionResult ObradiZahtjev(int? zahtjevId)
        {
            if (zahtjevId == null)
            {
                return NoContent();
            }

            var zahtjev = context.ZahtjevSobaZaZabavu.FirstOrDefault(z => z.Id == zahtjevId);

            if (zahtjev == null)
            {
                return NoContent();
            }

            zahtjev = PostaviZahtjev(zahtjev);

            context.Remove(zahtjev);
            context.SaveChanges();

            return RedirectToAction("ObradaZahtjevaZaSobu", "UpraviteljSobomZaZabavu");
        }

        public IActionResult OdbijZahtjev(int? zahtjevId)
        {
            if (zahtjevId == null) return NoContent();

            var zahtjev = context.ZahtjevZaPodizanjeKnjige.FirstOrDefault(z => z.Id == zahtjevId);
            context.ZahtjevZaPodizanjeKnjige.Remove(zahtjev);
            context.SaveChanges();
            return RedirectToAction("ObradaZahtjevaZaSobu", "UpraviteljSobomZaZabavu");
        }
    }
}
