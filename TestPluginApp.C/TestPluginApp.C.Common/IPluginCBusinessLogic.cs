using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPluginApp.C
{
    public interface IPluginCBusinessLogic
    {
        void Input(string text);

        string Output();
    }
}
