using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using TrainingTask.WebApp.Common.Mapping;
using TrainingTask.WebApp.Common.Models;
using TrainingTask.WebApp.Data;
using TrainingTask.WebApp.DTOs;
using TrainingTask.WebApp.Entities;
using TrainingTask.WebApp.Models.Units;

namespace TrainingTask.WebApp.Controllers
{
    public class UnitsController : Controller
    {
        #region fields
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        #endregion

        #region ctor
        public UnitsController(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion

        #region actions

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddUnitViewModel model)
        {
            var success = "Unit is Added Successfully";
            var error = "Failed To Add The Unit,Please Try Again";
            var duplicationError = "Unit Name Is Already Existed,Please Try Again With Dirfferent Name";

            if (ModelState.IsValid)
            {
                var isNameDuplicated = await _context.Companies.AnyAsync(c => c.Name == model.Name);
                if (!isNameDuplicated)
                {
                    var Unit = _mapper.Map<Unit>(model);

                    _context.Units.Add(Unit);
                    await _context.SaveChangesAsync();

                    TempData["success"] = success;
                    return RedirectToAction(nameof(Add));
                }

                TempData["error"] = duplicationError;
                return RedirectToAction(nameof(Add));
            }

            var errors = ModelState.Values.Select(v => v.Errors).Where(e => e.Count > 0);
            foreach (var subError in errors)
                ModelState.AddModelError(string.Empty, string.Join("\n", subError.Select(se => se.ErrorMessage)));

            TempData["error"] = error;

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await _context.Units.ProjectTo<UnitDetailsViewModel>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(c => c.Id == id);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _context.Units.ProjectTo<EditUnitViewModel>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(c => c.Id == id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUnitViewModel model)
        {
            var success = "Unit Is Updated Successfully";
            var error = "Failed To Update The Unit,Please Try Again";
            var duplicationError = "Unit Name Is Already Existed,Please Try Again With Dirfferent Name";

            if (ModelState.IsValid)
            {
                var isNameDuplicated = await _context.Units.AnyAsync(u => u.Name == model.Name && u.Id != model.Id);
                if (!isNameDuplicated)
                {
                    var unit = _mapper.Map<Unit>(model);

                    _context.Units.Update(unit);
                    await _context.SaveChangesAsync();

                    TempData["success"] = success;
                    return RedirectToAction(nameof(Edit));
                }

                TempData["error"] = duplicationError;
                return View();
            }

            var errors = ModelState.Values.Select(v => v.Errors).Where(e => e.Count > 0);
            foreach (var subError in errors)
                ModelState.AddModelError(string.Empty, string.Join("\n", subError.Select(se => se.ErrorMessage)));

            TempData["error"] = error;

            return View(model);
        }
        #endregion

        #region ajax

        [HttpGet]
        public async Task<bool> IsUnitNameValid(int? id, string name)
        {
            if (id == null)
                return !await _context.Units.AnyAsync(u => u.Name == name);

            return !await _context.Units.AnyAsync(u => u.Name == name && u.Id != id);
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedList<UnitDTO>>> Get([Required] int page, [Required] int size)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return await _context.Units.ProjectTo<UnitDTO>(_mapper.ConfigurationProvider).PaginateAsync(page, size);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var unit = await _context.Units.FindAsync(id);

            if (unit == null)
                return NotFound();

            _context.Units.Remove(unit);
            await _context.SaveChangesAsync();

            return Ok();
        }

        #endregion
    }
}
