using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SimpleGraphEditor.Models.GraphEditingStates
{
    public class EditorGraphHistory //(careTaker for graph data memento p.)
    {
        public Stack<GraphMemento> HistoryUndo = new Stack<GraphMemento>();
        public GraphMemento Current { get; private set; } = null;

        public Stack<GraphMemento> HistoryRedo = new Stack<GraphMemento>();

        public void AddGraphState(GraphMemento graphMemento) {
            if (Current == null) {
                Current = graphMemento;
                return;
            }

            // stop tracking parallel history
            if (HistoryRedo.Count != 0)
                HistoryRedo.Clear();

            HistoryUndo.Push(Current);

            Current = graphMemento;

        }

        public GraphMemento GetPrewiousState(int steps = 1) {
            if (HistoryUndo.Count == 0) return Current.GetCopyOfMemento();

            for (int i = 0; i < steps; i++) {
                HistoryRedo.Push(Current);
                Current = HistoryUndo.Pop();
            }

            return Current.GetCopyOfMemento();
        }

        public GraphMemento GetFutureState(int steps = 1) {

            if (HistoryRedo.Count == 0) return Current.GetCopyOfMemento();

            for (int i = 0; i < steps; i++)
            {
                HistoryUndo.Push(Current);
                Current = HistoryRedo.Pop();
            }

            return Current.GetCopyOfMemento();
        }
    }
}
