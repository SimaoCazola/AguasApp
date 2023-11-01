using AguasApp.Data.Entities;

namespace AguasApp.Helpers
{
    public interface IMailHelper
    {
        Response SendEmail(string to, string subject, string body);
       
    }
}
