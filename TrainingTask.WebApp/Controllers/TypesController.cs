using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using TrainingTask.WebApp.Common.Mapping;
using TrainingTask.WebApp.Common.Models;
using TrainingTask.WebApp.Data;
using TrainingTask.WebApp.DTOs;
using TrainingTask.WebApp.Entities;
using TrainingTask.WebApp.Models.Type;

namespace TrainingTask.WebApp.Controllers
{
    public class TypesController : Controller
    {
        #region fields
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        #endregion

        #region cros
        public TypesController(IApplicationDbContext context, IMapper mapper)
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
        public async Task<IActionResult> Add()
        {
            var companies = await _context.Companies.Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() }).ToListAsync();
            var model = new AddTypeViewModel
            {
                Companies = companies
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddTypeViewModel model)
        {
            var success = "Type is Added Successfully";
            var error = "Failed To Add The Type,Please Try Again";
            var duplicationError = "Type Name Is Already Existed,Please Try Again With Dirfferent Name";

            if (ModelState.IsValid)
            {
                var isNameDuplicated = await _context.Types.AnyAsync(c => c.Name == model.Name);
                if (!isNameDuplicated)
                {
                    var type = _mapper.Map<Entities.Type>(model);

                    _context.Types.Add(type);
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

            model.Companies = await _context.Companies.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToListAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await _context.Types.ProjectTo<TypeDetailsViewModel>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(t => t.Id == id);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _context.Types.ProjectTo<EditTypeViewModel>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(t => t.Id == id);
            model.Companies = await _context.Companies.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToListAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditTypeViewModel model)
        {
            var success = "Type is Edited Successfully";
            var error = "Failed To Edit The Type,Please Try Again";
            var duplicationError = "Type Name Is Already Existed,Please Try Again With Dirfferent Name";

            if (ModelState.IsValid)
            {
                var isNameDuplicated = await _context.Types.AnyAsync(c => c.Name == model.Name && c.Id != model.Id);
                if (!isNameDuplicated)
                {
                    var type = _mapper.Map<Entities.Type>(model);

                    _context.Types.Update(type);
                    await _context.SaveChangesAsync();

                    TempData["success"] = success;
                    return RedirectToAction(nameof(Edit));
                }

                TempData["error"] = duplicationError;
                return RedirectToAction(nameof(Edit));
            }

            var errors = ModelState.Values.Select(v => v.Errors).Where(e => e.Count > 0);
            foreach(var subError in errors)
                ModelState.AddModelError(string.Empty, string.Join("\n", subError.Select(se => se.ErrorMessage)));

            TempData["error"] = error;

            model.Companies = await _context.Companies.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToListAsync();
            return View(model);
        }

        #endregion

        #region ajax

        [HttpGet]
        public async Task<bool> IsTypeNameValid(int? id, string name)
        {
            if (id == null)
                return !await _context.Types.AnyAsync(c => c.Name == name);

            return !await _context.Types.AnyAsync(c => c.Name == name && c.Id != id);
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedList<TypeDTO>>> Get([Required]int page,[Required]int size)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return await _context.Types.PaginateWithProjectionAsync<Entities.Type, TypeDTO>(_mapper, page, size);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var company = await _context.Types.FindAsync(id);

            if (company == null)
                return NotFound();

            _context.Types.Remove(company);
            await _context.SaveChangesAsync();

            return Ok();
        }


        #endregion
    }
}
