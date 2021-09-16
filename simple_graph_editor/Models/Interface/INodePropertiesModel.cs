using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace SimpleGraphEditor.Models.Interface
{
    public interface INodePropertiesModel
    {
        Color BackColor { get; set; }
        int NodeSize { get; set; }
        int BorderWidth { get; set; }
        Color BorderColor { get; set; }
        bool IsEnabled { get; set; }

        Settings.NodeShape NodeShape { get; set; }

        //INodeTemplate CurrentData { get; set; } 

    }
}
