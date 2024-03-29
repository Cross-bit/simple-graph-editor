﻿using System;
using SimpleGraphEditor.Models;
using SimpleGraphEditor.Models.Interface;
using SimpleGraphEditor.Views;

namespace SimpleGraphEditor.Presenters.EditorStates
{
    public class ValueEditModeState : EditorState
    {
        private GraphPresenter _graphPresenter;
        private IGraphRepresentation<NodeData, EdgeData> _graphModel;
        private IEditorModel _editorModel;
        private IGraphView _graphView;

        private bool _isInsertingValue = false;

        private INode<NodeData> _editedNode = null;
        private IEdge<EdgeData, NodeData> _editedEdge = null;

        public ValueEditModeState (
            GraphPresenter graphPresenter,
            IGraphRepresentation<NodeData, EdgeData> graphModel,
            IEditorModel editorModel,
            IGraphView graphView) : base(graphPresenter, graphView, editorModel)
        {

            _graphPresenter = graphPresenter;
            _editorModel = editorModel;
            _graphModel = graphModel;
            _graphView = graphView;
        }

        public override void OnClientInteract((int x, int y) coords) {
            INode<NodeData> nodeClientInteracted = _graphModel.GetNodeOnCoordsBySize(coords);
            IEdge<EdgeData, NodeData> edgeClientInteracted = null; 

            if(nodeClientInteracted == null)
                edgeClientInteracted = _graphModel.GetEdgeOnCoords(coords);

            DisposeValueEdit();

            if (nodeClientInteracted != null)
                this.SetNodeValueInsertion(nodeClientInteracted);

            if (edgeClientInteracted != null)
                this.SetEdgeValueInsertion(edgeClientInteracted);
        }

        private void SetEdgeValueInsertion(IEdge<EdgeData,NodeData> edgeInteracted) {
            _isInsertingValue = true;
            _editedEdge = edgeInteracted;

            var lablePosition = _editedEdge.Data.CalculateEdgeLablePosition(_editedEdge);
            _graphView.ShowValueInsertionBox(lablePosition, _editedEdge.Data.Value);
            _graphView.ClientConfirmedOperation += ClientAcceptedEdgeValue;
        }

        private void SetNodeValueInsertion(INode<NodeData> nodeInteracted) {
            _isInsertingValue = true;
            _editedNode = nodeInteracted;
            _graphView.ShowValueInsertionBox((nodeInteracted.X, nodeInteracted.Y), _editedNode.Data.Value);
            _graphView.ClientConfirmedOperation += ClientAcceptedNodeValue;
        }

        public override void TurnOnDeletationMode() {
            if (_isInsertingValue) return;
            base.TurnOnDeletationMode();
        }

        public override void TurnOnDragMode() {
            if (_isInsertingValue) return;
            base.TurnOnDragMode();
        }

        public override void TurnOnEdgeInsertionMode() {
            if (_isInsertingValue) return;
            base.TurnOnEdgeInsertionMode();
        }

        public override void TurnOnIdleMode() {
            if (_isInsertingValue) {
                DisposeValueEdit();
                return;
            }
            base.TurnOnIdleMode();
        }
        public override void TurnOnNodeInsertionMode() {
            if (_isInsertingValue) return;
            base.TurnOnNodeInsertionMode();
        }
        public override void TurnOnValueEditState() { return; }

        private void ClientAcceptedNodeValue(object sender, EventArgs e)
        {
            _editedNode.Data.Value = _graphView.NewLableTextValue;
            _graphPresenter.UpdateNodes();
            DisposeValueEdit();
        }
        private void ClientAcceptedEdgeValue(object sender, EventArgs e)
        {
            _editedEdge.Data.Value = _graphView.NewLableTextValue;
            _graphPresenter.UpdateEdges();
            DisposeValueEdit();
        }
        private void DisposeValueEdit() {
            _isInsertingValue = false;
            _graphView.HideValueInsertionBox();
            _graphView.ClientConfirmedOperation -= ClientAcceptedEdgeValue;
            _graphView.ClientConfirmedOperation -= ClientAcceptedNodeValue;
        }
    }
}
