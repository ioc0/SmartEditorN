using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartEditorNew
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            tabControl1.TabPages.Add(SmartTabPage(""));
        }

        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("New Item");
        }
    }
}
