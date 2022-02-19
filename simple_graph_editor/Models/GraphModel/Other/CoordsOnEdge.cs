using System;
using System.Diagnostics;
using SimpleGraphEditor.Utils;
using SimpleGraphEditor.Models.Interface;
using SimpleGraphEditor.GeneralSettings;

namespace SimpleGraphEditor.Models.GraphModel
{
    // Checks if given coords are on the given edge
    public class CoordsOnEdge {
        (int x, int y) _coords;
        IEdge<EdgeData, NodeData> _edge;

        (int x, int y) _dirVector;

        (int x, int y) _coordsProjection;
        (int x, int y) _projStartNode;
        (int x, int y) _projEndNode;

        private float _maxDistCoef;

        public int MaxDistToleranceCoef { get; set; } = 1;


        public CoordsOnEdge((int x, int y) coords, IEdge<EdgeData, NodeData> edge) {
            _coords = coords;
            _edge = edge;
            _maxDistCoef = this.GetDefaultDistanceCoef();
        }

        public bool CheckIfCoordsOnEdge() {
            // set direction vector for line
            SetProjections();

            return this.IsCoordOnLine() && this.IsCoordBetweenTwoPoints();
        }

        private void SetProjections() {
            _dirVector = (_edge.Node1.X - _edge.Node2.X, _edge.Node1.Y - _edge.Node2.Y);
            // calculate projections on line
            _coordsProjection = MathHelpers.GetProjectionOnLine(_coords, _dirVector);
            _projStartNode = MathHelpers.GetProjectionOnLine((_edge.Node1.X, _edge.Node1.Y), _dirVector);
            _projEndNode = MathHelpers.GetProjectionOnLine((_edge.Node2.X, _edge.Node2.Y), _dirVector);
        }
        private float GetDefaultDistanceCoef() =>
            (_edge.Data.Template.Width / 2) + Settings.EdgeSelectionTolerancCoef;

        private bool IsCoordOnLine() {

            int distRef = MathHelpers.GetVectorsDistance((_edge.Node1.X, _edge.Node1.Y), _projStartNode);
            int perpDistFromLine = MathHelpers.GetVectorsDistance(_coords, _coordsProjection);
            int realDist = Math.Abs(perpDistFromLine - distRef);

            return realDist < _maxDistCoef;
        }

        private bool IsCoordBetweenTwoPoints() {
            // Distance of coord projection to:
            // start node projection
            int distToStartNodeProjection = MathHelpers.GetVectorsDistance(_projStartNode, _coordsProjection);
            // end node projection
            int distToEndNodeProjection = MathHelpers.GetVectorsDistance(_projEndNode, _coordsProjection);

            int edgeLength = MathHelpers.GetVectorNorm((_edge.Node1.X - _edge.Node2.X, _edge.Node1.Y - _edge.Node2.Y));

            return Math.Abs((distToStartNodeProjection + distToEndNodeProjection) - edgeLength) <= MaxDistToleranceCoef;
        }
    }
}
