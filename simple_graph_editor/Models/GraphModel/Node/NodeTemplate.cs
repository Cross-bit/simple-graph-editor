using System;
using System.Drawing;
using SimpleGraphEditor.Models.Interface;
using SimpleGraphEditor.GeneralSettings;

namespace SimpleGraphEditor.Models
{
    public class NodeTemplate : INodeTemplate, ICloneable
    {
        public Color BackColor { get; set; } = Settings.DefaultNodeColor;
        public Color BorderColor { get; set; } = Settings.DefaultNodeBorderColor;
        public Settings.NodeShape Shape { get; set; } = Settings.NodeShape.Circle;
        public int BorderWidth { get; set; } = Settings.DefaultNodeBorderWidth;
        public bool DrawBorder { get; set; } = false;
        public int Size { get; set; } = Settings.DefaultNodeRadius;

        public object Clone() {
            return this.MemberwiseClone();
        }
    }
}
