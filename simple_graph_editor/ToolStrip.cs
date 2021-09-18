using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleGraphEditor.Presenters;
using SimpleGraphEditor.Models;
using SimpleGraphEditor.Models.Interface;
using SimpleGraphEditor.Models.Properties;
using SimpleGraphEditor.Views;
using SimpleGraphEditor.Utils;
using System.IO;
using System.Diagnostics;
using System.Drawing;

namespace SimpleGraphEditor
{
    [System.ComponentModel.DesignerCategory("")]
    class Dummy4 { }

    public partial class EditorForm : System.Windows.Forms.Form, IToolStripView {
        public ToolStripPresenter StripPresenter { get; set; }

        private string _txtFileFilter= "txt files(*.txt)|*.txt|All files(*.*)|*.*";
        private string _jpgFileFilter = "jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
        public void InitializeToolStrip() {
            ExportAdjacencyListBtn.Click += (sender, e) => ExportAdjacencyListItemClicked();
            ExportEdgeListBtn.Click += (sender, e) => ExportEdgeListItemClicked();
            ExportScreenshotBtn.Click += (sender, e) => ExportScreenshot();
            ToolStripTop.Renderer = new CustomToolStripRenderer();
        }


        private void ExportAdjacencyListItemClicked() {
            OpenFileSaveDialog(StripPresenter.ExportAdjancencyList, _txtFileFilter);
        }

        private void ExportEdgeListItemClicked() {
            OpenFileSaveDialog(StripPresenter.ExportListOfEdges, _txtFileFilter);
        }

        private void ExportScreenshot() {
            OpenFileSaveDialog(MainCanvas.Image.Save, _jpgFileFilter);
        }

        private void OpenFileSaveDialog(Action<string> saveAction, string filter = "All files (*.*)|*.*") {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = filter;
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                saveAction.Invoke(saveFileDialog.FileName);
            }
        }
    }

    public class CustomToolStripRenderer : ToolStripProfessionalRenderer
    {

        public CustomToolStripRenderer() {
            this.RoundedEdges = false;
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e) {

            Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);
            e.Graphics.DrawRectangle(new Pen(SystemColors.WindowFrame), 1, 0, rc.Width - 2, rc.Height - 1);
            e.Item.BackColor = SystemColors.WindowFrame;

            if (e.Item.Selected)
                e.Graphics.FillRectangle(Brushes.DarkGray, rc);
            else
                base.OnRenderMenuItemBackground(e);
        }

        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e) {
            base.OnRenderButtonBackground(e);
        }

        protected override void OnRenderDropDownButtonBackground(ToolStripItemRenderEventArgs e) {
            Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);
            if(e.Item.Selected)
                e.Graphics.FillRectangle(Brushes.DarkGray, rc);
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e) {
            e.TextColor = Color.White;
            base.OnRenderItemText(e);
        }
    }
}
