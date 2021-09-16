using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace SimpleGraphEditor.Models
{
    public interface IEdgeTemplate {
        Color Color { get; set; }
        bool IsDirected { get; set; }
        int Width { get; set; }
    }
}
