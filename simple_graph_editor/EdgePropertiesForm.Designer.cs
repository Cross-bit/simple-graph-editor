using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleGraphEditor.Presenters;
using SimpleGraphEditor.Views;
using System.Runtime.InteropServices;
using SimpleGraphEditor.Vendor;


namespace SimpleGraphEditor.Views
{
    partial class EdgePropertiesForm
    {

        private void InitializeComponent()
        {
            this.EdgePropertiesPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.NodePropetiesInner1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.EdgeBackColorBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.WidthUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.IsDirectedCheckBox = new System.Windows.Forms.CheckBox();
            this.ColorPicker = new System.Windows.Forms.ColorDialog();
            this.EdgePropertiesPanel.SuspendLayout();
            this.NodePropetiesInner1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WidthUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // EdgePropertiesPanel
            // 
            this.EdgePropertiesPanel.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.EdgePropertiesPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.EdgePropertiesPanel.ColumnCount = 1;
            this.EdgePropertiesPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.EdgePropertiesPanel.Controls.Add(this.label1, 0, 0);
            this.EdgePropertiesPanel.Controls.Add(this.NodePropetiesInner1, 0, 1);
            this.EdgePropertiesPanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.EdgePropertiesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EdgePropertiesPanel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EdgePropertiesPanel.ForeColor = System.Drawing.Color.Coral;
            this.EdgePropertiesPanel.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.EdgePropertiesPanel.Location = new System.Drawing.Point(0, 0);
            this.EdgePropertiesPanel.Name = "EdgePropertiesPanel";
            this.EdgePropertiesPanel.RowCount = 2;
            this.EdgePropertiesPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.EdgePropertiesPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.EdgePropertiesPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.EdgePropertiesPanel.Size = new System.Drawing.Size(260, 379);
            this.EdgePropertiesPanel.TabIndex = 9;
            this.EdgePropertiesPanel.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.EdgeProperties_CellPaint);
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
            this.label1.Size = new System.Drawing.Size(132, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Edge properties";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NodePropetiesInner1
            // 
            this.NodePropetiesInner1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.NodePropetiesInner1.ColumnCount = 2;
            this.NodePropetiesInner1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.66667F));
            this.NodePropetiesInner1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.33333F));
            this.NodePropetiesInner1.Controls.Add(this.label2, 0, 0);
            this.NodePropetiesInner1.Controls.Add(this.EdgeBackColorBtn, 1, 2);
            this.NodePropetiesInner1.Controls.Add(this.label3, 0, 1);
            this.NodePropetiesInner1.Controls.Add(this.WidthUpDown, 1, 1);
            this.NodePropetiesInner1.Controls.Add(this.label4, 0, 2);
            this.NodePropetiesInner1.Controls.Add(this.IsDirectedCheckBox, 1, 0);
            this.NodePropetiesInner1.Dock = System.Windows.Forms.DockStyle.Top;
            this.NodePropetiesInner1.Location = new System.Drawing.Point(3, 43);
            this.NodePropetiesInner1.Name = "NodePropetiesInner1";
            this.NodePropetiesInner1.RowCount = 3;
            this.NodePropetiesInner1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.NodePropetiesInner1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.NodePropetiesInner1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.NodePropetiesInner1.Size = new System.Drawing.Size(254, 124);
            this.NodePropetiesInner1.TabIndex = 2;
            this.NodePropetiesInner1.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.EdgeProperties_CellPaint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 34);
            this.label2.TabIndex = 0;
            this.label2.Text = "Directed:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EdgeBackColorBtn
            // 
            this.EdgeBackColorBtn.BackColor = System.Drawing.Color.Black;
            this.EdgeBackColorBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.EdgeBackColorBtn.FlatAppearance.BorderSize = 0;
            this.EdgeBackColorBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.EdgeBackColorBtn.ForeColor = System.Drawing.Color.Red;
            this.EdgeBackColorBtn.Location = new System.Drawing.Point(110, 85);
            this.EdgeBackColorBtn.Margin = new System.Windows.Forms.Padding(5);
            this.EdgeBackColorBtn.Name = "EdgeBackColorBtn";
            this.EdgeBackColorBtn.Size = new System.Drawing.Size(30, 30);
            this.EdgeBackColorBtn.TabIndex = 0;
            this.EdgeBackColorBtn.UseVisualStyleBackColor = false;
            this.EdgeBackColorBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EdgeBackColorBtn_MouseClick);
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
            this.label3.Size = new System.Drawing.Size(99, 34);
            this.label3.TabIndex = 2;
            this.label3.Text = "Width:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // WidthUpDown
            // 
            this.WidthUpDown.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.WidthUpDown.Dock = System.Windows.Forms.DockStyle.Left;
            this.WidthUpDown.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.WidthUpDown.Location = new System.Drawing.Point(110, 50);
            this.WidthUpDown.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.WidthUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.WidthUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.WidthUpDown.Name = "WidthUpDown";
            this.WidthUpDown.Size = new System.Drawing.Size(40, 25);
            this.WidthUpDown.TabIndex = 3;
            this.WidthUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WidthUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.WidthUpDown.ValueChanged += new System.EventHandler(this.WidthUpDown_ClientEntery);
            this.WidthUpDown.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WidthUpDown_KeyEntry);
            this.WidthUpDown.KeyUp += new System.Windows.Forms.KeyEventHandler(this.WidthUpDown_KeyEntry);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(3, 83);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 38);
            this.label4.TabIndex = 4;
            this.label4.Text = "Color:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // IsDirectedCheckBox
            // 
            this.IsDirectedCheckBox.AutoSize = true;
            this.IsDirectedCheckBox.Checked = true;
            this.IsDirectedCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IsDirectedCheckBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.IsDirectedCheckBox.Location = new System.Drawing.Point(110, 5);
            this.IsDirectedCheckBox.Margin = new System.Windows.Forms.Padding(5);
            this.IsDirectedCheckBox.Name = "IsDirectedCheckBox";
            this.IsDirectedCheckBox.Size = new System.Drawing.Size(15, 30);
            this.IsDirectedCheckBox.TabIndex = 9;
            this.IsDirectedCheckBox.UseVisualStyleBackColor = true;
            this.IsDirectedCheckBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.IsDirectedCheckBox_MouseClick);
            // 
            // EdgePropertiesForm
            // 
            this.ClientSize = new System.Drawing.Size(260, 379);
            this.Controls.Add(this.EdgePropertiesPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EdgePropertiesForm";
            this.EdgePropertiesPanel.ResumeLayout(false);
            this.EdgePropertiesPanel.PerformLayout();
            this.NodePropetiesInner1.ResumeLayout(false);
            this.NodePropetiesInner1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WidthUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        private TableLayoutPanel EdgePropertiesPanel;
        private Label label1;
        private TableLayoutPanel NodePropetiesInner1;
        private Label label2;
        private Button NdBackColorBtn;
        private Label label3;
        private NumericUpDown WidthUpDown;
        private Label label4;
        private CheckBox IsDirectedCheckBox;
        private ColorDialog ColorPicker;
        private Button EdgeBackColorBtn;
    }
}
