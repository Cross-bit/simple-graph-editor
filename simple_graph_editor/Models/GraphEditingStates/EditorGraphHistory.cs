using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SimpleGraphEditor.Models.GraphEditingStates
{
    public class EditorGraphHistory : IMementoCareTaker
    {
        //(careTaker for graph data memento pattern)

        private Stack<GraphMemento> _historyUndo = new Stack<GraphMemento>();
        private GraphMemento _current { get; set; } = null;

        private Stack<GraphMemento> _historyRedo = new Stack<GraphMemento>();

        public void AddState(GraphMemento graphMemento)
        {
            if (_current == null)
            {
                _current = graphMemento;
                return;
            }

            // stop tracking parallel history
            if (_historyRedo.Count != 0)
                _historyRedo.Clear();

            _historyUndo.Push(_current);

            _current = graphMemento;

        }

        public GraphMemento GetPrewiousState(int steps = 1)
        {
            if (_historyUndo.Count == 0) return null;

            for (int i = 0; i < steps; i++)
            {
                _historyRedo.Push(_current);
                _current = _historyUndo.Pop();
            }

            return _current.GetCopyOfMemento();
        }

        public GraphMemento GetFutureState(int steps = 1)
        {

            if (_historyRedo.Count == 0) return null;

            for (int i = 0; i < steps; i++)
            {
                _historyUndo.Push(_current);
                _current = _historyRedo.Pop();
            }

            return _current.GetCopyOfMemento();
        }
    }
}
