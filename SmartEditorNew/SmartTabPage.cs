using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastColoredTextBoxNS;
using static System.String;

namespace SmartEditorNew
{
    class SmartTabPage : TabPage
    {
        private TextEditorTheme _currentTheme;

        private char[] autoCompleteBracketsList = {'(', ')', '{', '}', '[', ']', '"', '"', '\'', '\''};

        public char[] AutoCompleteBracketsList
        {
            get { return autoCompleteBracketsList; }
            set { autoCompleteBracketsList = value; }
        }

        private static int _lastNumber;
        private const string TabFormat = @"{0}{1}";
        private int CurrentNumber { get; }

        private string _fileName;

        public string FileName
        {
            get { return _fileName; }
            private set
            {
                _fileName = value.Trim();

                SetTabText();
            }
        }

        private void SetTabText()
        {
            if (_fileName.Length == 0)
            {

                //поправили текст
                Text = Format(TabFormat, (IsChanged) ? "*" : "...", "");
                //Text = Format(TabFormat, (IsChanged) ? "*" : "", "", CurrentNumber + " ");

                return;
            }

            var fileInfo = new FileInfo(_fileName);

            Text = Format(TabFormat, (IsChanged) ? "*" : "", fileInfo.Name);
        }
        private bool _isChanged;

        public bool IsChanged
        {
            get { return _isChanged; }
            private set
            {
                _isChanged = value;

                SetTabText();
            }
        }
        private readonly TableLayoutPanel _layout = new TableLayoutPanel();
        public FastColoredTextBox TextBox { get; } = new FastColoredTextBox();

        public SmartTabPage(string fileName, TextEditorTheme theme)
        {
            CurrentNumber = IncLastNumber();
            FileName = fileName;
            _currentTheme = theme;

            InitializeControl();

            if (FileName.Length != 0)
            {
                TextBox.OpenFile(FileName, Encoding.UTF8);
                IsChanged = false;
            }
        }
        public new event EventHandler<TextChangedEventArgs> TextChanged;

        private void InitializeControl()
        {
            Controls.Add(_layout);
            _layout.Controls.Add(TextBox);
            _layout.Dock = DockStyle.Fill;
            TextBox.AutoCompleteBracketsList = new[] { '(', ')', '{', '}', '[', ']', '\"', '\"', '\'', '\'' };
            TextBox.AutoCompleteBrackets = true;


            TextBox.AutoScrollMinSize = new Size(27, 14);
            TextBox.BackBrush = null;
            TextBox.BorderStyle = BorderStyle.FixedSingle;
            TextBox.CharHeight = 14;
            TextBox.CharWidth = 8;
            TextBox.Cursor = Cursors.IBeam;
            TextBox.DisabledColor = Color.FromArgb(100, 180, 180, 180);
            TextBox.Dock = DockStyle.Fill;
            TextBox.Font = new Font("Courier New", 9.75F);
            TextBox.ImeMode = ImeMode.On;
            TextBox.IsReplaceMode = false;
            TextBox.Location = new Point(2, 2);
            TextBox.Margin = new Padding(2);
            TextBox.Paddings = new Padding(0);
            TextBox.SelectionColor = Color.FromArgb(60, 0, 0, 255);
            TextBox.Size = new Size(408, 436);
            TextBox.TabIndex = 0;
            TextBox.Zoom = 100;
        }

        private static int IncLastNumber()
        {
            return Interlocked.Increment(ref _lastNumber);
        }
    }
}
