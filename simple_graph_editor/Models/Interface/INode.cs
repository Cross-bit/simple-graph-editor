using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleGraphEditor.Models.Interface
{
    /// <summary>
    /// Node representation interface.
    /// </summary>
    /// <typeparam name="T">Node data type.</typeparam>
    public interface INode<T> {

        /// <summary>Specifice Y coordinate of the nodes location.</summary>
        int Y { get; set; }

        /// <summary>Specifice X coordinate of the nodes location.</summary>
        int X { get; set; }

        /// <summary> Represents data of this node. </summary>
        T Data { get; set; }
    }
}
