namespace TextEditor
{
    partial class Main_Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Form));
            menuStrip_en = new MenuStrip();
            toolStrip1 = new ToolStrip();
            toolStripButton_New_Doc = new ToolStripButton();
            toolStripButton_Open = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripButton_Save = new ToolStripButton();
            toolStripButton_SaveAs = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripTextBox_search = new ToolStripTextBox();
            toolStripButton_search = new ToolStripButton();
            richTextBox_Main = new RichTextBox();
            contextMenuStrip_richTXTbox = new ContextMenuStrip(components);
            statusStrip1 = new StatusStrip();
            trackBar_Zoom = new TrackBar();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar_Zoom).BeginInit();
            SuspendLayout();
            // 
            // menuStrip_en
            // 
            menuStrip_en.AutoSize = false;
            menuStrip_en.BackColor = SystemColors.ControlLight;
            menuStrip_en.GripStyle = ToolStripGripStyle.Visible;
            menuStrip_en.Location = new Point(0, 0);
            menuStrip_en.Name = "menuStrip_en";
            menuStrip_en.Size = new Size(926, 24);
            menuStrip_en.TabIndex = 0;
            menuStrip_en.Text = "menuStrip1";
            // 
            // toolStrip1
            // 
            toolStrip1.AutoSize = false;
            toolStrip1.BackColor = SystemColors.ControlLight;
            toolStrip1.ImageScalingSize = new Size(24, 24);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton_New_Doc, toolStripButton_Open, toolStripSeparator1, toolStripButton_Save, toolStripButton_SaveAs, toolStripSeparator2, toolStripTextBox_search, toolStripButton_search });
            toolStrip1.Location = new Point(0, 24);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(926, 40);
            toolStrip1.Stretch = true;
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton_New_Doc
            // 
            toolStripButton_New_Doc.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton_New_Doc.Image = Properties.Resources._new;
            toolStripButton_New_Doc.ImageTransparentColor = Color.Magenta;
            toolStripButton_New_Doc.Name = "toolStripButton_New_Doc";
            toolStripButton_New_Doc.Size = new Size(28, 37);
            toolStripButton_New_Doc.Text = "New_Doc";
            toolStripButton_New_Doc.Click += toolStripButton_New_Doc_Click;
            // 
            // toolStripButton_Open
            // 
            toolStripButton_Open.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton_Open.Image = Properties.Resources.open;
            toolStripButton_Open.ImageTransparentColor = Color.Magenta;
            toolStripButton_Open.Name = "toolStripButton_Open";
            toolStripButton_Open.Size = new Size(28, 37);
            toolStripButton_Open.Text = "Open";
            toolStripButton_Open.Click += toolStripButton_Open_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 40);
            // 
            // toolStripButton_Save
            // 
            toolStripButton_Save.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton_Save.Image = Properties.Resources.Save;
            toolStripButton_Save.ImageTransparentColor = Color.Magenta;
            toolStripButton_Save.Name = "toolStripButton_Save";
            toolStripButton_Save.Size = new Size(28, 37);
            toolStripButton_Save.Text = "Save";
            toolStripButton_Save.Click += toolStripButton_Save_Click;
            // 
            // toolStripButton_SaveAs
            // 
            toolStripButton_SaveAs.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton_SaveAs.Image = Properties.Resources.save_as;
            toolStripButton_SaveAs.ImageTransparentColor = Color.Magenta;
            toolStripButton_SaveAs.Name = "toolStripButton_SaveAs";
            toolStripButton_SaveAs.Size = new Size(28, 37);
            toolStripButton_SaveAs.Text = "Save As";
            toolStripButton_SaveAs.Click += toolStripButton_SaveAs_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 40);
            // 
            // toolStripTextBox_search
            // 
            toolStripTextBox_search.Name = "toolStripTextBox_search";
            toolStripTextBox_search.Size = new Size(100, 40);
            toolStripTextBox_search.ToolTipText = "Search...";
            // 
            // toolStripButton_search
            // 
            toolStripButton_search.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton_search.Image = Properties.Resources.search;
            toolStripButton_search.ImageTransparentColor = Color.Magenta;
            toolStripButton_search.Name = "toolStripButton_search";
            toolStripButton_search.Size = new Size(28, 37);
            toolStripButton_search.Text = "Search";
            toolStripButton_search.Click += toolStripButton_search_Click;
            // 
            // richTextBox_Main
            // 
            richTextBox_Main.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox_Main.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            richTextBox_Main.Location = new Point(0, 67);
            richTextBox_Main.Name = "richTextBox_Main";
            richTextBox_Main.ScrollBars = RichTextBoxScrollBars.ForcedBoth;
            richTextBox_Main.Size = new Size(875, 518);
            richTextBox_Main.TabIndex = 0;
            richTextBox_Main.Text = "";
            // 
            // contextMenuStrip_richTXTbox
            // 
            contextMenuStrip_richTXTbox.AllowDrop = true;
            contextMenuStrip_richTXTbox.Name = "contextMenuStrip_richTXTbox";
            contextMenuStrip_richTXTbox.Size = new Size(61, 4);
            // 
            // statusStrip1
            // 
            statusStrip1.AutoSize = false;
            statusStrip1.BackColor = SystemColors.ControlLight;
            statusStrip1.Location = new Point(0, 582);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(926, 22);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // trackBar_Zoom
            // 
            trackBar_Zoom.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            trackBar_Zoom.LargeChange = 1;
            trackBar_Zoom.Location = new Point(881, 67);
            trackBar_Zoom.Name = "trackBar_Zoom";
            trackBar_Zoom.Orientation = Orientation.Vertical;
            trackBar_Zoom.Size = new Size(45, 512);
            trackBar_Zoom.TabIndex = 4;
            trackBar_Zoom.TickStyle = TickStyle.TopLeft;
            // 
            // Main_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(926, 604);
            Controls.Add(trackBar_Zoom);
            Controls.Add(statusStrip1);
            Controls.Add(richTextBox_Main);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip_en);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip_en;
            Name = "Main_Form";
            Text = "Text Editor";
            FormClosing += Main_Form_FormClosing;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar_Zoom).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip_en;
        private ToolStrip toolStrip1;
        private RichTextBox richTextBox_Main;
        private ContextMenuStrip contextMenuStrip_richTXTbox;
        private StatusStrip statusStrip1;
        private TrackBar trackBar_Zoom;
        private ToolStripTextBox toolStripTextBox_search;
        private ToolStripButton toolStripButton_search;
        private ToolStripButton toolStripButton_New_Doc;
        private ToolStripButton toolStripButton_Open;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolStripButton_Save;
        private ToolStripButton toolStripButton_SaveAs;
        private ToolStripSeparator toolStripSeparator2;
    }
}