using SimpleGraphEditor.Models;
using SimpleGraphEditor.Models.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitTestSimpleGraphEditor.AdditionalTools.GraphGenerator
{
    public abstract class GraphDataGenerator {

        protected int _graphSize;
        protected IGraphRepresentation<NodeData, EdgeData> _graphGenerated;

        public GraphDataGenerator(int graphSize, IGraphRepresentation<NodeData, EdgeData> emptyGraph) {
            _graphSize = graphSize;
            _graphGenerated = emptyGraph;
        }

        public virtual void GenerateGraphData() {

            if (_graphGenerated.GraphData == null)
                throw new Exception("Graph data instance does not exist!");

            if (_graphGenerated.GraphData.Count >= _graphSize)
                return;

            GenerateNodes();
            GenerateEdges();
        }

        protected abstract void GenerateNodes();

        protected abstract void GenerateEdges();
    }
}
