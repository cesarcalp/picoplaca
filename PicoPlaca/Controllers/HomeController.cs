using Microsoft.AspNetCore.Mvc;
using PicoPlaca.Domain;
using PicoPlaca.Transversal;
using PicoPlaca.ViewModel;
using System;

namespace PicoPlaca.Controllers
{
    public class HomeController : Controller
    {
        private IPredictorManagementService _verifierManagementService;
        public HomeController(IPredictorManagementService verifierManagementService)
        {
            _verifierManagementService = verifierManagementService;
        }
        public IActionResult Index()
        {
            ViewBag.DisplayMessage = "none";
            var model = new VerificatorViewModel
            {
                Date = DateTimeExtensions.Now(),
                Time = DateTimeExtensions.Now().TimeOfDay
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(VerificatorViewModel model)
        {
            ViewBag.DisplayMessage = "none";
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Data no valid");
                return View(model);
            }
            try
            {
                var service = _verifierManagementService.ValidatePicoPlaca(new Models.PicoPlacaParam
                {
                    PlateNumber = model.PlateNumber,
                    Date = model.Date.ToString(CustomFormatProvider.ShortDatePattern),
                    Time = model.Time.ToString()
                });
                if (service.AllowedToRoad)
                {
                    ViewBag.Message = "You are allowed to road!";
                    ViewBag.MessageType = "alert-success";
                }
                else
                {
                    ViewBag.Message = "You are not allowed to road";
                    ViewBag.MessageType = "alert-warning";
                }
                ViewBag.DisplayMessage = "block";
            }
            catch(Exception e)
            {
                ModelState.AddModelError("", e.Message);
            }
            return View(model);
        }
        
        public IActionResult Error()
        {
            return View();
        }
    }
}
