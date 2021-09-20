using SimpleGraphEditor.Models.Interface;
using System.Collections.Generic;
using System.Diagnostics;

namespace SimpleGraphEditor.Models.GraphModel.Operations
{
    using graphDataType = Dictionary<(int X, int Y), List<IEdge<EdgeData, NodeData>>>;

    public class CopyGraphData  {
        private graphDataType _originalData = new graphDataType();

        private Dictionary<(int x, int y), INode<NodeData>> _visitedNodes;

        private graphDataType _newGraphData;

        public CopyGraphData(graphDataType originalData) {
            _originalData = originalData;
        }

        public graphDataType Copy() {
            _newGraphData = new graphDataType();
            _visitedNodes = new Dictionary<(int x, int y), INode<NodeData>>();

            if (_originalData.Count > 0) {
                // all components
                foreach (var node in _originalData.Keys) {
                    if (!_visitedNodes.ContainsKey((node.X, node.Y)))
                        SetGraphCopy(_originalData[node][0].Node1);
                }            
            }

            Debug.WriteLine(_newGraphData.Count);

            return _newGraphData;
        }


        private INode<NodeData> SetGraphCopy(INode<NodeData> node1) {
            var newNode1 = new Node(node1.X, node1.Y, node1.Data);
            _visitedNodes.Add(node1.Coords, newNode1);
            _newGraphData.Add(newNode1.Coords, new List<IEdge<EdgeData, NodeData>>());

            foreach (var edge in _originalData[node1.Coords]) {

                // currently added edge
                INode<NodeData> newNode2 = null;

                if (_visitedNodes.ContainsKey((edge.Node2.X, edge.Node1.Y))) { 
                    // already have copy Node2
                    newNode2 = _visitedNodes[(edge.Node2.X, edge.Node1.Y)];
                }
                else { // else we have to recurse
                    newNode2 = SetGraphCopy(edge.Node2);
                }

                _newGraphData[newNode1.Coords].Add(new Edge(newNode1, newNode2, edge.Data));
            }

            return newNode1;
        }
    }
}
