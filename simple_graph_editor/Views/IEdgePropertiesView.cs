using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using SimpleGraphEditor.Presenters;

namespace SimpleGraphEditor.Views
{
    /// <summary> Represents edge graphics settings (panel properties) in editor.</summary>
    public interface IEdgePropertiesView {
        /// <summary> Presenter responsible for graphical changes. </summary>
        EdgePropertiesPresenter PropertiesPresenter { get; set; }

        /// <summary> Represents new edge line color user see. </summary>
        Color NewEdgeColor { get; set; }

        /// <summary> Whether user choosed to create directed/undirected edge. </summary>
        bool NewEdgeIsDirected {get; set; }

        /// <summary> Represents new edge line color user see. </summary>
        int NewEdgeWidth { get; set; }
    }
}
