using SimpleGraphEditor.Models.GraphModel.Operations;
using SimpleGraphEditor.Models.Interface;
using System.Collections.Generic;
using System.Diagnostics;

namespace SimpleGraphEditor.Models
{
    using graphDataType = Dictionary<INode<NodeData>, List<IEdge<EdgeData, NodeData>>>;

    public class GraphMemento { // (memento)

        private graphDataType _graphData = new graphDataType();

        public GraphMemento(graphDataType graphDataSave) {
            var copyGraphData = new CopyGraphData(graphDataSave);
            _graphData = copyGraphData.CreateCopy();
        }

        public GraphMemento GetCopyOfMemento() {
            return new GraphMemento(_graphData);
        }
        
        public graphDataType GetStateData() {
            return _graphData;
        }


    }
}
