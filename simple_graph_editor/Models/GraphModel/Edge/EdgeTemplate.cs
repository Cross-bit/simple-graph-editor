using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SimpleGraphEditor.Models
{
    public class EdgeTemplate : IEdgeTemplate, ICloneable
    {
        public Color Color { get; set; } = Color.Black;
        public bool IsDirected { get; set; } = true;
        public int Width { get; set; } = Settings.DefaultEdgeWidth;

        public object Clone() {
            return this.MemberwiseClone();
        }
    }
}
