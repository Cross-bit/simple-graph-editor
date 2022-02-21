using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleGraphEditor.Models.Interface
{
    /// <summary>
    /// Node representation interface.
    /// </summary>
    /// <typeparam name="TNodeData">Node data type.</typeparam>
    public interface INode<TNodeData> {

        /// <summary>Specifice Y coordinate of the nodes location.</summary>
        int Y { get; set; }

        /// <summary>Specifice X coordinate of the nodes location.</summary>
        int X { get; set; }

        /// <summary> Represents data of this node. </summary>
        TNodeData Data { get; set; }
    }
}
