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

            _infoTextBoxView.textBoxPresenter = this;
        }

        private void OnMouseMove(object sender, EventArgs e)  {
            BindTextLableAndData();
        }

        public void BindTextLableAndData() {
            // todo: decorator pattern
            var mouseX = _editorModel.CanvasMousePosition.X;
            var mouseY = _editorModel.CanvasMousePosition.Y;

            _stringBuilder.Append("x: ");
            _stringBuilder.Append(mouseX);
            _stringBuilder.Append(" y: ");
            _stringBuilder.Append(mouseY);

            _infoTextBoxView.MoouseCoordsText = _stringBuilder.ToString();
            _stringBuilder.Clear();
        }
    }
}
