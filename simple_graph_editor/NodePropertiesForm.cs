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
    public partial class NodePropertiesForm : System.Windows.Forms.Form, INodePropertiesView 
    {
        public NodePropertiesForm() {

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
        public Color NewBackColor { get; set; } = Settings.DefaultNodeColor;
        public Color NewBorderColor { get; set; } = Settings.DefaultNodeBorderColor;
        public int NewBorderWidth { get; set; } = Settings.DefaultNodeBorderWidth;
        public NodePropertiesPresenter PropPresenter { get; set; }
        public Settings.NodeShape NewNodeShape { get; set; } = Settings.NodeShape.Circle;

        ColorDialog ColorPicker = new ColorDialog();

        private Color _cellsBorderColor = Settings.EditorColorDarkTransparent1;
        private int _cellsBorderWidth = 2;

        private void NdBorderColorBtn_Click(object sender, EventArgs e) {
            if (ColorPicker.ShowDialog(this) == DialogResult.OK) {
                NdBorderColorBtn.BackColor = ColorPicker.Color;
                NewBorderColor = ColorPicker.Color;
                PropPresenter.UpdateCurrentTemplate();
            }
        }

        private void NdBackColorBtn_Click(object sender, EventArgs e) {
            if (ColorPicker.ShowDialog(this) == DialogResult.OK) {
                NdBackColorBtn.BackColor = ColorPicker.Color;
                NewBackColor = ColorPicker.Color;
                PropPresenter.UpdateCurrentTemplate();
            }
        }
        #region node size control
        private void SizeUpDown_ValueChanged(object sender, EventArgs e) {
            NewNodeSize = (int)SizeUpDown.Value;
            PropPresenter.UpdateCurrentTemplate();
        }
        private void SizeUpDown_ClientEntery(object sender, KeyEventArgs e) {

        }
        #endregion

        #region border width control

        private void BorderWidthUpDown_ValueChanged(object sender, EventArgs e) {            
            NewBorderWidth = (int)BorderWidthUpDown.Value;
            PropPresenter.UpdateCurrentTemplate();
        }
        private void BorderWidthUpDown_ClientEntry(object sender, KeyEventArgs e) {
            NewBorderWidth = (int)BorderWidthUpDown.Value;
            PropPresenter.UpdateCurrentTemplate();
        }

        #endregion

        private void ShapeSelection_ClientSelected(object sender, EventArgs e) {
            NewNodeShape = (Settings.NodeShape)ShapeSelection.SelectedItem;
            PropPresenter.UpdateCurrentTemplate();
        }

        public void UpdatePropertiesControls() {
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
