using System;
using System.Collections.Generic;
using System.Text;
using SimpleGraphEditor.Presenters.EditorStates;


namespace SimpleGraphEditor.Presenters
{
    public interface IGraphEditorMachine {
        EditorState CurrentState { get; }

        internal IdleModeState IdleModeState { get; set; }
        internal DeletionModeState DeletionModeState { get; set; }
        internal NodeInsertionModeState NodeInsertionModeState { get; set; }
        internal EdgeInsertionModeState EdgeInsertionModeState { get; set; }
        internal ValueEditModeState ValueEditModeState { get; set; }
        internal DragNodeState DragNodeModeState { get; set; }

        void SetNewEditorState(EditorState newState);
    }
}
