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
using TrainingTask.WebApp.Models.Items;

namespace TrainingTask.WebApp.Controllers
{
    public class ItemsController : Controller
    {
        #region fields
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        #endregion

        #region ctor
        public ItemsController(IApplicationDbContext context, IMapper mapper)
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
            var types = await _context.Types.Select(t => new SelectListItem { Value = t.Id.ToString(), Text = t.Name }).ToListAsync();
            var model = new AddItemViewModel
            {
                Types = types
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddItemViewModel model)
        {
            var success = "Item is Added Successfully";
            var error = "Failed To Add The Item,Please Try Again";
            var duplicationError = "Item Name Is Already Existed,Please Try Again With Dirfferent Name";

            if (ModelState.IsValid)
            {
                var isNameDuplicated = await _context.Items.AnyAsync(i => i.Name == model.Name);
                if (!isNameDuplicated)
                {
                    var item = _mapper.Map<Item>(model);

                    _context.Items.Add(item);
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

            model.Types = await _context.Types.Select(t => new SelectListItem { Value = t.Id.ToString(), Text = t.Name }).ToListAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await _context.Items.ProjectTo<ItemDetailsViewModel>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(m=>m.Id == id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _context.Items.ProjectTo<EditItemViewModel>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(i => i.Id == id);
            model.Types = await _context.Types.Select(t => new SelectListItem { Value = t.Id.ToString(), Text = t.Name }).ToListAsync();
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditItemViewModel model)
        {
            var success = "Item is Edited Successfully";
            var error = "Failed To Edit The Item,Please Try Again";
            var duplicationError = "Item Name Is Already Existed,Please Try Again With Dirfferent Name";

            if (ModelState.IsValid)
            {
                var isNameDuplicated = await _context.Items.AnyAsync(i => i.Name == model.Name && i.Id != model.Id);
                if (!isNameDuplicated)
                {
                    var item = _mapper.Map<Item>(model);

                    _context.Items.Update(item);
                    await _context.SaveChangesAsync();

                    TempData["success"] = success;
                    return RedirectToAction(nameof(Edit));
                }

                TempData["error"] = duplicationError;
                return RedirectToAction(nameof(Edit));
            }

            var errors = ModelState.Values.Select(v => v.Errors).Where(e => e.Count > 0);
            foreach (var subError in errors)
                ModelState.AddModelError(string.Empty, string.Join("\n", subError.Select(se => se.ErrorMessage)));

            TempData["error"] = error;

            model.Types = await _context.Types.Select(t => new SelectListItem { Value = t.Id.ToString(), Text = t.Name }).ToListAsync();
            return View(model);
        }
        #endregion

        #region ajax

        [HttpGet]
        public async Task<bool> IsItemNameValid(int? id, string name)
        {
            if (id == null)
                return !await _context.Items.AnyAsync(c => c.Name == name);

            return !await _context.Items.AnyAsync(c => c.Name == name && c.Id != id);
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedList<ItemDTO>>> Get([Required] int page, [Required] int size)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return await _context.Items.ProjectTo<ItemDTO>(_mapper.ConfigurationProvider).PaginateAsync(page, size);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var item = await _context.Items.FindAsync(id);

            if (item == null)
                return NotFound();

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();

            return Ok();
        }

        #endregion
    }
}
