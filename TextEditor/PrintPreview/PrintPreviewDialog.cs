using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TextEditor.PrintPreview
{
    public partial class PrintPreviewDialog : Form
    {
        PrintDocument? doc;
        public PrintPreviewDialog() : this(null)
        {
        }
        public PrintPreviewDialog(Control parentForm)
        {
            InitializeComponent();
            if (parentForm != null)
            {
                Size = parentForm.Size;
            }
        }

        private void userPrintPreviewControl1_Load(object sender, EventArgs e)
        {

        }

        public PrintDocument Document
        {
            get { return doc; }
            set
            {
                // unhook event handlers
                if (doc != null)
                {
                    doc.BeginPrint -= doc_BeginPrint;
                    doc.EndPrint -= doc_EndPrint;
                }

                // save the value
                doc = value;

                // hook up event handlers
                if (doc != null)
                {
                    doc.BeginPrint += doc_BeginPrint;
                    doc.EndPrint += doc_EndPrint;
                }

                // don't assign document to preview until this form becomes visible
                if (Visible)
                {
                    preview.Document = Document;
                }
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            preview.Document = Document;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (preview.IsRendering && !e.Cancel)
            {
                preview.Cancel();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            using (var dlg = new PrintDialog())
            {
                // configure dialog
                dlg.AllowSomePages = true;
                dlg.AllowSelection = true;
                dlg.UseEXDialog = true;
                dlg.Document = Document;

                // show allowed page range
                var ps = dlg.PrinterSettings;
                ps.MinimumPage = ps.FromPage = 1;
                ps.MaximumPage = ps.ToPage = preview.PageCount;

                // show dialog
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    // print selected page range
                    preview.Print();
                }
            }
        }

        private void btnPageSetup_Click(object sender, EventArgs e)
        {
            using (var dlg = new PageSetupDialog())
            {
                dlg.Document = Document;
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    // to show new page layout
                    preview.RefreshPreview();
                }
            }
        }

        private void btnZoom_ButtonClick(object sender, EventArgs e)
        {
            preview.ZoomMode = preview.ZoomMode == ZoomMode.ActualSize ? ZoomMode.FullPage : ZoomMode.ActualSize;
        }

        private void btnZoom_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == itemActualSize)
            {
                preview.ZoomMode = ZoomMode.ActualSize;
            }
            else if (e.ClickedItem == itemFullPage)
            {
                preview.ZoomMode = ZoomMode.FullPage;
            }
            else if (e.ClickedItem == itemPageWidth)
            {
                preview.ZoomMode = ZoomMode.PageWidth;
            }
            else if (e.ClickedItem == itemTwoPages)
            {
                preview.ZoomMode = ZoomMode.TwoPages;
            }


        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            preview.StartPage = 0;
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            preview.StartPage--;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            preview.StartPage++;
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            preview.StartPage = preview.PageCount - 1;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (preview.IsRendering)
            {
                preview.Cancel();
            }
            else Close();
        }

        void doc_BeginPrint(object sender, PrintEventArgs e)
        {
            btnCancel.Text = "&Cancel";
            btnPrint.Enabled = btnPageSetup.Enabled = false;
        }
        void doc_EndPrint(object sender, PrintEventArgs e)
        {
            btnCancel.Text = "&Close";
            btnPrint.Enabled = btnPageSetup.Enabled = true;
        }

        //!!!Pages
        void CommitPageNumber()
        {
            int page;
            if (int.TryParse(txtStartPage.Text, out page))
            {
                preview.StartPage = page - 1;
            }
        }

        private void txtStartPage_Enter(object sender, EventArgs e)
        {
            txtStartPage.SelectAll();
        }

        private void txtStartPage_Validating(object sender, CancelEventArgs e)
        {
            CommitPageNumber();
        }

        private void txtStartPage_KeyPress(object sender, KeyPressEventArgs e)
        {
            var c = e.KeyChar;
            if (c == (char)13)
            {
                CommitPageNumber();
                e.Handled = true;
            }
            else if (c > ' ' && !char.IsDigit(c))
            {
                e.Handled = true;
            }
        }

        private void preview_StartPageChanged(object sender, EventArgs e)
        {
            var page = preview.StartPage + 1;
            txtStartPage.Text = page.ToString();
        }

        private void preview_PageCountChanged(object sender, EventArgs e)
        {
            this.Update();
            Application.DoEvents();
            lbPageCount.Text = string.Format("of {0}", preview.PageCount);
        }


    }
}
