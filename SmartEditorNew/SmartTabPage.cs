using System;
using System.Collections.Generic;
using System.Drawing;
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
        private bool _trimmedTextInTheFrame;
        public bool TrimmedTextInTheFrame
        {
            private get { return _trimmedTextInTheFrame; }
            set { _trimmedTextInTheFrame = value;
                Invalidate();
            }
        }
        private Color _frameColor = Color.DarkRed;
        private readonly Pen _framePen = new Pen(Color.DarkRed);
        public Color FrameColor {
            get { return _frameColor; }
            set
            {
                _frameColor = value;
                _framePen.Color = Color.DarkRed;
                Invalidate();
            }
        }
        private class LineYComparer : IComparer<LineInfo>
        {
            private readonly int _y;
            public LineYComparer(int y)
            {

                this._y = y;
            }

        }



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

            TextBox.TextChanged += (sender, args) => {
                TextChanged?.Invoke(sender, args);
                IsChanged = true;

                
                HighlightText();
            };

            _currentTheme.ApplyTo(TextBox);
            HighlightText();
        }

        public void HighlightText()
        {
            TextBox.Range.ClearStyle(StyleIndex.All);
            TextBox.SyntaxHighlighter.HTMLSyntaxHighlight(TextBox.Range);
            TextBox.Range.ClearFoldingMarkers();

            //find PHP fragments
            foreach (var range in TextBox.GetRanges(@"<\?php.*?\?>", RegexOptions.Singleline))
            {
                foreach (var subRange in range.GetRanges(@"\?php.*?\?", RegexOptions.Singleline))
                {
                    //remove HTML highlighting from this fragment
                    subRange.ClearStyle(StyleIndex.All);
                    //do PHP highlighting
                    TextBox.SyntaxHighlighter.PHPSyntaxHighlight(range);
                    //TextBox.AutoCompleteBrackets = true;
                }
            }
        }


        private static int IncLastNumber()
        {
            return Interlocked.Increment(ref _lastNumber);
        }

        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        public void Save()
        {
            if (FileName.Length == 0)
            {
                return;
            }

            TextBox.SaveToFile(FileName, Encoding.UTF8);
            IsChanged = false;
        }

        public void SaveAs(string newFileName)
        {
            FileName = newFileName;
            if (FileName.Length == 0)
            {
                return;
            }

            TextBox.SaveToFile(FileName, Encoding.UTF8);
            IsChanged = false;
        }

        public void Open(string newFileName)
        {
            FileName = newFileName;
            if (FileName.Length == 0)
            {
                return;
            }

            TextBox.OpenFile(FileName, Encoding.UTF8);

            IsChanged = false;
        }

        public void Clear()
        {
            FileName = "";
            TextBox.Text = "";
            IsChanged = false;
        }

        public void SetCurrentTheme(TextEditorTheme theme)
        {
            _currentTheme = theme;
        }

    }
}
