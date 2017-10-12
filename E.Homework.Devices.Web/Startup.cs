using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E.Homework.Devices.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}