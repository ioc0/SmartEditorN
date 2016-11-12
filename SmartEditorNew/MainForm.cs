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
        private TextEditorTheme _currentTheme = TextEditorTheme.DefaultThemes["Default"];
        public MainForm()
        {
            InitializeComponent();
            tabControl1.TabPages.Add(new SmartTabPage("",_currentTheme));
        }

        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("New Item");
        }
    }
}
