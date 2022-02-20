using System.Drawing;

namespace SimpleGraphEditor.Models.Interface
{
    /// <summary> Interface for graphics of edge line. </summary>
    public interface IEdgeTemplate {

        /// <summary> Specifice edge line color. </summary>
        Color Color { get; set; }

        /// <summary> Specifice whether edge line should be drawn as directed. </summary>
        bool IsDirected { get; set; }

        /// <summary> Specifice edge line width. </summary>
        int Width { get; set; }
    }
}
