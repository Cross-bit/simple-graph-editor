using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using SimpleGraphEditor.Models.Interface;

namespace SimpleGraphEditor.Models
{
    public class LableTemplate : IValueLabelTemplate, ICloneable
    {
        public (int x, int y) Coords { get; set; }
        public Color fontColor { get; set; } = Settings.DefaultLableColor;
        public int fontSize { get; set; } = Settings.DefaultLableFontSize;

        public object Clone() {//shallow copy of data...
            return this.MemberwiseClone();
        }
    }
}
