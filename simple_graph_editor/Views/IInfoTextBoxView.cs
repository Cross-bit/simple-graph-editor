using System;
using System.Collections.Generic;
using System.Text;
using SimpleGraphEditor.Presenters;


namespace SimpleGraphEditor.Views
{
    public interface IInfoTextBoxView {
        InfoTextBoxPresenter textBoxPresenter { get; set; }
        string MoouseCoordsText { get; set; }
        bool IsMouseCoordsVisible { get; set; }
    }
}
