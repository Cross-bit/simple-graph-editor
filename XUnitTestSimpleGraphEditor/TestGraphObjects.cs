using SimpleGraphEditor.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestSimpleGraphEditor
{
    public class TestGraphObjects
    {
        [Fact]
        public void TestNodesEquality() {

            // nodes should override equal comparision based on their coordinates

            var nd1 = new Node(0, 1, new NodeData());
            var nd2 = new Node(0, 1, new NodeData());
            var nd3 = new Node(1, 0, new NodeData());

            // should be equal
            Assert.True(nd1.Equals(nd2));
            Assert.False(nd1.Equals(nd3));

            // type comparision
            Assert.False(nd1.Equals(new String("")));

            Assert.True(nd1 == nd2);
            Assert.False(nd1 != nd2);
            Assert.False(nd1 == nd3);
            Assert.True(nd1 != nd3);
        }
    }
}

