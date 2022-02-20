using System.Drawing;
using SimpleGraphEditor.GeneralSettings;
using SimpleGraphEditor.Presenters;

namespace SimpleGraphEditor.Views
{
    /// <summary> Represents node graphics settings (panel properties) in editor.</summary>
    public interface INodePropertiesView {

        /// <summary> Represents node background color user see. </summary>
        Color NewBackColor { get; set; }

        /// <summary> Represents node size that user is currently working with. </summary>
        int NewNodeSize { get; set; }

        /// <summary> Represents border color of node that user is currently working with. </summary>
        Color NewBorderColor { get; set; }

        /// <summary> Represents border width of node that user is currently working with. </summary>
        int NewBorderWidth { get; set; }

        /// <summary> Represents shape of node that user is currently working with. </summary>
        Settings.NodeShape NewNodeShape { get; set; } // todo: by class

        /// <summary> Represents node properties presenter. </summary>
        NodePropertiesPresenter PropertiesPresenter { get; set; }

        /// <summary> Updates all the graphical elements in the view. </summary>
        void UpdatePropertiesControls();
    }
}
