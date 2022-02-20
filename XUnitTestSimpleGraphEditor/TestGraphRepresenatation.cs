using System;
using Xunit;
using SimpleGraphEditor.Models.GraphModel;
using SimpleGraphEditor.Models;
using SimpleGraphEditor.Models.Interface;
using System.Collections.Generic;
using XUnitTestSimpleGraphEditor.AdditionalTools.GraphGenerator;
using System.Linq;

namespace XUnitTestSimpleGraphEditor
{
    public class TestGraphRepresenatation {

        IGraphRepresentation<NodeData, EdgeData> graph = new GraphRepresentationModel();

        [Fact]
        public void TestClear() {

            var completeGraphGenerator = new RandomDirectedCompGraphDataGenerator(5);
            completeGraphGenerator.GenerateGraphData();

            var testGraph = new GraphRepresentationModel(completeGraphGenerator.GraphData);

            Assert.Equal(5, testGraph.Size);

            testGraph.Clear();

            Assert.Equal(0, testGraph.Size);
        }

        #region Has specific memeber 
        
        public static IEnumerable<object[]> HasThisNeighbourNullArgsTestData =>
            new List<object[]>
            {
            new object[] { new Node(0, 0, new NodeData()), null },
            new object[] { null, new Node(0, 0, new NodeData()) },
            new object[] { null, null }
        };

        [Theory, MemberData(nameof(HasThisNeighbourNullArgsTestData))]
        public void TestHasThisNeighbourNullArgs(INode<NodeData> baseNode, INode<NodeData> neighbour) {
            Assert.Throws<ArgumentNullException>(() => graph.HasThisNeighbour(baseNode, neighbour));
        }


        [Fact]
        public void TestHasThisNeighbour() {
            
            var graphTestData = new Dictionary<INode<NodeData>, List<IEdge<EdgeData, NodeData>>>();
            var nd1 = new Node(0, 0, new NodeData());
            var nd2 = new Node(1, 1, new NodeData());

            var nd1_edgeList = new List<IEdge<EdgeData, NodeData>>();

            graphTestData.Add(nd1, nd1_edgeList);

            // what if one of the nodes is not presented in graph data

            var graphTest = new GraphRepresentationModel(graphTestData);
            Assert.Throws<Exception>(() => graphTest.HasThisNeighbour(nd2, nd1));
            Assert.Throws<Exception>(() => graphTest.HasThisNeighbour(nd1, nd2));

            graphTestData.Add(nd2, new List<IEdge<EdgeData, NodeData>>());

            var e1_2 = new Edge(nd1, nd2, new EdgeData());
            nd1_edgeList.Add(e1_2);

            graphTest = new GraphRepresentationModel(graphTestData);

            Assert.True(graphTest.HasThisNeighbour(nd1, nd2));
            Assert.False(graphTest.HasThisNeighbour(nd2, nd1));
        }

        // note: current implementation of IsEdgeBetweenTwoNodes is only composed of these two methods connected with ||
        // thus exceptions have to work transitively
        [Fact]
        public void TestIsEdgeBetweenTwoNodes() {

            var graphTestData = new Dictionary<INode<NodeData>, List<IEdge<EdgeData, NodeData>>>();
            var nd1 = new Node(0, 0, new NodeData());
            var nd2 = new Node(1, 1, new NodeData());

            var nd1_edgeList = new List<IEdge<EdgeData, NodeData>>();

            graphTestData.Add(nd1, nd1_edgeList);
            graphTestData.Add(nd2, new List<IEdge<EdgeData, NodeData>>());

            var e1_2 = new Edge(nd1, nd2, new EdgeData());
            nd1_edgeList.Add(e1_2);

            var graphTest = new GraphRepresentationModel(graphTestData);

            Assert.True(graphTest.IsEdgeBetweenTwoNodes(nd1, nd2));
            Assert.True(graphTest.IsEdgeBetweenTwoNodes(nd2, nd1)); // does not matter on orientation
        }


        #endregion

        #region Test all edges/nodes getters

        [Fact]
        public void TestGetAllNodes()
        {
            var nd1 = new Node(0, 0, new NodeData());
            var nd2 = new Node(0, 1, new NodeData());
            var nd3 = new Node(0, 2, new NodeData());

            var graphData = new Dictionary<INode<NodeData>, List<IEdge<EdgeData, NodeData>>>();

            graphData.Add(nd1, new List<IEdge<EdgeData, NodeData>>());
            graphData.Add(nd2, new List<IEdge<EdgeData, NodeData>>());
            graphData.Add(nd3, new List<IEdge<EdgeData, NodeData>>());

            var graphTest = new GraphRepresentationModel(graphData);

            int ctrSameNodes = 0;

            // are really all in there?
            foreach (var node in graphTest.GetAllNodes()) {
                if (graphData.ContainsKey(node))
                    ctrSameNodes++;
            }

            Assert.Equal(3, ctrSameNodes);
        }

