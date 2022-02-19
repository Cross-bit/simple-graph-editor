using System.IO;
using SimpleGraphEditor.Models.Interface;

namespace SimpleGraphEditor.Models.Export
{
    public class ExportAdjacencyList : IExportGraphData
    {
        private IGraphRepresentation<NodeData, EdgeData> _graphData;
        private string _filePath;
        public char DefaultDelimiter { get; set; } = '-';
        public char DefaultNeighbourDelimiter { get; set; } = ',';

        public ExportAdjacencyList (
        IGraphRepresentation<NodeData, EdgeData> graphData,
        string filePath 
            )
        {
            _graphData = graphData;
            _filePath = filePath;
        }

        public void ExportData() {
            using (var file = new StreamWriter(_filePath)) {

                foreach (var node in _graphData.GetAllNodes()) {
                    string record = "";
                    this.AddNodeRecordToLine(node, ref record);

                    int e_ctr = 0;
                    foreach (var edge in _graphData.GetAllNeighbourEdges(node)) {
                        if (e_ctr == 0) {
                            record += " " + DefaultDelimiter.ToString();
                        }
                        record += " ";
                        this.AddNodeRecordToLine(edge.Node2, ref record);
                        this.AddEdgeRecordToLine(edge, ref record);
                        if (e_ctr < _graphData.GetAllNeighbourEdges(node).Count-1)
                            record += DefaultNeighbourDelimiter;
                        e_ctr++;
                    }

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
