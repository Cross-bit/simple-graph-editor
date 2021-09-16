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
    class Dummy2 { }
    public partial class EditorForm : System.Windows.Forms.Form {

        private void MainForm_KeyDown(object sender, KeyEventArgs e) {
            
            switch (e.KeyCode) {
                case Keys.D:
                    MainPresenter.EditorMachine.CurrentState.TurnOnDeletationMode();
                    break;
                case Keys.I:
                    MainPresenter.EditorMachine.CurrentState.TurnOnNodeInsertionMode();
                    break;
                case Keys.E:
                    MainPresenter.EditorMachine.CurrentState.TurnOnEdgeInsertionMode();
                    break;
                case Keys.M:
                    MainPresenter.EditorMachine.CurrentState.TurnOnDragMode();
                    break;
                case Keys.W:
                    MainPresenter.EditorMachine.CurrentState.TurnOnValueEditState();
                    break;
                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    OnOperatationConfirmed();

                    break;
                case Keys.Escape:
                    e.SuppressKeyPress = true;
                    MainPresenter.EditorMachine.CurrentState.TurnOnIdleMode();
                    break;
            }

            // back one step
            if (e.KeyCode == Keys.Z && e.Control) {
                MainPresenter.MoveInGraphsHistory(GraphPresenter.HistoryMoveDir.backward);
            }
            else if (e.KeyCode == Keys.Y && e.Control) {
                MainPresenter.MoveInGraphsHistory(GraphPresenter.HistoryMoveDir.forward);
            }

            this.UpdateCanvas();
        }

        protected virtual void OnOperatationConfirmed() =>
            ClientConfirmedOperation?.Invoke(this, EventArgs.Empty);

        /*private void SupressDingSound(KeyEventArgs e) {
            // e.Handled = true;
            //e.SuppressKeyPress = true;
            //Form.AcceptButton
            

        }*/
    }
}
