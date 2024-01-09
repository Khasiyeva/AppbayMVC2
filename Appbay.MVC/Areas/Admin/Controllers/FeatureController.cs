using Appbay.Business.ViewModels;
using Appbay.Core.Models;
using Appbay.DAL.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Appbay.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeatureController : Controller
    {
        private readonly AppDbContext _context;

        public FeatureController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Feature> feature = _context.Features.ToList();
            return View(feature);
        }
        
        public async Task<IActionResult> Create()
        {
           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Feature feature)
        {
            await _context.AddAsync(feature);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            Feature feature = _context.Features.Find(id);

            UpdateFeature updateFeature = new UpdateFeature() 
            { 
                Description =feature.Description,
                Title =feature.Title,
                Icon =feature.Icon
            };

            return View(updateFeature);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id,UpdateFeature updateFeature)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Feature oldFeature = _context.Features.Find(updateFeature.Id);
            oldFeature.Description=updateFeature.Description;
            oldFeature.Title=updateFeature.Title;
            oldFeature.Icon=updateFeature.Icon;

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Feature feature = _context.Features.Find(id);
            _context.Features.Remove(feature);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
