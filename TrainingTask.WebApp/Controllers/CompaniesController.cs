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
using TrainingTask.WebApp.Models.Company;

namespace TrainingTask.WebApp.Controllers
{
    public class CompaniesController:Controller
    {
        #region fields
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        #endregion

        #region ctor
        public CompaniesController(IApplicationDbContext context,IMapper mapper)
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
        public async Task<IActionResult> Add(AddCompanyViewModel model)
        {
            var success = "Company is Added Successfully";
            var error = "Failed To Add The Company,Please Try Again";
            var duplicationError = "Company Name Is Already Existed,Please Try Again With Dirfferent Name";

            if (ModelState.IsValid)
            {
                var isNameDuplicated = await _context.Companies.AnyAsync(c => c.Name == model.Name);
                if (!isNameDuplicated)
                {
                    var company = _mapper.Map<Company>(model);

                    _context.Companies.Add(company);
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
            var model = await _context.Companies.ProjectTo<CompanyDetailsViewModel>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(c => c.Id == id);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _context.Companies.ProjectTo<EditCompanyViewModel>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(c => c.Id == id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditCompanyViewModel model)
        {
            var success = "Company Is Updated Successfully";
            var error = "Failed To Update The Company,Please Try Again";
            var duplicationError = "Company Name Is Already Existed,Please Try Again With Dirfferent Name";

            if (ModelState.IsValid)
            {
                var isNameDuplicated = await _context.Companies.AnyAsync(c => c.Name == model.Name && c.Id != model.Id);
                if (!isNameDuplicated)
                {
                    var company = _mapper.Map<Company>(model);

                    _context.Companies.Update(company);
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
        public async Task<bool> IsCompanyNameValid(int? id,string name)
        {
            if(id == null)
                return !await _context.Companies.AnyAsync(c => c.Name == name);

            return !await _context.Companies.AnyAsync(c => c.Name == name && c.Id != id);
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedList<CompanyDTO>>> Get([Required] int page,[Required] int size)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return await _context.Companies.PaginateWithProjectionAsync<Company,CompanyDTO>(_mapper, page, size);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var company = await _context.Companies.FindAsync(id);
            
            if (company == null)
                return NotFound();

            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();

            return Ok();
        }

        #endregion
    }
}
