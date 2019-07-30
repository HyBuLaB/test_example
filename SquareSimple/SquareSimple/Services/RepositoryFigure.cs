using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SquareSimpleLib.Figures;

namespace SquareSimpleLib.Services
{
    /// <summary>
    /// Класс который формирует настройки для вычесления фигур
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal static class RepositoryFigure<T>
    {
        /// <summary>
        /// Получение опций
        /// </summary>
        /// <param name="sidesCount">Количество сторон фигуры</param>
        /// <returns></returns>
        public static FigureOptions GetOptions(int sidesCount)
        {
            switch (sidesCount)
            {
                case 1: //its Sircle
                {
                    return new FigureOptions {
                        TypeOfFigure = typeof(T),
                        CalculatedFunction = SquareFunctions.GetSircleSquere
                    };
                }
                case 3: //its Triangle
                {
                    return new FigureOptions {
                        TypeOfFigure = typeof(T),
                        CalculatedFunction = SquareFunctions.GetTriangleSquere
                    };
                }


                default:
                    return default(FigureOptions);
            }
        }
    }
}
