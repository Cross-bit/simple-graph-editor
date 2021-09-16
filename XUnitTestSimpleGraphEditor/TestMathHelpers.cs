using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using SimpleGraphEditor.Utils;


namespace XUnitTestSimpleGraphEditor
{
    public class TestMathHelpers {

        [Fact]
        public void GetDotProductTest(){
            var vec1 = (1, 3);
            var vec2 = (50, 2);

            Assert.Equal(56, MathHelpers.GetDotProduct(vec1, vec2));
            Assert.Equal(56, MathHelpers.GetDotProduct(vec2, vec1));
            Assert.Equal(10, MathHelpers.GetDotProduct(vec1, vec1));

        }

        [Fact]
        public void TestHasThisNeighbour() {

            var projectedVec = (1, 3);
            var dirVec = (3, 2);

            var res = MathHelpers.GetProjectionOnLine(projectedVec, dirVec);
            
            Assert.Equal(2, res.x);
            Assert.Equal(1, res.y);

            projectedVec = (0, 3);
            res = MathHelpers.GetProjectionOnLine(projectedVec, dirVec);

            Assert.Equal(1, res.x);
            Assert.Equal(1, res.y);
        }
    }
}
