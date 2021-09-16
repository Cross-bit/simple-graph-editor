using System;
using System.Collections.Generic;
using System.Text;
using SimpleGraphEditor.Models;
using SimpleGraphEditor.Models.Interface;
using SimpleGraphEditor.Views;

namespace SimpleGraphEditor.Presenters
{
    using PropertyState = EditorTemplateChangedEventArgs.PropChanged;
    public class EdgePropertiesPresenter  {

        IEdgePropertiesModel _propertiesModel;
        IEdgePropertiesView _propertiesView;
        IEditorModel _editorModel;

        public EdgePropertiesPresenter(
            IEdgePropertiesView propView,
            IEdgePropertiesModel propModel,
            IEditorModel editorModel
            ) 
        {
            _propertiesModel = propModel;
            _propertiesView = propView;
            _editorModel = editorModel;

            _propertiesView.propPresenter = this;

        }
        
        /*private void BindNewTemplateAndProperties(object sender, EditorTemplateChangedEventArgs args) {

            if (args.ChangedProperty == PropertyState.currEdgeTemplate) {
                if (args.EdgeTemplate == null) throw new Exception("Edge template is null!");
                _propertiesView.NewEdgeColor = args.EdgeTemplate.Color;
                _propertiesView.NewEdgeWidth = args.EdgeTemplate.Width;
                _propertiesView.NewEdgeIsDirected = args.EdgeTemplate.IsDirected;
                UpdatePropertiesModel();
            }
        }*/

        #region update model
        public void UpdatePropertiesModel() {
            _propertiesModel.LineColor = _propertiesView.NewEdgeColor;
            _propertiesModel.IsDirected = _propertiesView.NewEdgeIsDirected;
            _propertiesModel.LineWidth = _propertiesView.NewEdgeWidth;
        }

        public void UpdateCurrentTemplate() {
            var newEdgeTemplate = new EdgeTemplate();

            newEdgeTemplate.Color =  _propertiesModel.LineColor;
            newEdgeTemplate.IsDirected = _propertiesModel.IsDirected;
            newEdgeTemplate.Width = _propertiesModel.LineWidth;

            _editorModel.CurrentEdgeTemplate = newEdgeTemplate;
        }
        #endregion
    }
}
