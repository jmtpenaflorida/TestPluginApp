using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPluginApp.C
{
    [Export(typeof(IPluginCBusinessLogic))]
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
