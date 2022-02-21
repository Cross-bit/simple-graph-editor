using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleGraphEditor.Models.Interface
{
    /// <summary>
    /// Edge representation interface.
    /// </summary>
    /// <typeparam name="TEdgeData">Edge data type</typeparam>
    /// <typeparam name="TNodeData">Node data type</typeparam>
    public interface IEdge<TEdgeData, TNodeData> {

        /// <summary> Specifice first node of this edge in the graph. (Thus specifice orientation of this edge.) </summary>
        INode<TNodeData> Node1 { get; set; }

        /// <summary> Specifice end node of this edge in the graph. (Thus specifice orientation of this edge.) </summary>
        INode<TNodeData> Node2 { get; set; }

        /// <summary> Represents data of this edge. </summary>
        TEdgeData Data { get; set; }

        /// <summary> Wheter this edge is directed. </summary>
        bool IsDirected { get; }
    }
}

