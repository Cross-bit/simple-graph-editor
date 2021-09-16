using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using SimpleGraphEditor.Models;
using SimpleGraphEditor.Models.Interface;

using SimpleGraphEditor.Presenters.CanvasRendererMachine;
using SimpleGraphEditor.Views;

namespace SimpleGraphEditor.Presenters.EditorStates
{
    public class EdgeInsertionModeState : EditorState
    {
        private GraphPresenter _graphPresenter;
        private IGraphRepresentation<NodeData, EdgeData> _graphModel;
        private IEditorModel _editorModel;
        private IGraphView _graphView;
        private INode<NodeData> _startEdgeNode = null;
        private INode<NodeData> _endEdgeNode = null;

        public EdgeInsertionModeState(
            GraphPresenter graphPresenter, 
            IGraphRepresentation<NodeData, EdgeData> graphModel,
            IEditorModel editorModel,
            IGraphView graphView ) : base(graphPresenter, graphView, editorModel)
        {

            _graphPresenter = graphPresenter;
            _graphModel = graphModel;
            _editorModel = editorModel;
            _graphView = graphView;
        }

        public override void OnClientInteract((int x, int y) coords) {

            var nodeClientInteracted = _graphModel.GetNodeInRadius(coords, Settings.DefaultNodeRadius);

            if (nodeClientInteracted == null) return;

            if (_startEdgeNode == null) {
                SetFirstSelectedNode(nodeClientInteracted);
            }
            else if (_endEdgeNode == null 
                && (!_graphModel.AreNodesConectedByEdge(_startEdgeNode, nodeClientInteracted) )) 
            {
                this.PlaceEdgeToGraph(nodeClientInteracted);
            }
        }

        public override void TurnOnDeletationMode() {
            this.ClearEdgeNodesData();
            base.TurnOnDeletationMode();
        }
        public override void TurnOnDragMode() {
            this.ClearEdgeNodesData();
            base.TurnOnDragMode();
        }
        public override void TurnOnEdgeInsertionMode() { return; }
        public override void TurnOnIdleMode() {
            this.ClearEdgeNodesData();
            base.TurnOnIdleMode();
        }
        public override void TurnOnNodeInsertionMode() {
            this.ClearEdgeNodesData();
            base.TurnOnNodeInsertionMode();
        }
        public override void TurnOnValueEditState() {
            this.ClearEdgeNodesData();
            base.TurnOnNodeInsertionMode();
        }

        private void ClearEdgeNodesData() {
            _editorModel.SelectedNode = null;
            (_startEdgeNode, _endEdgeNode) = (null, null);
        }

        private void SetFirstSelectedNode(INode<NodeData> nodeClientInteracted) {
            _startEdgeNode = nodeClientInteracted;
            _editorModel.SelectedNode = nodeClientInteracted;
        }
        private void PlaceEdgeToGraph(INode<NodeData> nodeClientInteracted) {
            _endEdgeNode = nodeClientInteracted;

            var startNodeNeighbours = _graphModel.GraphData[_startEdgeNode];

            _graphPresenter.AddEdge(_startEdgeNode, _endEdgeNode);
            _endEdgeNode = null;
        }

    }
}
