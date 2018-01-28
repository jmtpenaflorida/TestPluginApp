using System;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestPlugin;

namespace TestPluginApp.C
{
    public partial class Form1 : BasePlugin
    {
        [Import(typeof(IPluginCBusinessLogic))]
        private IPluginCBusinessLogic PluginLogic { get; set; }

        public Form1()
        {
            InitializeComponent();

            AssemblyCatalog catalog = new AssemblyCatalog(GetType().Assembly);
            CompositionContainer container = new CompositionContainer(catalog);
            container.ComposeParts(this);
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
