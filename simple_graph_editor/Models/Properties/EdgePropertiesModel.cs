using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using SimpleGraphEditor.Models.Interface;


namespace SimpleGraphEditor.Models.Properties
{
    public class EdgePropertiesModel : IEdgePropertiesModel
    {
        public Color LineColor { get; set; }
        public int LineWidth { get; set; }
        public bool IsDirected { get; set; }
    }
}
