using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleGraphEditor.Presenters;
using SimpleGraphEditor.Models;
using SimpleGraphEditor.Models.Interface;
using SimpleGraphEditor.Models.Properties;
using SimpleGraphEditor.Views;
using SimpleGraphEditor.Utils;

namespace SimpleGraphEditor
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            //MathHelpers.GetProjectionOnLine((1, 3), (3, 2));
            Application.SetHighDpiMode(HighDpiMode.SystemAware);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var ndPropForm = new NodePropertiesForm();
            var edgePropForm = new EdgePropertiesForm();
            var editorForm = new EditorForm(ndPropForm, edgePropForm);

            IGraphRepresentation<NodeData, EdgeData> graphRepresentatioModel = new GraphRepresentationModel();
            IEditorModel editorModel = new EditorModel();
            InfoTextBoxPresenter infoTextBoxPresenter = new InfoTextBoxPresenter(editorForm, editorModel);
            
            var GraphPresenter = new GraphPresenter(editorForm, graphRepresentatioModel, editorModel);

            var ToolStripPresenter = new ToolStripPresenter((IToolStripView)editorForm, graphRepresentatioModel);

            /* properties panels */
            INodePropertiesModel ndPropertiesModel = new NodePropertiesModel();
            IEdgePropertiesModel edgePropertiesModel = new EdgePropertiesModel();


            var NdPropertiesPresenter = new NodePropertiesPresenter(ndPropForm, ndPropertiesModel, editorModel);
            var EdgePropertiesPresenter = new EdgePropertiesPresenter(edgePropForm, edgePropertiesModel, editorModel);


            Application.Run(editorForm);
        }
    }
}
