using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Examen.Web.Controllers
{
    public class CompteController1 : Controller
    {
        IServiceCompte sc;
        IServiceBanque sb;

        public CompteController1(IServiceCompte sc, IServiceBanque sb)
        {
            this.sc = sc;
            this.sb = sb;
        }



        // GET: CompteController1
        public ActionResult Index(TypeCompte? type)
        {
            if(type==null)
            return View(sc.GetAll());
            return View(sc.GetMany(p => p.Type.Equals(type)));
        }

        // GET: CompteController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CompteController1/Create
        public ActionResult Create()
        {

            ViewBag.BanqueList = new SelectList(sb.GetAll(), "Code", "Nom");
            return View();
        }

        // POST: CompteController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Compte compte)
        {
            try
            {
                sc.Add(compte);
                sc.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CompteController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CompteController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: CompteController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CompteController1/Delete/5
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
