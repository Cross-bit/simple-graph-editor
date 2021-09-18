
namespace SimpleGraphEditor
{
    partial class EditorForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorForm));
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.ToolStripTop = new System.Windows.Forms.ToolStrip();
            this.FileDropDown = new System.Windows.Forms.ToolStripDropDownButton();
            this.FileExport = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportEdgeListBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportAdjacencyListBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportScreenshotBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.DrawPanel = new System.Windows.Forms.Panel();
            this.InfoTextBox = new System.Windows.Forms.Label();
            this.MainCanvas = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.MoveNodeBtn = new System.Windows.Forms.Button();
            this.EraseBtn = new System.Windows.Forms.Button();
            this.AddNodeBtn = new System.Windows.Forms.Button();
            this.AddEdgeBtn = new System.Windows.Forms.Button();
            this.InsertValueBtn = new System.Windows.Forms.Button();
            this.UndoBtn = new System.Windows.Forms.Button();
            this.RedoBtn = new System.Windows.Forms.Button();
            this.BackgroundColorBtn = new System.Windows.Forms.Button();
            this.PropertiesPanel = new System.Windows.Forms.Panel();
            this.ColorDialog = new System.Windows.Forms.ColorDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ToolStripTop.SuspendLayout();
            this.DrawPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainCanvas)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolStripTop
            // 
            this.ToolStripTop.AllowDrop = true;
            this.ToolStripTop.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ToolStripTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileDropDown});
            this.ToolStripTop.Location = new System.Drawing.Point(0, 0);
            this.ToolStripTop.Name = "ToolStripTop";
            this.ToolStripTop.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ToolStripTop.Size = new System.Drawing.Size(1159, 25);
            this.ToolStripTop.TabIndex = 0;
            this.ToolStripTop.Text = "ToolStrip";
            // 
            // FileDropDown
            // 
            this.FileDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.FileDropDown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileExport});
            this.FileDropDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FileDropDown.Name = "FileDropDown";
            this.FileDropDown.Size = new System.Drawing.Size(38, 22);
            this.FileDropDown.Text = "File";
            this.FileDropDown.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // FileExport
            // 
            this.FileExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExportEdgeListBtn,
            this.ExportAdjacencyListBtn,
            this.ExportScreenshotBtn});
            this.FileExport.Name = "FileExport";
            this.FileExport.Size = new System.Drawing.Size(108, 22);
            this.FileExport.Text = "Export";
            // 
            // ExportEdgeListBtn
            // 
            this.ExportEdgeListBtn.Image = ((System.Drawing.Image)(resources.GetObject("ExportEdgeListBtn.Image")));
            this.ExportEdgeListBtn.Name = "ExportEdgeListBtn";
            this.ExportEdgeListBtn.Size = new System.Drawing.Size(150, 22);
            this.ExportEdgeListBtn.Text = "Edge List";
            // 
            // ExportAdjacencyListBtn
            // 
            this.ExportAdjacencyListBtn.Image = ((System.Drawing.Image)(resources.GetObject("ExportAdjacencyListBtn.Image")));
            this.ExportAdjacencyListBtn.Name = "ExportAdjacencyListBtn";
            this.ExportAdjacencyListBtn.Size = new System.Drawing.Size(150, 22);
            this.ExportAdjacencyListBtn.Text = "Adjacency List";
            // 
            // ExportScreenshotBtn
            // 
            this.ExportScreenshotBtn.Image = ((System.Drawing.Image)(resources.GetObject("ExportScreenshotBtn.Image")));
            this.ExportScreenshotBtn.Name = "ExportScreenshotBtn";
            this.ExportScreenshotBtn.Size = new System.Drawing.Size(150, 22);
            this.ExportScreenshotBtn.Text = "Screenshot";
            // 
            // DrawPanel
            // 
            this.DrawPanel.AutoSize = true;
            this.DrawPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DrawPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.DrawPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DrawPanel.Controls.Add(this.InfoTextBox);
            this.DrawPanel.Controls.Add(this.MainCanvas);
            this.DrawPanel.Controls.Add(this.flowLayoutPanel1);
            this.DrawPanel.Controls.Add(this.PropertiesPanel);
            this.DrawPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DrawPanel.Location = new System.Drawing.Point(0, 25);
            this.DrawPanel.Name = "DrawPanel";
            this.DrawPanel.Size = new System.Drawing.Size(1159, 496);
            this.DrawPanel.TabIndex = 1;
            // 
            // InfoTextBox
            // 
            this.InfoTextBox.AutoSize = true;
            this.InfoTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.InfoTextBox.Location = new System.Drawing.Point(0, 479);
            this.InfoTextBox.Name = "InfoTextBox";
            this.InfoTextBox.Size = new System.Drawing.Size(53, 15);
            this.InfoTextBox.TabIndex = 2;
            this.InfoTextBox.Text = "Position:";
            this.InfoTextBox.Paint += new System.Windows.Forms.PaintEventHandler(this.InfoTextBoxPaint);
            // 
            // MainCanvas
            // 
            this.MainCanvas.BackColor = System.Drawing.SystemColors.Window;
            this.MainCanvas.Cursor = System.Windows.Forms.Cursors.Cross;
            this.MainCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainCanvas.Location = new System.Drawing.Point(0, 0);
            this.MainCanvas.Name = "MainCanvas";
            this.MainCanvas.Size = new System.Drawing.Size(917, 494);
            this.MainCanvas.TabIndex = 0;
            this.MainCanvas.TabStop = false;
            this.MainCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.MainDrawSpace_Paint);
            this.MainCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MainCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScrollMargin = new System.Drawing.Size(5, 5);
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Gray;
            this.flowLayoutPanel1.Controls.Add(this.MoveNodeBtn);
            this.flowLayoutPanel1.Controls.Add(this.EraseBtn);
            this.flowLayoutPanel1.Controls.Add(this.AddNodeBtn);
            this.flowLayoutPanel1.Controls.Add(this.AddEdgeBtn);
            this.flowLayoutPanel1.Controls.Add(this.InsertValueBtn);
            this.flowLayoutPanel1.Controls.Add(this.UndoBtn);
            this.flowLayoutPanel1.Controls.Add(this.RedoBtn);
            this.flowLayoutPanel1.Controls.Add(this.BackgroundColorBtn);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(917, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(40, 494);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // MoveNodeBtn
            // 
            this.MoveNodeBtn.BackColor = System.Drawing.Color.Transparent;
            this.MoveNodeBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MoveNodeBtn.BackgroundImage")));
            this.MoveNodeBtn.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.MoveNodeBtn.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.MoveNodeBtn.FlatAppearance.BorderSize = 0;
            this.MoveNodeBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.MoveNodeBtn.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.WindowFrame;
            this.MoveNodeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MoveNodeBtn.Font = new System.Drawing.Font("Permanent Marker", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MoveNodeBtn.ForeColor = System.Drawing.Color.White;
            this.MoveNodeBtn.Image = ((System.Drawing.Image)(resources.GetObject("MoveNodeBtn.Image")));
            this.MoveNodeBtn.Location = new System.Drawing.Point(5, 10);
            this.MoveNodeBtn.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.MoveNodeBtn.Name = "MoveNodeBtn";
            this.MoveNodeBtn.Padding = new System.Windows.Forms.Padding(3);
            this.MoveNodeBtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.MoveNodeBtn.Size = new System.Drawing.Size(32, 32);
            this.MoveNodeBtn.TabIndex = 0;
            this.MoveNodeBtn.UseVisualStyleBackColor = false;
            this.MoveNodeBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MoveNodeBtn_MouseClick);
            // 
            // EraseBtn
            // 
            this.EraseBtn.BackColor = System.Drawing.Color.Transparent;
            this.EraseBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("EraseBtn.BackgroundImage")));
            this.EraseBtn.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.EraseBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.EraseBtn.FlatAppearance.BorderSize = 0;
            this.EraseBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.EraseBtn.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.WindowFrame;
            this.EraseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EraseBtn.Font = new System.Drawing.Font("Permanent Marker", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EraseBtn.ForeColor = System.Drawing.Color.White;
            this.EraseBtn.Image = ((System.Drawing.Image)(resources.GetObject("EraseBtn.Image")));
            this.EraseBtn.Location = new System.Drawing.Point(5, 57);
            this.EraseBtn.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.EraseBtn.Name = "EraseBtn";
            this.EraseBtn.Padding = new System.Windows.Forms.Padding(3);
            this.EraseBtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.EraseBtn.Size = new System.Drawing.Size(32, 32);
            this.EraseBtn.TabIndex = 3;
            this.EraseBtn.UseVisualStyleBackColor = false;
            this.EraseBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EraseBtn_MouseClick);
            // 
            // AddNodeBtn
            // 
            this.AddNodeBtn.BackColor = System.Drawing.Color.Transparent;
            this.AddNodeBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AddNodeBtn.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.AddNodeBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.AddNodeBtn.FlatAppearance.BorderSize = 0;
            this.AddNodeBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.AddNodeBtn.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.WindowFrame;
            this.AddNodeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddNodeBtn.Font = new System.Drawing.Font("Permanent Marker", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AddNodeBtn.ForeColor = System.Drawing.Color.White;
            this.AddNodeBtn.Image = ((System.Drawing.Image)(resources.GetObject("AddNodeBtn.Image")));
            this.AddNodeBtn.Location = new System.Drawing.Point(5, 104);
            this.AddNodeBtn.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.AddNodeBtn.Name = "AddNodeBtn";
            this.AddNodeBtn.Padding = new System.Windows.Forms.Padding(3);
            this.AddNodeBtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.AddNodeBtn.Size = new System.Drawing.Size(32, 32);
            this.AddNodeBtn.TabIndex = 1;
            this.AddNodeBtn.UseVisualStyleBackColor = false;
            this.AddNodeBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AddNodeBtn_MouseClick);
            // 
            // AddEdgeBtn
            // 
            this.AddEdgeBtn.BackColor = System.Drawing.Color.Transparent;
            this.AddEdgeBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AddEdgeBtn.BackgroundImage")));
            this.AddEdgeBtn.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.AddEdgeBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.AddEdgeBtn.FlatAppearance.BorderSize = 0;
            this.AddEdgeBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.AddEdgeBtn.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.WindowFrame;
            this.AddEdgeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddEdgeBtn.Font = new System.Drawing.Font("Permanent Marker", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AddEdgeBtn.ForeColor = System.Drawing.Color.White;
            this.AddEdgeBtn.Image = ((System.Drawing.Image)(resources.GetObject("AddEdgeBtn.Image")));
            this.AddEdgeBtn.Location = new System.Drawing.Point(5, 151);
            this.AddEdgeBtn.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.AddEdgeBtn.Name = "AddEdgeBtn";
            this.AddEdgeBtn.Padding = new System.Windows.Forms.Padding(3);
            this.AddEdgeBtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.AddEdgeBtn.Size = new System.Drawing.Size(32, 32);
            this.AddEdgeBtn.TabIndex = 2;
            this.AddEdgeBtn.UseVisualStyleBackColor = false;
            this.AddEdgeBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AddEdgeBtn_MouseClick);
            // 
            // InsertValueBtn
            // 
            this.InsertValueBtn.BackColor = System.Drawing.Color.Transparent;
            this.InsertValueBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("InsertValueBtn.BackgroundImage")));
            this.InsertValueBtn.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.InsertValueBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.InsertValueBtn.FlatAppearance.BorderSize = 0;
            this.InsertValueBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.InsertValueBtn.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.WindowFrame;
            this.InsertValueBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InsertValueBtn.Font = new System.Drawing.Font("Permanent Marker", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.InsertValueBtn.ForeColor = System.Drawing.Color.White;
            this.InsertValueBtn.Image = ((System.Drawing.Image)(resources.GetObject("InsertValueBtn.Image")));
            this.InsertValueBtn.Location = new System.Drawing.Point(5, 198);
            this.InsertValueBtn.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.InsertValueBtn.Name = "InsertValueBtn";
            this.InsertValueBtn.Padding = new System.Windows.Forms.Padding(3);
            this.InsertValueBtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.InsertValueBtn.Size = new System.Drawing.Size(32, 32);
            this.InsertValueBtn.TabIndex = 4;
            this.InsertValueBtn.UseVisualStyleBackColor = false;
            this.InsertValueBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.InsertValueBtn_MouseClick);
            // 
            // UndoBtn
            // 
            this.UndoBtn.BackColor = System.Drawing.Color.Transparent;
            this.UndoBtn.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.UndoBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.UndoBtn.FlatAppearance.BorderSize = 0;
            this.UndoBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.UndoBtn.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.WindowFrame;
            this.UndoBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UndoBtn.Font = new System.Drawing.Font("Permanent Marker", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.UndoBtn.ForeColor = System.Drawing.Color.White;
            this.UndoBtn.Image = ((System.Drawing.Image)(resources.GetObject("UndoBtn.Image")));
            this.UndoBtn.Location = new System.Drawing.Point(5, 245);
            this.UndoBtn.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.UndoBtn.Name = "UndoBtn";
            this.UndoBtn.Padding = new System.Windows.Forms.Padding(3);
            this.UndoBtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.UndoBtn.Size = new System.Drawing.Size(32, 32);
            this.UndoBtn.TabIndex = 5;
            this.UndoBtn.UseVisualStyleBackColor = false;
            this.UndoBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UndoBtn_MouseClick);
            // 
            // RedoBtn
            // 
            this.RedoBtn.BackColor = System.Drawing.Color.Transparent;
            this.RedoBtn.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.RedoBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.RedoBtn.FlatAppearance.BorderSize = 0;
            this.RedoBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.RedoBtn.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.WindowFrame;
            this.RedoBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RedoBtn.Font = new System.Drawing.Font("Permanent Marker", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RedoBtn.ForeColor = System.Drawing.Color.White;
            this.RedoBtn.Image = ((System.Drawing.Image)(resources.GetObject("RedoBtn.Image")));
            this.RedoBtn.Location = new System.Drawing.Point(5, 292);
            this.RedoBtn.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.RedoBtn.Name = "RedoBtn";
            this.RedoBtn.Padding = new System.Windows.Forms.Padding(3);
            this.RedoBtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RedoBtn.Size = new System.Drawing.Size(32, 32);
            this.RedoBtn.TabIndex = 6;
            this.RedoBtn.UseVisualStyleBackColor = false;
            this.RedoBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RedoBtn_MouseClick);
            // 
            // BackgroundColorBtn
            // 
            this.BackgroundColorBtn.BackColor = System.Drawing.Color.White;
            this.BackgroundColorBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BackgroundColorBtn.FlatAppearance.BorderSize = 0;
            this.BackgroundColorBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BackgroundColorBtn.ForeColor = System.Drawing.Color.Red;
            this.BackgroundColorBtn.Location = new System.Drawing.Point(5, 334);
            this.BackgroundColorBtn.Margin = new System.Windows.Forms.Padding(5);
            this.BackgroundColorBtn.Name = "BackgroundColorBtn";
            this.BackgroundColorBtn.Size = new System.Drawing.Size(30, 30);
            this.BackgroundColorBtn.TabIndex = 7;
            this.BackgroundColorBtn.UseVisualStyleBackColor = false;
            this.BackgroundColorBtn.Click += new System.EventHandler(this.BackgroundColorBtn_Click);
            // 
            // PropertiesPanel
            // 
            this.PropertiesPanel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.PropertiesPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.PropertiesPanel.Location = new System.Drawing.Point(957, 0);
            this.PropertiesPanel.Name = "PropertiesPanel";
            this.PropertiesPanel.Size = new System.Drawing.Size(200, 494);
            this.PropertiesPanel.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(1019, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 2;
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1159, 521);
            this.Controls.Add(this.DrawPanel);
            this.Controls.Add(this.ToolStripTop);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditorForm";
            this.Text = "GraphToTex";
            this.TransparencyKey = System.Drawing.Color.DimGray;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.ToolStripTop.ResumeLayout(false);
            this.ToolStripTop.PerformLayout();
            this.DrawPanel.ResumeLayout(false);
            this.DrawPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainCanvas)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.ToolStrip ToolStripTop;
        private System.Windows.Forms.Panel DrawPanel;
        private System.Windows.Forms.PictureBox MainCanvas;
        private System.Windows.Forms.Button MoveNodeBtn;
        private System.Windows.Forms.Label InfoTextBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button AddNodeBtn;
        private System.Windows.Forms.Button AddEdgeBtn;
        private System.Windows.Forms.Button EraseBtn;
        private System.Windows.Forms.Button InsertValueBtn;
        private System.Windows.Forms.ColorDialog ColorDialog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button UndoBtn;
        private System.Windows.Forms.Button RedoBtn;
        private System.Windows.Forms.Panel PropertiesPanel;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripDropDownButton FileDropDown;
        private System.Windows.Forms.ToolStripMenuItem FileExport;
        private System.Windows.Forms.ToolStripMenuItem ExportEdgeListBtn;
        private System.Windows.Forms.ToolStripMenuItem ExportAdjacencyListBtn;
        private System.Windows.Forms.ToolStripMenuItem ExportScreenshotBtn;
        private System.Windows.Forms.Button BackgroundColorBtn;
    }
}

