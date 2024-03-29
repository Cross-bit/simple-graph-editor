﻿using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using SimpleGraphEditor.Presenters;
using SimpleGraphEditor.GeneralSettings;

namespace SimpleGraphEditor.Views
{
    public partial class EdgePropertiesForm : System.Windows.Forms.Form, IEdgePropertiesView
    {
        public GraphPresenter graphPresenter { get; set; }
        public EdgePropertiesPresenter PropertiesPresenter { get; set; }
        public Color NewEdgeColor { get; set; } = Settings.DefaultEdgeColor;
        public bool NewEdgeIsDirected { get; set; } = Settings.IsEdgeDirectedDefault;
        public int NewEdgeWidth { get; set; } = Settings.DefaultEdgeWidth;

        private Color _cellsBorderColor = Settings.EditorColorDarkTransparent1;
        private int _cellsBorderWidth = 2;

        public EdgePropertiesForm() {
            InitializeComponent();
            InitializeColorPicker();
        }

        void InitializeColorPicker() {
            ColorPicker.AllowFullOpen = true;
            ColorPicker.AnyColor = true;
            ColorPicker.SolidColorOnly = false;
        }

        private void IsDirectedCheckBox_MouseClick(object sender, MouseEventArgs e) {
            NewEdgeIsDirected = IsDirectedCheckBox.Checked;
            PropertiesPresenter.UpdateCurrentTemplate();
        }
        private void EdgeBackColorBtn_MouseClick(object sender, MouseEventArgs e) {
            if (ColorPicker.ShowDialog(this) == DialogResult.OK) {
                EdgeBackColorBtn.BackColor = ColorPicker.Color;
                NewEdgeColor = ColorPicker.Color;
                PropertiesPresenter.UpdateCurrentTemplate();
            }
        }
        private void WidthUpDown_ClientEntery(object sender, EventArgs e) {
            NewEdgeWidth = (int) WidthUpDown.Value;
            PropertiesPresenter.UpdateCurrentTemplate();
        }
        private void WidthUpDown_KeyEntry(object sender, KeyEventArgs e) {
            NewEdgeWidth = (int)WidthUpDown.Value;
            PropertiesPresenter.UpdateCurrentTemplate();
        }

        #region other 
        // cells border
        private void EdgeProperties_CellPaint(object sender, TableLayoutCellPaintEventArgs e) {
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
