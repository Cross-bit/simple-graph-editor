using SimpleGraphEditor.Models;
using SimpleGraphEditor.Models.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitTestSimpleGraphEditor.AdditionalTools.GraphGenerator
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

        protected abstract void GenerateNodes();

        protected abstract void GenerateEdges();
    }
}
