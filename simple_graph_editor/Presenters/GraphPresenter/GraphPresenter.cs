using SimpleGraphEditor.Models;
using SimpleGraphEditor.Views;
using System.Collections.Generic;
using SimpleGraphEditor.Presenters.CanvasRendererMachine;
using SimpleGraphEditor.Models.Interface;
using SimpleGraphEditor.Models.GraphEditingStates;

namespace SimpleGraphEditor.Presenters
{
    public class GraphPresenter {

        private IGraphRepresentation<NodeData, EdgeData> _graphModel;
        private IGraphView _graphView;
        private IEditorModel _editorModel;

        public GraphEditorMachine EditorMachine;
        public CanvasRenderMachine CanvasRenderer { get; set; }

        public EditorGraphHistory GraphHistory { get; set; }
        public enum HistoryMoveDir { forward, backward };

        public GraphPresenter(
            IGraphView newGraphView,
            IGraphRepresentation<NodeData, EdgeData> newGraphRepresentation,
            IEditorModel newEditorModel
            ) {
            _graphView = newGraphView;
            _graphModel = newGraphRepresentation;
            _editorModel = newEditorModel;

            _graphView.MainPresenter = this;
            _editorModel.CurrentNewNodeTemplate = new NodeTemplate();

            // TODO: skrze injection
            this.CanvasRenderer = new CanvasRenderMachine(this);
            this.EditorMachine = new GraphEditorMachine(this, _graphView, _graphModel, _editorModel);
            this.GraphHistory = new EditorGraphHistory();

            // save intial empty graph state
            this.GraphHistory.AddGraphState(((IMementoOriginator)_graphModel).CreateMemento());
        }

        public void MoveInGraphsHistory(HistoryMoveDir direction, int steps = 1) {
            if(direction == HistoryMoveDir.forward)
                ((IMementoOriginator)_graphModel).RestoreFromMemento(GraphHistory.GetFutureState());
            else if(direction == HistoryMoveDir.backward)
                ((IMementoOriginator)_graphModel).RestoreFromMemento(GraphHistory.GetPrewiousState());

            this.UpdataNodes();
            this.UpdateEdges();
        }

        public void GraphInteract((int x, int y) coordinates) =>
            EditorMachine.CurrentState.OnClientInteract(coordinates);

        #region Updates view based on models

        #region data binding
        private void BindNewNodeShapeTemplate(INodeTemplate template) {

            _graphView.NewNodeColor = template.BackColor;
            _graphView.NewNodeShape = template.Shape;
            _graphView.NewNodeSize = template.Size;
            _graphView.NewNodeDrawBorder = template.DrawBorder;
            _graphView.NewNodeBorderWidth = template.BorderWidth;
            _graphView.NewNodeBorderColor = template.BorderColor;
           // Debug.WriteLine("Idaho" + template.BackColor);
            // Update view tools
            _graphView.UpdateNodeBrush();
            _graphView.UpdateNodePen();
        }

        private void BindNewEdgeShapeTemplate(IEdgeTemplate template) {

            _graphView.NewEdgeColor = template.Color;
            _graphView.NewEdgeIsDirected = template.IsDirected;
            _graphView.NewEdgeWidth = template.Width;

            // Update view tools
            _graphView.UpdateEdgePen();
        }

        private void BindNewLabelTextTemplate(IValueLabelTemplate template) {
            _graphView.NewLabelFontColor = template.fontColor;
            _graphView.NewLabelFontSize = template.fontSize;
        }
        #endregion

        #region whole canvas actions
        public void ClearCanvas() => _graphView.ClearCanvas();
        public void RenderCanvas() {
            foreach (var render in CanvasRenderer.CurrentRenderQueue)
                render?.Invoke();
        }
        #endregion

        #region dummy mouse node & edge for new node insertion

        // AllowsFreeMovement of node in editor
        public void UpdateMouseDummyNode() {
            BindNewNodeShapeTemplate(_editorModel.GetCopyOfCurrentNodeTemplate());
            _graphView.AddNodeShape(_editorModel.CanvasMousePosition); // update view
        }
        public void UpdateMouseDummyEdge() {
            if (_editorModel.SelectedNode == null) return;
            //Debug.WriteLine(_editorModel.GetCurrentEdgeTemplate().Width);
            BindNewEdgeShapeTemplate(_editorModel.GetCopyOfCurrentEdgeTemplate());
            var startCords = (_editorModel.SelectedNode.X, _editorModel.SelectedNode.Y);
            _graphView.AddEdgeShape(startCords, _editorModel.CanvasMousePosition); // update view
        }
        #endregion
        
