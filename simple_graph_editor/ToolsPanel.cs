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

namespace SimpleGraphEditor
{

    [System.ComponentModel.DesignerCategory("")]
    class Dummy1 { }

    // toolsPanel
    partial class EditorForm : System.Windows.Forms.Form, IToolsPanelView  {

        ToolTip NodeBtnToolTip = new ToolTip();

        private ColorDialog _colorPicker = new ColorDialog();

        public void InitializeToolsPanel() {
            NodeBtnToolTip.SetToolTip(AddNodeBtn, "Add node to graph." );
            NodeBtnToolTip.SetToolTip(AddEdgeBtn, "Add edge to graph.");
            NodeBtnToolTip.SetToolTip(MoveNodeBtn, "Move node.");
            NodeBtnToolTip.SetToolTip(EraseBtn, "Erase from graph.");
            NodeBtnToolTip.SetToolTip(InsertValueBtn, "Insert value.");
            NodeBtnToolTip.SetToolTip(UndoBtn, "Undo (ctrl + z)");
            NodeBtnToolTip.SetToolTip(RedoBtn, "Redo (ctrl + y)");
            NodeBtnToolTip.SetToolTip(BackgroundColorBtn, "Set background color.");
        }

        private void MoveNodeBtn_MouseClick(object sender, MouseEventArgs e) {
            MainPresenter.EditorMachine.CurrentState.TurnOnDragMode();
        }

        private void AddNodeBtn_MouseClick(object sender, MouseEventArgs e) {
            MainPresenter.EditorMachine.CurrentState.TurnOnNodeInsertionMode();
        }

        private void AddEdgeBtn_MouseClick(object sender, MouseEventArgs e) {
            MainPresenter.EditorMachine.CurrentState.TurnOnEdgeInsertionMode();
        }

        private void EraseBtn_MouseClick(object sender, MouseEventArgs e) {
            MainPresenter.EditorMachine.CurrentState.TurnOnDeletationMode();
        }

        private void InsertValueBtn_MouseClick(object sender, MouseEventArgs e) {
            MainPresenter.EditorMachine.CurrentState.TurnOnValueEditState();
        }

        private void UndoBtn_MouseClick(object sender, MouseEventArgs e) {
            MainPresenter.EditorMachine.CurrentState.TurnOnIdleMode();
            MainPresenter.MoveInGraphsHistory(GraphPresenter.HistoryMoveDir.backward);
            UpdateCanvas();
        }

        private void RedoBtn_MouseClick(object sender, MouseEventArgs e) {
            MainPresenter.EditorMachine.CurrentState.TurnOnIdleMode();
            MainPresenter.MoveInGraphsHistory(GraphPresenter.HistoryMoveDir.forward);
            UpdateCanvas();
        }

        private void EdgeProperties_CellPaint(object sender, TableLayoutCellPaintEventArgs e) {
            RenderTablePanelBorders((TableLayoutPanel)sender, e, 3, Color.FromArgb(45, 45, 45));
        }

        private void RenderTablePanelBorders(TableLayoutPanel panel, TableLayoutCellPaintEventArgs e, int borderWidth, Color borderColor) {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            var rectangle = e.CellBounds;
            using (var pen = new Pen(borderColor, borderWidth)) {
                pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

                if (e.Row == (panel.RowCount - 1))
                {
                    rectangle.Height -= 1;
                }

                if (e.Column == (panel.ColumnCount - 1))
                {
                    rectangle.Width -= 1;
                }

                e.Graphics.DrawRectangle(pen, rectangle);
            }
        }

        private void BackgroundColorBtn_Click(object sender, EventArgs e) {

            if (_colorPicker.ShowDialog(this) == DialogResult.OK) {
                BackgroundColorBtn.BackColor = _colorPicker.Color;
                CanvasBackColor = _colorPicker.Color;
                UpdateCanvas();
            }
        }

    }
}
