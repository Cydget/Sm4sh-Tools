﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Sm4shCommand.Classes;

namespace Sm4shCommand
{
    /// <summary>
    /// Provides an extended RichTextBox with Intellisense like code completion and syntax highlighting.
    /// </summary>
    //class ITSCodeBox : RichTextBox
    //{
    //    #region Members
    //    private List<CommandInfo> commandDictionary;
    //    private ListBox AutocompleteBox;
    //    private ITSToolTip ITSToolTip;
    //    private TooltipDictionary EventDescriptions;
    //    private const int WM_USER = 0x0400;
    //    private const int EM_SETEVENTMASK = (WM_USER + 69);
    //    private const int WM_SETREDRAW = 0x0b;
    //    private IntPtr OldEventMask;
    //    #endregion

    //    #region External Methods
    //    [DllImport("user32")]
    //    private extern static int GetCaretPos(out Point p);
    //    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    //    private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
    //    #endregion

    //    #region Constructors

    //    public ITSCodeBox()
    //        : base()
    //    {
    //        AutocompleteBox = new ListBox();
    //        AutocompleteBox.Parent = this;
    //        AutocompleteBox.KeyUp += OnKeyUp;
    //        AutocompleteBox.Visible = false;
    //        ITSToolTip = new ITSToolTip();
    //        this.commandDictionary = new List<CommandInfo>();

    //        ITSToolTip.RichTextBox = this;
    //        EventDescriptions = new TooltipDictionary();
    //        ITSToolTip.Dictionary = EventDescriptions;
    //    }
    //    #endregion

    //    #region Properties
    //    /// <summary>
    //    /// The autocomplete dictionary.
    //    /// </summary>
    //    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    //    public List<CommandInfo> CommandDictionary
    //    {
    //        get { return this.commandDictionary; }
    //        set { this.commandDictionary = value; }
    //    }
    //    /// <summary>
    //    /// The autocomplete dictionary.
    //    /// </summary>
    //    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    //    public ITSToolTip Tooltip
    //    {
    //        get { return this.ITSToolTip; }
    //        set { this.ITSToolTip = value; }
    //    }
    //    /// <summary>
    //    /// The text of the current line.
    //    /// </summary>
    //    public string CurrentLineText
    //    {
    //        get
    //        {
    //            if (Lines.Length > 0)
    //                return Lines[CurrentLineIndex];
    //            else return "";
    //        }
    //    }
    //    /// <summary>
    //    /// The index of the current line.
    //    /// </summary>
    //    public int CurrentLineIndex
    //    {
    //        get
    //        {

    //            Point cp;
    //            GetCaretPos(out cp);
    //            return GetLineFromCharIndex(GetCharIndexFromPosition(cp));

    //        }
    //    }
    //    #endregion

    //    #region Methods
    //    private string FomatParams(string commandName)
    //    {
    //        string Param = "";
    //        foreach (CommandInfo c in commandDictionary)
    //            if (c.Name == commandName)
    //            {
    //                for (int i = 0; i < c.ParamSyntax.Count; i++)
    //                    Param += String.Format("{0}={1}", c.ParamSyntax[i], i + 1 != c.ParamSyntax.Count ? ", " : "");
    //                break;
    //            }
    //        return Param;
    //    }
    //    protected override void OnKeyDown(KeyEventArgs e)
    //    {
    //        if ((e.KeyCode == Keys.Enter | e.KeyCode == Keys.Down | e.KeyCode == Keys.Space) && AutocompleteBox.Visible == true)
    //        {
    //            AutocompleteBox.Focus();
    //            if (e.KeyCode == Keys.Down && !(AutocompleteBox.SelectedIndex >= AutocompleteBox.Items.Count))
    //                AutocompleteBox.SelectedIndex++;
    //            e.SuppressKeyPress = true;
    //            e.Handled = true;
    //        }
    //        else if (e.KeyCode == Keys.Escape | String.IsNullOrEmpty(CurrentLineText) && AutocompleteBox.Visible == true)
    //        {
    //            AutocompleteBox.Visible = false;
    //            e.Handled = true;
    //        }
    //    }
    //    private void OnKeyUp(object sender, KeyEventArgs e)
    //    {
    //        if (e.KeyCode == Keys.Enter | e.KeyCode == Keys.Space)
    //        {
    //            Point cp;
    //            string commandName = ((ListBox)sender).SelectedItem.ToString();
    //            string TempStr = this.Text.Remove(GetFirstCharIndexFromLine(CurrentLineIndex), Lines[CurrentLineIndex].Length);
    //            GetCaretPos(out cp);
    //            this.Text = TempStr.Insert(GetFirstCharIndexFromLine(CurrentLineIndex), commandName + String.Format("({0})", FomatParams(commandName)));
    //            this.SelectionStart = GetCharIndexFromPosition(cp) + Lines[GetLineFromCharIndex(GetCharIndexFromPosition(cp))].Length;
    //            AutocompleteBox.Hide();
    //            this.Focus();
    //        }
    //    }
    //    /// <summary>
    //    /// WndProc
    //    /// </summary>
    //    /// <param name="m"></param>

