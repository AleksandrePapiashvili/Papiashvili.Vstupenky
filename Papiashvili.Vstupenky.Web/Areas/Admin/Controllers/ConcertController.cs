using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Papiashvili.Vstupenky.Web.Vstupenky.Abstraction;
using Papiashvili.Vstupenky.Web.Vstupenky.Domain.Entites;
using Papiashvili.Vstupenky.Web.Vstupenky.Infrastrucure.Database;

namespace UTB.Eshop.Web.Areas.Admin.Controllers
{
    
    [Area("Admin")]
    
    public class ConcertController : Controller
    {
        IConcertAdminService _concertService;
        public ConcertController(IConcertAdminService concertService)
        {
            _concertService = concertService;
        }
        
        public IActionResult Index()
        {
            IList<Concert> concerts = _concertService.Select();
            return View(concerts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Concert concert)
        {
            _concertService.Create(concert);

            return RedirectToAction(nameof(ConcertController.Index));
        }


        public IActionResult Delete(int Id)
        {
            bool deleted = _concertService.Delete(Id);

            if (deleted)
            {
                return RedirectToAction(nameof(ConcertController.Index));
            }
            else
            {
                return NotFound();
            }
        }
    }
}
