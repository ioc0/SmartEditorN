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

        private void drawCross(object sender, DrawItemEventArgs e)
        {
            e.Graphics.DrawString("\u271A", e.Font, Brushes.Black, e.Bounds.Left + 3, e.Bounds.Top + 5);
            e.Graphics.DrawString("\u274C", e.Font, Brushes.Black, e.Bounds.Right - 18, e.Bounds.Top + 5);
            e.Graphics.DrawString(tabControl1.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + 15,
                e.Bounds.Top + 2);
            e.DrawFocusRectangle();
        }

        private void buttonsForTabs(object sender, MouseEventArgs e)
        {
            var i = tabControl1.SelectedIndex;
            var r = tabControl1.GetTabRect(i);
            //Getting the position of the "+" mark.
            var tab = tabControl1.SelectedTab as SmartTabPage;
            var newButton = new Rectangle(r.Left + 2, r.Top + 4, 9, 7);
            if (newButton.Contains(e.Location))
            {
                tabControl1.TabPages.Add(new SmartTabPage("", _currentTheme));
            }

            //getting the position of "x" mark.
            var closeButton = new Rectangle(r.Right - 16, r.Top + 4, 9, 7);

            if (closeButton.Contains(e.Location) && tab.TextBox.Text.Length != 0)
            {
                var dialogResult = MessageBox.Show(
                @"Would you like to Save changes",
                @"Confirm",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);


                if (dialogResult == DialogResult.Yes)
                {
                    saveTabPageToFile(tabControl1.SelectedTab);
                    tabControl1.TabPages.RemoveAt(i);

                }
                if (dialogResult == DialogResult.No)
                {
                    tabControl1.TabPages.RemoveAt(i);
                }

                if (dialogResult == DialogResult.Cancel && dialogResult == DialogResult.Abort)
                {
                    return;
                }

            }
            if (closeButton.Contains(e.Location) && tab.TextBox.Text.Length == 0)
            {
                tabControl1.TabPages.RemoveAt(i);
            }
        }

        private void saveTabPageToFile(TabPage selectedTab)
        {
            var sfd = new SaveFileDialog
            {

            };
            if (sfd.ShowDialog() == DialogResult.OK) {
                (selectedTab as SmartTabPage)?.SaveAs(sfd.FileName);

            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
