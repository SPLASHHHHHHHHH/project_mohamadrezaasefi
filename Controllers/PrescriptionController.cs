using IdentitySample.Models;
using IdentitySample.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentitySample.Mvc.Controllers
{

    public class PrescriptionController : Controller
    {
        readonly ApplicationDbContext _applicationDbContext;
        public PrescriptionController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }




        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _applicationDbContext.Prescriptions.OrderByDescending(p => p.CreatedDate).ToListAsync();
            return View(result);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await Task.CompletedTask;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Prescription prescription)
        {
            await _applicationDbContext.Prescriptions.AddAsync(prescription);
            await _applicationDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(GetAll));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _applicationDbContext.Prescriptions.SingleAsync(p => p.Id == id);
            _applicationDbContext.Prescriptions.Remove(result);
            await _applicationDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(GetAll));
        }




        [HttpGet]
        public async Task<IActionResult> ShowOnly(string nationalCode)
        {
            var result = await _applicationDbContext.Prescriptions.Where(p => p.NationalCode == nationalCode).ToListAsync();
            return View(result.OrderByDescending(p => p.CreatedDate));
        }




    }
}
