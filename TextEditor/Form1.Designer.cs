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
            toolStripComboBox_Font = new ToolStripComboBox();
            toolStripSeparator3 = new ToolStripSeparator();
            toolStripComboBox_Size = new ToolStripComboBox();
            toolStripSeparator4 = new ToolStripSeparator();
            toolStripButt_Bold = new ToolStripButton();
            toolStripButt_Italic = new ToolStripButton();
            StripButt_Underline = new ToolStripButton();
            toolStripButt_Strike = new ToolStripButton();
            toolStripSeparator5 = new ToolStripSeparator();
            toolStripButt_FrontColor = new ToolStripButton();
            toolStripButt_BackFrontColor = new ToolStripButton();
            toolStripSeparator6 = new ToolStripSeparator();
            toolStripButton_Copy = new ToolStripButton();
            toolStripButton_Cut = new ToolStripButton();
            toolStripSeparator7 = new ToolStripSeparator();
            toolStripButton_Paste = new ToolStripButton();
            toolStripButton_PasteAsText = new ToolStripButton();
            toolStripSeparator10 = new ToolStripSeparator();
            toolStripButton_clear_all = new ToolStripButton();
            toolStripTextBox_search = new ToolStripTextBox();
            toolStripButton_search = new ToolStripButton();
            toolStripSeparator8 = new ToolStripSeparator();
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
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton_New_Doc, toolStripButton_Open, toolStripSeparator1, toolStripButton_Save, toolStripButton_SaveAs, toolStripSeparator2, toolStripComboBox_Font, toolStripSeparator3, toolStripComboBox_Size, toolStripSeparator4, toolStripButt_Bold, toolStripButt_Italic, StripButt_Underline, toolStripButt_Strike, toolStripSeparator5, toolStripButt_FrontColor, toolStripButt_BackFrontColor, toolStripSeparator6, toolStripButton_Copy, toolStripButton_Cut, toolStripSeparator7, toolStripButton_Paste, toolStripButton_PasteAsText, toolStripSeparator10, toolStripButton_clear_all, toolStripTextBox_search, toolStripButton_search, toolStripSeparator8 });
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
            // toolStripComboBox_Font
            // 
            toolStripComboBox_Font.DropDownStyle = ComboBoxStyle.DropDownList;
            toolStripComboBox_Font.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripComboBox_Font.Name = "toolStripComboBox_Font";
            toolStripComboBox_Font.Size = new Size(121, 40);
            toolStripComboBox_Font.SelectedIndexChanged += toolStripComboBox_Font_SelectedIndexChanged;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 40);
            // 
            // toolStripComboBox_Size
            // 
            toolStripComboBox_Size.DropDownStyle = ComboBoxStyle.DropDownList;
            toolStripComboBox_Size.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripComboBox_Size.Name = "toolStripComboBox_Size";
            toolStripComboBox_Size.Size = new Size(121, 40);
            toolStripComboBox_Size.SelectedIndexChanged += toolStripComboBox_Size_SelectedIndexChanged;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 40);
            // 
            // toolStripButt_Bold
            // 
            toolStripButt_Bold.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButt_Bold.Image = (Image)resources.GetObject("toolStripButt_Bold.Image");
            toolStripButt_Bold.ImageTransparentColor = Color.Magenta;
            toolStripButt_Bold.Name = "toolStripButt_Bold";
            toolStripButt_Bold.Size = new Size(28, 37);
            toolStripButt_Bold.Text = "Bold Font";
            toolStripButt_Bold.Click += toolStripButt_Bold_Click;
            // 
            // toolStripButt_Italic
            // 
            toolStripButt_Italic.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButt_Italic.Image = Properties.Resources.italic;
            toolStripButt_Italic.ImageTransparentColor = Color.Magenta;
            toolStripButt_Italic.Name = "toolStripButt_Italic";
            toolStripButt_Italic.Size = new Size(28, 37);
            toolStripButt_Italic.Text = "Italic Font";
            // 
            // StripButt_Underline
            // 
            StripButt_Underline.DisplayStyle = ToolStripItemDisplayStyle.Image;
            StripButt_Underline.Image = Properties.Resources.underline1;
            StripButt_Underline.ImageTransparentColor = Color.Magenta;
            StripButt_Underline.Name = "StripButt_Underline";
            StripButt_Underline.Size = new Size(28, 37);
            StripButt_Underline.Text = "Underline Font";
            StripButt_Underline.Click += StripButt_Underline_Click;
            // 
            // toolStripButt_Strike
            // 
            toolStripButt_Strike.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButt_Strike.Image = Properties.Resources.strikeout;
            toolStripButt_Strike.ImageTransparentColor = Color.Magenta;
            toolStripButt_Strike.Name = "toolStripButt_Strike";
            toolStripButt_Strike.Size = new Size(28, 37);
            toolStripButt_Strike.Text = "Strikeout Font";
            toolStripButt_Strike.Click += toolStripButt_Strike_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(6, 40);
            // 
            // toolStripButt_FrontColor
            // 
            toolStripButt_FrontColor.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButt_FrontColor.Image = Properties.Resources.font_сolor1;
            toolStripButt_FrontColor.ImageTransparentColor = Color.Magenta;
            toolStripButt_FrontColor.Name = "toolStripButt_FrontColor";
            toolStripButt_FrontColor.Size = new Size(28, 37);
            toolStripButt_FrontColor.Text = "Font Color";
            toolStripButt_FrontColor.Click += toolStripButt_FrontColor_Click;
            // 
            // toolStripButt_BackFrontColor
            // 
            toolStripButt_BackFrontColor.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButt_BackFrontColor.Image = Properties.Resources.font_background1;
            toolStripButt_BackFrontColor.ImageTransparentColor = Color.Magenta;
            toolStripButt_BackFrontColor.Name = "toolStripButt_BackFrontColor";
            toolStripButt_BackFrontColor.Size = new Size(28, 37);
            toolStripButt_BackFrontColor.Text = "Backgroung Font Color";
            toolStripButt_BackFrontColor.Click += toolStripButt_BackFrontColor_Click;
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(6, 40);
            // 
            // toolStripButton_Copy
            // 
            toolStripButton_Copy.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton_Copy.Image = Properties.Resources.copy1;
            toolStripButton_Copy.ImageTransparentColor = Color.Magenta;
            toolStripButton_Copy.Name = "toolStripButton_Copy";
            toolStripButton_Copy.Size = new Size(28, 37);
            toolStripButton_Copy.Text = "Copy";
            toolStripButton_Copy.Click += copyToolStripMenuItem_Click;
            // 
            // toolStripButton_Cut
            // 
            toolStripButton_Cut.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton_Cut.Image = Properties.Resources.cut;
            toolStripButton_Cut.ImageTransparentColor = Color.Magenta;
            toolStripButton_Cut.Name = "toolStripButton_Cut";
            toolStripButton_Cut.Size = new Size(28, 37);
            toolStripButton_Cut.Text = "Cut";
            toolStripButton_Cut.Click += cutToolStripMenuItem_Click;
            // 
            // toolStripSeparator7
            // 
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new Size(6, 40);
            // 
            // toolStripButton_Paste
            // 
            toolStripButton_Paste.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton_Paste.Image = Properties.Resources.insert;
            toolStripButton_Paste.ImageTransparentColor = Color.Magenta;
            toolStripButton_Paste.Name = "toolStripButton_Paste";
            toolStripButton_Paste.Size = new Size(28, 37);
            toolStripButton_Paste.Text = "Paste";
            toolStripButton_Paste.Click += pasteToolStripMenuItem_Click;
            // 
            // toolStripButton_PasteAsText
            // 
            toolStripButton_PasteAsText.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton_PasteAsText.Image = Properties.Resources.insert_Symb;
            toolStripButton_PasteAsText.ImageTransparentColor = Color.Magenta;
            toolStripButton_PasteAsText.Name = "toolStripButton_PasteAsText";
            toolStripButton_PasteAsText.Size = new Size(28, 37);
            toolStripButton_PasteAsText.Text = "PasteAsText";
            toolStripButton_PasteAsText.Click += pasteAsTextToolStripMenuItem_Click;
            // 
            // toolStripSeparator10
            // 
            toolStripSeparator10.Name = "toolStripSeparator10";
            toolStripSeparator10.Size = new Size(6, 40);
            // 
            // toolStripButton_clear_all
            // 
            toolStripButton_clear_all.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton_clear_all.Image = Properties.Resources.delete;
            toolStripButton_clear_all.ImageTransparentColor = Color.Magenta;
            toolStripButton_clear_all.Name = "toolStripButton_clear_all";
            toolStripButton_clear_all.Size = new Size(28, 37);
            toolStripButton_clear_all.Text = "Clear All";
            toolStripButton_clear_all.Click += toolStripButton_clear_all_Click;
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
            // toolStripSeparator8
            // 
            toolStripSeparator8.Name = "toolStripSeparator8";
            toolStripSeparator8.Size = new Size(6, 40);
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
        private ToolStripComboBox toolStripComboBox_Font;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripComboBox toolStripComboBox_Size;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton toolStripButt_Bold;
        private ToolStripButton toolStripButt_Italic;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripButton StripButt_Underline;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripButton toolStripButt_Strike;
        private ToolStripButton toolStripButt_FrontColor;
        private ToolStripButton toolStripButt_BackFrontColor;
        private ToolStripButton toolStripButton_Copy;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripButton toolStripButton_Cut;
        private ToolStripButton toolStripButton_Paste;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripButton toolStripButton_PasteAsText;
        private ToolStripSeparator toolStripSeparator10;
        private ToolStripButton toolStripButton_clear_all;
    }
}