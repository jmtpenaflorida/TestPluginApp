using System;
using System.ComponentModel;
using System.Drawing;
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
}
