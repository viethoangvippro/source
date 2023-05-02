using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Data.Services;
using Project.Models;

namespace Project.Controllers
{
    public class ActorsController : Controller
    {
        public readonly IActorsService _service;

        public ActorsController(IActorsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }
        // get : Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        
        public async Task<IActionResult> Create([Bind("FullName,Picture,Description")]Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.AddAsync(actor);
            
            return RedirectToAction(nameof(Index));
        }

        // get : Detail/1
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }
        // get : Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }
        [HttpPost]

        public async Task<IActionResult> Edit(int id, [Bind("Id, FullName,Picture,Description")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.UpdateAsync(id, actor);

            return RedirectToAction(nameof(Index));
        }

        // get : Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }
        [HttpPost, ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            await _service.DeleteAsync(id);


            return RedirectToAction(nameof(Index));
        }
    }
}
