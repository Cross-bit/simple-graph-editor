using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using SimpleGraphEditor.Models.Interface;
using SimpleGraphEditor.Models.GraphEditingStates;
using SimpleGraphEditor.Utils;
using SimpleGraphEditor.Models;

namespace SimpleGraphEditor.Models.GraphModel
{
    public class GraphRepresentationModel : IGraphRepresentation<NodeData, EdgeData>, IMementoOriginator
    { // (originator for memento)

        private Dictionary<INode<NodeData>, List<IEdge<EdgeData, NodeData>>> _graphData;

        public IReadOnlyDictionary<INode<NodeData>, List<IEdge<EdgeData, NodeData>>> GraphData { get => _graphData; }
        
        public GraphRepresentationModel() {
            _graphData = new Dictionary<INode<NodeData>, List<IEdge<EdgeData, NodeData>>>();
        }

        #region history
        public GraphMemento CreateMemento() { // Save current graph state
            return new GraphMemento(_graphData);
        }

        public void RestoreFromMemento(GraphMemento graphMemento) {
            if (graphMemento == null) return;
            _graphData = graphMemento.GetStateData();
        }
        #endregion

        public bool HasThisNeighbour(INode<NodeData> baseNode, INode<NodeData> searchedNeighbour) {

            if (!_graphData.ContainsKey(baseNode)) throw new Exception("basenode does not exist in graph database!");

            var baseNodeEdges = _graphData[baseNode];
            if (baseNodeEdges == null) return false;

            foreach (var edgesData in baseNodeEdges) {
                if (edgesData.Node2 == searchedNeighbour) return true;
            }
            return false;
        }

        public bool AreNodesConectedByEdge(INode<NodeData> node1, INode<NodeData> node2) {
            return HasThisNeighbour(node1, node2) || HasThisNeighbour(node2, node1);
        }

        #region Graph editing operations
        public void AddNodeToGraph(INode<NodeData> newNode) {
            if (_graphData.ContainsKey(newNode)) throw new Exception("Trying to add already existing node to database!");

            _graphData.Add(newNode, new List<IEdge<EdgeData, NodeData>>());
        }

        public void AddEdgeToGraph(IEdge<EdgeData, NodeData> newEdge, INode<NodeData> node) {
            if (node == null) throw new ArgumentNullException();
            if(!_graphData.ContainsKey(node)) throw new Exception("Database doesn't contain given node key!");
            if (_graphData[node].Contains(newEdge)) throw new Exception("Trying to add already existing edge to database!");

            _graphData[node].Add(newEdge);
        }
        public void RemoveNodeFromGraph(INode<NodeData> nodeToDelete) {
            if(nodeToDelete == null) throw new Exception("Given node is null!");
            if (!_graphData.ContainsKey(nodeToDelete)) throw new Exception("Node is not in database!");

            // remove incident edges
            foreach (var edges in _graphData.Values) {
                edges?.RemoveAll(edge => edge.Node1 == nodeToDelete || edge.Node2 == nodeToDelete);
                //TODO: možná ještě předělat reprezentaci grafu na seznam následovníků a hrany dát jako separátní list?
            }

            _graphData.Remove(nodeToDelete);
        }

        public void RemoveEdgeFromGraph(IEdge<EdgeData, NodeData> edgeToRemove) {
            if (edgeToRemove == null) throw new Exception("Given edge is null!");
            //if(edgeToRemove.Data.Template.Shape == Settings.EdgeShape.Directed) TODO: dalo by se ušetřit nějaké procházení pro undirected graph

            foreach (var edges in _graphData.Values) {
                 edges?.RemoveAll(edge => edge == edgeToRemove);
            }
        }

        // Undirectly
        public HashSet<(INode<NodeData>, IEdge<EdgeData, NodeData>)> GetConnectionsUndirected(INode<NodeData> baseNode) {
            if (baseNode == null) throw new ArgumentNullException("baseNode is null");
            if (!_graphData.ContainsKey(baseNode)) throw new Exception("baseNode is not in graph!");

            var searchResult = new HashSet<(INode<NodeData>, IEdge<EdgeData, NodeData>)>();

            // correct edges
            foreach (var edge in _graphData[baseNode]) searchResult.Add((edge.Node2, edge));

            // also edges in oposite direction
            foreach (var data in _graphData) {
                if(data.Key != baseNode)
                foreach (var edge in data.Value) { 
                    // TODO: maybe change a bit representation and turn this to O(m)... by separating list of edges from list
                    if(edge.Node2 == baseNode && !searchResult.Contains((edge.Node2, edge)))
                            searchResult.Add((edge.Node2, edge));
                }
            }

            return searchResult;
        }

        #endregion

        public INode<NodeData> GetNodeOnCoords((int x, int y) coord) {
            foreach (var node in _graphData.Keys) {
                if (IsCoordInNodeInRadius(coord, node)) return node;
            }
            return null;
        }
        
        private bool IsCoordInNodeInRadius((int x, int y) coord, INode<NodeData> node){
            var distance = Math.Sqrt(Math.Pow(node.X - coord.x, 2d) + Math.Pow(node.Y - coord.y, 2d));
            return distance < node.Data.Template.Size / 2 && node.Data.IsEnabled;
        }

        public IEdge<EdgeData, NodeData> GetEdgeOnCoords((int x, int y) coord) {
            var alreadyChecked = new HashSet<IEdge<EdgeData, NodeData>>();
            foreach (var incidentEdges in _graphData.Values) {
                foreach (var edge in incidentEdges) {
                    if (alreadyChecked.Contains(edge)) continue;

                    // check if coords lies on the edge
                    var coordsOnEdge = new CoordsOnEdge(coord, edge);
                    if (coordsOnEdge.CheckIfCoordsOnEdge()) return edge;

                    alreadyChecked.Add(edge);
                }

            }

            return null;
        }


        /*public bool IsNodeInRadius((int x, int y) coord, int radius) {
            return GetNodeInRadius(coord, radius) != null ? true : false;
        }*/


        public INode<NodeData> GetColsestNodeInRectangle((int x, int y) coordinates, int radius) {
            throw new NotImplementedException(); // TODO?
        }

    }
}