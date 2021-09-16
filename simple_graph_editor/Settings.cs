using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;


namespace SimpleGraphEditor
{
    public static class Settings
    {
        public enum NodeShape { Circle, Square };
        
        public static readonly Color CanvasColor = Color.White;

        public static readonly int DefaultEdgeWidth = 2;
        public static readonly bool IsEdgeDirectedDefault = true;

        public static readonly int DefaultLableFontSize = 13;

        public static readonly string DefaultLableFont = "Arial";
        public static readonly Color DefaultLableColor = Color.Black;
        public static readonly int DefaultLableDistFromEdge = 20;

        public static readonly int EdgeSelectionTolerancCoef = 2;
        public static readonly int DefaultNodeRadius = 40; // TODO: linknout v view
    }
}
