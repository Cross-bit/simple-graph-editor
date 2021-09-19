using SimpleGraphEditor.Models;
using SimpleGraphEditor.Models.Interface;
using SimpleGraphEditor.Views;

namespace SimpleGraphEditor.Presenters.EditorStates
{
    public class NodeInsertionModeState : EditorState
    {
        private GraphPresenter _graphPresenter;
        private IGraphRepresentation<NodeData, EdgeData> _graphModel;
        private IGraphView _graphView; 

        public NodeInsertionModeState(GraphPresenter graphPresenter,
            IGraphRepresentation<NodeData, EdgeData> graphModel,
            IGraphView graphView,
            IEditorModel editorModel
            ) : base(graphPresenter, graphView, editorModel)
        {
            _graphPresenter = graphPresenter;
            _graphModel = graphModel;
            _graphView = graphView;
        }

        public override void TurnOnNodeInsertionMode() { return; }

        public override void OnClientInteract((int x, int y) coords) {
            if (_graphModel.GetNodeInRadius(coords, Settings.DefaultNodeRadius) == null) {
                _graphPresenter.AddNode(coords);
            }
        }
    }
}
