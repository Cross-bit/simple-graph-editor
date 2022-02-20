using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleGraphEditor.Models.Interface
{
    public interface IEditorModel {

        /// <summary> Currently selected node by user in the graph representation. </summary>
        INode<NodeData> SelectedNode { get; set; }

        /// <summary> Current node template that is beeing used in application. </summary>
        INodeTemplate CurrentNewNodeTemplate { set; }

        /// <summary> Current edge template that is beeing used in application. </summary>
        IEdgeTemplate CurrentNewEdgeTemplate { set; }

        /// <summary> Current lable template that is beeing used in application. </summary>
        IValueLabelTemplate CurrentNewLableTemplate { set; }

        /// <summary> Mouse position on the canvas. </summary>
        (int X, int Y) CanvasMousePosition { get; }

        void SetMousePosition((int X, int Y) coords);

        void SetActiveObjects(HashSet<(INode<NodeData>, IEdge<EdgeData, NodeData>)> data);

        /// <summary> Creates copy of current node template. </summary>
        INodeTemplate GetCopyOfCurrentNodeTemplate();

        /// <summary> Creates copy of current edge template. </summary>
        IEdgeTemplate GetCopyOfCurrentEdgeTemplate();

        /// <summary> Creates copy of current lable template. </summary>
        IValueLabelTemplate GetCopyOfCurrentLableTemplate();
        event EventHandler<EventArgs> MouseMove;

        /// <summary> Tracks current history state, that happened. </summary>
        string CurrentHistoryState { get; set; }

//        event EventHandler<EditorTemplateChangedEventArgs> TemplateChanged;

    }
}
