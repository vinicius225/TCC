using Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class UnidadeController : Controller
    {

        private readonly IMedicoRepository _medicoRepository;

        public UnidadeController(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        // GET: UnidadesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UnidadesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UnidadesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UnidadesController/Create
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
        public ActionResult PlantaoCreate()
        {
            ViewBag.MedicosList = _medicoRepository.GetAll().ToList();
            return View();
        }

        // GET: UnidadesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UnidadesController/Edit/5
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

        // GET: UnidadesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UnidadesController/Delete/5
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