        [Fact]
        public void TestGetAllEdges() {

            var graphDataGenerator = new CompleteGraphDataGenerator(5);
            graphDataGenerator.GenerateGraphData();

            var allEdges = graphDataGenerator.GraphData.Values;
            var allOriginalEdgesSet = new HashSet<IEdge<EdgeData, NodeData>>();

            foreach (var edgesOriginal in allEdges) {
                foreach (var edgeOriginal in edgesOriginal) {
                    allOriginalEdgesSet.Add(edgeOriginal);
                }
            }



            var testGraph = new GraphRepresentationModel(graphDataGenerator.GraphData);

            int ctr = 0;
            // will we get really all?
            foreach (var graphEdge in testGraph.GetAllEdges()) {
                if (allOriginalEdgesSet.Contains(graphEdge)) {
                    ctr++;
                }
            }

            Assert.Equal(20, ctr); // K5 has 10 edges, undirectly 2*10


        }

        #endregion

        #region Add/Remove new node into graph
        [Fact]
        public void TestAddNodeToGraph() {

            var nd1 = new Node(0, 0, new NodeData());

            var graphTest = new GraphRepresentationModel();

            graphTest.AddNodeToGraph(nd1);
            Assert.Equal(1, graphTest.Size);


            // can not add same node twice
            Assert.Throws<Exception>(() => graphTest.AddNodeToGraph(nd1));


            string nd2Name = "nd2";
            var nd2 = new Node(0, 1, new NodeData() { Name = nd2Name });

            // should add node with default name
            graphTest.AddNodeToGraph(nd2, false);

            Assert.Equal(nd2Name, nd2.Data.Name);
        }

        [Fact]
        public void TestRemoveNodeFromGraph() {

            var graphDataGenerator = new CompleteGraphDataGenerator(3);
            graphDataGenerator.GenerateGraphData();

            var testGraph = new GraphRepresentationModel(graphDataGenerator.GraphData);

            var nodeToRemove = graphDataGenerator.GraphData.Keys.First();

            Assert.Equal(3, graphDataGenerator.GraphData.Count);

            testGraph.RemoveNodeFromGraph(nodeToRemove);

            Assert.Equal(2, graphDataGenerator.GraphData.Count);


            var allEdgeGroups = graphDataGenerator.GraphData.Values;
            var allgraphEdges = new HashSet<IEdge<EdgeData, NodeData>>();

            foreach (var edgesOriginal in allEdgeGroups) {
                foreach (var edgeOriginal in edgesOriginal)
                {
                    allgraphEdges.Add(edgeOriginal);
                }
            }

            // also check if all incident edtges were removed!
            foreach (var edge in allgraphEdges) {
                Assert.NotEqual(edge.Node1, nodeToRemove);
                Assert.NotEqual(edge.Node2, nodeToRemove);
            }
        }


        #endregion

        #region Test add/remove/get edge
        [Fact]
        public void TestRemoveEdgeFromGraph() {
            var graphDataGenerator = new CompleteGraphDataGenerator(5);
            graphDataGenerator.GenerateGraphData();

            var graph = new GraphRepresentationModel(graphDataGenerator.GraphData);

            var edgeToRemove = graphDataGenerator.GraphData.Values.First().First();

            graph.RemoveEdgeFromGraph(edgeToRemove);

            // check if is present
            foreach (var edge in graphDataGenerator.GetAllEdges()) {
                Assert.False(edge.Node1 == edgeToRemove.Node1 && edge.Node2 == edgeToRemove.Node2);
            }

            // nodes were preserved
            Assert.Equal(5, graphDataGenerator.GraphData.Count);

            Assert.Throws<ArgumentNullException>(()=> graph.RemoveEdgeFromGraph(null));
        }

        [Fact]
        public void TestAddDirectedEdge() {
            
            var nd1 = new Node(0, 0, new NodeData());
            var nd2 = new Node(0, 6, new NodeData());

            graph.AddNodeToGraph(nd1);
            graph.AddNodeToGraph(nd2);
            
            Assert.False(graph.IsEdgeBetweenTwoNodes(nd1, nd2));

            graph.AddDirectedEdgeToGraph(nd1, nd2, new EdgeData());
            
            Assert.True(graph.HasThisNeighbour(nd1, nd2));
            Assert.False(graph.HasThisNeighbour(nd2, nd1));

            Assert.Throws<ArgumentNullException>(() => graph.AddDirectedEdgeToGraph(null, nd2, new EdgeData()));
            Assert.Throws<ArgumentNullException>(() => graph.AddDirectedEdgeToGraph(nd1, null, new EdgeData()));

            graph.RemoveNodeFromGraph(nd1);
            Assert.Throws<Exception>(() => graph.AddDirectedEdgeToGraph(nd1, nd2, new EdgeData())); // already should be in the graph

            graph.AddNodeToGraph(nd1);
            graph.RemoveNodeFromGraph(nd2);
            Assert.Throws<Exception>(() => graph.AddDirectedEdgeToGraph(nd1, nd2, new EdgeData())); // already should be in the graph
        }

        

