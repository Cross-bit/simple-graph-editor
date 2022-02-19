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

        private HashSet<INode<NodeData>> _nodesWithoutEdge;
        private HashSet<INode<NodeData>> _nodesExported;

        public ExportEdgesList(IGraphRepresentation<NodeData, EdgeData> graphData,
            string filePath
            )
        {
            _graphData = graphData;
            _filePath = filePath;
        }

        public void ExportData() {
            using (var file = new StreamWriter(_filePath)) {
                _nodesWithoutEdge = new HashSet<INode<NodeData>>();
                _nodesExported = new HashSet<INode<NodeData>>();

                this.ExportEdges(file);

                this.ExportSingleNodes(file);

            }
        }

        private void ExportEdges(StreamWriter file) {
            foreach (var node in _graphData.GraphData.Keys) {
                if (_graphData.GraphData[node].Count == 0)
                {
                    _nodesWithoutEdge.Add(node);
                    continue;
                }

                foreach (var edge in _graphData.GraphData[node])
                {
                    _nodesExported.Add(edge.Node1);
                    _nodesExported.Add(edge.Node2);
                    string record = "";

                    this.AddNodeRecordToLine(edge.Node1, ref record);
                    record += " " + DefaultDelimiter.ToString() + " ";
                    this.AddNodeRecordToLine(edge.Node2, ref record);
                    this.AddEdgeRecordToLine(edge, ref record);
                    file.WriteLine(record);
                }
            }
        }

        private void ExportSingleNodes(StreamWriter file) {
            foreach (var singleNode in _nodesWithoutEdge) {
                if (!_nodesExported.Contains(singleNode)) {
                    string record = "";
                    this.AddNodeRecordToLine(singleNode, ref record);
                    file.WriteLine(record);
                }
            }
        }


        protected virtual void AddEdgeRecordToLine(IEdge<EdgeData, NodeData> edge, ref string record) {
            if (edge.Data.Value != null && edge.Data.Value != "")
                record += "[" + edge.Data.Value + "]";
        }

        protected virtual void AddNodeRecordToLine(INode<NodeData> node, ref string record) {
            record += node.Data.Name;

            if (node.Data.Value != null && node.Data.Value != "")
                record += "(" + node.Data.Value + ")";
        }

    }
}
