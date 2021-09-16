using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleGraphEditor.Models.Interface
{
    public interface IMementoOriginator {
        public GraphMemento CreateMemento();
        public void RestoreFromMemento(GraphMemento graphMemento);
    }
}
