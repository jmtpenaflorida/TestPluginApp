using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestPlugin;
using TestPluginApp.C.Common;
using TestPluginApp.C.BL;

namespace TestPluginApp.C
{
    public partial class Form1 : BasePlugin
    {
        private IPluginCBusinessLogic pluginLogic = new PluginCBusinessLogic();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           MessageBox.Show(pluginLogic.Output());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            pluginLogic.Input(textBox1.Text);
        }
    }
}
