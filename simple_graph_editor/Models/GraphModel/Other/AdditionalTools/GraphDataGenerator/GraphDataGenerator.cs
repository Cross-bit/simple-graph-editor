using SimpleGraphEditor.Models;
using SimpleGraphEditor.Models.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleGraphEditor.Models.GraphModel
{
    public abstract class GraphDataGenerator {

        protected int _graphSize;
        protected Dictionary<INode<NodeData>, List<IEdge<EdgeData, NodeData>>> _graphData;

        public Dictionary<INode<NodeData>, List<IEdge<EdgeData, NodeData>>> GraphData => _graphData;

        public GraphDataGenerator(int graphSize) {
            
            _graphSize = graphSize < 0 ? 0 : graphSize;

            _graphData ??= new Dictionary<INode<NodeData>, List<IEdge<EdgeData, NodeData>>>(graphSize);
        }

        public virtual void GenerateGraphData() {

            if (_graphData.Count >= _graphSize)
                return;

            GenerateNodes();
            GenerateEdges();
        }

        public virtual IEnumerable<IEdge<EdgeData, NodeData>> GetAllEdges() {
            foreach (var edgeGroup in _graphData.Values) {
                foreach (var edge in edgeGroup) {
                    yield return edge;
                }
            }
        }

        protected abstract void GenerateNodes();

        protected abstract void GenerateEdges();
    }
}