        // TODO: update only needed stuff (only real node and edge intersections etc.)
        public void UpdateEdges() {
            HashSet<IEdge<EdgeData, NodeData>> updatedEdges = new HashSet<IEdge<EdgeData, NodeData>>();
            foreach (var edgeList in _graphModel.GraphData.Values) {

                if (edgeList != null)
                    foreach (var edge in edgeList) {
                        if (!updatedEdges.Contains(edge)) {
                            // Bind new edgeTemplate
                            var edgeTemplate = edge.Data.Template;

                            // Bind end node data e. g. for the line cap of oriented edges, ( the start is based on nodes data)
                            BindNewNodeShapeTemplate(edge.Node2.Data.Template);

                            BindNewEdgeShapeTemplate(edgeTemplate);
                            
                            var edgeStartCoords = (edge.Node1.X, edge.Node1.Y);
                            var edgeEndCoords = (edge.Node2.X, edge.Node2.Y);

                            // Update view
                            if (edge.Data.CanBeRendered)
                                _graphView.AddEdgeShape(edgeStartCoords, edgeEndCoords);

                            UpdateEdgeLable(edge);
                        }
                        updatedEdges.Add(edge);
                    }
            }
        }
        public void UpdataNodes() {

            foreach (var node in _graphModel.GraphData.Keys) {

                // Bind model current node settings and view current node
                var template = node.Data.Template; // TODO: nastavení uživatelem
                BindNewNodeShapeTemplate(template);

                // Update node shapes in view
                if (node.Data.CanBeRendered)
                    _graphView.AddNodeShape((node.X, node.Y));

                // update the lable value
                this.UpdateNodeLable(node);
            }
        }

        private void UpdateEdgeLable(IEdge<EdgeData, NodeData> edge) {
            if (edge.Data.Value == null) return;
            // bind edge lable
            BindNewLabelTextTemplate(edge.Data.LabelTemplate);

            var lablePosition = edge.Data.CalculateEdgeLablePosition(edge);

            // update view
            _graphView.AddElementValueText(lablePosition, edge.Data.Value);
        }
        private void UpdateNodeLable(INode<NodeData> node) {
            if (node.Data.Value == null) return;

            // bind data
            this.BindNewLabelTextTemplate(node.Data.LableTemplate);

            // update view
            _graphView.AddElementValueText((node.X, node.Y), node.Data.Value);
        }
        #endregion

        #region Update Models
        public void AddEdge(INode<NodeData> startNode, INode<NodeData> endNode) {
            if (startNode == null || endNode == null) return;

            // Update model
            var edgeData = new EdgeData();
            edgeData.Template = _editorModel.GetCopyOfCurrentEdgeTemplate();

            IEdge<EdgeData, NodeData> newEdge = new Edge(startNode, endNode, edgeData);
            IEdge<EdgeData, NodeData> newEdgeBack = new Edge(endNode, startNode, edgeData);

            // todo: zítra přesunout do modelu todo: zítra fakt už přesunout do modelu !!!
            _graphModel.GraphData[startNode].Add(newEdge);

            if(!edgeData.Template.IsDirected)// undirected
                _graphModel.GraphData[endNode].Add(newEdgeBack); 

            // save modified graph
            this.GraphHistory.AddGraphState(((IMementoOriginator)_graphModel).CreateMemento());
        }
        
        public void AddNode((int x, int y) coordinates) {

            var nodeData = new NodeData();
            nodeData.Name = "node" + _graphModel.GraphData.Count + 1;

            nodeData.Template = _editorModel.GetCopyOfCurrentNodeTemplate(); // TODO: moc se mi nelíbí v editor modelu...

            INode<NodeData> newNode = new Node(coordinates.x, coordinates.y, nodeData);

            _graphModel.AddNodeToGraph(newNode);

            // save modified graph
            this.GraphHistory.AddGraphState(((IMementoOriginator)_graphModel).CreateMemento());

        }
        public void DeleteNode((int x, int y) coordinates) {
            // todo: move radius somewhere global constant
            var nodeToDelete = _graphModel.GetNodeOnCoordsBySize(coordinates);
            if (nodeToDelete == null) return;
            // updata model
            _graphModel.RemoveNodeFromGraph(nodeToDelete);

            // save modified graph
            this.GraphHistory.AddGraphState(((IMementoOriginator)_graphModel).CreateMemento());

        }
        public void DeleteEdge((int x, int y) coordinates) {
            var edge = _graphModel.GetEdgeOnCoords(coordinates);
            if (edge == null) return;

            // updata model
            _graphModel.RemoveEdgeFromGraph(edge);

            // save modified graph
            this.GraphHistory.AddGraphState(((IMementoOriginator)_graphModel).CreateMemento());
        }

        public void UpdateMousePosition() => // Update mouse position in editor model
            _editorModel.SetMousePosition(_graphView.MouseCoords);

        #endregion updates model
    }
}