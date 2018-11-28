using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParkFinder.Models;
using ParkFinder.Factory;
namespace ParkFinder.Controllers
{
    public class HomeController : Controller
    {
        private readonly TrailFactory _trailFactory;

        public HomeController(TrailFactory tFactory)
        {
            _trailFactory=tFactory;
        }

        [HttpGet("")]
        [HttpGet("home")]
        public IActionResult Index()
        {
            var trails= _trailFactory.FindAllTrail();
            return View("Index",trails);
        }




        [HttpGet("trail/{id}")]
        public IActionResult Trail(int id)
        {
           var trail=_trailFactory.FindById(id);
            if (trail==null)
            {
                return RedirectToAction("Index");   
            }
            return View("trail",trail);
        }



        [HttpPost("addtrailProccess")]
        public IActionResult AddTrail(Trail newTrail)
        {
            if (ModelState.IsValid)
            {
                _trailFactory.AddTrail(newTrail);
                return RedirectToAction("Index");
            }
            
   
            return View("newTrailForm");
         
        }

        [HttpGet("newTrail")]
        public IActionResult NewTrail()
        {
            return View("newTrailForm");
         
        }

    }
}
