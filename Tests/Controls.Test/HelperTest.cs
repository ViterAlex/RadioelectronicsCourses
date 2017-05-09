using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Controls.Test
{
    [TestClass]
    public class HelperTest
    {
        [TestMethod]
        public void CenterRect_100_100()
        {
            //arrange
            var rect = new RectangleF(10, 10, 10, 10);
            var expected = new RectangleF(95, 95, 10, 10);
            //act
            rect = RectangleHelper.CenterTo(rect, new Point(100, 100));
            //assert
            Assert.AreEqual(expected, rect);
        }
    }
}
