using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastColoredTextBoxNS;

namespace SmartEditorNew
{
    class TextEditorTheme
    {
        public string Name { get; set; }
        public Color BackgroundColor { get; set; }
        public Color ForegroundColor { get; set; }
        public TextStyle DefaultStyle { get; set; } //All
        public TextStyle AttributeStyle { get; set; } //HTML
        public TextStyle AttributeValueStyle { get; set; } //HTML
        public TextStyle CommentStyle { get; set; } //All
        public TextStyle HtmlEntityStyle { get; set; } //HTML: &nbsp; etc
        public TextStyle KeywordStyle { get; set; } //JS, PHP
        public TextStyle KeywordStyle2 { get; set; } //PHP
        public TextStyle KeywordStyle3 { get; set; } //PHP
        public TextStyle NumberStyle { get; set; } //JS, PHP
        public TextStyle StringStyle { get; set; } //JS, PHP
        public TextStyle TagBracketStyle { get; set; } //HTML
        public TextStyle TagNameStyle { get; set; } //HTML
        public TextStyle VariableStyle { get; set; } //JS, PHP


        public TextStyle[] Styles => new TextStyle[] { DefaultStyle, AttributeStyle,
            AttributeValueStyle, CommentStyle,
            HtmlEntityStyle, KeywordStyle, KeywordStyle2,
            KeywordStyle3, NumberStyle, StringStyle, TagBracketStyle,
            TagNameStyle, VariableStyle };
        public static Dictionary<string, TextEditorTheme> DefaultThemes = new Dictionary<string, TextEditorTheme> {
            {"Default", new TextEditorTheme {
                BackgroundColor = Color.White,
                ForegroundColor = ColorTranslator.FromHtml("#000080"),
                DefaultStyle = new TextStyle(new SolidBrush(ColorTranslator.FromHtml("#000080")), new SolidBrush(Color.White), FontStyle.Regular),
                AttributeStyle = new TextStyle(new SolidBrush(ColorTranslator.FromHtml("#885d3b")), new SolidBrush(Color.White), FontStyle.Regular),
                AttributeValueStyle = new TextStyle(new SolidBrush(ColorTranslator.FromHtml("#808080")), new SolidBrush(Color.White), FontStyle.Regular),
                CommentStyle = new TextStyle(new SolidBrush(ColorTranslator.FromHtml("#008000")), new SolidBrush(Color.White), FontStyle.Regular),
                HtmlEntityStyle = new TextStyle(new SolidBrush(ColorTranslator.FromHtml("#FF8000")), new SolidBrush(Color.White), FontStyle.Regular),
                KeywordStyle = new TextStyle(new SolidBrush(ColorTranslator.FromHtml("#0000FF")), new SolidBrush(Color.White), FontStyle.Regular),
                KeywordStyle2 = new TextStyle(new SolidBrush(ColorTranslator.FromHtml("#0000FF")), new SolidBrush(Color.White), FontStyle.Regular),
                KeywordStyle3 = new TextStyle(new SolidBrush(ColorTranslator.FromHtml("#0000FF")), new SolidBrush(Color.White), FontStyle.Regular),
                NumberStyle = new TextStyle(new SolidBrush(ColorTranslator.FromHtml("#FF8000")), new SolidBrush(Color.White), FontStyle.Regular),
                StringStyle = new TextStyle(new SolidBrush(ColorTranslator.FromHtml("#808080")), new SolidBrush(Color.White), FontStyle.Regular),
                TagBracketStyle = new TextStyle(new SolidBrush(ColorTranslator.FromHtml("#8000FF")), new SolidBrush(Color.White), FontStyle.Regular),
                TagNameStyle = new TextStyle(new SolidBrush(ColorTranslator.FromHtml("#0000FF")), new SolidBrush(Color.White), FontStyle.Regular),
                VariableStyle = new TextStyle(new SolidBrush(ColorTranslator.FromHtml("#000080")), new SolidBrush(Color.White), FontStyle.Regular),
            } },
            {"Night Sky", new TextEditorTheme {
                BackgroundColor = ColorTranslator.FromHtml("#272822"),
                ForegroundColor = ColorTranslator.FromHtml("#CFBFAD"),
                DefaultStyle = new TextStyle(new SolidBrush(ColorTranslator.FromHtml("#CFBFAD")), new SolidBrush(ColorTranslator.FromHtml("#272822")), FontStyle.Regular),
                AttributeStyle = new TextStyle(new SolidBrush(ColorTranslator.FromHtml("#BFA4A4")), new SolidBrush(ColorTranslator.FromHtml("#272822")), FontStyle.Regular),
                AttributeValueStyle = new TextStyle(new SolidBrush(ColorTranslator.FromHtml("#ECE47E")), new SolidBrush(ColorTranslator.FromHtml("#272822")), FontStyle.Regular),
                CommentStyle = new TextStyle(new SolidBrush(ColorTranslator.FromHtml("#8A826B")), new SolidBrush(ColorTranslator.FromHtml("#272822")), FontStyle.Regular),
                HtmlEntityStyle = new TextStyle(new SolidBrush(ColorTranslator.FromHtml("#C48CFF")), new SolidBrush(ColorTranslator.FromHtml("#272822")), FontStyle.Regular),
                KeywordStyle = new TextStyle(new SolidBrush(ColorTranslator.FromHtml("#FF007F")), new SolidBrush(ColorTranslator.FromHtml("#272822")), FontStyle.Regular),
                KeywordStyle2 = new TextStyle(new SolidBrush(ColorTranslator.FromHtml("#FF007F")), new SolidBrush(ColorTranslator.FromHtml("#272822")), FontStyle.Regular),
                KeywordStyle3 = new TextStyle(new SolidBrush(ColorTranslator.FromHtml("#FF007F")), new SolidBrush(ColorTranslator.FromHtml("#272822")), FontStyle.Regular),
                NumberStyle = new TextStyle(new SolidBrush(ColorTranslator.FromHtml("#C48CFF")), new SolidBrush(ColorTranslator.FromHtml("#272822")), FontStyle.Regular),
                StringStyle = new TextStyle(new SolidBrush(ColorTranslator.FromHtml("#ECE47E")), new SolidBrush(ColorTranslator.FromHtml("#272822")), FontStyle.Regular),
                TagBracketStyle = new TextStyle(new SolidBrush(ColorTranslator.FromHtml("#F9FAF4")), new SolidBrush(ColorTranslator.FromHtml("#272822")), FontStyle.Regular),
                TagNameStyle = new TextStyle(new SolidBrush(ColorTranslator.FromHtml("#FF007F")), new SolidBrush(ColorTranslator.FromHtml("#272822")), FontStyle.Regular),
                VariableStyle = new TextStyle(new SolidBrush(ColorTranslator.FromHtml("#CFBFAD")), new SolidBrush(ColorTranslator.FromHtml("#272822")), FontStyle.Regular),
            } },
            {"Deep Space", new TextEditorTheme {
                BackgroundColor = ColorTranslator.FromHtml("#1E1E1E"),
                ForegroundColor = ColorTranslator.FromHtml("#DCDCDC"),
                DefaultStyle = new TextStyle(new SolidBrush(ColorTranslator.FromHtml("#DCDCDC")), new SolidBrush(ColorTranslator.FromHtml("#1E1E1E")), FontStyle.Regular),
                AttributeStyle = new TextStyle(new SolidBrush(ColorTranslator.FromHtml("#DCDCDC")), new SolidBrush(ColorTranslator.FromHtml("#1E1E1E")), FontStyle.Regular),
                AttributeValueStyle = new TextStyle(new SolidBrush(ColorTranslator.FromHtml("#D69D85")), new SolidBrush(ColorTranslator.FromHtml("#1E1E1E")), FontStyle.Regular),
                CommentStyle = new TextStyle(new SolidBrush(ColorTranslator.FromHtml("#57A64A")), new SolidBrush(ColorTranslator.FromHtml("#1E1E1E")), FontStyle.Regular),
                HtmlEntityStyle = new TextStyle(new SolidBrush(ColorTranslator.FromHtml("#B5CEA8")), new SolidBrush(ColorTranslator.FromHtml("#1E1E1E")), FontStyle.Bold),
                KeywordStyle = new TextStyle(new SolidBrush(ColorTranslator.FromHtml("#569CD6")), new SolidBrush(ColorTranslator.FromHtml("#1E1E1E")), FontStyle.Bold),
                KeywordStyle2 = new TextStyle(new SolidBrush(ColorTranslator.FromHtml("#569CD6")), new SolidBrush(ColorTranslator.FromHtml("#1E1E1E")), FontStyle.Bold),
                KeywordStyle3 = new TextStyle(new SolidBrush(ColorTranslator.FromHtml("#569CD6")), new SolidBrush(ColorTranslator.FromHtml("#1E1E1E")), FontStyle.Bold),
                NumberStyle = new TextStyle(new SolidBrush(ColorTranslator.FromHtml("#B5CEA8")), new SolidBrush(ColorTranslator.FromHtml("#1E1E1E")), FontStyle.Bold),
                StringStyle = new TextStyle(new SolidBrush(ColorTranslator.FromHtml("#D69D85")), new SolidBrush(ColorTranslator.FromHtml("#1E1E1E")), FontStyle.Regular),
                TagBracketStyle = new TextStyle(new SolidBrush(ColorTranslator.FromHtml("#FFFFFF")), new SolidBrush(ColorTranslator.FromHtml("#1E1E1E")), FontStyle.Regular),
                TagNameStyle = new TextStyle(new SolidBrush(ColorTranslator.FromHtml("#569CD6")), new SolidBrush(ColorTranslator.FromHtml("#1E1E1E")), FontStyle.Bold),
                VariableStyle = new TextStyle(new SolidBrush(ColorTranslator.FromHtml("#C8C8C8")), new SolidBrush(ColorTranslator.FromHtml("#1E1E1E")), FontStyle.Regular),
            } },
            {"Zenburn", new TextEditorTheme {
                BackgroundColor = ColorTranslator.FromHtml("#404040"),
                ForegroundColor = ColorTranslator.FromHtml("#F6F3E8"),
                DefaultStyle = new TextStyle(new SolidBrush(ColorTranslator.FromHtml("#F6F3E8")), new SolidBrush(ColorTranslator.FromHtml("#404040")), FontStyle.Regular),
                AttributeStyle = new TextStyle(new SolidBrush(ColorTranslator.FromHtml("#F6F3E8")), new SolidBrush(ColorTranslator.FromHtml("#404040")), FontStyle.Regular),
                AttributeValueStyle = new TextStyle(new SolidBrush(ColorTranslator.FromHtml("#CC9393")), new SolidBrush(ColorTranslator.FromHtml("#404040")), FontStyle.Regular),
                CommentStyle = new TextStyle(new SolidBrush(ColorTranslator.FromHtml("#B3B5AF")), new SolidBrush(ColorTranslator.FromHtml("#404040")), FontStyle.Regular),
                HtmlEntityStyle = new TextStyle(new SolidBrush(ColorTranslator.FromHtml("#8ACCCF")), new SolidBrush(ColorTranslator.FromHtml("#404040")), FontStyle.Regular),
                KeywordStyle = new TextStyle(new SolidBrush(ColorTranslator.FromHtml("#EFEFAF")), new SolidBrush(ColorTranslator.FromHtml("#404040")), FontStyle.Regular),
                KeywordStyle2 = new TextStyle(new SolidBrush(ColorTranslator.FromHtml("#EFEFAF")), new SolidBrush(ColorTranslator.FromHtml("#404040")), FontStyle.Regular),
                KeywordStyle3 = new TextStyle(new SolidBrush(ColorTranslator.FromHtml("#EFEFAF")), new SolidBrush(ColorTranslator.FromHtml("#404040")), FontStyle.Regular),
                NumberStyle = new TextStyle(new SolidBrush(ColorTranslator.FromHtml("#8ACCCF")), new SolidBrush(ColorTranslator.FromHtml("#404040")), FontStyle.Regular),
                StringStyle = new TextStyle(new SolidBrush(ColorTranslator.FromHtml("#CC9393")), new SolidBrush(ColorTranslator.FromHtml("#404040")), FontStyle.Regular),
                TagBracketStyle = new TextStyle(new SolidBrush(ColorTranslator.FromHtml("#FFFFFF")), new SolidBrush(ColorTranslator.FromHtml("#404040")), FontStyle.Regular),
                TagNameStyle = new TextStyle(new SolidBrush(ColorTranslator.FromHtml("#EFEFAF")), new SolidBrush(ColorTranslator.FromHtml("#404040")), FontStyle.Regular),
                VariableStyle = new TextStyle(new SolidBrush(ColorTranslator.FromHtml("#D4C4A9")), new SolidBrush(ColorTranslator.FromHtml("#404040")), FontStyle.Regular),
            } },
        };

