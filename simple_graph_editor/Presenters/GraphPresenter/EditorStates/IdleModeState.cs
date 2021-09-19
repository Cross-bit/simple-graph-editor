using SimpleGraphEditor.Views;
using SimpleGraphEditor.Models;
using SimpleGraphEditor.Models.Interface;

namespace SimpleGraphEditor.Presenters.EditorStates
{
    public class IdleModeState : EditorState
    {
        private GraphPresenter _graphPresenter;
        private IGraphView _graphView;
        private IEditorModel _editorModel;
        private IGraphRepresentation<NodeData, EdgeData> _graphModel;

        private IEdge<EdgeData, NodeData> _selectedEdge = null;
        private INode<NodeData> _selectedNode = null;

        public IdleModeState(GraphPresenter graphPresenter,
            IGraphRepresentation<NodeData, EdgeData> graphModel,
            IGraphView graphView,
            IEditorModel editorModel
            ) : base(graphPresenter, graphView, editorModel)
        {
            _graphPresenter = graphPresenter;
            _graphView = graphView;
            _editorModel = editorModel;
            _graphModel = graphModel;
        }

        public override void OnClientInteract((int x, int y) coords) {
            /*var nodeClientInteracted = _graphModel.GetNodeInRadius(coords, Settings.DefaultNodeRadius); 
            // TODO!!! udělat na zákadě velikosti nodu namísto fix radius!
            IEdge<EdgeData, NodeData> edgeClientInteracted = null;

            if (nodeClientInteracted != null) {
                _editorModel.CurrentNodeTemplate = nodeClientInteracted.Data.Template;
                _graphView.OpenNodeProperties();
                return;
            }

            edgeClientInteracted = _graphModel.GetEdgeOnCoords(coords);
            if (edgeClientInteracted != null) {
                _editorModel.CurrentEdgeTemplate = edgeClientInteracted.Data.Template;
                _graphView.OpenEdgeProperties();
            }*/

        }

        public override void TurnOnIdleMode() { return; }
    }
}
