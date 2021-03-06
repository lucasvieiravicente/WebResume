﻿using System;
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
    [ResponseCache(CacheProfileName = "HomeCache")]
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISendEmailAppService _appService;

        public HomeController(ILogger<HomeController> logger, ISendEmailAppService appService)
        {
            _logger = logger;
            _appService = appService;
        }

        public IActionResult Index() => View(new EmailViewModel());

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View();        

        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]        
        public IActionResult SendEmail(EmailViewModel emailViewModel)
        {
            if (!ModelState.IsValid) return BadRequest(GetMessageErrors());             

            _appService.SendEmail(emailViewModel);            
            
            return Ok("E-mail enviado com sucesso!");
        }
    }
}
