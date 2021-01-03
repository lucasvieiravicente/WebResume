using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace lucasvieiravicentenetcore.Controllers
{
    public class BaseController : Controller
    {
        public string GetMessageErrors()
        {
            string message = "";

            ModelState.Values.ToList().ForEach(model =>
            {
                model.Errors.ToList().ForEach(error => 
                {
                    message += $"<li>{error.ErrorMessage}</li>";
                });
            });

            return message;
        }
    }
}
