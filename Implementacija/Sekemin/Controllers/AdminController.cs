using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sekemin.Data;
using Sekemin.Models;
using Sekemin.ViewModels;

namespace Sekemin.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> logger;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<Osoba> userManager;
        private readonly BazaContext context;
        public AdminController(RoleManager<IdentityRole> roleManager, UserManager<Osoba> userManager, ILogger<AdminController> logger, BazaContext context)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.logger = logger;
            this.context = context;
        }
        
        

        [HttpGet]
        public IActionResult Index()
        {
            var korisnici =  userManager.Users;
            var uloge = roleManager.Roles;
            var tuple = new Tuple<IEnumerable<Osoba>, IEnumerable<IdentityRole>>(korisnici, uloge);
            return View(tuple);
        }

        [HttpPost]
        public async Task<IActionResult> ObrisiKorisnika(string id)
        {
            var korisnik = await userManager.FindByIdAsync(id);

            if( korisnik != null)
            {
                var result = await userManager.DeleteAsync(korisnik);

                if(result.Succeeded)
                {
                    return RedirectToAction("Zahtjev", "GetZahtjeviZaRazduzivanje");
                }

            }

            return View("NotFound");
        }

        [HttpGet]
        public IActionResult KreirajUlogu()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> KreirajUlogu(KreirajUlogu model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole uloga = new IdentityRole
                {
                    Name = model.NazivUloge
                };

                IdentityResult result = await roleManager.CreateAsync(uloga);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "account");
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task DodijeliUlogu()
        {
            var korisnik = await GetKorisnik();

            await userManager.AddToRoleAsync(korisnik, "Administrator");
        }







        private async Task<Osoba> GetKorisnik()
        {
            return await userManager.GetUserAsync(HttpContext.User);
        }

    }
}