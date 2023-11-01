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
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripTextBox_search, toolStripButton_search });
            toolStrip1.Location = new Point(0, 24);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(926, 40);
            toolStrip1.Stretch = true;
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
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
    }
}