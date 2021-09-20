using System;
using System.Collections.Generic;
using System.Text;

using SimpleGraphEditor.Models.Interface;
using SimpleGraphEditor.Models;
using System.Linq;
using System.Diagnostics;
using SimpleGraphEditor.Models.GraphModel.Operations;

namespace SimpleGraphEditor.Models
{
    using graphDataType = Dictionary<(int x, int y), List<IEdge<EdgeData, NodeData>>>;

    public class GraphMemento { // (memento)

        private graphDataType _graphData = new graphDataType();

        public GraphMemento(graphDataType graphDataSave) {
            var copyGraphData = new CopyGraphData(graphDataSave);
            _graphData = copyGraphData.Copy();
        }

        public GraphMemento GetCopyOfMemento() {
            return new GraphMemento(_graphData);
        }
        
        public graphDataType GetStateData() {

            return _graphData;
        }


    }
}
