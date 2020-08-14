using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using lucasvieiravicentenetcore.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using lucasvieiravicentenetcore.Services.Interfaces;

namespace lucasvieiravicentenetcore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISendEmailAppService _appService;

        public HomeController(ILogger<HomeController> logger, ISendEmailAppService appService)
        {
            _logger = logger;
            _appService = appService;
        }

        public IActionResult Index()
        {
            return View(new EmailViewModel());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public IActionResult SendEmail(EmailViewModel emailViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = new Tuple<string, string>("Verifique os campos!", "alert alert-danger");
                return View(nameof(Index));
            }                

            _appService.SendEmail(emailViewModel);

            ViewBag.Message = new Tuple<string, string>("E-mail enviado com sucesso!", "alert alert-success");
            return View(nameof(Index));
        }
    }
}
