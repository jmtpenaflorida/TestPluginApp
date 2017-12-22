using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestPlugin;

namespace TestPluginApp.C
{
    public partial class Form1 : BasePlugin
    {
        private IPluginCBusinessLogic PluginLogic { get; set; }

        public Form1()
        {
            InitializeComponent();

            PluginLogic = new PluginsLogicFactory().CreateInstance<IPluginCBusinessLogic>(new PluginsLogicDictionary("PluginsLogic"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
           MessageBox.Show(PluginLogic.Output());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            PluginLogic.Input(textBox1.Text);
        }
    }

    public class PluginsLogicDictionary
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

    public class PluginsLogicFactory
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
