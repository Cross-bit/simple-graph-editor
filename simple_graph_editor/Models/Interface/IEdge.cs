using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleGraphEditor.Models.Interface
{
    /// <summary>
    /// Edge representation interface.
    /// </summary>
    /// <typeparam name="T">Edge data type</typeparam>
    /// <typeparam name="S">Node data type</typeparam>
    public interface IEdge<T, S> {

        /// <summary> Specifice first node of this edge in the graph. (Thus specifice orientation of this edge.) </summary>
        INode<S> Node1 { get; set; }

        /// <summary> Specifice end node of this edge in the graph. (Thus specifice orientation of this edge.) </summary>
        INode<S> Node2 { get; set; }

        /// <summary> Represents data of this edge. </summary>
        T Data { get; set; }
    }
}

