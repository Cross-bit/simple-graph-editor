using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace SimpleGraphEditor.Models.Interface
{
    public interface IValueLabelTemplate {
        (int x, int y) Coords { get; set; }
        Color fontColor { get; set; }
        int fontSize { get; set; }
    }
}
