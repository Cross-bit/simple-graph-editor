using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleGraphEditor.Models.Interface
{
    /// <summary>
    /// Base interface for graph with givne representation 
    /// </summary>
    /// <typeparam name="T">Node data</typeparam>
    /// <typeparam name="S">Edge data</typeparam>
    public interface IGraphRepresentation<T, S> {

        /// <summary>Adds new node to the graph. </summary>
        /// <param name="newNode"></param>
        /// <param name="createDefaultName">Whether to override name by automatically generated in the graph model.</param>
        void AddNodeToGraph(INode<T> newNode, bool createDefaultName = true);

        /// <summary>Removes given node from the graph.</summary>
        /// <param name="nodeToRemove"></param>
        void RemoveNodeFromGraph(INode<T> nodeToRemove);

        /// <summary> Add new edge to the graph. </summary>
        /// <param name="newEdge"></param>
        /// <param name="node"></param>
        void AddEdgeToGraph(IEdge<S, T> newEdge, INode<NodeData> node);
        
        /// <summary> Removes given edge from the graph. </summary>
        /// <param name="edgeToRemove"></param>
        void RemoveEdgeFromGraph(IEdge<EdgeData, NodeData> edgeToDelete);

        /// <summary> Returns all edges that origins in the base nodes. </summary>
        /// <param name="baseNode"></param>
        ICollection<IEdge<EdgeData, NodeData>> GetAllNeighbourEdges(INode<NodeData> baseNode);

        /// <summary> Returns enumerable of all edges in the graph. </summary>
        IEnumerable<IEdge<EdgeData, NodeData>> GetAllEdges();

        /// <summary> Returns enumerable of all nodes in the graph. </summary>
        IEnumerable<INode<NodeData>> GetAllNodes();

        /// <summary> Current number of nodes in the graph. </summary>
        int NodesCount { get; }
        
        IEdge<EdgeData, NodeData> GetEdgeOnCoords((int x, int y) coordinates);
        INode<T> GetNodeOnCoordsBySize((int x, int y) coords);
        INode<T> GetNodeByPosition((int x, int y) coords);
        HashSet<(INode<T>, IEdge<S, T>)> GetConnectionsUndirected(INode<T> baseNode);
        // directed check for neighbour of baseNode
        bool HasThisNeighbour(INode<NodeData> baseNode, INode<NodeData> searchedNeighbour);
        
        /// <summary>Checks if there exists any connection(edge) between two given nodes.</summary>
        /// <param name="node1"></param>
        /// <param name="node2"></param>
        /// <returns>True if there is edge.</returns>
        bool IsEdgeBetweenTwoNodes(INode<NodeData> node1, INode<NodeData> node2);
    }
}