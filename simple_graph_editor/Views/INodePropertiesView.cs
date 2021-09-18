using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using SimpleGraphEditor.Models.Interface;
using SimpleGraphEditor.Presenters;

namespace SimpleGraphEditor.Views
{
    public interface INodePropertiesView {
        Color NewBackColor { get; set; }
        int NewNodeSize { get; set; }
        Color NewBorderColor { get; set; }
        int NewBorderWidth { get; set; }
        Settings.NodeShape NewNodeShape { get; set; }

        NodePropertiesPresenter PropPresenter { get; set; }

        void UpdatePropertiesControls();

    }
}
