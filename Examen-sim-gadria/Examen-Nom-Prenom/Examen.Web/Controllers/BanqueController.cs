using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Examen.Web.Controllers
{
    public class BanqueController : Controller
    {
        // GET: BanqueController
        IServiceBanque sb;
        IServiceCompte sc;

        public BanqueController(IServiceBanque sb, IServiceCompte sc)
        {
            this.sb = sb;   
            this.sc = sc;
        }

        public ActionResult Index()
        {
            return View(sc.GetAll());
        }

        // GET: BanqueController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BanqueController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BanqueController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BanqueController/Edit/5
        public ActionResult Edit(int id)
        {
           
           
                return View(sb.GetById(id));
            
        }

        // POST: BanqueController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Banque? banque)
        {
            try
            {
                sb.Update(banque);
                sb.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BanqueController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BanqueController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
