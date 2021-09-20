using SimpleGraphEditor.GeneralSettings;
using System.Drawing;

namespace SimpleGraphEditor.Models.Interface
{
    public interface INodeTemplate {
        public Color BackColor { get; set; }
        public Color BorderColor { get; set; }
        public int BorderWidth { get; set; }
        public bool DrawBorder { get; set; }
        public Settings.NodeShape Shape { get; set; }
        public int Size { get; set; }
    }
}
