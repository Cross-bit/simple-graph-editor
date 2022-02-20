using System;
using System.Collections.Generic;
using System.Text;
using SimpleGraphEditor.Presenters;

namespace SimpleGraphEditor.Views
{
    /// <summary> Represents interface for toolstrip view (typically the bar on top of the application).</summary>
    public interface IToolStripView {
        ToolStripPresenter StripPresenter { get; set; }
        void InitializeToolStrip();
    }
}
