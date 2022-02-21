using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleGraphEditor.Models.Interface
{
    /// <summary>
    /// Base interface for graph representation.
    /// </summary>
    /// <typeparam name="TNodeData">Node data</typeparam>
    /// <typeparam name="TEdgeData">Edge data</typeparam>
    public interface IGraphRepresentation<TNodeData, TEdgeData> {

        /// <summary>Adds new node to the graph. </summary>
        /// <param name="newNode"></param>
        /// <param name="createDefaultName">Whether to override name by automatically generated in the graph model.</param>
        void AddNodeToGraph(INode<TNodeData> newNode, bool createDefaultName = true);

        /// <summary>Removes given node from the graph.</summary>
        /// <param name="nodeToRemove"></param>
        void RemoveNodeFromGraph(INode<TNodeData> nodeToRemove);

        /// <summary> Add new edge to the graph. </summary>
        /// <param name="newEdge"></param>
        /// <param name="node"></param>
        [Obsolete]
        void AddEdgeToGraph(IEdge<TEdgeData, TNodeData> newEdge, INode<NodeData> node);

        /// <summary> Add new edge to the graph, between node1 and node2. </summary>
        /// <param name="node1"></param>
        /// <param name="node2"></param>
        /// <param name="edgeData"></param>
        void AddDirectedEdgeToGraph(INode<NodeData> node1, INode<NodeData> node2, TEdgeData edgeData);

        /// <summary> Add new edge to the graph, between node1 and node2. </summary>
        /// <param name="node1"></param>
        /// <param name="node2"></param>
        /// <param name="edgeData"></param>
        void AddUnDirectedEdgeToGraph(INode<NodeData> node1, INode<NodeData> node2, TEdgeData edgeData);

        /// <summary> Removes given edge from the graph. </summary>
        /// <param name="edgeToRemove"></param>
        void RemoveEdgeFromGraph(IEdge<EdgeData, NodeData> edgeToDelete);

        /// <summary> Removes all data from the graph. </summary>
        void Clear();

        /// <summary> Returns all edges that origins in the base nodes. </summary>
        /// <param name="baseNode"></param>
        ICollection<IEdge<EdgeData, NodeData>> GetAllNeighbourEdges(INode<NodeData> baseNode);

        /// <summary> Returns enumerable of all edges in the graph. </summary>
        IEnumerable<IEdge<EdgeData, NodeData>> GetAllEdges();

        /// <summary> Returns enumerable of all nodes in the graph. </summary>
        IEnumerable<INode<NodeData>> GetAllNodes();

        /// <summary> Current number of nodes in the graph. </summary>
        int Size { get; }
        
        /// <summary> Gets edge based on position and edge line width.</summary>
        /// <param name="coordinates"></param>
        /// <returns></returns>
        IEdge<EdgeData, NodeData> GetEdgeOnCoords((int x, int y) coordinates);
        INode<TNodeData> GetNodeOnCoordsBySize((int x, int y) coords);
        INode<TNodeData> GetNodeByPosition((int x, int y) coords);
        HashSet<(INode<TNodeData>, IEdge<TEdgeData, TNodeData>)> GetConnectionsUndirected(INode<TNodeData> baseNode);
        // directed check for neighbour of baseNode
        bool HasThisNeighbour(INode<NodeData> baseNode, INode<NodeData> searchedNeighbour);
        
        /// <summary>Checks if there exists any connection(edge) between two given nodes.</summary>
        /// <param name="node1"></param>
        /// <param name="node2"></param>
        /// <returns>True if there is edge.</returns>
        bool IsEdgeBetweenTwoNodes(INode<NodeData> node1, INode<NodeData> node2);
    }
}