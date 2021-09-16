using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using SimpleGraphEditor.Presenters;
using SimpleGraphEditor.Views;
using System.Drawing;

namespace SimpleGraphEditor
{
    [System.ComponentModel.DesignerCategory("")]
    class Dummy3 { }

    public partial class EditorForm : System.Windows.Forms.Form, IInfoTextBoxView {
        public string MoouseCoordsText { get; set; }
        public bool IsMouseCoordsVisible { get; set; } // TODO: možná odstranit asi nebudu implementovat...
        public InfoTextBoxPresenter textBoxPresenter { get; set; }

        public void InitializeInfoTextBox() {
            InfoTextBox.Parent = MainCanvas;
            InfoTextBox.BackColor = Color.Transparent;
            
        }

        public void InfoTextBoxPaint(object sender, EventArgs e) {
            InfoTextBox.Text = this.MoouseCoordsText;
        }
    }
}
