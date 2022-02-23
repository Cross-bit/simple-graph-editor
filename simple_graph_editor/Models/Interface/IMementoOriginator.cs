using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleGraphEditor.Models.Interface
{
    /// <summary> Defines memento originator in memento pattern. </summary>
    public interface IMementoOriginator
    {

        /// <summary>Captures current state of originator into memento.</summary>
        /// <returns>Memento containing data of current object. </returns>
        public GraphMemento CreateMemento();

        /// <summary>Restores originator data based on given memento. </summary>
        /// <param name="graphMemento">Memento to restore data from.</param>
        public void RestoreFromMemento(GraphMemento graphMemento);
    }
}