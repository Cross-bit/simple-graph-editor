using System;
using System.Collections.Generic;
using System.Text;
using SimpleGraphEditor.Models;
using SimpleGraphEditor.Views;
using SimpleGraphEditor.Presenters.CanvasRendererMachine;
using SimpleGraphEditor.Models.Interface;
using System.Diagnostics;

namespace SimpleGraphEditor.Presenters.EditorStates
{
    public class DragNodeState : EditorState {

        private GraphPresenter _graphPresenter;
        private IGraphRepresentation<NodeData, EdgeData> _graphModel;
        private IEditorModel _editorModel;

        private (int x, int y) _initialNodePos;

        public DragNodeState(
            GraphPresenter graphPresenter,
            IGraphView graphView,
            IGraphRepresentation<NodeData, EdgeData> graphModel,
            IEditorModel editorModel ) : base(graphPresenter, graphView, editorModel)
        {
            _graphPresenter = graphPresenter;
            _graphModel = graphModel;
            _editorModel = editorModel;
        }

        public override void OnClientInteract((int x, int y) coords) {
            var nodeClientInteracted = _graphModel.GetNodeInRadius(coords, Settings.DefaultNodeRadius);

            // Get Selected Node
            if (_editorModel.SelectedNode == null && nodeClientInteracted != null) {
                this.SetSelectedNode(nodeClientInteracted);
            }

            // Place selected node;
            if (_editorModel.SelectedNode != null && nodeClientInteracted == null) {
                this.PlaceSelectedNode();
                _graphPresenter.GraphHistory.AddGraphState(((IMementoOriginator)_graphModel).CreateMemento());
            }
            // Set proper renderer
            _graphPresenter.CanvasRenderer.SetCurrentRenderTo(CanvasRenderMachine.RenderState.REND1);
        }

        public override void TurnOnDragMode() { return; }

        public override void TurnOnEdgeInsertionMode() {
            this.ClearOperation();
            base.TurnOnEdgeInsertionMode();
        }

        public override void TurnOnIdleMode() {
            this.ClearOperation();
            base.TurnOnIdleMode();
        }

        public override void TurnOnNodeInsertionMode() {
            this.ClearOperation();
            base.TurnOnNodeInsertionMode();
        }

        private void OnMouseMoved(object sender, EventArgs e) {
            if (_editorModel.SelectedNode == null) return;
            _editorModel.SelectedNode.X = _editorModel.CanvasMousePosition.X;
            _editorModel.SelectedNode.Y = _editorModel.CanvasMousePosition.Y; // TODO: případně v budoucnu odstranit z editorModel SelectedNode a MousePosition a pouze tady bindnout _view a nějaký lokální selectedNode?
        }
        public override void TurnOnValueEditState() {
            this.ClearOperation();
            base.TurnOnValueEditState();
        }

        private void ClearOperation() {
            // set default position
            if (_editorModel.SelectedNode != null) {
                _editorModel.SelectedNode.X = _initialNodePos.x;
                _editorModel.SelectedNode.Y = _initialNodePos.y;
            }
            this.PlaceSelectedNode();
        }
        private void SetSelectedNode(INode<NodeData> nodeClientInteracted) {
            _initialNodePos = (nodeClientInteracted.X, nodeClientInteracted.Y);
            _editorModel.MouseMove += OnMouseMoved;
            _editorModel.SelectedNode = nodeClientInteracted;
            _editorModel.SelectedNode.Data.IsEnabled = false;
        }
        private void PlaceSelectedNode() {
            _editorModel.MouseMove -= OnMouseMoved;

            if (_editorModel.SelectedNode == null) return;
            _editorModel.SelectedNode.Data.IsEnabled = true;
            _editorModel.SelectedNode = null;
        }

    }
}
