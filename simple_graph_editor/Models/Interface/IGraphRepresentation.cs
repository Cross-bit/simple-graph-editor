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
        
        void AddNodeToGraph(INode<T> newNode, bool createDefaultName = true);
        void RemoveNodeFromGraph(INode<T> newNode);
        void AddEdgeToGraph(IEdge<S, T> newEdge, INode<NodeData> node);
        /// <summary> Removes given edge from the graph. </summary>
        /// <param name="edgeToRemove"></param>
        void RemoveEdgeFromGraph(IEdge<EdgeData, NodeData> edgeToDelete);

        ICollection<IEdge<EdgeData, NodeData>> GetAllNeighbourEdges(INode<NodeData> baseNode);
        IEnumerable<IEdge<EdgeData, NodeData>> GetAllEdges();
        IEnumerable<INode<NodeData>> GetAllNodes();
        int NodesCount { get; }

        IEdge<EdgeData, NodeData> GetEdgeOnCoords((int x, int y) coordinates);
        INode<T> GetNodeOnCoordsBySize((int x, int y) coords);
        INode<T> GetNodeByPosition((int x, int y) coords);
        HashSet<(INode<T>, IEdge<S, T>)> GetConnectionsUndirected(INode<T> baseNode);
        // directed check for neighbour of baseNode
        bool HasThisNeighbour(INode<NodeData> baseNode, INode<NodeData> searchedNeighbour);
        // undirected, whether node1 and node2 are connected 
        /// <summary>bla bla </summary>
        /// <param name="node1"></param>
        /// <param name="node2"></param>
        /// <returns></returns>
        bool IsEdgeBetweenTwoNodes(INode<NodeData> node1, INode<NodeData> node2);
    }
}