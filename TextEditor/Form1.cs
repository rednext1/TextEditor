namespace TextEditor
{
    public partial class Main_Form : Form
    {
        public Main_Form()
        {
            InitializeComponent();
            //1111
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


        private void toolStripButton_New_Doc_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton_Open_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton_Save_Click(object sender, EventArgs e)
        {

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
    }
}