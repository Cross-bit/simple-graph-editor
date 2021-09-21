using System;
using System.Collections.Generic;
using System.Text;
using SimpleGraphEditor.Views;
using SimpleGraphEditor.Models;
using SimpleGraphEditor.Models.Interface;
using System.Diagnostics;

namespace SimpleGraphEditor.Presenters
{
    public class InfoTextBoxPresenter
    {

        private IInfoTextBoxView _infoTextBoxView;
        private IEditorModel _editorModel;

        private StringBuilder _stringBuilder = new StringBuilder();

        public InfoTextBoxPresenter(IInfoTextBoxView infoTextBoxView, IEditorModel editorModel) {
            _editorModel = editorModel;
            _editorModel.MouseMove += OnMouseMove;
            _infoTextBoxView = infoTextBoxView;

            _infoTextBoxView.TextBoxPresenter = this;
        }

        private void OnMouseMove(object sender, EventArgs e)  {
            BindTextLableAndData();
        }

        public void BindTextLableAndData() {

            var mouseX = _editorModel.CanvasMousePosition.X;
            var mouseY = _editorModel.CanvasMousePosition.Y;
            // set mouse coords text
            _stringBuilder.Append("x: ");
            _stringBuilder.Append(mouseX);
            _stringBuilder.Append(" y: ");
            _stringBuilder.Append(mouseY);

            _infoTextBoxView.DataText = _stringBuilder.ToString();
            _stringBuilder.Clear();
        }
    }
}
