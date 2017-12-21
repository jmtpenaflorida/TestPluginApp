using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Specialized;
using System.Reflection;
using System.IO;
using TestPlugin;

namespace TestPluginApp
{
    public partial class MainForm : Form
    {
       
        public MainForm()
        {
            InitializeComponent();

            var PluginDictionary = new PluginDictionary();

            foreach(var plugin in PluginDictionary.Plugins)
            {
                ToolStripMenuItem menuItem = new ToolStripMenuItem() { Text = plugin.Key, Tag = plugin.Value };
                mainMenu.Items.Add(menuItem);
            }
        }

        private void mainMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if ((e.ClickedItem.Tag == null) || (! File.Exists(e.ClickedItem.Tag.ToString())))
                return;

            BasePlugin plugin = new PluginFactory().CreatePlugin(e.ClickedItem.Tag.ToString());

            plugin.MdiParent = this;
            plugin.Show();            
        }
    }

    public class PluginDictionary
    {
        public Dictionary<string, string> Plugins { get; set;  }

        public PluginDictionary()
        {
            Plugins = new Dictionary<string, string>();

            var plugins = ConfigurationManager.GetSection("Plugins") as NameValueCollection;
            if (plugins != null)
            {
                foreach (string pluginsKey in plugins.AllKeys)
                {
                    Plugins.Add(pluginsKey, plugins[pluginsKey]);
                }
            }
        }
    }

    public class PluginFactory
    {
        public BasePlugin CreatePlugin(string assemblyFileName)
        {
            List<BasePlugin> plugins = new List<BasePlugin>();

            Assembly assembly = Assembly.LoadFile(assemblyFileName);

            BasePlugin plugin = Activator.CreateInstance((from type in assembly.GetTypes()
                                                          where type.BaseType == typeof(BasePlugin)
                                                          select type).First()) as BasePlugin;

            return plugin;
        }
    }
}
