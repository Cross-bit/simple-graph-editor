using System;
using System.Drawing;
using SimpleGraphEditor.Models.Interface;

namespace SimpleGraphEditor.Models
{
    public class NodeTemplate : INodeTemplate, ICloneable
    {
        public Color BackColor { get; set; } = Color.Red;
        public Color BorderColor { get; set; } = Color.Black;
        public Settings.NodeShape Shape { get; set; } = Settings.NodeShape.Circle;
        public int BorderWidth { get; set; } = 40;
        public bool DrawBorder { get; set; } = false;
        public int Size { get => _size; set => _size = value; }

        int _size = Settings.DefaultNodeRadius;

        public object Clone() {
            return this.MemberwiseClone();
        }
    }
}
