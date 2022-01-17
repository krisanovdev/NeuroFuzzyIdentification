using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCalculateIt.Supplementary
{
    public static class ConvertingExtensions
    {
        public static double ToDouble(this object obj)
        {
            try
            {
                return Convert.ToDouble(obj);
            }
            catch { }

            double result;

            if (!double.TryParse(obj.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out result) &&
                !double.TryParse(obj.ToString(), NumberStyles.Any, CultureInfo.GetCultureInfo("ru-RU"), out result))
                throw new Exception("Неправильный формат числа");

            return result;
        }

        public static int ToInt(this object obj)
        {
            try
            {
                return Convert.ToInt32(obj);
            }
            catch { }

            int result;

            if (!int.TryParse(obj.ToString(), out result))
                throw new Exception("Неправильный формат числа");

            return result;
        }

        public static T[] ToArray<T>(this string str, Func<String, T> mapper)
        {
            return str.Split().Where(s => !String.IsNullOrEmpty(s)).Select(mapper).ToArray();
        }
    }
}
