using SimpleGraphEditor.Models.Interface;

namespace SimpleGraphEditor.Models
{
    public class Node : INode<NodeData> {

        public int X { get; set; }
        public int Y { get; set; }

        public NodeData Data { get; set; }

        public Node(int newX, int newY, NodeData newData) {
            this.X = newX;
            this.Y = newY;
            this.Data = newData;
        }


        public static bool operator ==(Node a, INode<NodeData> b) {
            return a.X == b.X && a.Y == b.Y; }

        public static bool operator !=(Node a, INode<NodeData> b) {
            return a.X != b.X && a.Y != b.Y; }

        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
                return false;
            else {
                INode<NodeData> node = (INode<NodeData>)obj;
                return node.X == this.X && node.Y == this.Y;
            }
        }
    }
}
