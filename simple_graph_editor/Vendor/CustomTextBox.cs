using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SimpleGraphEditor.Vendor
{
    public class CustomTextBox : TextBox{
        public CustomTextBox() {
            SetStyle(ControlStyles.SupportsTransparentBackColor |
                        ControlStyles.OptimizedDoubleBuffer |
                        ControlStyles.AllPaintingInWmPaint |
                        ControlStyles.ResizeRedraw |
                        ControlStyles.UserPaint, true);
            BackColor = Color.Transparent;
        }
    }
}
