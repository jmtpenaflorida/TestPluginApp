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

namespace TestPluginB
{
    public partial class Form1 : BasePlugin
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = (checkBox1.Checked ? Color.Green : Color.Blue);
        }
    }
}
