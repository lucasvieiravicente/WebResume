using lucasvieiravicentenetcore.Models;
using System.Threading.Tasks;

namespace lucasvieiravicentenetcore.Services.Interfaces
{
    public interface ISendEmailAppService
    {
        Task SendEmail(EmailViewModel email);
    }
}
