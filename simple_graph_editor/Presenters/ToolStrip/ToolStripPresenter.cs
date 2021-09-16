using System;
using System.Collections.Generic;
using System.Text;
using SimpleGraphEditor.Models;
using SimpleGraphEditor.Views;
using SimpleGraphEditor.Models.Interface;
using SimpleGraphEditor.Models.Export;


namespace SimpleGraphEditor.Presenters
{
    public class ToolStripPresenter {

        IGraphRepresentation<NodeData, EdgeData> _graphModel;
        IToolStripView _stripView;

        IExportGraphData _exportEdgeList;

        public ToolStripPresenter(IToolStripView stripView, IGraphRepresentation<NodeData, EdgeData> graphModel) {
            _graphModel = graphModel;
            _stripView = stripView;

            _stripView.StripPresenter = this;
        }


        public void ExportListOfEdges(string savePath) {
            _exportEdgeList = new ExportEdgesList(_graphModel, savePath);
            _exportEdgeList.ExportData();
        }

        public void ExportAdjancencyList(string savePath) {
            _exportEdgeList = new ExportAdjacencyList(_graphModel, savePath);
            _exportEdgeList.ExportData();
        }

        public void ExportPrintScreen(string savePath) {
            
        }

    }
}
