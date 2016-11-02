using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework;

namespace Plugin1
{
    public class FirstPlugin : IPlugin
    {
        public string Name { set; get; }

        public FirstPlugin()
        {
            this.Name = "I FirstPlugin";
        }
    }
}
