using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.Homework.Devices.Business
{
   public class Settings
    {
        public string ConnectionString { get; set; }
        public string HubName { get; set; }
        public string PublishMethodName { get; set; }


        public Settings()
        {
            
        }
    }
}
