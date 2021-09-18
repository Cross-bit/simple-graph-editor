using System;
using System.Collections.Generic;
using System.Text;
using SimpleGraphEditor.Models;
using System.Windows.Forms;
using SimpleGraphEditor.Presenters;
using System.Drawing;

namespace SimpleGraphEditor.Views
{
    public interface IGraphView {
        GraphPresenter MainPresenter { set; }
        void AddNodeShape((int x, int y) coordinates);
        void AddEdgeShape((int x, int y) startNodeCoordinates, (int x, int y) endNodeCoordinates);
        void AddElementValueText((int x, int y) textPosition, string nodeData);
        void UpdateCanvas();
        void ClearCanvas();
        void UpdateNodeBrush();
        void UpdateNodePen();
        void UpdateEdgePen();
        void ShowValueInsertionBox((int x, int y) coords, string defaultValue = "");
        void HideValueInsertionBox();
        
        void OpenNodeProperties();
        void OpenEdgeProperties();
        void ClosePropertiesPanel();
        
        // new node template
        int NewNodeBorderWidth { get; set; }
        Color NewNodeBorderColor { get; set; }
        bool NewNodeDrawBorder { get; set; }
        
        Color NewNodeColor { get; set; }
        Color CanvasBackColor { get; }
        int NewNodeSize { get; set; }
        
        // new lable
        public int NewLabelFontSize { get; set; }
        public Color NewLabelFontColor { get; set; }
        string NewLableTextValue { get; set; }
        
        event EventHandler<EventArgs> ClientConfirmedOperation; // something 
        
        Settings.NodeShape NewNodeShape { get; set; }
        bool NewEdgeIsDirected { get; set; }
        Color NewEdgeColor { get; set; }
        int NewEdgeWidth { get; set; }
        (int X, int Y) MouseCoords { get; set; }

    }
}
