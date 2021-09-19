using System.Drawing;

namespace SimpleGraphEditor.Models.Interface
{
    public interface IEdgeTemplate {
        Color Color { get; set; }
        bool IsDirected { get; set; }
        int Width { get; set; }
    }
}
