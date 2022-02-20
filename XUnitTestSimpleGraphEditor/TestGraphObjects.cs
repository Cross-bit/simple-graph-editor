using SimpleGraphEditor.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestSimpleGraphEditor
{
    public class TestGraphObjects
    {
        public void TestNodesEquality() {

            // nodes should override equal comparision based on their coordinates

            var nd1 = new Node(0, 1, new NodeData());
            var nd2 = new Node(0, 1, new NodeData());

            // should be equal
            Assert.True(nd1.Equals(nd2));

            // test type
            

        }
    }
}
