using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SimpleGraphEditor.Models.GraphEditingStates
{
    public class EditorGraphHistory //(careTaker for graph data memento p.)
    {
        public Stack<GraphMemento> historyUndo = new Stack<GraphMemento>();
        public GraphMemento current { get; private set; } = null;
        public Stack<GraphMemento> historyRedo = new Stack<GraphMemento>();

        private GraphMemento lastRedoCopy = null;

        public void AddGraphState(GraphMemento graphMemento) {
            if (current == null) {
                current = graphMemento;
                return;
            }

            // stop tracking parallel history...
            if (historyRedo.Count != 0) {
                current = lastRedoCopy;
                historyRedo.Clear();
            }

            historyUndo.Push(current);
            current = graphMemento;

            Debug.WriteLine(historyUndo.Count);

        }

        public GraphMemento GetPrewiousState(int steps = 1) {
            if (historyUndo.Count == 0) return null;

            for (int i = 0; i < steps; i++)
            {
                historyRedo.Push(current);
                current = historyUndo.Pop();
            }
            lastRedoCopy = current.GetCopyOfMemento();

            return current;
        }

        public GraphMemento GetFutureState(int steps = 1) {

            if (historyRedo.Count == 0) return null;

            for (int i = 0; i < steps; i++)
            {
                historyUndo.Push(current);
                current = historyRedo.Pop();
            }

            return current;
        }
    }
}
