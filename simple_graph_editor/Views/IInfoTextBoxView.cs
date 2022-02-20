using System;
using System.Collections.Generic;
using System.Text;
using SimpleGraphEditor.Presenters;


namespace SimpleGraphEditor.Views
{
    /// <summary> Interface for informational messages in text view. </summary>
    public interface IInfoTextBoxView {

        /// <summary> Represents node properties presenter.  </summary>
        InfoTextBoxPresenter TextBoxPresenter { get; set; }

        /// <summary> Full message to show. </summary>
        string DataText { get; set; }

        /// <summary> Display informations about mouse position. </summary>
        bool IsMouseCoordsVisible { get; set; }

        void InitializeInfoTextBox();
    }
}
