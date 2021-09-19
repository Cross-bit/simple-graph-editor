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

        IEdgePropertiesView _propertiesView;
        IEditorModel _editorModel;

        public EdgePropertiesPresenter(
            IEdgePropertiesView propView,
            IEditorModel editorModel
            ) 
        {
            _propertiesView = propView;
            _editorModel = editorModel;

            _propertiesView.propPresenter = this;

        }
        
        #region update model
        public void UpdateCurrentTemplate() {
            var newEdgeTemplate = new EdgeTemplate();

            newEdgeTemplate.Color = _propertiesView.NewEdgeColor;
            newEdgeTemplate.IsDirected = _propertiesView.NewEdgeIsDirected;
            newEdgeTemplate.Width = _propertiesView.NewEdgeWidth;

            _editorModel.CurrentNewEdgeTemplate = newEdgeTemplate;
        }
        #endregion
    }
}
