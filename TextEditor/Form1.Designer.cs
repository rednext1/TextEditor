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
            richTextBox_Main = new RichTextBox();
            contextMenuStrip_richTXTbox = new ContextMenuStrip(components);
            statusStrip1 = new StatusStrip();
            trackBar_Zoom = new TrackBar();
            ((System.ComponentModel.ISupportInitialize)trackBar_Zoom).BeginInit();
            SuspendLayout();
            // 
            // menuStrip_en
            // 
            menuStrip_en.GripStyle = ToolStripGripStyle.Visible;
            menuStrip_en.Location = new Point(0, 0);
            menuStrip_en.Name = "menuStrip_en";
            menuStrip_en.Size = new Size(800, 24);
            menuStrip_en.TabIndex = 0;
            menuStrip_en.Text = "menuStrip1";
            // 
            // toolStrip1
            // 
            toolStrip1.Location = new Point(0, 24);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 25);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // richTextBox_Main
            // 
            richTextBox_Main.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox_Main.Location = new Point(0, 52);
            richTextBox_Main.Name = "richTextBox_Main";
            richTextBox_Main.ScrollBars = RichTextBoxScrollBars.ForcedBoth;
            richTextBox_Main.Size = new Size(749, 373);
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
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // trackBar_Zoom
            // 
            trackBar_Zoom.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            trackBar_Zoom.LargeChange = 1;
            trackBar_Zoom.Location = new Point(755, 52);
            trackBar_Zoom.Name = "trackBar_Zoom";
            trackBar_Zoom.Orientation = Orientation.Vertical;
            trackBar_Zoom.Size = new Size(45, 373);
            trackBar_Zoom.TabIndex = 4;
            // 
            // Main_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}