using System;
using System.Collections.Generic;

namespace SimpleGraphEditor.Presenters.CanvasRendererMachine
{

    /// <summary>
    /// Ensures correct rendering order of shapes on canvas.
    /// </summary>
    public class CanvasRenderMachine {

        private GraphPresenter _graphPresenter;
        public Queue<Action> CurrentRenderQueue { get; private set; } = new Queue<Action>();
        
        /// <summary> Different rendering options. </summary>
        public enum RenderState {
            ///<summary>Renders only blank canvas.</summary>
            REND0,
            ///<summary>Render order: clear canvas, placed edges, placed nodes</summary>
            REND1,
            ///<summary>Render order: clear canvas, placed edges, placed nodes, node attached to mouse</summary>
            REND2,
            ///<summary>Render order: clear canvas, edges attached to mouse, placed edges, placed nodes</summary>
            REND3,
            ///<summary>Render order: clear canvas, edges attached to mouse, placed edges, placed nodes, node attached to mouse
            ///</summary>
            /*REND4*/
        }; // for more info see documentation

        private RenderState _currentState = RenderState.REND1;
        private Dictionary<RenderState, Action> _rendererMap = new Dictionary<RenderState, Action>();

        public CanvasRenderMachine(GraphPresenter newGraphPresenter) {
            this._graphPresenter = newGraphPresenter;

            #region Set up renderer states
                _rendererMap.Add(RenderState.REND0, () => { CurrentRenderQueue.Enqueue(_graphPresenter.ClearCanvas); });

                _rendererMap.Add(RenderState.REND1, () => { // default renderer
                    CurrentRenderQueue.Enqueue(_graphPresenter.ClearCanvas);
                    CurrentRenderQueue.Enqueue(_graphPresenter.UpdateEdges);
                    CurrentRenderQueue.Enqueue(_graphPresenter.UpdateNodes);
                });

                _rendererMap.Add(RenderState.REND2, () => { // e. g. new node insertion
                    CurrentRenderQueue.Enqueue(_graphPresenter.ClearCanvas);
                    CurrentRenderQueue.Enqueue(_graphPresenter.UpdateEdges);
                    CurrentRenderQueue.Enqueue(_graphPresenter.UpdateNodes);
                    CurrentRenderQueue.Enqueue(_graphPresenter.UpdateMouseDummyNode);
                });

                _rendererMap.Add(RenderState.REND3, () => { // e. g. new edge insertion
                    CurrentRenderQueue.Enqueue(_graphPresenter.ClearCanvas);
                    CurrentRenderQueue.Enqueue(_graphPresenter.UpdateMouseDummyEdge);
                    CurrentRenderQueue.Enqueue(_graphPresenter.UpdateEdges);
                    CurrentRenderQueue.Enqueue(_graphPresenter.UpdateNodes);
                });

            #endregion

            SetCurrentRenderTo(RenderState.REND1);
        }
        
        public void SetCurrentRenderTo(RenderState renderer) {
            if (!_rendererMap.ContainsKey(renderer)) throw new Exception("Renderer is missing in Map!");
            if (_currentState == renderer) return;

            _currentState = renderer;
            
            CurrentRenderQueue.Clear();
            _rendererMap[renderer]?.Invoke();
        }


    }
}
