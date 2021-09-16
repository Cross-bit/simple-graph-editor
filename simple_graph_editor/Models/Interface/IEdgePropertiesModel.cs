using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;


namespace SimpleGraphEditor.Models.Interface
{
    public interface IEdgePropertiesModel  {
        Color LineColor { get; set; }
        int LineWidth { get; set; }
        bool IsDirected { get; set; }

    }
}
