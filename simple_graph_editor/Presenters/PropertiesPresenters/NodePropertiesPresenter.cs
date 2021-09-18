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
        private INodePropertiesModel _propertiesModel;

        private INodePropertiesView _propertiesView;

        private IEditorModel _editorModel;

        public NodePropertiesPresenter(INodePropertiesView propView, INodePropertiesModel propModel, IEditorModel editorModel) {
            _propertiesModel = propModel;
            _propertiesView = propView;
            _editorModel = editorModel;

            _propertiesView.PropPresenter = this;
        }

/*        private void BindNewTemplateAndProperties(object sender, EditorTemplateChangedEventArgs args) {

            if (args.ChangedProperty == PropertyState.currNdTemplate) {
                Debug.WriteLine("dostali sme se sem");
                if (args.NodeTemplate == null) throw new Exception("Edge template is null!");
                _propertiesView.NewBackColor = args.NodeTemplate.BackColor;
                _propertiesView.NewBorderColor = args.NodeTemplate.BorderColor;
                //_propertiesView.NewBorderWidth = args.NodeTemplate.BorderWidth; // todo: fixnout
                _propertiesView.NewNodeSize = args.NodeTemplate.Size;
                _propertiesView.NewNodeShape = args.NodeTemplate.Shape;

                _propertiesView.UpdatePropertiesUI();
                UpdatePropertiesModel();
            }
        }*/


        #region update Models

        public void UpdatePropertiesModel() {
            _propertiesModel.BackColor = _propertiesView.NewBackColor;
            _propertiesModel.BorderColor = _propertiesView.NewBorderColor;
            _propertiesModel.BorderWidth = _propertiesView.NewBorderWidth;
            _propertiesModel.NodeSize = _propertiesView.NewNodeSize;
            _propertiesModel.NodeShape = _propertiesView.NewNodeShape;

        }

        // updates editors current template
        public void UpdateCurrentTemplate() {
            // new template
            var template = new NodeTemplate();
            template.BackColor = _propertiesModel.BackColor;
            template.BorderColor = _propertiesModel.BorderColor;
            template.Size = _propertiesModel.NodeSize;
            template.BorderWidth = _propertiesModel.BorderWidth;
            template.DrawBorder = template.BorderWidth <= 0 ? false : true;

            template.Shape = _propertiesModel.NodeShape;

            // set in editor
            _editorModel.CurrentNodeTemplate = template;
        }

        #endregion


    }
}