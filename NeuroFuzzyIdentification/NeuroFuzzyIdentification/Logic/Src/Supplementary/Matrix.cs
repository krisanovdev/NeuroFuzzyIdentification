using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCalculateIt.Supplementary
{
    public class Matrix
    {
        private double[,] elements;

        public int RowsCount { get { return elements.GetLength(0); } }
        public int ColumnsCount { get { return elements.GetLength(1); } }

        public double this[int i, int j]
        {
            get { return elements[i, j]; }
            set { elements[i, j] = value; }
        }

        public Matrix(int rowsCount, int columnsCount)
        {
            elements = new double[rowsCount, columnsCount];
        }

        public Matrix(double[,] array)
        {
            elements = new double[array.GetLength(0), array.GetLength(1)];
            for (int i = 0; i < array.GetLength(0); ++i)
                for (int j = 0; j < array.GetLength(1); ++j)
                    elements[i, j] = array[i, j];
        }

        public Matrix Transposed()
        {
            Matrix result = new Matrix(ColumnsCount, RowsCount);
            for (int i = 0; i < RowsCount; ++i)
                for (int j = 0; j < ColumnsCount; ++j)
                    result[j, i] = elements[i, j];
            return result;
        }

        public Vector ToVector()
        {
            if (RowsCount > 1 && ColumnsCount > 1)
                return null;

            Vector result = new Vector(Math.Max(RowsCount, ColumnsCount));
            for (int i = 0; i < result.Size; ++i)
                result[i] = RowsCount == 1 ? elements[0, i] : elements[i, 0];
            return result;
        }

        public static Matrix operator -(Matrix a)
        {
            Matrix result = new Matrix(a.RowsCount, a.ColumnsCount);
            for (int i = 0; i < result.RowsCount; ++i)
                for (int j = 0; j < result.ColumnsCount; ++j)
                    result[i, j] = -a[i, j];
            return result;
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            Matrix result = new Matrix(a.RowsCount, a.ColumnsCount);
            for (int i = 0; i < result.RowsCount; ++i)
                for (int j = 0; j < result.ColumnsCount; ++j)
                    result[i, j] = a[i, j] + b[i, j];
            return result;
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            Matrix result = new Matrix(a.RowsCount, a.ColumnsCount);
            for (int i = 0; i < result.RowsCount; ++i)
                for (int j = 0; j < result.ColumnsCount; ++j)
                    result[i, j] = a[i, j] - b[i, j];
            return result;
        }

        public static Matrix operator *(double k, Matrix a)
        {
            Matrix result = new Matrix(a.RowsCount, a.ColumnsCount);
            for (int i = 0; i < result.RowsCount; ++i)
                for (int j = 0; j < result.ColumnsCount; ++j)
                    result[i, j] = k * a[i, j];
            return result;
        }

        public static Matrix operator *(Matrix a, double k)
        {
            return k * a;
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            Matrix result = new Matrix(a.RowsCount, b.ColumnsCount);
            for (int i = 0; i < result.RowsCount; ++i)
                for (int j = 0; j < result.ColumnsCount; ++j)
                    for (int k = 0; k < a.ColumnsCount; ++k)
                        result[i, j] += a[i, k] * b[k, j];
            return result;
        }

        public static Matrix operator /(Matrix a, double k)
        {
            return 1 / k * a;
        }
    }
}
