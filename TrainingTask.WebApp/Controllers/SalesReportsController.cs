using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TrainingTask.WebApp.Common.Mapping;
using TrainingTask.WebApp.Common.Models;
using TrainingTask.WebApp.Data;
using TrainingTask.WebApp.DTOs;
using TrainingTask.WebApp.Entities;
using TrainingTask.WebApp.Models.SalesReports;

namespace TrainingTask.WebApp.Controllers
{
    public class SalesReportsController : Controller
    {
        #region fields
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        #endregion

        #region ctor
        public SalesReportsController(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion

        #region actions
        public IActionResult Index()
        {
            return View();
        }
        #endregion

        #region ajax
        [HttpGet]
        public async Task<ActionResult<PaginatedList<SalesReportDTO>>> Get([Required] int page, [Required] int size,SalesReportViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return await _context.Invoices.Where(i => i.Date > model.From && i.Date < model.To).PaginateWithProjectionAsync<Invoice, SalesReportDTO>(_mapper, page, size);
        }
        #endregion
    }
}
