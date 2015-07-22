using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GuestBook.Startup))]
namespace GuestBook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
