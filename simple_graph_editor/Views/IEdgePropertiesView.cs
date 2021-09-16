using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using SimpleGraphEditor.Presenters;

namespace SimpleGraphEditor.Views
{
    public interface IEdgePropertiesView {
        EdgePropertiesPresenter propPresenter { get; set; }
        Color NewEdgeColor { get; set; }
        bool NewEdgeIsDirected {get; set; }
        int NewEdgeWidth { get; set; }
    }
}
