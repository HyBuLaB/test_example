using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SquareSimpleLib.Attributes;
using SquareSimpleLib.Figures;

namespace SquareSimpleLib
{
    public class SquareSimple
    {
        /// <summary>
        /// Новые фигуры с их вычеслениями которые хранятся в памяти
        /// </summary>
        private readonly Dictionary<Type, FigureOptions> _cachedNewFigures = new Dictionary<Type, FigureOptions>();

        /// <summary>
        /// Вычесление площади фигуры с учетом возможного добавление своих фигур 
        /// </summary>
        /// <typeparam name="T">Тип фигуры</typeparam>
        /// <param name="calculatedValue">Фигура</param>
        /// <param name="propertys">Значение проперти</param>
        /// <returns>Площадь</returns>
        public double CalculateSquare<T>(T calculatedValue, params Func<T, double>[] propertys) where T : class
        {
            if (_cachedNewFigures.TryGetValue(typeof(T), out var options))
                return options.CalculatedFunction.Invoke(propertys.Select(x => x.Invoke(calculatedValue)).ToArray());

            return GetCalculatedSquare(calculatedValue, propertys);
        }

        /// <summary>
        /// Площадь фигуры исходя из значений свойств
        /// </summary>
        /// <typeparam name="T">Тип фигуры</typeparam>
        /// <param name="calculatedValue">фигура</param>
        /// <param name="propertys">Значения свойств</param>
        /// <returns>Площадь</returns>
        public static double GetCalculatedSquare<T>(T calculatedValue, params Func<T, double>[] propertys) where T : class
        {
            if (!propertys.Any())
                return default(double);

            var opt = Services.RepositoryFigure<T>.GetOptions(propertys.Length);
            return opt.CalculatedFunction.Invoke(propertys.Select(x => x.Invoke(calculatedValue)).ToArray());
        }

        /// <summary>
        /// Добавление собственной фигуры
        /// </summary>
        /// <typeparam name="T">Тип фигуры</typeparam>
        /// <param name="figure">Фигура</param>
        /// <param name="func">Функция вычесления проперти</param>
        public void AddNewFigure<T>(T figure, Func<double[], double> func)
        {
            var newOption = new FigureOptions {TypeOfFigure = typeof(T), CalculatedFunction = func};
            _cachedNewFigures.Add(typeof(T), newOption);
        }

        /// <summary>
        /// Получение информации о фигуре по правилам
        /// </summary>
        /// <typeparam name="T">тип</typeparam>
        /// <param name="calculatedValue">фигура</param>
        /// <returns></returns>
        public static FigureInformation GetFigureInfo<T>(T calculatedValue)
        {
            var propertys = calculatedValue.GetType().GetProperties();
            var information = new FigureInformation();
            information.Corners = propertys
                .Where(x => x.CustomAttributes.Any(o => o.AttributeType.Equals(typeof(CornerAttribute))))
                .Select(x => x.GetValue(calculatedValue, null) as double?)
                .ToArray();
            return information;
        }
    }
}
