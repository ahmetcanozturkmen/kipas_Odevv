using Microsoft.AspNetCore.Mvc;
using kipas_Odev.Services;
using kipas_Odev.Models;

namespace kipas_Odev.Controllers
{
    public class PersonelController : Controller
    {
        private readonly IPersonelService _personelService;

        public PersonelController(IPersonelService personelService)
        {
            _personelService = personelService;
        }

        // LISTELEME + ARAMA
        public async Task<IActionResult> Index(string? search)
        {
            var list = await _personelService.GetAllAsync(search);
            return View(list);
        }
        // GET: /Personel/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View(new PersonelFormViewModel());
        }

        // POST: /Personel/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PersonelFormViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                var entity = new Personel
                {
                    Title = model.Title,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    BirthDate = model.BirthDate,
                    Position = model.Position,
                    HireDate = model.HireDate,
                    State = model.State,
                    Address = model.Address,
                    Notes = model.Notes
                };

                await _personelService.AddAsync(entity);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "An unexpected error occurred while saving.");
                return View(model);
            }
        }
        // GET: /Personel/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var entity = await _personelService.GetByIdAsync(id);
            if (entity == null)
                return NotFound();

            var model = new PersonelFormViewModel
            {
                Id = entity.Id,
                Title = entity.Title,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                BirthDate = entity.BirthDate,
                Position = entity.Position,
                HireDate = entity.HireDate,
                State = entity.State,
                Address = entity.Address,
                Notes = entity.Notes
            };

            return View(model);
        }

        // POST: /Personel/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PersonelFormViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                var entity = await _personelService.GetByIdAsync(model.Id);
                if (entity == null)
                    return NotFound();

                entity.Title = model.Title;
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.BirthDate = model.BirthDate;
                entity.Position = model.Position;
                entity.HireDate = model.HireDate;
                entity.State = model.State;
                entity.Address = model.Address;
                entity.Notes = model.Notes;

                await _personelService.UpdateAsync(entity);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "An unexpected error occurred while updating.");
                return View(model);
            }
        }
        // POST: /Personel/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _personelService.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                // İstersen TempData ile mesaj basarız, şimdilik basit kalsın
                return RedirectToAction(nameof(Index));
            }
        }

    }

}