using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace SimpleGraphEditor.Models.Interface
{
    /// <summary> Interface for grafical representation of text lable of drawn objects. </summary>
    public interface IValueLabelTemplate {

        /// <summary> Specifice lable position. </summary>
        (int x, int y) Coords { get; set; }

        /// <summary> Specifice lable font color. </summary>
        Color fontColor { get; set; }

        /// <summary> Specifice lable font size. </summary>
        int fontSize { get; set; }
    }
}
