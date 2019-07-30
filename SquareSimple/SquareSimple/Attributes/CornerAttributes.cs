using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareSimpleLib.Attributes
{
    /// <summary>
    /// Аттрибут для свойств. Помечает свойство значение угла. Для вычесления информации фигуры
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class CornerAttribute : Attribute
    {
        
    }
}
