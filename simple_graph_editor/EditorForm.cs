using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleGraphEditor.Presenters;
using SimpleGraphEditor.Views;
using System.Runtime.InteropServices;
using SimpleGraphEditor.Vendor;

namespace SimpleGraphEditor
{

    public partial class EditorForm : System.Windows.Forms.Form, IGraphView {

        public GraphPresenter MainPresenter { private get; set; }

        #region new node template data
        // Mouse node
        public Color NewNodeBorderColor { get; set; } = Color.Black;
        public Color NewNodeColor { get; set; } = Color.Black;
        public int NewNodeSize { get; set; } = 40;
        public int NewNodeBorderWidth { get; set; } = 3;
        public bool NewNodeDrawBorder { get; set; } = false;
        public Settings.NodeShape NewNodeShape { get; set; } = Settings.NodeShape.Circle;
        #endregion

        #region new edge template data
        public bool NewEdgeIsDirected { get; set; } = false;
        public Color NewEdgeColor { get; set; } = Color.Black;
        public int NewEdgeWidth { get; set; } = 4;
        #endregion

        #region new lable template data
        public int NewLabelFontSize { get; set; }
        public Color NewLabelFontColor { get; set; }
        public string NewLableTextValue { get; set; }
        #endregion

        public Color CanvasBackColor { get; private set; } = Settings.CanvasDefaultColor;
        public List<(int x, int y)> ActiveNodesPositions { get; set; } = new List<(int x, int y)>();
        public (int X, int Y) MouseCoords { get; set; }

        private Rectangle _mouseRectangle;

        private Point _currentEdgeStart = new Point(0, 0);

        // Pen settings
        private SolidBrush _currentNodeBrush = new SolidBrush(Color.Black);
        private Pen _currentNodePen = new Pen(Color.Black, 5);

        private Pen _currentEdgePen = new Pen(Color.Black, Settings.DefaultEdgeWidth);

        private int _arrowSize = 10; //TODO:

        private Dictionary<(int x, int y), Label> _elementsValuesTexts = new Dictionary<(int x, int y), Label>();

        private (int x, int y) _lastMouseClickedCoords;

        private TextBox _valueInsertionBox  = new TextBox(); // for entering node/edge value data

        Graphics _canvasGraphics;

        public event EventHandler<EventArgs> ClientConfirmedOperation;

        private EdgePropertiesForm _edgePropertiesForm;
        private NodePropertiesForm _nodePropertiesForm;
        private Form _currentPropertiesForm;

        public EditorForm(NodePropertiesForm nodePropertiesForm, EdgePropertiesForm edgePropertiesForm) {
            this.DoubleBuffered = true;
            this.KeyPreview = true;

            _edgePropertiesForm = edgePropertiesForm;
            _nodePropertiesForm = nodePropertiesForm;

            InitializeComponent();

            InitializeCanvas();
            InitializeToolStrip();
            InitializeToolsPanel();
            InitializeInfoTextBox();
            InitializeOther();
        }

        private void InitializeOther() {
            _valueInsertionBox.Visible = false;
            _valueInsertionBox.Parent = MainCanvas;
            //_valueInsertionBox.BorderStyle = BorderStyle.None;
            _valueInsertionBox.TextAlign = HorizontalAlignment.Center;

            PropertiesPanel.Visible = false;

            // on main window change
            this.MainCanvas.LocationChanged += new System.EventHandler((sender, e) => UpdateCanvas());
            this.MainCanvas.SizeChanged += new System.EventHandler((sender, e) => UpdateCanvas());
            this.MainCanvas.Click += new System.EventHandler((sender, e) => UpdateCanvas());
            this.MaximizedBoundsChanged += new System.EventHandler((sender, e) => UpdateCanvas());
        }

        private void InitializeCanvas() {
            _mouseRectangle = new Rectangle(0, 0, NewNodeSize, NewNodeSize);
            MainCanvas.BackColor = CanvasBackColor;
            if(IsCanvasSizeValid())
                MainCanvas.Image = new Bitmap(MainCanvas.Width, MainCanvas.Height);
            _canvasGraphics = Graphics.FromImage(MainCanvas.Image);
            _canvasGraphics.SmoothingMode = SmoothingMode.AntiAlias;
        }

        private bool IsCanvasSizeValid() =>
            MainCanvas.Width > 0 && MainCanvas.Height > 0;

        private void MainForm_MouseDown(object sender, MouseEventArgs e) {
            _lastMouseClickedCoords = (e.X, e.Y);
            if (e.Button == MouseButtons.Left) 
                MainPresenter.GraphInteract(_lastMouseClickedCoords);
        }

        #region Node Creation

