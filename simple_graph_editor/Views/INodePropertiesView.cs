using System.Drawing;
using SimpleGraphEditor.GeneralSettings;
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
