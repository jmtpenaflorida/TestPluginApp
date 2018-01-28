using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPluginApp.C
{
    
    internal class NewPluginCBusinessLogic : IPluginCBusinessLogic
    {
        private string value;

        public void Input(string text)
        {
            value = text;
        }

        public string Output()
        {
            return "This came from the New Plugin C Business Logic: " + value + ": From New Plugin";
        }
    }
}
