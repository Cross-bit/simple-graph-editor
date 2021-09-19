using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SimpleGraphEditor.Models
{
    public class EdgeTemplate : IEdgeTemplate, ICloneable
    {
        public Color Color { get; set; } = Settings.DefaultEdgeColor;
        public bool IsDirected { get; set; } = Settings.IsEdgeDirectedDefault;
        public int Width { get; set; } = Settings.DefaultEdgeWidth;

        public object Clone() {
            return this.MemberwiseClone();
        }
    }
}