        // Updates(redraws) node based on it's coordinates.
        public void AddNodeShape((int x, int y) coordinates) {
            
            switch (NewNodeShape) {
                case Settings.NodeShape.Circle:
                    _canvasGraphics.FillEllipse(_currentNodeBrush, new Rectangle(coordinates.x - NewNodeSize / 2, coordinates.y - NewNodeSize / 2, NewNodeSize, NewNodeSize));

                    if (NewNodeDrawBorder)
                        _canvasGraphics.DrawEllipse(_currentNodePen, new Rectangle(coordinates.x - NewNodeSize / 2, coordinates.y - NewNodeSize / 2, NewNodeSize, NewNodeSize));
                    break;
                case Settings.NodeShape.Square:
                    _canvasGraphics.FillRectangle(_currentNodeBrush, new Rectangle(coordinates.x - NewNodeSize / 2, coordinates.y - NewNodeSize / 2, NewNodeSize, NewNodeSize));

                    if (NewNodeDrawBorder)
                        _canvasGraphics.DrawRectangle(_currentNodePen, new Rectangle(coordinates.x - NewNodeSize / 2, coordinates.y - NewNodeSize / 2, NewNodeSize, NewNodeSize));
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Edge Creation
        public void AddEdgeShape((int x, int y) startNodeCoordinates, (int x, int y) endNodeCoordinates) {
            var startPoint = new Point(startNodeCoordinates.x, startNodeCoordinates.y);
            var endPoint = new Point(endNodeCoordinates.x, endNodeCoordinates.y);
            _canvasGraphics.DrawLine(_currentEdgePen, startPoint, endPoint);
        }
        #endregion

        #region Value lable creation
            public void AddElementValueText((int x, int y) textPosition, string value) {

            var font = new Font(Settings.DefaultLableFont, Settings.DefaultLableFontSize, FontStyle.Bold);
            var sizeOfString = _canvasGraphics.MeasureString(value, font);
            var brush = new SolidBrush(Color.Black);
            var point = new Point(
                textPosition.x - ((int)sizeOfString.Width/2), 
                textPosition.y - ((int)sizeOfString.Height / 2) );

            _canvasGraphics.DrawString(value, font, brush, point);
        }

        #endregion

        #region Canvas
        // Updates also canvas size
        public void UpdateCanvas() {
            InitializeCanvas();
            MainPresenter?.UpdateEdges();
            MainPresenter?.UpdataNodes();
        }

        public void ClearCanvas() => _canvasGraphics.Clear(CanvasBackColor);

        #endregion

        private void MainForm_MouseMove(object sender, MouseEventArgs e) {
            MouseCoords = (e.X , e.Y);


            MainPresenter.UpdateMousePosition();

            #region check for valid mouse region
                _mouseRectangle.X = e.X - NewNodeSize / 2;
                _mouseRectangle.Y = e.Y - NewNodeSize / 2;

                if (_mouseRectangle.Right > MainCanvas.Width)
                    _mouseRectangle.X = MainCanvas.Width - _mouseRectangle.Width;
                if (_mouseRectangle.Bottom > MainCanvas.Height)
                    _mouseRectangle.Y = MainCanvas.Height - _mouseRectangle.Height;
                if (_mouseRectangle.Top < 0) _mouseRectangle.Y = 0;
                if (_mouseRectangle.Left < 0) _mouseRectangle.X = 0;
            #endregion
            MainCanvas.Invalidate();
        }

        private void MainDrawSpace_Paint(object sender, PaintEventArgs e) => 
            MainPresenter.RenderCanvas();

        //private void OnMouseAttachedEvent() => MouseAttachedEvent?.Invoke(this, EventArgs.Empty);
        //TODO: v momentu co MouseAttachedEvent != null, zavolat this.Refresh(), ale pouze jednou...
        private void ToolsMenu_Paint(object sender, PaintEventArgs e) {
            var panel = (Panel)sender;
        }

        #region clients value insertion text box for nodes and edges
        public void ShowValueInsertionBox((int x, int y) coords, string defaultValue = "") {
            _valueInsertionBox.Visible = true;
            _valueInsertionBox.Select(); // active cursor
            _valueInsertionBox.Text = defaultValue;
            _valueInsertionBox.TextChanged += (sender, e) => {
                this.NewLableTextValue = _valueInsertionBox.Text; };
            _valueInsertionBox.Location = new Point(coords.x - (_valueInsertionBox.Width/2), coords.y - (_valueInsertionBox.Height / 2));
        }

        public void HideValueInsertionBox() => _valueInsertionBox.Visible = false;
        #endregion

        #region Updating DrawingTools
        public void UpdateNodeBrush() =>
            _currentNodeBrush.Color = NewNodeColor;

        public void UpdateNodePen() {
            _currentNodePen.Color = NewNodeBorderColor;
            _currentNodePen.Width = NewNodeBorderWidth;
        }

        public void UpdateEdgePen() {
            _currentEdgePen.Color = NewEdgeColor;
            _currentEdgePen.Width = NewEdgeWidth;


            if(NewEdgeIsDirected)
                _currentEdgePen.CustomEndCap = this.SetCustomLineCap();
            else
                _currentEdgePen.EndCap = LineCap.Round;
        }
        #endregion

        // (Triangle lineCap)
        private CustomLineCap SetCustomLineCap() {
            GraphicsPath capPath = new GraphicsPath();
            var pointes = new Point[3] { new Point(-3, -15), new Point(3, -15), new Point(0, -10) };
            //_arrowSize
            capPath.AddClosedCurve(pointes); // AddPoligon - rovný čáry
            return new CustomLineCap(capPath, null);
        }

        private void SetPropertiesPanel() {
            _currentPropertiesForm.TopLevel = false;
            _currentPropertiesForm.FormBorderStyle = FormBorderStyle.None;
            this.PropertiesPanel.Controls.Add(_currentPropertiesForm);
            _currentPropertiesForm.Dock = DockStyle.Fill;
            _currentPropertiesForm.Show();

            PropertiesPanel.Visible = true;
        }

        public void ClosePropertiesPanel() {
            PropertiesPanel.Visible = false;
        }

        public void OpenNodeProperties() {
            _currentPropertiesForm?.Hide();
            _currentPropertiesForm = _nodePropertiesForm;
            SetPropertiesPanel();
        }

        public void OpenEdgeProperties() {
            _currentPropertiesForm?.Hide();
            _currentPropertiesForm = _edgePropertiesForm;
            SetPropertiesPanel();
        }
    }
}

