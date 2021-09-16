using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleGraphEditor.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">Edge data type</typeparam>
    /// <typeparam name="S">Node data type</typeparam>
    public interface IEdge<T, S> {
        INode<S> Node1 { get; set; }
        INode<S> Node2 { get; set; }
        T Data { get; set; }
    }
}

