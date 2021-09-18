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
        public string DataText { get; set; }
        public bool IsMouseCoordsVisible { get; set; } = true;
        public InfoTextBoxPresenter TextBoxPresenter { get; set; }

        public void InitializeInfoTextBox() {
            InfoTextBox.Parent = MainCanvas;
            InfoTextBox.BackColor = Color.Transparent;
            
        }

        private void InfoTextBoxPaint(object sender, EventArgs e) {
            if(IsMouseCoordsVisible)
                InfoTextBox.Text = this.DataText;
        }
    }
}
