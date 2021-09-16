using System;
using Xunit;
using SimpleGraphEditor.Models;
using SimpleGraphEditor.Models.Interface;
using System.Collections.Generic;

namespace XUnitTestSimpleGraphEditor
{
    public class TestGraphRepresenatation {

        IGraphRepresentation<NodeData, EdgeData> graph = new GraphRepresentationModel();
        
        //  IGraphRepresentation graphRep = new GraphRepresenatationModel();
        //GraphRepresenatationModel graphRep = new GraphRepresenatationModel();

        [Fact]
        public void TestHasThisNeighbour() {
            //TODO: fixnout
            var nd1 = new Node(0, 0, new NodeData());
            var nd2 = new Node(1, 1, new NodeData());
            var e1_2 = new Edge(nd1, nd2, new EdgeData());
            graph.AddNodeToGraph(nd1);
            graph.AddEdgeToGraph(e1_2, nd1);
            //graph.GraphData.Add(nd1, new List<IEdge<EdgeData, NodeData>>() { e1_2 });

            Assert.True(graph.HasThisNeighbour(nd1, nd2));
            Assert.Throws<Exception>(() => graph.HasThisNeighbour(nd2, nd1));

            graph.AddNodeToGraph(nd2);
            //Assert.False(graph.HasThisNeighbour(nd2, nd1));

            //graph.GraphData[nd2] = new List<IEdge<EdgeData, NodeData>>() { e1_2 };
            Assert.True(graph.HasThisNeighbour(nd2, nd1));

        }
        

    }
}
