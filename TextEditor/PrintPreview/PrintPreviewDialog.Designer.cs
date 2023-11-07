namespace TextEditor.PrintPreview
{
    partial class PrintPreviewDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintPreviewDialog));
            toolStrip1 = new ToolStrip();
            btnPrint = new ToolStripButton();
            btnPageSetup = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            btnZoom = new ToolStripSplitButton();
            itemActualSize = new ToolStripMenuItem();
            itemPageWidth = new ToolStripMenuItem();
            itemFullPage = new ToolStripMenuItem();
            itemTwoPages = new ToolStripMenuItem();
            btnFirst = new ToolStripButton();
            btnPrev = new ToolStripButton();
            txtStartPage = new ToolStripTextBox();
            lbPageCount = new ToolStripLabel();
            btnNext = new ToolStripButton();
            btnLast = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            btnCancel = new ToolStripButton();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            preview = new UserPrintPreviewControl();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.AutoSize = false;
            toolStrip1.ImageScalingSize = new Size(24, 24);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnPrint, btnPageSetup, toolStripSeparator1, btnZoom, btnFirst, btnPrev, txtStartPage, lbPageCount, btnNext, btnLast, toolStripSeparator2, btnCancel });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 40);
            toolStrip1.Stretch = true;
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnPrint
            // 
            btnPrint.Image = Properties.Resources.printer;
            btnPrint.ImageTransparentColor = Color.Magenta;
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(60, 37);
            btnPrint.Text = "Print";
            btnPrint.Click += btnPrint_Click;
            // 
            // btnPageSetup
            // 
            btnPageSetup.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnPageSetup.Image = Properties.Resources.pageSettings;
            btnPageSetup.ImageTransparentColor = Color.Magenta;
            btnPageSetup.Name = "btnPageSetup";
            btnPageSetup.Size = new Size(28, 37);
            btnPageSetup.Text = "Page Setup";
            btnPageSetup.Click += btnPageSetup_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 40);
            // 
            // btnZoom
            // 
            btnZoom.DropDownItems.AddRange(new ToolStripItem[] { itemActualSize, itemPageWidth, itemFullPage, itemTwoPages });
            btnZoom.Image = Properties.Resources.magnifier;
            btnZoom.ImageTransparentColor = Color.Magenta;
            btnZoom.Name = "btnZoom";
            btnZoom.Size = new Size(79, 37);
            btnZoom.Text = "Zoom";
            btnZoom.ButtonClick += btnZoom_ButtonClick;
            btnZoom.DropDownItemClicked += btnZoom_DropDownItemClicked;
            // 
            // itemActualSize
            // 
            itemActualSize.Name = "itemActualSize";
            itemActualSize.Size = new Size(135, 22);
            itemActualSize.Text = "Actual Size";
            // 
            // itemPageWidth
            // 
            itemPageWidth.Name = "itemPageWidth";
            itemPageWidth.Size = new Size(135, 22);
            itemPageWidth.Text = "Page Width";
            // 
            // itemFullPage
            // 
            itemFullPage.Name = "itemFullPage";
            itemFullPage.Size = new Size(135, 22);
            itemFullPage.Text = "Full Page";
            // 
            // itemTwoPages
            // 
            itemTwoPages.Name = "itemTwoPages";
            itemTwoPages.Size = new Size(135, 22);
            itemTwoPages.Text = "Two Pages";
            // 
            // btnFirst
            // 
            btnFirst.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnFirst.Image = Properties.Resources.Sback;
            btnFirst.ImageTransparentColor = Color.Magenta;
            btnFirst.Name = "btnFirst";
            btnFirst.Size = new Size(28, 37);
            btnFirst.Text = "First Page";
            btnFirst.Click += btnFirst_Click;
            // 
            // btnPrev
            // 
            btnPrev.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnPrev.Image = Properties.Resources.rBack;
            btnPrev.ImageTransparentColor = Color.Magenta;
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(28, 37);
            btnPrev.Text = "Previous Page";
            btnPrev.Click += btnPrev_Click;
            // 
            // txtStartPage
            // 
            txtStartPage.BackColor = SystemColors.ControlLightLight;
            txtStartPage.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtStartPage.Name = "txtStartPage";
            txtStartPage.Size = new Size(28, 40);
            txtStartPage.Enter += txtStartPage_Enter;
            txtStartPage.KeyPress += txtStartPage_KeyPress;
            txtStartPage.Validating += txtStartPage_Validating;
            // 
            // lbPageCount
            // 
            lbPageCount.Name = "lbPageCount";
            lbPageCount.Size = new Size(0, 37);
            // 
            // btnNext
            // 
            btnNext.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnNext.Image = Properties.Resources.rForward;
            btnNext.ImageTransparentColor = Color.Magenta;
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(28, 37);
            btnNext.Text = "Next Page";
            btnNext.Click += btnNext_Click;
            // 
            // btnLast
            // 
            btnLast.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnLast.Image = Properties.Resources.Sforward;
            btnLast.ImageTransparentColor = Color.Magenta;
            btnLast.Name = "btnLast";
            btnLast.Size = new Size(28, 37);
            btnLast.Text = "Last Page";
            btnLast.Click += btnLast_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 40);
            // 
            // btnCancel
            // 
            btnCancel.Image = Properties.Resources.delete;
            btnCancel.ImageTransparentColor = Color.Magenta;
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(71, 37);
            btnCancel.Text = "Cancel";
            btnCancel.Click += btnCancel_Click;
            // 
            // preview
            // 
            preview.AutoScroll = true;
            preview.Dock = DockStyle.Fill;
            preview.Document = null;
            preview.Location = new Point(0, 40);
            preview.Name = "preview";
            preview.Size = new Size(800, 410);
            preview.TabIndex = 1;
            preview.StartPageChanged += preview_StartPageChanged;
            preview.PageCountChanged += preview_PageCountChanged;
            // 
            // PrintPreviewDialog
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(800, 450);
            Controls.Add(preview);
            Controls.Add(toolStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "PrintPreviewDialog";
            Text = "TextEditor Print Preview Dialog";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton btnPrint;
        private ToolStripButton btnPageSetup;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSplitButton btnZoom;
        private ToolStripButton btnFirst;
        private ToolStripButton btnPrev;
        private ToolStripTextBox txtStartPage;
        private ToolStripButton btnNext;
        private ToolStripButton btnLast;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton btnCancel;
        private ToolStripMenuItem itemActualSize;
        private ToolStripMenuItem itemPageWidth;
        private ToolStripMenuItem itemFullPage;
        private ToolStripMenuItem itemTwoPages;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private UserPrintPreviewControl preview;
        private ToolStripLabel lbPageCount;
    }
}