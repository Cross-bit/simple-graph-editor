using System;
using System.Drawing;
using SimpleGraphEditor.Models.Interface;

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
