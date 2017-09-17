using System.Threading.Tasks;
using Identity.ServicesLibrary;
using Microsoft.AspNet.Identity;

namespace Identity.IdentityLibrary
{
    public class MyEmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            SendEmail(message as MyIdentityMessage);
            return Task.FromResult(0);
        }

        public void SendEmail(MyIdentityMessage message)
        {
            new SendEmailService(message.Destination, message.Subject, message.Body).SendEmail();
        }
    }
}
