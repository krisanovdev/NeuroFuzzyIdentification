using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCalculateIt.Supplementary
{
    public static class MultidimensionalArrayExtensions
    {
        public static TAccumulate[] AggregateByColumns<TSource, TAccumulate>(this TSource[,] values, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> function)
        {
            return Enumerable.Range(0, values.GetLength(1)).Select(column => Enumerable.Range(0, values.GetLength(0)).Select(row => values[row, column]).Aggregate(seed, function)).ToArray();
        }

        public static double[] SumsByColumns(this double[,] values)
        {
            return values.AggregateByColumns(0.0, (total, value) => total + value);
        }

        public static TAccumulate[] AggregateByRows<TSource, TAccumulate>(this TSource[,] values, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> function)
        {
            return Enumerable.Range(0, values.GetLength(0)).Select(row => Enumerable.Range(0, values.GetLength(1)).Select(column => values[row, column]).Aggregate(seed, function)).ToArray();
        }

        public static double[] SumsByRows(this double[,] values)
        {
            return values.AggregateByRows(0.0, (total, value) => total + value);
        }

        public static TResult[,] Select<TSource, TResult>(this TSource[,] values, Func<TSource, TResult> selector)
        {
            var result = new TResult[values.GetLength(0), values.GetLength(1)];
            for (int i = 0; i < values.GetLength(0); ++i)
                for (int j = 0; j < values.GetLength(1); ++j)
                    result[i, j] = selector(values[i, j]);
            return result;
        }
    }
}
