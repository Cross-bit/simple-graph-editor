using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleGraphEditor.Models.Interface
{
    public interface IEditorModel {

        INode<NodeData> SelectedNode { get; set; }
        INodeTemplate CurrentNewNodeTemplate { set; }
        IEdgeTemplate CurrentNewEdgeTemplate { set; }
        IValueLabelTemplate CurrentNewLableTemplate { set; }
        (int X, int Y) CanvasMousePosition { get; }
        void SetMousePosition((int X, int Y) coords);
        void SetActiveObjects(HashSet<(INode<NodeData>, IEdge<EdgeData, NodeData>)> data);
        INodeTemplate GetCopyOfCurrentNodeTemplate();
        IEdgeTemplate GetCopyOfCurrentEdgeTemplate();
        IValueLabelTemplate GetCopyOfCurrentLableTemplate();
        event EventHandler<EventArgs> MouseMove;
        string CurrentHistoryState { get; set; }

//        event EventHandler<EditorTemplateChangedEventArgs> TemplateChanged;

    }
}
