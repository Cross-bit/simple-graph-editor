using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleGraphEditor.Models
{
    public class Edge : IEdge<EdgeData, NodeData>
    {
        public INode<NodeData> Node1 { get; set; }
        public INode<NodeData> Node2 { get; set; }
        public EdgeData Data { get; set; } = new EdgeData();

        public Edge(INode<NodeData> newNode1, INode<NodeData> newNode2, EdgeData newData) {
            this.Node1 = newNode1;
            this.Node2 = newNode2;
            this.Data = newData;
        }
    }
}
