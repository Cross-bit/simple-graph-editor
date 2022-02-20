using SimpleGraphEditor.GeneralSettings;
using System.Drawing;

namespace SimpleGraphEditor.Models.Interface
{
    /// <summary> Specifice node shape color. </summary>
    public interface INodeTemplate {

        /// <summary> Specifice node shape color. </summary>
        public Color BackColor { get; set; }

        /// <summary> Specifice node border color. </summary>
        public Color BorderColor { get; set; }

        /// <summary> Specifice node border width. </summary>
        public int BorderWidth { get; set; }

        /// <summary> Wheter to render node border. </summary>
        public bool DrawBorder { get; set; }

        /// <summary> Specifice node shape. </summary>
        public Settings.NodeShape Shape { get; set; } // todo: make as object

        /// <summary> Specifice node shape size. </summary>
        public int Size { get; set; }
    }
}
