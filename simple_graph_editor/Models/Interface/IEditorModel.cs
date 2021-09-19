using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleGraphEditor.Models.Interface
{
    public interface IEditorModel {

        INode<NodeData> SelectedNode { get; set; }
        INodeTemplate CurrentNodeTemplate { set; }
        IEdgeTemplate CurrentEdgeTemplate { set; }
        IValueLabelTemplate CurrentLableTemplate { set; }

        (int X, int Y) CanvasMousePosition { get; }
        void OnMousePositionChanged((int X, int Y) coords);
        void SetActiveObjects(HashSet<(INode<NodeData>, IEdge<EdgeData, NodeData>)> data);

        INodeTemplate GetCurrentNodeTemplate();
        IEdgeTemplate GetCurrentEdgeTemplate();

        IValueLabelTemplate GetCurrentLableTemplate();

        event EventHandler<EventArgs> MouseMove;

        event EventHandler<EditorTemplateChangedEventArgs> TemplateChanged;

    }
}
