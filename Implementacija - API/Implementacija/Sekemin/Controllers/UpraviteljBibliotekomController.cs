using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sekemin.Data;
using Sekemin.Models;

namespace Sekemin.Controllers
{
     [Authorize(Roles="UpraviteljBibliotekom")]
    public class UpraviteljBibliotekomController : Controller
    {
        private readonly BazaContext context;

        public UpraviteljBibliotekomController(BazaContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        private ZahtjevZaPodizanjeKnjige PostaviZahtjev(ZahtjevZaPodizanjeKnjige zahtjev)
        {
            var knjiga = context.Knjiga.FirstOrDefault(k => k.Id == zahtjev.KnjigaId);
            var student = context.Student.FirstOrDefault(s => s.Id == zahtjev.StudentId);
            zahtjev.Knjiga = knjiga;
            zahtjev.Student = student;
            return zahtjev;
        }

        private List<ZahtjevZaPodizanjeKnjige> PostaviKnjiguIStudenta(List<ZahtjevZaPodizanjeKnjige> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i] = PostaviZahtjev(list[i]);
            }
            return list;
        }

        public IActionResult ObradaZahtjevaZaPodizanjeKnjige()
        {
            var bazaContext = context.ZahtjevZaPodizanjeKnjige.Where(z => z.Knjiga != null);
            var lista = PostaviKnjiguIStudenta(bazaContext.ToList());
            return View(lista);
        }

        public IActionResult ObradiZahtjev(int? zahtjevId)
        {
            if (zahtjevId == null)
            {
                return NoContent();
            }

            var zahtjev = context.ZahtjevZaPodizanjeKnjige.FirstOrDefault(z => z.Id == zahtjevId);

            if (zahtjev == null)
            {
                return NoContent();
            }

            zahtjev = PostaviZahtjev(zahtjev);

            if (zahtjev.Knjiga.StudentId != null)
            {
                return  OdbijZahtjev(zahtjevId);
            }

            var knjiga = zahtjev.Knjiga;
            var student = zahtjev.Student;

            knjiga.Student = student;
            knjiga.StudentId = student.Id;

            context.Update(knjiga);
            context.ZahtjevZaPodizanjeKnjige.Remove(zahtjev);
            context.SaveChanges();

            return  RedirectToAction("ObradaZahtjevaZaPodizanjeKnjige", "UpraviteljBibliotekom");
        }

        public IActionResult OdbijZahtjev(int? zahtjevId)
        {
            if (zahtjevId == null) return NoContent();

            var zahtjev =  context.ZahtjevZaPodizanjeKnjige.FirstOrDefault(z => z.Id == zahtjevId);
            context.ZahtjevZaPodizanjeKnjige.Remove(zahtjev);
            context.SaveChanges();
            return RedirectToAction("ObradaZahtjevaZaPodizanjeKnjige", "UpraviteljBibliotekom");
        }
    }
}
