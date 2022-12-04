using Data.DTOs;
using Data.Entities;
using Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class UnidadeController : Controller
    {

        private readonly IUnidadeSaudeRepository _unidadeSaudeRepository;
        private readonly IMedicoRepository _medicoRepository;
        private readonly IPlantaoRepository _plantaoRepository;

        public UnidadeController(IUnidadeSaudeRepository unidadeSaudeRepository, IMedicoRepository medicoRepository, IPlantaoRepository plantaoRepository)
        {
            _unidadeSaudeRepository = unidadeSaudeRepository;
            _medicoRepository = medicoRepository;
            _plantaoRepository = plantaoRepository;
        }



        // GET: UnidadesController
        public ActionResult Index()
        {
            return View(_unidadeSaudeRepository.GetAll().ToList());
        }
        public IActionResult PlantaoListar(int id)
        {
            var plantao = _plantaoRepository.GetAll().Where(a=> a.id == id).ToList(); 
            return View(plantao);   
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
        public ActionResult Create(UnidadeDTO unidadeDTO)
        {
            try
            {
                var unidade = new UnidadeSaude();
                unidadeDTO.Set(unidade);
                _unidadeSaudeRepository.Add(unidade);
                TempData["mensagem"] = Helper.HelperHtml.MessageAlert("Adicionado com sucesso", Helper.Enum.ErrosEnum.Sucesso);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            var unidade = _unidadeSaudeRepository.Get(id);
            var unidadeDTO = new UnidadeDTO();
            unidadeDTO.Get(unidade);
            return View(unidadeDTO);
        }

        [HttpPost]
        public ActionResult Edit(UnidadeDTO unidadeDTO)
        {
            var unidade = _unidadeSaudeRepository.Get(unidadeDTO.id);
            try
            {

                unidadeDTO.Set(unidade);
                _unidadeSaudeRepository.Update(unidade);
                TempData["mensagem"] = Helper.HelperHtml.MessageAlert("Atualizado com sucesso", Helper.Enum.ErrosEnum.Sucesso);
                return RedirectToAction("Index");

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
