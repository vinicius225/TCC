using Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class MedicoController : Controller
    {
        private readonly IMedicoRepository _medicoRepository;
        private readonly IEspecialidadeRepository _especialidadeRepository;

        public MedicoController(IMedicoRepository medicoRepository, IEspecialidadeRepository especialidadeRepository)
        {
            _medicoRepository = medicoRepository;
            _especialidadeRepository = especialidadeRepository;
        }

        // GET: MedicosController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MedicosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MedicosController/Create
        public ActionResult Create()
        {
            ViewBag.Especialidades = _especialidadeRepository.GetAll().ToList();
            return View();
        }

        // POST: MedicosController/Create
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

        // GET: MedicosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MedicosController/Edit/5
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

        // GET: MedicosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MedicosController/Delete/5
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
