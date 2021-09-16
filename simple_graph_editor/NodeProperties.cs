using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

namespace SimpleGraphEditor
{
    public partial class NodeProperties : System.Windows.Forms.Form, INodePropertiesView
    {
        public NodeProperties()  
        {
            InitializeComponent();

            InitializeColorPicker();
            InitializeNodeSelection();
        }

        void InitializeColorPicker() {
            ColorPicker.AllowFullOpen = true;
            ColorPicker.AnyColor = true;
            ColorPicker.SolidColorOnly = false;
        }

        void InitializeNodeSelection() {
            ShapeSelection.Items.Add(Settings.NodeShape.Circle);
            ShapeSelection.SelectedItem = Settings.NodeShape.Circle;
            ShapeSelection.Items.Add(Settings.NodeShape.Square);
            ShapeSelection.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public int NewNodeSize { get; set; } = Settings.DefaultNodeRadius;
        public Color NewBorderColor { get; set; } = Color.Black;
        public Color NewBackColor { get; set; } = Color.Red;
        public int NewBorderWidth { get; set; } = 0;
        public NodePropertiesPresenter propPresenter { get; set; }
        public Settings.NodeShape NewNodeShape { get; set; } = Settings.NodeShape.Circle;

        ColorDialog ColorPicker = new ColorDialog();

        private Color _cellsBorderColor = Color.FromArgb(50, 45, 45, 45);
        private int _cellsBorderWidth = 2; // todo asi do settings

        private void NdBorderColorBtn_Click(object sender, EventArgs e) {
            if (ColorPicker.ShowDialog(this) == DialogResult.OK) {
                NdBorderColorBtn.BackColor = ColorPicker.Color;
                NewBorderColor = ColorPicker.Color;
                UpdateData();
            }
        }

        private void NdBackColorBtn_Click(object sender, EventArgs e) {
            if (ColorPicker.ShowDialog(this) == DialogResult.OK) {
                NdBackColorBtn.BackColor = ColorPicker.Color;
                NewBackColor = ColorPicker.Color;
                UpdateData();
            }
        }
        #region node size control
        private void SizeUpDown_ValueChanged(object sender, EventArgs e) {
            NewNodeSize = (int)SizeUpDown.Value;
            Debug.WriteLine(NewNodeSize);
            UpdateData();
        }
        private void SizeUpDown_ClientEntery(object sender, KeyEventArgs e) {
            NewNodeSize = (int)SizeUpDown.Value;
            UpdateData();
        }
        #endregion

        #region border width control

        private void BorderWidthUpDown_ValueChanged(object sender, EventArgs e) {            
            NewBorderWidth = (int)BorderWidthUpDown.Value;
            UpdateData();
        }
        private void BorderWidthUpDown_ClientEntery(object sender, KeyEventArgs e) {
            NewBorderWidth = (int)BorderWidthUpDown.Value;
            UpdateData();
        }

        #endregion

        private void ShapeSelection_ClientSelected(object sender, EventArgs e) {
            NewNodeShape = (Settings.NodeShape)ShapeSelection.SelectedItem;
            UpdateData();
        }

        private void UpdateData() {
            propPresenter.UpdatePropertiesModel();
            propPresenter.UpdateCurrentTemplate();
        }

        public void UpdatePropertiesUI() {
            ColorPicker.Color = NewBackColor;
            NdBackColorBtn.BackColor = NewBackColor;
            NdBorderColorBtn.BackColor = NewBorderColor;
            SizeUpDown.Value = NewNodeSize;
            BorderWidthUpDown.Value = NewBorderWidth;
            ShapeSelection.SelectedItem = NewNodeShape;
        }

        #region other (e. g. rendering panel cells )

        private void NodePropeties_CellPaint(object sender, TableLayoutCellPaintEventArgs e) {
            // rendering back
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            var rectangle = e.CellBounds;
            using (var pen = new Pen(_cellsBorderColor, _cellsBorderWidth)) {
                pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

                if (e.Row == (((TableLayoutPanel)sender).RowCount - 1)) {
                    rectangle.Height -= 1;
                }

                if (e.Column == (((TableLayoutPanel)sender).ColumnCount - 1)) {
                    rectangle.Width -= 1;
                }

                e.Graphics.DrawRectangle(pen, rectangle);
            }
        }

        #endregion

    }
}
