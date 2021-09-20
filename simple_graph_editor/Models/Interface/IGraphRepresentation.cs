using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleGraphEditor.Models.Interface
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">Node data</typeparam>
    /// <typeparam name="S">Edge data</typeparam>
    public interface IGraphRepresentation<T, S> {
        IReadOnlyDictionary<INode<T>, List<IEdge<S, T>>> GraphData { get; }
        void AddNodeToGraph(INode<T> newNode);
        void RemoveNodeFromGraph(INode<T> newNode);
        void AddEdgeToGraph(IEdge<S, T> newEdge, INode<NodeData> node);
        void RemoveEdgeFromGraph(IEdge<EdgeData, NodeData> edgeToDelete);
        IEdge<EdgeData, NodeData> GetEdgeOnCoords((int x, int y) coordinates);
        INode<T> GetNodeOnCoordsBySize((int x, int y) coords);
        INode<T> GetNodeByPosition((int x, int y) coords);
        HashSet<(INode<T>, IEdge<S, T>)> GetConnectionsUndirected(INode<T> baseNode);
        // directed check for neighbour of baseNode
        bool HasThisNeighbour(INode<NodeData> baseNode, INode<NodeData> searchedNeighbour);
        // undirected, whether node1 and node2 are connected 
        bool AreNodesConectedByEdge(INode<NodeData> node1, INode<NodeData> node2);
    }
}