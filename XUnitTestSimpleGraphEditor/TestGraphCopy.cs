using System;
using System.Collections.Generic;
using Xunit;
using SimpleGraphEditor.Models.GraphModel;
using SimpleGraphEditor.Models;
using SimpleGraphEditor.Models.Interface;
using XUnitTestSimpleGraphEditor.AdditionalTools.GraphGenerator;
using SimpleGraphEditor.Models.GraphModel.Operations;

namespace XUnitTestSimpleGraphEditor
{
    using graphDataType = Dictionary<INode<NodeData>, List<IEdge<EdgeData, NodeData>>>;

    public class TestGraphCopy {

        [Fact]
        public void TestCreateCopyCompleteGraph() {

            // create complete K5 and test if it copies correctly
            var graphDataGenerator = new CompleteGraphDataGenerator(5);
            graphDataGenerator.GenerateGraphData();
            Assert.Equal(5, graphDataGenerator.GraphData.Count);
            
            var graphCopier = new CopyGraphData(graphDataGenerator.GraphData);

            var copiedData = graphCopier.CreateCopy();
            
            AssertCopied(graphDataGenerator.GraphData, copiedData);

        }

        [Fact]
        public void TestCreateCopyEdgeEmptyGraph() {

            // create empty graph and test if it copies correctly
            var graphDataGenerator1 = new EmptyGraphDataGenerator(10);
            graphDataGenerator1.GenerateGraphData();

            Assert.Equal(10, graphDataGenerator1.GraphData.Count);

            var graphCopier = new CopyGraphData(graphDataGenerator1.GraphData);

            var copiedData1 = graphCopier.CreateCopy();

            AssertCopied(graphDataGenerator1.GraphData, copiedData1);

        }

        [Fact]
        public void TestCreateCopyEmptyGraph() {
 
            var graphDataGenerator = new EmptyGraphDataGenerator(0);
            graphDataGenerator.GenerateGraphData();

            var graphCopier = new CopyGraphData(graphDataGenerator.GraphData);

            var copiedData = graphCopier.CreateCopy();

            AssertCopied(graphDataGenerator.GraphData, copiedData);
        }


        [Fact]
        public void TestCreateCopyCompleteGraphOriented() {

            var graphDataGenerator = new RandomDirectedCompGraphDataCreator(5);
            graphDataGenerator.GenerateGraphData();

            var graphCopier = new CopyGraphData(graphDataGenerator.GraphData);

            var copiedData = graphCopier.CreateCopy();

            AssertCopied(graphDataGenerator.GraphData, copiedData);
        }


        private void AssertCopied(graphDataType originalGraphData, graphDataType copiedGraphData) {

            // check if num of copied nodes is same
            Assert.Equal(copiedGraphData.Count, originalGraphData.Count);

            // check if nodes at same position are different
            foreach (Node oldNode in originalGraphData.Keys)
            {

                int numberOfcopiedNdWithOldNdCoords = 0; // should be unique => 1
                Node copiedNodeFound = null;
                foreach (var copiedNode in copiedGraphData.Keys)
                {

                    if (oldNode.X == copiedNode.X && oldNode.Y == copiedNode.Y) {
                        // so they should be different instances
                        Assert.NotSame(oldNode, copiedNode);

                        copiedNodeFound = (Node)copiedNode;
                        numberOfcopiedNdWithOldNdCoords++;
                    }
                }

                Assert.Equal(1, numberOfcopiedNdWithOldNdCoords);

                AssertEdges(copiedNodeFound, oldNode, originalGraphData[oldNode], copiedGraphData[copiedNodeFound]);
            }
        }

        private void AssertEdges(
            Node copiedNode,
            Node oldNode,
            List<IEdge<EdgeData, NodeData>> originalIncidentEdges, 
            List<IEdge<EdgeData, NodeData>> copiedIncidentEdges
        ) {
            // check if number of neighbours is same
            Assert.Equal(copiedIncidentEdges.Count, originalIncidentEdges.Count);

            foreach (var copiedEdge in copiedIncidentEdges) {

                foreach (var oldEdge in originalIncidentEdges) {

                    // do the edges have same endpoint?
                    if (copiedEdge.Node2.X == oldEdge.Node2.X && copiedEdge.Node2.Y == oldEdge.Node2.Y) {
                        Assert.NotSame(oldEdge, copiedEdge);

                        //+ check if the value stayed preserved
                        Assert.Equal(oldEdge.Data.Value, copiedEdge.Data.Value);
                    }
                }
            }
        }
    }
}
