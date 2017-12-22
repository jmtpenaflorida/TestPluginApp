using System;
using System.Data;
using System.Linq;

namespace TestPluginApp.C
{
    internal class PluginsLogicFactory
    {
        public T CreateInstance<T>(PluginsLogicDictionary pluginsLogicDictionary)
        {
            Type type = Type.GetType(((from pluginLogic in pluginsLogicDictionary.PluginsLogic
                                       where pluginLogic.Key == typeof(T).Name
                                       select pluginLogic).First().Value));

            if (type.GetInterface(typeof(T).Name) == null)
                throw new Exception("Not implementing valid interface");

            return (dynamic) Activator.CreateInstance(type);
        }
    }
}
