using System;
using System.Collections.Generic;
using System.Text;
using SimpleGraphEditor.Views;
using SimpleGraphEditor.Models;
using SimpleGraphEditor.Models.Interface;
using System.Diagnostics;

namespace SimpleGraphEditor.Presenters
{
    using PropertyState = EditorTemplateChangedEventArgs.PropChanged;

    public class NodePropertiesPresenter
    {

        private INodePropertiesView _propertiesView;

        private IEditorModel _editorModel;

        public NodePropertiesPresenter(INodePropertiesView propView, IEditorModel editorModel) {
            _propertiesView = propView;
            _editorModel = editorModel;

            _propertiesView.PropPresenter = this;
        }

        #region update Models

        // updates editors current template
        public void UpdateCurrentTemplate() {
            // new template
            var template = new NodeTemplate();
            template.BackColor = _propertiesView.NewBackColor;
            template.BorderColor = _propertiesView.NewBorderColor;
            template.Size = _propertiesView.NewNodeSize; 
            template.BorderWidth = _propertiesView.NewBorderWidth;
            template.DrawBorder = template.BorderWidth <= 0 ? false : true;

            template.Shape = _propertiesView.NewNodeShape;

            // set in editor
            _editorModel.CurrentNodeTemplate = template;
        }

        #endregion


    }
}