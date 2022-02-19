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


    public class TestGraphCopy {

        [Fact]
        public void TestCreateCopy() {

            // create complete K5 and test if it copies correctly
            IGraphRepresentation<NodeData, EdgeData> graph = new GraphRepresentationModel();
            var graphDataGenerator = new CompleteGraphDataGenerator(5, graph);
            graphDataGenerator.GenerateGraphData();

            

          //  var copier = new CopyGraphData(graph.GraphData);



            /*var nd1 = new Node(0, 0, new NodeData() { Value = "1" });
            var nd2 = new Node(0, 1, new NodeData() { Value = "2" });
            var nd3 = new Node(0, 2, new NodeData() { Value = "3" });
            var nd4 = new Node(0, 3, new NodeData() { Value = "4" });
            var nd5 = new Node(0, 4, new NodeData() { Value = "5" });

            var single = new Node(0, 4, new NodeData() { Value = "42" });

            var e1_2 = new Edge(nd1, nd2, new EdgeData());
            var e1_3 = new Edge(nd1, nd3, new EdgeData());
            var e1_4 = new Edge(nd1, nd4, new EdgeData());
            var e1_5 = new Edge(nd1, nd5, new EdgeData());

            var e2_1 = new Edge(nd2, nd1, new EdgeData());
            var e2_3 = new Edge(nd2, nd3, new EdgeData());
            var e2_4 = new Edge(nd2, nd4, new EdgeData());
            var e2_5 = new Edge(nd2, nd5, new EdgeData());

            var e3_1 = new Edge(nd3, nd1, new EdgeData());
            var e3_2 = new Edge(nd3, nd2, new EdgeData());
            var e3_4 = new Edge(nd3, nd4, new EdgeData());
            var e3_5 = new Edge(nd3, nd5, new EdgeData());

            var e4_1 = new Edge(nd4, nd2, new EdgeData());
            var e4_2 = new Edge(nd4, nd2, new EdgeData());
            var e4_3 = new Edge(nd4, nd2, new EdgeData());
            var e4_5 = new Edge(nd4, nd2, new EdgeData());

            var e5_1 = new Edge(nd1, nd2, new EdgeData());
            var e5_2 = new Edge(nd1, nd2, new EdgeData());
            var e5_3 = new Edge(nd1, nd2, new EdgeData());
            var e5_4 = new Edge(nd1, nd2, new EdgeData());*/



            /*graph.AddNodeToGraph(nd1);
            graph.AddEdgeToGraph(e1_2, nd1);*/


        }



    }
}
