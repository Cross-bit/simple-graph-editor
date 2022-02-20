using SimpleGraphEditor.Models.Interface;
using SimpleGraphEditor.Views;
using SimpleGraphEditor.Presenters.CanvasRendererMachine;



namespace SimpleGraphEditor.Presenters.EditorStates
{
    public abstract class EditorState {

        GraphPresenter _graphPresenter;
        IGraphView _graphView;

        IEditorModel _editorModel;
        public EditorState(
            GraphPresenter graphPresenter,
            IGraphView graphView,
            IEditorModel editorModel
            )
        {

            _graphPresenter = graphPresenter;
            _graphView = graphView;
            _editorModel = editorModel;
        }

        public virtual void TurnOnDeletationMode() {
            _graphView.ClosePropertiesPanel();
            _graphPresenter.CanvasRenderer.SetCurrentRenderTo(CanvasRenderMachine.RenderState.REND1);
            _graphPresenter.EditorMachine.CurrentState = _graphPresenter.EditorMachine.DeletionModeState;
        }

        public virtual void TurnOnDragMode() {
            _graphView.ClosePropertiesPanel();
            _graphPresenter.CanvasRenderer.SetCurrentRenderTo(CanvasRenderMachine.RenderState.REND1);
            _graphPresenter.EditorMachine.CurrentState = _graphPresenter.EditorMachine.DragNodeModeState;
        }

        public virtual void TurnOnEdgeInsertionMode() {
            _graphView.OpenEdgeProperties();
            _graphPresenter.CanvasRenderer.SetCurrentRenderTo(CanvasRenderMachine.RenderState.REND3);
            _graphPresenter.EditorMachine.CurrentState = _graphPresenter.EditorMachine.EdgeInsertionModeState;
        }
        public virtual void TurnOnIdleMode() {
            _graphView.ClosePropertiesPanel();
            _graphPresenter.CanvasRenderer.SetCurrentRenderTo(CanvasRenderMachine.RenderState.REND1);
            _graphPresenter.EditorMachine.CurrentState = _graphPresenter.EditorMachine.IdleModeState;
        }
        public virtual void TurnOnNodeInsertionMode() {
            _graphView.OpenNodeProperties();
            _graphPresenter.CanvasRenderer.SetCurrentRenderTo(CanvasRenderMachine.RenderState.REND2);
            _graphPresenter.EditorMachine.CurrentState = _graphPresenter.EditorMachine.NodeInsertionModeState;
        }

        public virtual void TurnOnValueEditState() {
            _graphView.ClosePropertiesPanel();
            _graphPresenter.CanvasRenderer.SetCurrentRenderTo(CanvasRenderMachine.RenderState.REND1);
            _graphPresenter.EditorMachine.CurrentState = _graphPresenter.EditorMachine.ValueEditModeState;
        }
        public abstract void OnClientInteract((int x, int y) coords);

    }
}
