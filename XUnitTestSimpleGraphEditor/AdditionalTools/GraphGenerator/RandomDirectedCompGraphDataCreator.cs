using SimpleGraphEditor.Models;
using SimpleGraphEditor.Models.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace XUnitTestSimpleGraphEditor.AdditionalTools.GraphGenerator
{
    public class RandomDirectedCompGraphDataCreator : CompleteGraphDataGenerator {

        public RandomDirectedCompGraphDataCreator(int graphSize) : base(graphSize) { }

        protected override void GenerateEdges() {

            HashSet<(INode<NodeData>, INode<NodeData>)> alreadyAddedPairs = new HashSet<(INode<NodeData>, INode<NodeData>)>();

            foreach (var baseNode in _graphData.Keys) {

                foreach (var newNeighbour in _graphData.Keys) {

                    if (!alreadyAddedPairs.Contains((baseNode, newNeighbour)) && !alreadyAddedPairs.Contains((newNeighbour, baseNode))) {
                        var edgeData = new EdgeData();
                        edgeData.Template.IsDirected = true;
                        var newEdge = new Edge(baseNode, newNeighbour, edgeData);
                        _graphData[baseNode].Add(newEdge);
                    }
                }
            }
        }
    }
}
