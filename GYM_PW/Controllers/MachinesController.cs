using GYM_PW.Services;
using Microsoft.AspNetCore.Http;
using GYM_PW.Models.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GYM_PW.Controllers
{
    public class MachinesController : Controller
    {
        private readonly IMachineApiService _apiService;
        private readonly ApplicationDbContext _context;

        public MachinesController(IMachineApiService apiService, ApplicationDbContext context)
        {
            _apiService = apiService;
            _context = context;
        }

        public async Task<IActionResult> Machines()
        {
            var machines = await _apiService.GetAllAsync();
            var orderedMachines = machines.OrderBy(m => m.Id).ToList();
            return View(orderedMachines);
        }

        public async Task<IActionResult> Details(int id)
        {
            var machine = await _apiService.GetByIdAsync(id);
            if (machine == null) return NotFound();
            return View(machine);
        }

        // GET: MachinesController/Create
        public ActionResult CreateMachine()
        {
            return View();
        }


        // POST: MachinesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Machine machine)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _apiService.CreateAsync(machine);
            if (response.IsSuccessStatusCode)
                return Ok();

            return BadRequest();
        }

        public IActionResult CreateMachinePartial()
        {
            return PartialView("CreateMachine", new Machine());
        }

        // POST: Machines1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(Machine machine)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var response = await _apiService.CreateAsync(machine);
        //    if (response.IsSuccessStatusCode)
        //        return Ok();

        //    return BadRequest();
        //}

        // GET: MachinesController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var machine = await _apiService.GetByIdAsync(id);
            if (machine == null)
                return NotFound();
            return View(machine);
        }

        // POST: MachinesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Machine machine)
        {
            if (id != machine.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(machine);

            var response = await _apiService.UpdateAsync(id, machine);
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Machines));

            ModelState.AddModelError("", "No se pudo actualizar la máquina.");
            return View(machine);
        }

        // GET: MachinesController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var machine = await _apiService.GetByIdAsync(id);
            if (machine == null)
                return NotFound();
            return View(machine);
        }

        // POST: MachinesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _apiService.DeleteAsync(id);
            if (response.IsSuccessStatusCode)
                return Ok();
            return BadRequest();
        }
    }
}
