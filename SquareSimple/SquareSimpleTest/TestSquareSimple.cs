using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SquareSimpleLib;

namespace SquareSimpleTest
{
    [TestClass]
    public class TestSquareSimple
    {
        /// <summary>
        /// Тестирование вычисления площади окружности 
        /// </summary>
        [TestMethod]
        public void TestSquareOfSircle()
        {
            var sirqle = new Sirqle();
            sirqle.radius = 2;

            var expected = 12.566;

            Assert.AreEqual((int)expected, (int)SquareSimple.GetCalculatedSquare(sirqle, x => x.radius));
        }

        /// <summary>
        /// Тестироваение вычисления площади треугольник
        /// </summary>
        [TestMethod]
        public void TestSquareOfTriangle()
        {
            var triangle = new Triangle();
            triangle.a = 3;
            triangle.b = 4;
            triangle.c = 5;

            var expected = 6;

            Assert.AreEqual(expected, SquareSimple.GetCalculatedSquare(triangle, x => x.a, x => x.b, x => x.c));
        }

        /// <summary>
        /// Тестирование добавление кастомной фигуры
        /// </summary>
        [TestMethod]
        public void TestAddingNewFigure()
        {
            var cube = new Cube();
            cube.CubeSide = 3;
            var expected = 6 * Math.Pow(3,2);

            SquareSimple square = new SquareSimple();
            square.AddNewFigure(cube, cube.CubeSquare);

            Assert.AreEqual(expected, square.CalculateSquare(cube, x => x.CubeSide));
        }

        /// <summary>
        /// Тестирование является ли треугольник прямоугольным
        /// </summary>
        [TestMethod]
        public void TestRightTriangle()
        {
            var triangle = new Triangle();
            triangle.a = 90;
            triangle.b = 60;
            triangle.c = 30;

            var expected = true;

            Assert.AreEqual(expected, SquareSimple.GetFigureInfo(triangle).isRightTriangle);
        }
    }

    /// <summary>
    /// Класс куба для нового объекта
    /// </summary>
    public class Cube
    {
        public double CubeSide;

        public double CubeSquare(double[] d)
        {
            return 6 * Math.Pow(d[0], 2);
        }
    }

    /// <summary>
    /// Класс окружности
    /// </summary>
    public class Sirqle
    {
        public double radius;
    }

    /// <summary>
    /// Класс треугольника
    /// </summary>
    public class Triangle
    {
        [SquareSimpleLib.Attributes.Corner]
        public double a { get; set; }

        [SquareSimpleLib.Attributes.Corner]
        public double b { get; set; }

        [SquareSimpleLib.Attributes.Corner]
        public double c { get; set; }
    }


}