    //    /// <summary>
    //    /// OnTextChanged event.
    //    /// </summary>
    //    /// <param name="e"></param>
    //    protected override void OnTextChanged(EventArgs e)
    //    {
    //        Point cp;
    //        GetCaretPos(out cp);
    //        AutocompleteBox.SetBounds(cp.X + this.Left, cp.Y + 10, 280, 70);

    //        List<string> FilteredList =
    //            commandDictionary.Where(s => s.Name.StartsWith(CurrentLineText)).Select(m => m.Name).ToList();

    //        if (FilteredList.Count != 0 && !CurrentLineText.EndsWith(")") &&
    //            !CurrentLineText.EndsWith("(") && !String.IsNullOrEmpty(CurrentLineText))
    //        {
    //            AutocompleteBox.DataSource = FilteredList;
    //            AutocompleteBox.Show();
    //        }
    //        else
    //            AutocompleteBox.Hide();

    //        // Process lines.
    //        ProcessAllLines();

    //    }
    //    /// <summary>
    //    /// Process a line.
    //    /// <param name="LineIndex"> The index of the line to process.</param>
    //    /// </summary>
    //    public void FormatLine(string[] lines, int LineIndex)
    //    {
    //        if (lines.Length == 0)
    //            return;

    //        string line = lines[LineIndex];

    //        // Save the position and make the whole line black
    //        int nPosition = SelectionStart;
    //        SelectionStart = GetFirstCharIndexFromLine(LineIndex);
    //        SelectionLength = line.Length;
    //        SelectionColor = Color.Black;

    //        // Process numbers
    //        Format(line, LineIndex, "\\b(?:[0-9]*\\.)?[0-9]+\\b", Color.Red); // Decimal
    //        Format(line, LineIndex, @"\b0x[a-fA-F\d]+\b", Color.DarkCyan); // Hexadecimal

    //        // Don't need to process these, they just slow everything down.

    //        // Process parenthesis
    //        Format(line, LineIndex, "[\x28-\x2c]", Color.Blue);
    //        //// Process comments
    //        Format(line, LineIndex, "\"[^\"]*\"", Color.DarkRed);

    //        SelectionStart = nPosition;
    //        SelectionLength = 0;
    //        SelectionColor = Color.Black;
    //    }
    //    /// <summary>
    //    /// Process a regular expression, painting the matched syntax.
    //    /// </summary>
    //    /// <param name="line"> The line of text to process.</param>
    //    /// <param name="LineIndex"> The index of the line to process.</param>
    //    /// <param name="Regex">The regular expression to use in evaluation.</param>
    //    /// <param name="color">The color to paint matches.</param>
    //    private void Format(string line, int LineIndex, string strRegex, Color color)
    //    {

    //        Regex regKeywords = new Regex(strRegex, RegexOptions.IgnoreCase);
    //        Match regMatch;

    //        for (regMatch = regKeywords.Match(line); regMatch.Success; regMatch = regMatch.NextMatch())
    //        {
    //            // Process the words
    //            int nStart = GetFirstCharIndexFromLine(LineIndex) + regMatch.Index;
    //            int nLenght = regMatch.Length;
    //            SelectionStart = nStart;
    //            SelectionLength = nLenght;
    //            SelectionColor = color;
    //        }

    //    }
    //    /// <summary>
    //    /// Processes all lines in the code box.
    //    /// </summary>
    //    public void ProcessAllLines()
    //    {
    //        BeginUpdate();
    //        string[] lines = Lines;
    //        for (int i = 0; i < lines.Length; i++)
    //            FormatLine(lines, i);
    //        EndUpdate();
    //    }

    //    public void BeginUpdate()
    //    {
    //        SendMessage(this.Handle, WM_SETREDRAW, IntPtr.Zero, IntPtr.Zero);
    //        OldEventMask = (IntPtr)SendMessage(this.Handle, EM_SETEVENTMASK, IntPtr.Zero, IntPtr.Zero);
    //    }

    //    public void EndUpdate()
    //    {
    //        SendMessage(this.Handle, WM_SETREDRAW, (IntPtr)1, IntPtr.Zero);
    //        SendMessage(this.Handle, EM_SETEVENTMASK, IntPtr.Zero, OldEventMask);
    //    }
    //    #endregion
    //}

    class ITSCodeBox : Control
    {
        public ITSCodeBox()
        {
            _contentRect = new Rectangle(this.Location, this.Size);
            this.BackColor = SystemColors.Window;
        }

        public CommandList _list;
        public Rectangle _contentRect;
        public string[] Lines;

        protected override void OnPaint(PaintEventArgs e)
        {
            if (_list == null)
                return;

            base.OnPaint(e);

            Graphics g = e.Graphics;
            List<string> tmp = new List<string>();
            float x = _contentRect.X;
            float y = _contentRect.Y;

            for (int i = 0; i < _list.Count; i++)
            {
                Command c = _list[i];
                string s = c.ToString();


                g.DrawString(s, Font, SystemBrushes.MenuText, x, y);
                tmp.Add(s);


                y += Font.Height;

            }
            Lines = tmp.ToArray();
        }
    }
}