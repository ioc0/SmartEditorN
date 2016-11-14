﻿using System;
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
            themeChanger.DropDownItems.Add(new ToolStripSeparator());
            foreach (var theme in TextEditorTheme.DefaultThemes)
            {
                var item = new ToolStripMenuItem { Text = theme.Key };
                item.Click += (sender, args) => {
                    _currentTheme = theme.Value;
                    ApplyCurrentTheme();

                };
            }
        }

        private void ApplyCurrentTheme()
        {
            foreach (var tab in tabControl1.TabPages.OfType<SmartTabPage>()) {
                _currentTheme.ApplyTo(tab);
            }
        }

        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("New Item");
        }
    }
}
