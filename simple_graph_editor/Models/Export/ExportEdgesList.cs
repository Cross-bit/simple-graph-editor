using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using SimpleGraphEditor.Models;
using SimpleGraphEditor.Models.Interface;
using System.Diagnostics;

namespace SimpleGraphEditor.Models.Export
{
    public class ExportEdgesList : IExportGraphData {

        private IGraphRepresentation<NodeData, EdgeData> _graphData;
        private string _filePath;
        public char DefaultDelimiter { get; set; } = '-';

        public ExportEdgesList(IGraphRepresentation<NodeData, EdgeData> graphData,
            string filePath
            )
        {
            _graphData = graphData;
            _filePath = filePath;
        }

        public void ExportData() {
            using (var file = new StreamWriter(_filePath)) {
                HashSet<INode<NodeData>> NodesWithoutEdge = new HashSet<INode<NodeData>>();
                HashSet<INode<NodeData>> NodesExported = new HashSet<INode<NodeData>>();

                foreach (var node in _graphData.GraphData.Keys) {
                    if (_graphData.GraphData[node].Count == 0) {
                        NodesWithoutEdge.Add(node);
                        continue; 
                    }

                    foreach (var edge in _graphData.GraphData[node]) {
                        NodesExported.Add(edge.Node1);
                        NodesExported.Add(edge.Node2);
                        string record = edge.Node1.Data.Name + " " + DefaultDelimiter.ToString() + " " + edge.Node2.Data.Name;
                        file.WriteLine(record);
                    }
                }

                foreach (var singleNode in NodesWithoutEdge) {
                    if(!NodesExported.Contains(singleNode))
                        file.WriteLine(singleNode.Data.Name);
                }
            }
        }
    }
}
