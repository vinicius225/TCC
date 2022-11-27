using Data;
using Data.DTOs;
using Data.Entities;
using Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;

namespace MVC.Controllers
{
    public class MedicoController : Controller
    {
        private readonly IMedicoRepository _medicoRepository;
        private readonly IEspecialidadeRepository _especialidadeRepository;
        private readonly AppDbContext _appDbContext;
        public MedicoController(IMedicoRepository medicoRepository, IEspecialidadeRepository especialidadeRepository, AppDbContext appDbContext)
        {
            _medicoRepository = medicoRepository;
            _especialidadeRepository = especialidadeRepository;
            _appDbContext = appDbContext;
        }



        // GET: MedicosController
        public ActionResult Index()
        {
            return View(_appDbContext.Medico.Include(a => a.Especialidade).ToList());
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
        public ActionResult Create(MedicoDTO medicoDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        var medicoBD = new Medico();



                        medicoDTO.Set(medicoBD);
                        var listEspecialidade = new List<Especialidade>();
                        foreach( int item in medicoDTO.ids_Especialidades)
                        {
                            var temp = _especialidadeRepository.Get(item);
                            listEspecialidade.Add(temp);
                        }
                        medicoBD.Especialidade = listEspecialidade;

                        _medicoRepository.Add(medicoBD);

                    }
                }

                catch
                {
                    ViewBag.Especialidades = _especialidadeRepository.GetAll().ToList();
                    return View();
                }

            }
            return RedirectToAction(nameof(Index));

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
