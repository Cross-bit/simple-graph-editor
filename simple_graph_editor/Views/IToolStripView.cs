using System;
using System.Collections.Generic;
using System.Text;
using SimpleGraphEditor.Presenters;

namespace SimpleGraphEditor.Views
{
    public interface IToolStripView {
        ToolStripPresenter StripPresenter { get; set; }

        void InitializeToolStrip();
    }
}
