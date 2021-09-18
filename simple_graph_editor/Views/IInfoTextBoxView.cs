using System;
using System.Collections.Generic;
using System.Text;
using SimpleGraphEditor.Presenters;


namespace SimpleGraphEditor.Views
{
    public interface IInfoTextBoxView {
        InfoTextBoxPresenter TextBoxPresenter { get; set; }
        string DataText { get; set; }
        bool IsMouseCoordsVisible { get; set; }

        void InitializeInfoTextBox();
    }
}
