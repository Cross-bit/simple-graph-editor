using System;
using SimpleGraphEditor.Models;
using SimpleGraphEditor.Models.Interface;

namespace XUnitTestSimpleGraphEditor.AdditionalTools.GraphGenerator
{
    public class CompleteGraphDataGenerator : GraphDataGenerator
    {

        public CompleteGraphDataGenerator(int graphSize, IGraphRepresentation<NodeData, EdgeData> graphData) 
            : base (graphSize, graphData) { }

        protected override void GenerateNodes() {
            for (int i = 0; i < _graphSize; i++) {

                var nodeData = new NodeData() { Value = i.ToString() };
                INode<NodeData> newNode = new Node(0, i, nodeData);
                _graphGenerated.AddNodeToGraph(newNode);
            }
        }

        protected override void GenerateEdges() {
            foreach (var baseNode in _graphGenerated.GraphData.Keys) {
                foreach (var newNeighbour in _graphGenerated.GraphData.Keys) {
                    var newEdge = new Edge(baseNode, newNeighbour, new EdgeData());
                    _graphGenerated.AddEdgeToGraph(newEdge, baseNode);
                }
            }
        }
    }
}
