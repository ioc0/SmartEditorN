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
            
            foreach (var theme in TextEditorTheme.DefaultThemes)
            {
                var item = new ToolStripMenuItem { Text = theme.Key };
                
                tsmiThemes.DropDownItems.Add(item);
                item.Click += (sender, args) => {
                    _currentTheme = theme.Value;
                    ApplyCurrentTheme();

                };
            }
            
        }
        //Theme applayer method
        private void ApplyCurrentTheme()
        {
            foreach (var tab in tabControl1.TabPages.OfType<SmartTabPage>()) {
                _currentTheme.ApplyTo(tab);
            }
        }
        //new Empty Tag
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Add(new SmartTabPage("", _currentTheme));
        }
        //
        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                DefaultExt = "*.*",
                Filter = @"All Files|*.*"
            };
            // Create a OpenFileDialog to request a path and file name to save to.
            ofd.ShowDialog();

            var fteTabPage = tabControl1.SelectedTab as SmartTabPage;

            if (fteTabPage == null)
            {
                return;
            }

            if (fteTabPage.FileName.Length == 0 && !fteTabPage.IsChanged)
            {
                fteTabPage.Open(ofd.FileName);
            }
            else
            {
                tabControl1.TabPages.Add(new SmartTabPage(ofd.FileName, _currentTheme));
                tabControl1.SelectedIndex = tabControl1.TabCount - 1;
            }
        }
    }
}
