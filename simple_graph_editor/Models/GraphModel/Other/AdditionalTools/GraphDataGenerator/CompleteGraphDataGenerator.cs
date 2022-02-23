using System;
using System.Collections.Generic;
using SimpleGraphEditor.Models;
using SimpleGraphEditor.Models.Interface;

namespace SimpleGraphEditor.Models.GraphModel
{
    public class CompleteGraphDataGenerator : GraphDataGenerator
    {

        public CompleteGraphDataGenerator(int graphSize) : base (graphSize) { }

        protected override void GenerateNodes() {
            for (int i = 0; i < _graphSize; i++) {
                var nodeData = new NodeData() { Value = i.ToString() };
                INode<NodeData> newNode = new Node(i*50, i*50, nodeData);
                _graphData.Add(newNode, new List<IEdge<EdgeData, NodeData>>());
            }
        }

        protected override void GenerateEdges() {
            foreach (var baseNode in _graphData.Keys) {
                foreach (var newNeighbour in _graphData.Keys) {

                    if(baseNode != newNeighbour) {
                        var edgeData = new EdgeData();
                        var edgeTemplate = new EdgeTemplate();
                        edgeTemplate.IsDirected = false;
                        edgeData.Template = edgeTemplate;

                        var newEdge = new Edge(baseNode, newNeighbour, edgeData, false);
                        _graphData[baseNode].Add(newEdge);
                    }
                }
            }
        }
    }
}
