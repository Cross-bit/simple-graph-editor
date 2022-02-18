using System;
using System.Collections.Generic;
using System.IO;
using SimpleGraphEditor.Models;
using SimpleGraphEditor.Models.Interface;
using System.Diagnostics;


namespace SimpleGraphEditor.Models.Export
{
    public class ExportAdjacencyMatrix : IExportGraphData
    {
        // TODO:

        private IGraphRepresentation<NodeData, EdgeData> _graphData;
        private string _filePath;
        private int[,] _matrix; // cell options 0, 1, -1

        public char DefaultDelimiter { get; set; } = '-';

        public ExportAdjacencyMatrix(IGraphRepresentation<NodeData, EdgeData> graphData,
            string filePath
            )
        {
            _graphData = graphData;
            _filePath = filePath;

            int dims = _graphData.GraphData.Count;

            _matrix = new int[dims, dims];
        }

        public void ExportData() {
            using (var file = new StreamWriter(_filePath)) {

            }
        }

        private void GenarateMatrix() {

        }

    }
}
