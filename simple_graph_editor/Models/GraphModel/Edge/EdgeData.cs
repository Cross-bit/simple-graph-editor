using SimpleGraphEditor.Models.Interface;
using SimpleGraphEditor.GeneralSettings;
using SimpleGraphEditor.Utils;

namespace SimpleGraphEditor.Models
{
    public class EdgeData {
        public IEdgeTemplate Template { get; set; } = new EdgeTemplate();
        public IValueLabelTemplate LabelTemplate { get; set; } = new LableTemplate();
        public bool CanBeRendered { get; set; } = true;
        public string Value { get; set; }

        public (int x, int y) CalculateEdgeLablePosition(IEdge<EdgeData, NodeData> edge) {
            (int x, int y) centerPoint = ((edge.Node1.X + edge.Node2.X) / 2, (edge.Node1.Y + edge.Node2.Y) / 2);
            /*var xCoord = edge.Node1.X < edge.Node2.X ? edge.Node1.X - edge.Node2.X : edge.Node2.X - edge.Node1.X;
            var yCoord = edge.Node1.Y < edge.Node2.Y ? edge.Node2.Y - edge.Node1.Y : edge.Node1.Y - edge.Node2.Y;
            (int x, int y) dirVector = (xCoord, yCoord);*/
            (int x, int y) dirVector = (edge.Node1.X - edge.Node2.X, edge.Node1.Y - edge.Node2.Y); 
             (int x, int y) perpendicularVec = (dirVector.y, dirVector.x * (-1));
            (int x, int y) sizedPerpendicular = MathHelpers.GetVectorOfGivenLength(perpendicularVec, Settings.DefaultLableDistFromEdge);

            return (sizedPerpendicular.x + centerPoint.x, sizedPerpendicular.y + centerPoint.y);
        }
    }
}
