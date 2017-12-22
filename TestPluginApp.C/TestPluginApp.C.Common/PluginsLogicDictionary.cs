using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;

namespace TestPluginApp.C
{
    internal class PluginsLogicDictionary
    {
        public Dictionary<string, string> PluginsLogic { get; set; }

        public PluginsLogicDictionary(string section)
        {
            PluginsLogic = new Dictionary<string, string>();

            var pluginsLogic = ConfigurationManager.GetSection(section) as NameValueCollection;
            if (pluginsLogic != null)
            {
                foreach (string pluginsLogicKey in pluginsLogic.AllKeys)
                {
                    PluginsLogic.Add(pluginsLogicKey, pluginsLogic[pluginsLogicKey]);
                }
            }
        }
    }
}
