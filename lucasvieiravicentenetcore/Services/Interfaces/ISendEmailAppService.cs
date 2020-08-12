using lucasvieiravicentenetcore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lucasvieiravicentenetcore.Services.Interfaces
{
    public interface ISendEmailAppService
    {
        void SendEmail(EmailViewModel email);
    }
}