        public void ApplyTo(FastColoredTextBox textBox)
        {
            textBox.ClearStylesBuffer();
            textBox.BackColor = BackgroundColor;
            textBox.ForeColor = ForegroundColor;
            textBox.DefaultStyle = DefaultStyle;
            textBox.SyntaxHighlighter.AttributeStyle = AttributeStyle;
            textBox.SyntaxHighlighter.AttributeValueStyle = AttributeValueStyle;
            textBox.SyntaxHighlighter.CommentStyle = CommentStyle;
            textBox.SyntaxHighlighter.HtmlEntityStyle = HtmlEntityStyle;
            textBox.SyntaxHighlighter.KeywordStyle = KeywordStyle;
            textBox.SyntaxHighlighter.KeywordStyle2 = KeywordStyle2;
            textBox.SyntaxHighlighter.KeywordStyle3 = KeywordStyle3;
            textBox.SyntaxHighlighter.NumberStyle = NumberStyle;
            textBox.SyntaxHighlighter.StringStyle = StringStyle;
            textBox.SyntaxHighlighter.TagBracketStyle = TagBracketStyle;
            textBox.SyntaxHighlighter.TagNameStyle = TagNameStyle;
            textBox.SyntaxHighlighter.VariableStyle = VariableStyle;
        }

        public void ApplyTo(SmartTabPage tab)
        {
            if (tab == null)
            {
                return;
            }

            tab.SetCurrentTheme(this);
            ApplyTo(tab.TextBox);
            tab.HighlightText();
        }

    }
}
