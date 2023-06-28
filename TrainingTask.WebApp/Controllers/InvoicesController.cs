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
using TrainingTask.WebApp.Models.Invoice;

namespace TrainingTask.WebApp.Controllers
{
    public class InvoicesController : Controller
    {
        #region fields
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        #endregion

        #region cros
        public InvoicesController(IApplicationDbContext context, IMapper mapper)
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
            var items = await _context.Items.Select(t => new SelectListItem { Value = t.Id.ToString(), Text = t.Name }).ToListAsync();
            var clients = await _context.Clients.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToListAsync();
            var model = new AddInvoiceViewModel
            {
                Items = items,
                Clients = clients
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddInvoiceViewModel model)
        {
            var success = "Invoice is Added Successfully";
            var error = "Failed To Add The Invoice,Please Try Again";

            if (ModelState.IsValid)
            {
                var invoice = _mapper.Map<Invoice>(model);

                _context.Invoices.Add(invoice);
                await _context.SaveChangesAsync();

                TempData["success"] = success;
                return RedirectToAction(nameof(Add));
            }

            var errors = ModelState.Values.Select(v => v.Errors).Where(e => e.Count > 0);
            foreach (var subError in errors)
                ModelState.AddModelError(string.Empty, string.Join("\n", subError.Select(se => se.ErrorMessage)));

            TempData["error"] = error;

            model.Items = await _context.Items.Select(t => new SelectListItem { Value = t.Id.ToString(), Text = t.Name }).ToListAsync();
            model.Clients = await _context.Clients.Select(t => new SelectListItem { Value = t.Id.ToString(), Text = t.Name }).ToListAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await _context.Invoices.ProjectTo<InvoiceDetailsViewModel>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(i => i.Id == id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _context.Invoices.ProjectTo<EditInvoiceViewModel>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(i => i.Id == id);
            model.Items = await _context.Items.Select(t => new SelectListItem { Value = t.Id.ToString(), Text = t.Name }).ToListAsync();
            model.Clients = await _context.Clients.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToListAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditInvoiceViewModel model)
        {
            var success = "Invoice is Edited Successfully";
            var error = "Failed To Edit The Invoice,Please Try Again";

            if (ModelState.IsValid)
            {
                var invoice = await _context.Invoices.FindAsync(model.Id);
                 invoice = _mapper.Map(model,invoice);

                _context.Invoices.Update(invoice);
                await _context.SaveChangesAsync();

                TempData["success"] = success;
                return RedirectToAction(nameof(Edit));
            }

            var errors = ModelState.Values.Select(v => v.Errors).Where(e => e.Count > 0);
            foreach (var subError in errors)
                ModelState.AddModelError(string.Empty, string.Join("\n", subError.Select(se => se.ErrorMessage)));

            TempData["error"] = error;

            model.Items = await _context.Items.Select(t => new SelectListItem { Value = t.Id.ToString(), Text = t.Name }).ToListAsync();
            model.Clients = await _context.Clients.Select(t => new SelectListItem { Value = t.Id.ToString(), Text = t.Name }).ToListAsync();
            return View(model);
        }
        #endregion

        #region ajax

        [HttpGet]
        public async Task<ActionResult<PaginatedList<InvoiceDTO>>> Get([Required] int page, [Required] int size)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return await _context.Invoices.PaginateWithProjectionAsync<Invoice,InvoiceDTO>(_mapper, page, size);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var invoice = await _context.Invoices.FindAsync(id);

            if (invoice == null)
                return NotFound();

            _context.Invoices.Remove(invoice);
            await _context.SaveChangesAsync();

            return Ok();
        }

        #endregion
    }
}