        [Fact]
        public void TestAddUnDirectedEdge() {
            graph.Clear();

            var nd1 = new Node(0, 0, new NodeData());
            var nd2 = new Node(0, 6, new NodeData());

            graph.AddNodeToGraph(nd1);
            graph.AddNodeToGraph(nd2);

            Assert.False(graph.IsEdgeBetweenTwoNodes(nd1, nd2));

            graph.AddUnDirectedEdgeToGraph(nd1, nd2, new EdgeData());

            Assert.True(graph.HasThisNeighbour(nd1, nd2));
            Assert.True(graph.HasThisNeighbour(nd2, nd1));

            Assert.Throws<ArgumentNullException>(() => graph.AddUnDirectedEdgeToGraph(null, nd2, new EdgeData()));
            Assert.Throws<ArgumentNullException>(() => graph.AddUnDirectedEdgeToGraph(nd1, null, new EdgeData()));

            graph.RemoveNodeFromGraph(nd1);
            Assert.Throws<Exception>(() => graph.AddUnDirectedEdgeToGraph(nd1, nd2, new EdgeData())); // already should be in the graph

            graph.AddNodeToGraph(nd1);
            graph.RemoveNodeFromGraph(nd2);
            Assert.Throws<Exception>(() => graph.AddUnDirectedEdgeToGraph(nd1, nd2, new EdgeData())); // already should be in the graph
        }

        [Fact]
        public void TestGetAllNeighbourEdges() {
            var graphDataGenerator = new CompleteGraphDataGenerator(5);
            graphDataGenerator.GenerateGraphData();

            var graph = new GraphRepresentationModel(graphDataGenerator.GraphData);

            var nodeToCheck = graphDataGenerator.GraphData.Keys.First();


            int ctr = 0;
            foreach (var edge in graph.GetAllNeighbourEdges(nodeToCheck)) {

                // check if node1 equals to the right one
                Assert.Equal(edge.Node1, nodeToCheck);

                if (graphDataGenerator.GraphData.Keys.Contains(edge.Node2)) {
                    ctr++;
                }
                
            }

            Assert.Equal(4, ctr);
        }

        #endregion

        #region Get edge by coordinate
        [Fact]
        public void TestGetEdgeOnCoords() {

            var nd1 = new Node(0, 0, new NodeData());
            var nd2 = new Node(0, 6, new NodeData());

            var e12_template = new EdgeTemplate();
            e12_template.Width = 2;
            var e12_data = new EdgeData();
            e12_data.Template = e12_template;

            var e12 = new Edge(nd1, nd2, e12_data);

            var graphData = new Dictionary<INode<NodeData>, List<IEdge<EdgeData, NodeData>>>();

            graphData.Add(nd1, new List<IEdge<EdgeData, NodeData>>());
            graphData.Add(nd2, new List<IEdge<EdgeData, NodeData>>());

            graphData[nd1].Add(e12);

            var graph = new GraphRepresentationModel(graphData);


             // should be on tne line
            Assert.Equal(e12, graph.GetEdgeOnCoords((0, 3)));
            Assert.Equal(e12, graph.GetEdgeOnCoords((1, 3))); // test if width is also applied
            Assert.Equal(e12, graph.GetEdgeOnCoords((0, 6)));
            Assert.Equal(e12, graph.GetEdgeOnCoords((0, 0)));
            Assert.Null(graph.GetEdgeOnCoords((5, 3)));
            Assert.Null(graph.GetEdgeOnCoords((0, 7)));
        }

        [Fact]
        public void TestGetEdgeOnCoordsWithUnorientedEdge() {

            // what if there is also backward edge 

            var nd1 = new Node(0, 0, new NodeData());
            var nd2 = new Node(0, 6, new NodeData());

            var e12_template = new EdgeTemplate();
            e12_template.Width = 2;
            var e12_data = new EdgeData();
            e12_data.Template = e12_template;

            var e21_template = new EdgeTemplate();
            e21_template.Width = 2;
            var e21_data = new EdgeData();
            e21_data.Template = e21_template;

            var e12 = new Edge(nd1, nd2, e12_data, false);
            var e21 = new Edge(nd2, nd1, e21_data, false);// add oposite edge

            var graphData = new Dictionary<INode<NodeData>, List<IEdge<EdgeData, NodeData>>>();

            graphData.Add(nd1, new List<IEdge<EdgeData, NodeData>>());
            graphData.Add(nd2, new List<IEdge<EdgeData, NodeData>>());

            graphData[nd1].Add(e12);
            graphData[nd2].Add(e21);

            var graph = new GraphRepresentationModel(graphData);

            // should be on tne line
            Assert.True(e12 == graph.GetEdgeOnCoords((0, 3)) || e21 == graph.GetEdgeOnCoords((0, 3)));
            Assert.True(e12 == graph.GetEdgeOnCoords((1, 3)) || e21 == graph.GetEdgeOnCoords((1, 3)));
            Assert.True(e12 == graph.GetEdgeOnCoords((0, 6)) || e21 == graph.GetEdgeOnCoords((0, 6)));
            Assert.True(e12 == graph.GetEdgeOnCoords((0, 0)) || e21 == graph.GetEdgeOnCoords((0, 0)));
            Assert.Null(graph.GetEdgeOnCoords((5, 3)));
            Assert.Null(graph.GetEdgeOnCoords((0, 7)));
        }

        #endregion

    }
}


