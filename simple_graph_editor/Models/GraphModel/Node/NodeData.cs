using SimpleGraphEditor.Models.Interface;
namespace SimpleGraphEditor.Models
{

    public class NodeData {
        public string Name { get; set; }
        public bool IsEnabled { get; set; } = true; // can client interact with this node?
        public bool CanBeRendered { get; set; } = true; // Render on canvas?
        public INodeTemplate Template { get; set; } = new NodeTemplate();
        public IValueLabelTemplate LableTemplate { get; set; } = new LableTemplate();
        public string Value { get; set; } = null;
    }
}
