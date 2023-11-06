using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace TextEditor
{
    public partial class Main_Form : Form
    {
        //Earning methods with a file - Art Start
        string doc_name = @"";
        //Earning methods with a file - Art End

        //Last File Recently File -> Yan Start
        const int MEMORY_FILE_SAVE = 10; // Number of last files memorised
        Queue<string> MeM_LisT = new Queue<string>();
        //Last File Recently File -> Yan End

        //TrackBar_Zoom ->Serg Start
        float start_zoom_scale = 1f;
        //TrackBar_Zoom ->Serg End

        // Changing the background color of text positioning - Art Start
        Color color;
        // Changing the background color of text positioning - Art End

        public Main_Form()
        {
            InitializeComponent();
            //Development of Undo-Redo - Art Start
            Init_Undo_Redo();
            //Development of Undo-Redo - Art Start

            //Last File Recently File -> Yan Start
            Init_List();
            //Last File Recently File -> Yan End

            //Displays the position of the caret in the text and status document -> Yan Start
            Init_Mod();
            //Displays the position of the caret in the text and status document -> Yan End

            //FONTS
            Init_Font();

            //TrackBar_Zoom
            trackBar_Zoom.Value = 3; // 3 - 100%
            trackBar_Zoom_Scroll(this, null);

            //DragDrop
            richTextBox_Main.AllowDrop = true;
            this.richTextBox_Main.DragDrop += new DragEventHandler(this.textBox_Main_DragDrop);

            //Tabulation - Art Start
            richTextBox_Main.Multiline = true;
            richTextBox_Main.AcceptsTab = true;
            //Tabulation - Art End

            // Changing the background color of text positioning - Art Start
            color = toolStripButton_textCenter.BackColor;
            toolStripButton_textLeft.BackColor = Color.LightBlue;
            // Changing the background color of text positioning - Art end
        }

        //Tabulation - Art Start
        private void richTextBox_Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.Handled = false;
            }
        }
        //Tabulation - Art End

        //Organising searches in a document -> Yan
        int start_pos_search = 0;
        private void toolStripButton_search_Click(object sender, EventArgs e)
        {
            string find_str = toolStripTextBox_search.Text;
            int end_pos_search = richTextBox_Main.TextLength;

            if (toolStripTextBox_search.Text == "")
            {
                MessageBox.Show("Please enter string for Search!", "Text Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (richTextBox_Main.TextLength == 0)
            {
                MessageBox.Show("The document is empty! Nothing to find.", "Text Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (start_pos_search < end_pos_search)
            {
                start_pos_search = richTextBox_Main.Find(find_str, start_pos_search, richTextBox_Main.Text.Length, RichTextBoxFinds.MatchCase) + 1;

                if (start_pos_search == 0) MessageBox.Show("Position not found!", "Text Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    richTextBox_Main.ScrollToCaret();
                }
            }
        }
        //Organising searches in a document->yan End

        //Earning methods with a file - Art Start
        public void OpenDocument()
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Filter = "Supported files (*.rtf, *.txt)|*.rtf;*.txt|" + "All files (*.*)|*.*";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    OpenDocument(dlg.FileName);
                    SaveRecentFile(dlg.FileName); //insert to list so that opened file will shown on the list -> Yan
                }
            }
        }

        public void OpenDocument(string fileName)
        {
            if (!PromtToSaveDocument())
                return;

            LoadDocument(fileName);
            doc_name = fileName;
            this.Text = "TextEditor -" + fileName;
        }

        private void LoadDocument(string _path)
        {
            RichTextBoxStreamType streamType = _path.EndsWith(".rtf") ? RichTextBoxStreamType.RichText : RichTextBoxStreamType.PlainText;
            try
            {
                richTextBox_Main.LoadFile(_path, streamType);
                ControlTextBoxSelectionChanged();
            }
            catch (IOException e) { MessageBox.Show(e.Message); }
        }

        private void ControlTextBoxSelectionChanged()
        {
            this.richTextBox_Main.SelectAll();
            this.richTextBox_Main.Select(0, 0);
            this.richTextBox_Main.Modified = false;
        }

        public bool SaveDocument() => SaveDocument(doc_name);

        public bool SaveDocument(string _file_name)
        {
            if (string.IsNullOrEmpty(_file_name)) //Check if the open file has a name, if it does not - call saving
            {
                return SaveDocumentAs();
            }
            try
            {
                RichTextBoxStreamType streamType = _file_name.EndsWith(".rtf") ? RichTextBoxStreamType.RichText : RichTextBoxStreamType.PlainText;
                richTextBox_Main.SaveFile(_file_name, streamType);
                richTextBox_Main.Modified = false;
            }
            catch (IOException e) { MessageBox.Show(e.Message); }

            return true;
        }
        public bool SaveDocumentAs()
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.FileName = doc_name;
                dlg.Filter = "RTF (*.rtf)|*.rtf|TXT (*.txt)|*.txt";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    doc_name = dlg.FileName;
                    this.Text = "TextEditor -" + doc_name;
                    return SaveDocument();
                }
            }
            return false;

        }

        private bool PromtToSaveDocument()
        {
            if (!richTextBox_Main.Modified) return true;
            DialogResult dialog = MessageBox.Show("Do you want to save '" + doc_name + "'?", "TextEditor - Question", MessageBoxButtons.YesNoCancel);
            switch (dialog)
            {
                case DialogResult.Yes: return SaveDocument();
                case DialogResult.No: return true;
                case DialogResult.Cancel: return false;
            }
            throw new ApplicationException();
        }

        private void NewDocument()
        {
            if (!PromtToSaveDocument())
                return;
            richTextBox_Main.Clear();
            doc_name = "New Document";
            this.Text = "TextEditor -" + doc_name;
            ControlTextBoxSelectionChanged();
        }


        private void toolStripButton_New_Doc_Click(object sender, EventArgs e)
        {
            NewDocument();
        }

        private void toolStripButton_Open_Click(object sender, EventArgs e)
        {
            OpenDocument();
        }

        private void toolStripButton_Save_Click(object sender, EventArgs e)
        {
            SaveDocument();
        }

        private void toolStripButton_SaveAs_Click(object sender, EventArgs e)
        {
            SaveDocumentAs();
        }

        private void Main_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.PromtToSaveDocument())
            {
                e.Cancel = true;
            }
        }
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Earning methods with a file - Art Start
        //FONTS
        private void Init_Font()
        {
            //Stuffing the list with fonts
            foreach (int size in new int[] { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 })
            {
                this.toolStripComboBox_Size.Items.Add(size.ToString());
            }
            //Stuffing the list with font sizes
            foreach (FontFamily fontFamily in FontFamily.Families)
            {
                this.toolStripComboBox_Font.Items.Add(fontFamily.Name);

            }
            this.Upd_Style_Text();
            this.richTextBox_Main.SelectionChanged += delegate { this.Upd_Style_Text(); };
        }

        private void Upd_Style_Text()
        {
            Font font = this.richTextBox_Main.SelectionFont;
            bool none = font == null;
            toolStripComboBox_Font.Text = none ? "" : font.FontFamily.Name;
            toolStripComboBox_Size.Text = none ? "" : font.Size.ToString();
        }
        private void toolStripComboBox_Font_SelectedIndexChanged(object sender, EventArgs e)
        {
            Font font = this.richTextBox_Main.SelectionFont;

            if (font == null)
            {
                MessageBox.Show("Warning! Text Editor cannot change the font style, text with different fonts is selected!",
                   "Text Editor - Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string fontFamilyName = this.toolStripComboBox_Font.Text;

            this.richTextBox_Main.SelectionFont = new Font(fontFamilyName, font.Size, font.Style, font.Unit);
        }

        private void toolStripComboBox_Size_SelectedIndexChanged(object sender, EventArgs e)
        {
            Font font = this.richTextBox_Main.SelectionFont;

            if (font == null)
            {
                MessageBox.Show("Warning! Text Editor cannot change the font size, text with different fonts is selected!",
                    "Text Editor - Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.richTextBox_Main.SelectionFont = new Font(font.FontFamily, float.Parse(this.toolStripComboBox_Size.Text), font.Style, GraphicsUnit.Point);
        }

        void ToggleSelectionFontStyle(FontStyle fontStyle)
        {
            if (this.richTextBox_Main.SelectionFont == null)
            {
                MessageBox.Show("The selected text has different fonts!");
            }
            else
            {
                this.richTextBox_Main.SelectionFont = new Font(this.richTextBox_Main.SelectionFont,
                    this.richTextBox_Main.SelectionFont.Style ^ fontStyle);
            }
        }

        private void toolStripButt_Bold_Click(object sender, EventArgs e)
        {
            ToggleSelectionFontStyle(FontStyle.Bold);
        }

        private void toolStripButt_Italic_Click(object sender, EventArgs e)
        {
            ToggleSelectionFontStyle(FontStyle.Italic);
        }

        private void StripButt_Underline_Click(object sender, EventArgs e)
        {
            ToggleSelectionFontStyle(FontStyle.Underline);
        }

        private void toolStripButt_Strike_Click(object sender, EventArgs e)
        {
            ToggleSelectionFontStyle(FontStyle.Strikeout);
        }

        private void toolStripButt_FrontColor_Click(object sender, EventArgs e)
        {
            ColorDialog dialog_color = new ColorDialog();
            dialog_color.Color = richTextBox_Main.SelectionColor;
            if (dialog_color.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               dialog_color.Color != richTextBox_Main.SelectionColor)
            {
                richTextBox_Main.SelectionColor = dialog_color.Color;
            }
        }

        private void toolStripButt_BackFrontColor_Click(object sender, EventArgs e)
        {
            ColorDialog dialog_color = new ColorDialog();
            dialog_color.Color = richTextBox_Main.SelectionBackColor;
            if (dialog_color.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               dialog_color.Color != richTextBox_Main.SelectionBackColor)
            {
                richTextBox_Main.SelectionBackColor = dialog_color.Color;
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBox_Main.Copy();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBox_Main.Cut();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBox_Main.Paste();
        }

        private void pasteAsTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBox_Main.SelectedText = Clipboard.GetText();
        }

        private void toolStripButton_clear_all_Click(object sender, EventArgs e)
        {
            richTextBox_Main.Clear();
        }

        private void toolStripMenuItem_Delete_Click(object sender, EventArgs e)
        {
            richTextBox_Main.SelectedText = "";
        }

        //Recent file -> Yan start
        private void SaveRecentFile(string path)
        {

            recentlyFileToolStripMenuItem.DropDownItems.Clear();
            LoadRecentList();
            if (!(MeM_LisT.Contains(path)))
                MeM_LisT.Enqueue(path);
            while (MeM_LisT.Count > MEMORY_FILE_SAVE)
            {
                MeM_LisT.Dequeue();
            }
            foreach (string item in MeM_LisT)
            {

                ToolStripMenuItem fileRecent = new ToolStripMenuItem(item, null, RecentFile_click);
                recentlyFileToolStripMenuItem.DropDownItems.Add(fileRecent);
            }

            StreamWriter stringToWrite =
            new StreamWriter(Environment.CurrentDirectory + "\\LastFile.txt");
            foreach (string item in MeM_LisT)
            {
                stringToWrite.WriteLine(item);
            }
            stringToWrite.Flush();
            stringToWrite.Close();
        }

        private void Init_List()
        {
            LoadRecentList();

            while (MeM_LisT.Count > MEMORY_FILE_SAVE)
            {
                MeM_LisT.Dequeue();
            }
            foreach (string item in MeM_LisT)
            {
                ToolStripMenuItem fileRecent = new ToolStripMenuItem(item, null, RecentFile_click);
                recentlyFileToolStripMenuItem.DropDownItems.Add(fileRecent);
            }
            StreamWriter stringToWrite = new StreamWriter(Environment.CurrentDirectory + "\\LastFile.txt");
            foreach (string item in MeM_LisT)
            {
                stringToWrite.WriteLine(item);
            }
            stringToWrite.Flush();
            stringToWrite.Close();
        }

        private void LoadRecentList()
        {
            MeM_LisT.Clear();
            try
            {
                StreamReader listToRead = new StreamReader(System.Environment.CurrentDirectory + "\\LastFile.txt");
                string line;
                while ((line = listToRead.ReadLine()) != null)
                    MeM_LisT.Enqueue(line);
                listToRead.Close();
            }
            catch (Exception)
            {

            }
        }
        private void RecentFile_click(object sender, EventArgs e)
        {
            OpenDocument(sender.ToString());
        }
        //Recent file -> Yan end

        //Displays the position of the caret in the text and status document -> Yan Start
        private static int EM_LINEINDEX = 187;
        [DllImport("user32.dll")]
        extern static int SendMessage(IntPtr hwnd, int message, int wparam, int lparam);
        private void UpdateCaretPos()
        {
            int line, col, index;
            index = richTextBox_Main.SelectionStart;
            line = richTextBox_Main.GetLineFromCharIndex(index);
            col = index - SendMessage(richTextBox_Main.Handle, EM_LINEINDEX, -1, 0);
            toolStripStatusLabel_CursorPosition.Text = "Row: " + (++line).ToString() + ", Col: " + (++col).ToString();
        }

        private void Init_Mod()
        {
            this.Upd_Mod();
            this.UpdateCaretPos();
            this.richTextBox_Main.ModifiedChanged += delegate { this.Upd_Mod(); this.UpdateCaretPos(); };
            this.richTextBox_Main.KeyDown += delegate { this.UpdateCaretPos(); };
            this.richTextBox_Main.KeyUp += delegate { this.UpdateCaretPos(); };
        }

        private void Upd_Mod()
        {
            this.toolStripStatusLabel_Rec.Enabled = this.richTextBox_Main.Modified;
            this.toolStripStatusLabel_Rec.Text = (this.richTextBox_Main.Modified) ? "Document CHANGED" : "Document not change";
        }
        private void richTextBox_Main_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.richTextBox_Main.TextChanged -= new System.EventHandler(this.richTextBox_Main_TextChanged);
                if (this.richTextBox_Main.Focus())
                {
                    this.richTextBox_Main.Clear();//Delete OLE object
                    this.richTextBox_Main.Paste();
                    this.richTextBox_Main.Select(0, 0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error read file" + ex.ToString());
            }
        }
        //Displays the position of the caret in the text and status document -> Yan End

        //TrackBar_Zoom ->Serg Start
        private void trackBar_Zoom_Scroll(object sender, EventArgs e)
        {
            switch (trackBar_Zoom.Value)
            {
                case 10: { richTextBox_Main.ZoomFactor = start_zoom_scale * 4f; label_curr_zoom.Text = "Zoom Scale: " + "400" + "%"; } break;
                case 9: { richTextBox_Main.ZoomFactor = start_zoom_scale * 3.5f; label_curr_zoom.Text = "Zoom Scale: " + "350" + "%"; } break;
                case 8: { richTextBox_Main.ZoomFactor = start_zoom_scale * 3f; label_curr_zoom.Text = "Zoom Scale: " + "300" + "%"; } break;
                case 7: { richTextBox_Main.ZoomFactor = start_zoom_scale * 2.5f; label_curr_zoom.Text = "Zoom Scale: " + "250" + "%"; } break;
                case 6: { richTextBox_Main.ZoomFactor = start_zoom_scale * 2f; label_curr_zoom.Text = "Zoom Scale: " + "200" + "%"; } break;
                case 5: { richTextBox_Main.ZoomFactor = start_zoom_scale * 1.5f; label_curr_zoom.Text = "Zoom Scale: " + "150" + "%"; } break;
                case 4: { richTextBox_Main.ZoomFactor = start_zoom_scale * 1.25f; label_curr_zoom.Text = "Zoom Scale: " + "125" + "%"; } break;
                case 3: { richTextBox_Main.ZoomFactor = 1f; label_curr_zoom.Text = "Zoom Scale: " + "100" + "%"; } break;
                case 2: { richTextBox_Main.ZoomFactor = start_zoom_scale * 0.6f; label_curr_zoom.Text = "Zoom Scale: " + "60" + "%"; } break;
                case 1: { richTextBox_Main.ZoomFactor = start_zoom_scale * 0.3f; label_curr_zoom.Text = "Zoom Scale: " + "30" + "%"; } break;
                case 0: { richTextBox_Main.ZoomFactor = start_zoom_scale * 0.15f; label_curr_zoom.Text = "Zoom Scale: " + "15" + "%"; } break;

                default:
                    break;
            }
        }
        //TrackBar_Zoom ->Serg End

        //Drag and Drop ->Serg Start
        private void textBox_Main_DragDrop(object sender, DragEventArgs e)
        {
            richTextBox_Main.SelectionIndent = 0;
            try
            {
                string str_for_drop;
                Array arr = (Array)e.Data.GetData(DataFormats.FileDrop);
                if (arr != null)
                {
                    str_for_drop = arr.GetValue(0).ToString();

                    this.Activate();
                    OpenDocument(str_for_drop);
                    if (this.richTextBox_Main.Focus())
                    {
                        this.richTextBox_Main.SelectAll();
                        this.richTextBox_Main.Cut();
                    }
                    this.richTextBox_Main.TextChanged += new System.EventHandler(this.richTextBox_Main_TextChanged);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in DragDrop function: " + ex.Message);
            }
        }
        //Drag and Drop ->Serg End

        //Development of Undo-Redo - Art Start
        private void Init_Undo_Redo()
        {
            this.Upd_Retry_Butt();
            this.richTextBox_Main.TextChanged += delegate { this.Upd_Retry_Butt(); };
        }
        void Upd_Retry_Butt()
        {
            this.contextMenuStrip_richTXTbox.Enabled = this.richTextBox_Main.CanUndo;
            this.toolStripButton_Undo.Enabled = this.richTextBox_Main.CanUndo;
            this.toolStripButton_Redo.Enabled = this.richTextBox_Main.CanRedo;
        }
        private void toolStripButton_Undo_Click(object sender, EventArgs e)
        {
            this.richTextBox_Main.Undo();
            this.Upd_Retry_Butt();
        }

        private void toolStripButton_Redo_Click(object sender, EventArgs e)
        {
            this.richTextBox_Main.Redo();
            this.Upd_Retry_Butt();
        }

        //Development of Undo-Redo - Art End
        private void toolStripMenuItem_SellAll_Click(object sender, EventArgs e)
        {
            if (this.richTextBox_Main.Focus())
            {
                richTextBox_Main.SelectAll();
            }
        }

        //Adding lists to richtextbox - Art start
        private void toolStripButton_list_Click(object sender, EventArgs e)
        {
            richTextBox_Main.SelectionIndent = 50;
            SendKeys.SendWait($"{'^'}{'+'}{'L'}");
        }
        //Adding lists to richtextbox - Art End

        // text positioning - Art start
        private void toolStripButton_textLeft_Click(object sender, EventArgs e)
        {
            richTextBox_Main.SelectionIndent = 0;
            richTextBox_Main.SelectionAlignment = HorizontalAlignment.Left;
            toolStripButton_textLeft.BackColor = Color.LightBlue;
            toolStripButton_textCenter.BackColor = color;
            toolStripButton_textRight.BackColor = color;

        }

        private void toolStripButton_textCenter_Click(object sender, EventArgs e)
        {
            richTextBox_Main.SelectionAlignment = HorizontalAlignment.Center;
            toolStripButton_textLeft.BackColor = color;
            toolStripButton_textCenter.BackColor = Color.LightBlue;
            toolStripButton_textRight.BackColor = color;
        }

        private void toolStripButton_textRight_Click(object sender, EventArgs e)
        {
            richTextBox_Main.SelectionAlignment = HorizontalAlignment.Right;
            toolStripButton_textLeft.BackColor = color;
            toolStripButton_textCenter.BackColor = color;
            toolStripButton_textRight.BackColor = Color.LightBlue;
        }
        // text positioning - Art end
        



    }
}