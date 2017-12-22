using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPluginApp.C
{
    internal class PluginCBusinessLogic : IPluginCBusinessLogic
    {
        private string value;

        public void Input(string text)
        {
            value = text;
        }

        public string Output()
        {
            return "This came from Plugin C Business Logic: " + value;
        }
    }
}
