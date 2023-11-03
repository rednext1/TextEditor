using System.Runtime.InteropServices;

namespace TextEditor
{
    public partial class Main_Form : Form
    {

        //Last File Recently File -> Yan Start
        const int MEMORY_FILE_SAVE = 10; // Number of last files memorised
        Queue<string> MeM_LisT = new Queue<string>();
        //Last File Recently File -> Yan End

        public Main_Form()
        {
            InitializeComponent();

            //Last File Recently File -> Yan Start
            Init_List();
            //Last File Recently File -> Yan End

            //Displays the position of the caret in the text and status document -> Yan Start
            Init_Mod();
            //Displays the position of the caret in the text and status document -> Yan End
        }

        private void Main_Form_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

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

        string doc_name = @"";

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
            if (string.IsNullOrEmpty(_file_name)) //Проверяем есть ли имя у открытого файла, нет - вызываем сохранение
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

        private void toolStripButton_New_Doc_Click(object sender, EventArgs e)
        {

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

        }

        private void toolStripComboBox_Font_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox_Size_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButt_Bold_Click(object sender, EventArgs e)
        {

        }

        private void StripButt_Underline_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButt_Strike_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButt_FrontColor_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButt_BackFrontColor_Click(object sender, EventArgs e)
        {

        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pasteAsTextToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton_clear_all_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton_Undo_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton_Redo_Click(object sender, EventArgs e)
        {

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
        //Displays the position of the caret in the text and status document  -> Yan end

    }
}