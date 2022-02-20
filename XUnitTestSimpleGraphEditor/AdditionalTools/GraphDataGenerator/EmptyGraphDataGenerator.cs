using SimpleGraphEditor.Models;
using SimpleGraphEditor.Models.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitTestSimpleGraphEditor.AdditionalTools.GraphGenerator
{
    public class EmptyGraphDataGenerator : CompleteGraphDataGenerator {
        public EmptyGraphDataGenerator(int graphSize) : base(graphSize) { }

        public override void GenerateGraphData() {
            base.GenerateNodes();
        }
    }
}
