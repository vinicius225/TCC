using Data.DTOs;
using Data.Entities;
using Data.Repositories.Interfaces;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class EspecialidadeController : Controller
    {
        private readonly IEspecialidadeRepository _especialidadeRepository;

        public EspecialidadeController(IEspecialidadeRepository especialidadeRepository)
        {
            _especialidadeRepository = especialidadeRepository;
        }


        // GET: EspecialidadeController
        public ActionResult Index()
        {
            return View( _especialidadeRepository.GetAll().ToList());
        }

        // GET: EspecialidadeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EspecialidadeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EspecialidadeController/Create
        [HttpPost]
        public ActionResult Create(EspecialidadeDTO especialidade)
        {
            try
            {

                    if (ModelState.IsValid)
                    {
                        var especialidadeBD = new Especialidade();
                        especialidade.Set(especialidadeBD);
                        _especialidadeRepository.Add(especialidadeBD);
                    }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EspecialidadeController/Edit/5
        public ActionResult Edit(int id)
        {

            var especialidadeBD = _especialidadeRepository.Get(id);
            if (especialidadeBD == null)
            {
                return RedirectToAction(nameof(Index));
            }
            var especialidade = new EspecialidadeDTO();
            especialidade.Get(especialidadeBD);
            return View(especialidade);
        }

        // POST: EspecialidadeController/Edit/5
        [HttpPost]
        public ActionResult Edit( int id,EspecialidadeDTO especialidade)
        {
            try
            {

                var especialidadeBD = _especialidadeRepository.Get(especialidade.id);

                if (ModelState.IsValid)
                {
                    especialidade.Set(especialidadeBD);
                    _especialidadeRepository.Update(especialidadeBD);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EspecialidadeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EspecialidadeController/Delete/5
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
