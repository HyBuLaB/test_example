using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareSimpleLib.Figures
{
    /// <summary>
    /// Опции фигуры
    /// </summary>
    internal class FigureOptions
    {
        /// <summary>
        /// Тип фигуры
        /// </summary>
        public Type TypeOfFigure { get; set; }

        /// <summary>
        /// Функция вычесления площади фигуры
        /// </summary>
        public Func<double[], double> CalculatedFunction { get; set; }
    }

    /// <summary>
    /// Информации о фигуре 
    /// </summary>
    public class FigureInformation
    {
        /// <summary>
        /// Углы фигуры
        /// </summary>
        public double?[] Corners { get; set; }

        /// <summary>
        /// Является ли треугольниц прямым
        /// </summary>
        public bool isRightTriangle => Corners.Any(x => x.HasValue && x.Value.Equals(90));
    }
}
