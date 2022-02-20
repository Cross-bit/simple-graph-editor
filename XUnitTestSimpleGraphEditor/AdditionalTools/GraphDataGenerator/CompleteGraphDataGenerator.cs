using System;
using System.Collections.Generic;
using SimpleGraphEditor.Models;
using SimpleGraphEditor.Models.Interface;

namespace XUnitTestSimpleGraphEditor.AdditionalTools.GraphGenerator
{
    public class CompleteGraphDataGenerator : GraphDataGenerator
    {

        public CompleteGraphDataGenerator(int graphSize) : base (graphSize) { }

        protected override void GenerateNodes() {
            for (int i = 0; i < _graphSize; i++) {
                var nodeData = new NodeData() { Value = i.ToString() };
                INode<NodeData> newNode = new Node(0, i, nodeData);
                _graphData.Add(newNode, new List<IEdge<EdgeData, NodeData>>());
            }
        }

        protected override void GenerateEdges() {
            foreach (var baseNode in _graphData.Keys) {
                foreach (var newNeighbour in _graphData.Keys) {
                    var newEdge = new Edge(baseNode, newNeighbour, new EdgeData());
                    _graphData[baseNode].Add(newEdge);
                }
            }
        }
    }
}
