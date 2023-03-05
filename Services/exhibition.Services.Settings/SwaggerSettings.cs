using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exhibition.Services.Settings
{
    public class SwaggerSettings
    {
        public bool Enabled { get; private set; }



        public SwaggerSettings()
        {
            Enabled = false;
        }
    }
}
