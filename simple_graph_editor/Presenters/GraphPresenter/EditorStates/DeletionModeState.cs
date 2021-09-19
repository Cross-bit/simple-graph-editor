using SimpleGraphEditor.Views;
using SimpleGraphEditor.Models.Interface;

namespace SimpleGraphEditor.Presenters.EditorStates
{
    public class DeletionModeState : EditorState {

        GraphPresenter _graphPresenter;
        IGraphView _graphView;
        IEditorModel _editorModel;
        public DeletionModeState(
            GraphPresenter graphPresenter, 
            IGraphView graphView,
            IEditorModel editorModel
            ) : base (graphPresenter, graphView, editorModel) 
        {
            _graphPresenter = graphPresenter;
            _graphView = graphView;
            _editorModel = editorModel;
        }

        public override void OnClientInteract((int x, int y) coords) {
            // Interacted in this mode? => delete the node...
            _graphPresenter.DeleteNode(coords);
            // ... try if hit an edge
            _graphPresenter.DeleteEdge(coords);
        }
    }
}
