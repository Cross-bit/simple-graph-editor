using SimpleGraphEditor.Presenters.EditorStates;
using SimpleGraphEditor.Models.Interface;
using SimpleGraphEditor.Views;
using SimpleGraphEditor.Models;

namespace SimpleGraphEditor.Presenters
{
    public class GraphEditorMachine {

        // possible editor states
        internal IdleModeState IdleModeState { get; set; }
        internal DeletionModeState DeletionModeState { get; set; }
        internal NodeInsertionModeState NodeInsertionModeState { get; set; }
        internal EdgeInsertionModeState EdgeInsertionModeState { get; set; }
        internal ValueEditModeState ValueEditModeState { get; set; }
        internal DragNodeState DragNodeModeState { get; set; }

        public EditorState CurrentState { get; set; }

        private IGraphView _graphView;
        private IGraphRepresentation<NodeData, EdgeData> _graphModel;
        private IEditorModel _editorModel;
        private GraphPresenter _graphPresenter;

        public GraphEditorMachine(
            GraphPresenter newGraphPresenter,
            IGraphView newGraphView,
            IGraphRepresentation<NodeData, EdgeData> newGraphModel,
            IEditorModel newEditorModel
            ) {

            _graphPresenter = newGraphPresenter;
            _editorModel = newEditorModel;
            _graphModel = newGraphModel;
            _graphView = newGraphView;

            // state machine initialisation
            IdleModeState = new IdleModeState(_graphPresenter, _graphModel, _graphView, _editorModel);
            NodeInsertionModeState = new NodeInsertionModeState(_graphPresenter, _graphModel, _graphView, _editorModel);
            EdgeInsertionModeState = new EdgeInsertionModeState(_graphPresenter, _graphModel, _editorModel, _graphView);
            DeletionModeState = new DeletionModeState(_graphPresenter, _graphView, _editorModel);
            DragNodeModeState = new DragNodeState(_graphPresenter, _graphView, _graphModel, _editorModel);
            ValueEditModeState = new ValueEditModeState(_graphPresenter, _graphModel, _editorModel, _graphView);
            
            CurrentState = IdleModeState;
        }
    }
}
