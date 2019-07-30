using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareSimpleLib.Services
{
    /// <summary>
    /// Класс который хранит функции для вычесления значений площади
    /// </summary>
    internal static class SquareFunctions
    {
        /// <summary>
        /// Площадь окружности по радиусу
        /// </summary>
        /// <param name="values">вычесляемое значение</param>
        /// <returns></returns>
        public static double GetSircleSquere(double[] values) => Math.PI * Math.Pow(values[0], 2);

        /// <summary>
        /// Площадь треугольника по трем сторонам
        /// </summary>
        /// <param name="values">вычесляемое значение</param>
        /// <returns></returns>
        public static double GetTriangleSquere(double[] values)
        {
            var semiperimetr = values.Sum() / 2;
            return Math.Sqrt(semiperimetr * (semiperimetr - values[0]) * (semiperimetr - values[1]) * (semiperimetr - values[2]));
        }
    }
}
