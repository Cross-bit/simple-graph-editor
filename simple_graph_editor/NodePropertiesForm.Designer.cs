using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleGraphEditor
{
    partial class NodePropertiesForm
    {

        private void InitializeComponent()
        {
            this.NodePropertiesPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.NodePropetiesInner1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.NdBackColorBtn = new System.Windows.Forms.Button();
            this.ShapeSelection = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SizeUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.NdBorderColorBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.BorderWidthUpDown = new System.Windows.Forms.NumericUpDown();
            this.NodePropertiesPanel.SuspendLayout();
            this.NodePropetiesInner1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SizeUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BorderWidthUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // NodePropertiesPanel
            // 
            this.NodePropertiesPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.NodePropertiesPanel.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.NodePropertiesPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.NodePropertiesPanel.ColumnCount = 1;
            this.NodePropertiesPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.NodePropertiesPanel.Controls.Add(this.label1, 0, 0);
            this.NodePropertiesPanel.Controls.Add(this.NodePropetiesInner1, 0, 1);
            this.NodePropertiesPanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.NodePropertiesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NodePropertiesPanel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NodePropertiesPanel.ForeColor = System.Drawing.Color.Coral;
            this.NodePropertiesPanel.Location = new System.Drawing.Point(0, 0);
            this.NodePropertiesPanel.Margin = new System.Windows.Forms.Padding(4);
            this.NodePropertiesPanel.Name = "NodePropertiesPanel";
            this.NodePropertiesPanel.RowCount = 2;
            this.NodePropertiesPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.NodePropertiesPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.NodePropertiesPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.NodePropertiesPanel.Size = new System.Drawing.Size(284, 398);
            this.NodePropertiesPanel.TabIndex = 8;
            this.NodePropertiesPanel.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.NodePropeties_CellPaint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Node properties";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NodePropetiesInner1
            // 
            this.NodePropetiesInner1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.NodePropetiesInner1.ColumnCount = 2;
            this.NodePropetiesInner1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.66667F));
            this.NodePropetiesInner1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.33333F));
            this.NodePropetiesInner1.Controls.Add(this.label2, 0, 0);
            this.NodePropetiesInner1.Controls.Add(this.NdBackColorBtn, 1, 2);
            this.NodePropetiesInner1.Controls.Add(this.ShapeSelection, 1, 0);
            this.NodePropetiesInner1.Controls.Add(this.label3, 0, 1);
            this.NodePropetiesInner1.Controls.Add(this.SizeUpDown, 1, 1);
            this.NodePropetiesInner1.Controls.Add(this.label4, 0, 2);
            this.NodePropetiesInner1.Controls.Add(this.label5, 0, 3);
            this.NodePropetiesInner1.Controls.Add(this.NdBorderColorBtn, 1, 3);
            this.NodePropetiesInner1.Controls.Add(this.label6, 0, 4);
            this.NodePropetiesInner1.Controls.Add(this.BorderWidthUpDown, 1, 4);
            this.NodePropetiesInner1.Dock = System.Windows.Forms.DockStyle.Top;
            this.NodePropetiesInner1.Location = new System.Drawing.Point(3, 43);
            this.NodePropetiesInner1.Name = "NodePropetiesInner1";
            this.NodePropetiesInner1.RowCount = 5;
            this.NodePropetiesInner1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.NodePropetiesInner1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.NodePropetiesInner1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.NodePropetiesInner1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.NodePropetiesInner1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.NodePropetiesInner1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.NodePropetiesInner1.Size = new System.Drawing.Size(278, 199);
            this.NodePropetiesInner1.TabIndex = 2;
            this.NodePropetiesInner1.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.NodePropeties_CellPaint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 34);
            this.label2.TabIndex = 0;
            this.label2.Text = "Shape:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NdBackColorBtn
            // 
            this.NdBackColorBtn.BackColor = System.Drawing.Color.Red;
            this.NdBackColorBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.NdBackColorBtn.FlatAppearance.BorderSize = 0;
            this.NdBackColorBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.NdBackColorBtn.ForeColor = System.Drawing.Color.Red;
            this.NdBackColorBtn.Location = new System.Drawing.Point(120, 85);
            this.NdBackColorBtn.Margin = new System.Windows.Forms.Padding(5);
            this.NdBackColorBtn.Name = "NdBackColorBtn";
            this.NdBackColorBtn.Size = new System.Drawing.Size(30, 30);
            this.NdBackColorBtn.TabIndex = 0;
            this.NdBackColorBtn.UseVisualStyleBackColor = false;
            this.NdBackColorBtn.Click += new System.EventHandler(this.NdBackColorBtn_Click);
            // 
            // ShapeSelection
            // 
            this.ShapeSelection.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ShapeSelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShapeSelection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShapeSelection.FormattingEnabled = true;
            this.ShapeSelection.ItemHeight = 15;
            this.ShapeSelection.Location = new System.Drawing.Point(120, 10);
            this.ShapeSelection.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.ShapeSelection.Name = "ShapeSelection";
            this.ShapeSelection.Size = new System.Drawing.Size(153, 23);
            this.ShapeSelection.TabIndex = 1;
            this.ShapeSelection.DropDownClosed += new System.EventHandler(this.ShapeSelection_ClientSelected);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(3, 43);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 34);
            this.label3.TabIndex = 2;
            this.label3.Text = "Size:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SizeUpDown
            // 
            this.SizeUpDown.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.SizeUpDown.Dock = System.Windows.Forms.DockStyle.Left;
            this.SizeUpDown.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SizeUpDown.Location = new System.Drawing.Point(120, 50);
            this.SizeUpDown.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.SizeUpDown.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.SizeUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.SizeUpDown.Name = "SizeUpDown";
            this.SizeUpDown.Size = new System.Drawing.Size(40, 25);
            this.SizeUpDown.TabIndex = 3;
            this.SizeUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SizeUpDown.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.SizeUpDown.ValueChanged += new System.EventHandler(this.SizeUpDown_ValueChanged);
            this.SizeUpDown.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SizeUpDown_ClientEntery);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(3, 83);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 34);
            this.label4.TabIndex = 4;
            this.label4.Text = "Background color:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(3, 123);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 34);
            this.label5.TabIndex = 5;
            this.label5.Text = "Border color:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NdBorderColorBtn
            // 
            this.NdBorderColorBtn.BackColor = System.Drawing.Color.Black;
            this.NdBorderColorBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.NdBorderColorBtn.FlatAppearance.BorderSize = 0;
            this.NdBorderColorBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.NdBorderColorBtn.ForeColor = System.Drawing.Color.RosyBrown;
            this.NdBorderColorBtn.Location = new System.Drawing.Point(120, 125);
            this.NdBorderColorBtn.Margin = new System.Windows.Forms.Padding(5);
            this.NdBorderColorBtn.Name = "NdBorderColorBtn";
            this.NdBorderColorBtn.Size = new System.Drawing.Size(30, 30);
            this.NdBorderColorBtn.TabIndex = 6;
            this.NdBorderColorBtn.UseVisualStyleBackColor = false;
            this.NdBorderColorBtn.Click += new System.EventHandler(this.NdBorderColorBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Location = new System.Drawing.Point(3, 163);
            this.label6.Margin = new System.Windows.Forms.Padding(3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 34);
            this.label6.TabIndex = 7;
            this.label6.Text = "Border width:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BorderWidthUpDown
            // 
            this.BorderWidthUpDown.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.BorderWidthUpDown.Dock = System.Windows.Forms.DockStyle.Left;
            this.BorderWidthUpDown.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BorderWidthUpDown.Location = new System.Drawing.Point(120, 170);
            this.BorderWidthUpDown.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.BorderWidthUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.BorderWidthUpDown.Name = "BorderWidthUpDown";
            this.BorderWidthUpDown.Size = new System.Drawing.Size(40, 25);
            this.BorderWidthUpDown.TabIndex = 8;
            this.BorderWidthUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BorderWidthUpDown.ValueChanged += new System.EventHandler(this.BorderWidthUpDown_ValueChanged);
            // 
            // NodePropertiesForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 398);
            this.Controls.Add(this.NodePropertiesPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NodePropertiesForm";
            this.NodePropertiesPanel.ResumeLayout(false);
            this.NodePropertiesPanel.PerformLayout();
            this.NodePropetiesInner1.ResumeLayout(false);
            this.NodePropetiesInner1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SizeUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BorderWidthUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TableLayoutPanel NodePropertiesPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel NodePropetiesInner1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button NdBackColorBtn;
        private System.Windows.Forms.ComboBox ShapeSelection;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown SizeUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button NdBorderColorBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown BorderWidthUpDown;
    }
}
