using System;
using System.Collections.Generic;
using SimpleGraphEditor.Models.Interface;

namespace SimpleGraphEditor.Models
{
    public class EditorModel : IEditorModel
    {

        public INode<NodeData> SelectedNode { get; set; }
        public INodeTemplate CurrentNewNodeTemplate { private get => _currentNodeTemplate; set {
                _currentNodeTemplate = value;
                OnPropertyChanged(EditorTemplateChangedEventArgs.PropChanged.currNdTemplate);
            } 
        }

        private INodeTemplate _currentNodeTemplate = new NodeTemplate();
        public IEdgeTemplate CurrentNewEdgeTemplate { private get => _currentEdgeTemplate; set {
                _currentEdgeTemplate = value;
                OnPropertyChanged(EditorTemplateChangedEventArgs.PropChanged.currEdgeTemplate);
            }
        }

        private IEdgeTemplate _currentEdgeTemplate = new EdgeTemplate();
        public IValueLabelTemplate CurrentNewLableTemplate {
            private get => _currentLableTemplate; set {
                _currentLableTemplate = value;
            }
        }

        private IValueLabelTemplate _currentLableTemplate = new LableTemplate();

        public (int X, int Y) CanvasMousePosition { get; private set; }
        public string CurrentHistoryState { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event EventHandler<EventArgs> MouseMove;

      //  public event EventHandler<EditorTemplateChangedEventArgs> TemplateChanged; TODO:

        protected virtual void OnPropertyChanged(EditorTemplateChangedEventArgs.PropChanged property) {
            /*TemplateChanged?.Invoke(this, new EditorTemplateChangedEventArgs() {
                ChangedProperty = property,
                EdgeTemplate = _currentEdgeTemplate,
                NodeTemplate = _currentNodeTemplate,
                ValueTemplate = _currentLableTemplate
            });*/
        }

        public IEdgeTemplate GetCopyOfCurrentEdgeTemplate() {
            return ((ICloneable)CurrentNewEdgeTemplate).Clone() as IEdgeTemplate;
        }

        public INodeTemplate GetCopyOfCurrentNodeTemplate() {
            return ((ICloneable)CurrentNewNodeTemplate).Clone() as INodeTemplate;
        }
        public IValueLabelTemplate GetCopyOfCurrentLableTemplate() {
            return ((ICloneable)CurrentNewLableTemplate).Clone() as IValueLabelTemplate;
        }

        public void SetActiveObjects(HashSet<(INode<NodeData>, IEdge<EdgeData, NodeData>)> data) {
            throw new NotImplementedException();
        }

        public void SetMousePosition((int X, int Y) coords) {
            CanvasMousePosition = coords;
            OnMousePositionChanged(); 
        }

        protected virtual void OnMousePositionChanged() =>
            MouseMove?.Invoke(this, EventArgs.Empty); // position changed, inform subs
    }

    public class EditorTemplateChangedEventArgs : EventArgs {
        public enum PropChanged { currNdTemplate, currEdgeTemplate, currLableTemplate }

        public IEdgeTemplate EdgeTemplate = null;
        public INodeTemplate NodeTemplate = null;
        public IValueLabelTemplate ValueTemplate = null;

        public PropChanged ChangedProperty;
    }
}
