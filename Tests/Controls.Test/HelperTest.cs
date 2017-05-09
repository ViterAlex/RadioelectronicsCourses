using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Controls.Test
{
    [TestClass]
    public class HelperTest
    {
        private Point _pt1;
        private Point _pt2;
        [TestInitialize]
        public void Initialize()
        {
            _pt1 = new Point(100, 21);
            _pt2 = new Point(259, 311);
        }
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

        [TestMethod]
        public void GetRectangle_100_100__300_300_notEqual()
        {
            //arrange
            var expected = new Rectangle(100, 21, 159, 290);
            //act
            var rect = _pt1.GetRectangle(_pt2, false);
            //assert
            Assert.AreEqual(expected, rect);
        }
    }
}
