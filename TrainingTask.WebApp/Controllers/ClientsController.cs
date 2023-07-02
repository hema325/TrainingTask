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
using TrainingTask.WebApp.Models.Clients;

namespace TrainingTask.WebApp.Controllers
{
    public class ClientsController : Controller
    {
        #region fields
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        #endregion

        #region ctor
        public ClientsController(IApplicationDbContext context, IMapper mapper)
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
        public async Task<IActionResult> Add(AddClientViewModel model)
        {
            var success = "Client is Added Successfully";
            var error = "Failed To Add The Client,Please Try Again";
            var duplicationError = "Client Name Is Already Existed,Please Try Again With Dirfferent Name";

            if (ModelState.IsValid)
            {
                var isNameDuplicated = await _context.Clients.AnyAsync(c => c.Name == model.Name);
                if (!isNameDuplicated)
                {
                    var client = _mapper.Map<Client>(model);

                    _context.Clients.Add(client);
                    await _context.SaveChangesAsync();

                    TempData["success"] = success;
                    return RedirectToAction(nameof(Add));
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

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await _context.Clients.ProjectTo<ClientDetailsViewModel>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(c => c.Id == id);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _context.Clients.ProjectTo<EditClientViewModel>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(c => c.Id == id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditClientViewModel model)
        {
            var success = "Client is Updated Successfully";
            var error = "Failed To Update The Client,Please Try Again";
            var duplicationError = "Client Name Is Already Existed,Please Try Again With Dirfferent Name";

            if (ModelState.IsValid)
            {
                var isNameDuplicated = await _context.Clients.AnyAsync(c => c.Name == model.Name && c.Id != model.Id);
                if (!isNameDuplicated)
                {
                    var client = _mapper.Map<Client>(model);

                    _context.Clients.Update(client);
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
        public async Task<bool> IsClientNameValid(int? id, string name)
        {
            if (id == null)
                return !await _context.Clients.AnyAsync(c => c.Name == name);

            return !await _context.Clients.AnyAsync(c => c.Name == name && c.Id != id);
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedList<ClientDTO>>> Get([Required] int page, [Required] int size)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return await _context.Clients.PaginateWithProjectionAsync<Client, ClientDTO>(_mapper, page, size);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var client = await _context.Clients.FindAsync(id);

            if (client == null)
                return NotFound();

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            return Ok();
        }

        #endregion
    }
}
