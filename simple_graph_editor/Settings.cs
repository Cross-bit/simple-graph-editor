using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;


namespace SimpleGraphEditor
{
    public static class Settings
    {
        #region defalut canvas settings
        public static readonly Color CanvasDefaultColor = Color.White;
        #endregion

        #region defalut node settings
        public enum NodeShape { Circle, Square };
        public static readonly Color DefaultNodeColor = Color.Red;
        public static readonly Color DefaultNodeBorderColor = Color.Black;
        public static readonly int DefaultNodeRadius = 40;
        public static readonly int DefaultNodeBorderWidth = 2;
        #endregion

        #region defalult edge settings
        public static readonly Color DefaultEdgeColor = Color.Black;
        public static readonly int EdgeSelectionTolerancCoef = 2;
        public static readonly int DefaultEdgeWidth = 2;
        public static readonly bool IsEdgeDirectedDefault = true;
        #endregion

        #region default lable settings
        public static readonly string DefaultLableFont = "Arial";
        public static readonly Color DefaultLableColor = Color.Black;
        public static readonly int DefaultLableFontSize = 13;
        public static readonly int DefaultLableDistFromEdge = 20;
        #endregion

    }
}
