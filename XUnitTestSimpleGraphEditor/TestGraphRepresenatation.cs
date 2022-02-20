using System;
using Xunit;
using SimpleGraphEditor.Models.GraphModel;
using SimpleGraphEditor.Models;
using SimpleGraphEditor.Models.Interface;
using System.Collections.Generic;

namespace XUnitTestSimpleGraphEditor
{
    public class TestGraphRepresenatation {

        IGraphRepresentation<NodeData, EdgeData> graph = new GraphRepresentationModel();

        [Fact]
        public void TestHasThisNeighbour() {
            
            var nd1 = new Node(0, 0, new NodeData());
            var nd2 = new Node(1, 1, new NodeData());
            var e1_2 = new Edge(nd1, nd2, new EdgeData());

            graph.AddNodeToGraph(nd1);

            Assert.Throws<Exception>(() => graph.HasThisNeighbour(nd2, nd1));

            graph.AddNodeToGraph(nd2);

            graph.AddEdgeToGraph(e1_2, nd1);

            Assert.True(graph.HasThisNeighbour(nd1, nd2));
        }

        [Fact]
        public void TestIsEdgeBetweenTwoNodes() {

            var nd1 = new Node(0, 0, new NodeData());
            var nd2 = new Node(1, 1, new NodeData());
            var e1_2 = new Edge(nd1, nd2, new EdgeData());

            graph.AddNodeToGraph(nd1);

            graph.AddNodeToGraph(nd2);

            graph.AddEdgeToGraph(e1_2, nd1);

            Assert.True(graph.IsEdgeBetweenTwoNodes(nd1, nd2));
        }

        [Fact]
        public void TestRemoveEdgeFromGraph()
        {
            var nd1 = new Node(0, 0, new NodeData());
            var nd2 = new Node(0, 6, new NodeData());

            var e_temp1 = new EdgeTemplate();
            var e_temp2 = new EdgeTemplate();

            var e1_2 = new Edge(nd1, nd2, new EdgeData() { Template = e_temp1 });
            var e2_1 = new Edge(nd2, nd1, new EdgeData() { Template = e_temp2 });

            graph.AddNodeToGraph(nd1);
            graph.AddNodeToGraph(nd2);

            graph.AddEdgeToGraph(e1_2, nd1);
            graph.AddEdgeToGraph(e2_1, nd2);

            graph.RemoveEdgeFromGraph(e2_1);

            Assert.False(graph.IsEdgeBetweenTwoNodes(nd1, nd2));
        }


    }
}
