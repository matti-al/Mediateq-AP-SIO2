using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Mediateq_AP_SIO2.StartupOwin))]

namespace Mediateq_AP_SIO2
{
    public partial class StartupOwin
    {
        public void Configuration(IAppBuilder app)
        {
            //AuthStartup.ConfigureAuth(app);
        }
    }
}
