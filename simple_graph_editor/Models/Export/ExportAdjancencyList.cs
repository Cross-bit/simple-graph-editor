using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using SimpleGraphEditor.Models;
using SimpleGraphEditor.Models.Interface;

namespace SimpleGraphEditor.Models
{
    public class ExportAdjancencyList : IExportGraphData
    {
        private IGraphRepresentation<NodeData, EdgeData> _graphData;
        private string _filePath;
        public char DefaultDelimiter { get; set; } = '-';
        public char DefaultNeighbourDelimiter { get; set; } = ',';

        public ExportAdjancencyList (
        IGraphRepresentation<NodeData, EdgeData> graphData,
        string filePath 
            )
        {
            _graphData = graphData;
            _filePath = filePath;
        }

        public void ExportData() {
            using (var file = new StreamWriter(_filePath)) {

                foreach (var node in _graphData.GraphData.Keys) {
                    string record = node.Data.Name;
                    int e_ctr = 0;
                    foreach (var edge in _graphData.GraphData[node]) {
                        if (e_ctr == 0) {
                            record += " " + DefaultDelimiter.ToString();
                        }
                        record += " " + edge.Node2.Data.Name;
                        if(e_ctr < _graphData.GraphData[node].Count-1)
                            record += DefaultNeighbourDelimiter;
                        e_ctr++;
                    }

                    file.WriteLine(record);
                }
            }
        }
    }
}
