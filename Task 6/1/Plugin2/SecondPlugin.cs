using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework;

namespace Plugin2
{
    public class SecondPlugin : IPlugin
    {
        public string Name { get; set; }

        public SecondPlugin()
        {
            this.Name = "I SecondPlugin";
        }
    }
}
