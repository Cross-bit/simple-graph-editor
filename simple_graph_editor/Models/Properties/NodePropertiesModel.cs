using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using SimpleGraphEditor.Models.Interface;

namespace SimpleGraphEditor.Models.Properties
{
    public class NodePropertiesModel : INodePropertiesModel {
        public Color BackColor { get; set; }
        public int NodeSize { get; set; }
        public int BorderWidth { get; set; }
        public Color BorderColor { get; set; }
        public bool IsEnabled { get; set; }
        public Settings.NodeShape NodeShape { get; set; }
    }
}
