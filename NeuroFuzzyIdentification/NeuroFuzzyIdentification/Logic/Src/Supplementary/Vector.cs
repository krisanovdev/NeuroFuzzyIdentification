using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCalculateIt.Supplementary
{
    public class Vector
    {
        private double[] coordinates;

        public int Size { get { return coordinates.Length; } }
        public double this[int i]
        {
            get { return coordinates[i]; }
            set { coordinates[i] = value; }
        }

        public double Norm { get { return NormL2; } }

        public double NormLInf { get { return coordinates.Max(x => Math.Abs(x)); } }
        public double NormL1 { get { return coordinates.Sum(x => Math.Abs(x)); } }
        public double NormL2 { get { return Math.Sqrt(coordinates.Sum(x => x * x)); } }

        public Vector(int n)
        {
            coordinates = new double[n];
        }

        public Vector(double[] array)
        {
            coordinates = new double[array.Length];
            for (int index = 0; index < array.Length; ++index)
                coordinates[index] = array[index];
        }

        public override string ToString()
        {
            return coordinates.ToFormattedString();
        }

        public Matrix ToVerticalMatrix()
        {
            Matrix result = new Matrix(Size, 1);
            for (int i = 0; i < Size; ++i)
                result[i, 0] = coordinates[i];
            return result;
        }

        public Matrix ToHorizontalMatrix()
        {
            Matrix result = new Matrix(1, Size);
            for (int i = 0; i < Size; ++i)
                result[0, i] = coordinates[i];
            return result;
        }

        public static Vector operator -(Vector a)
        {
            Vector result = new Vector(a.Size);
            for (int index = 0; index < a.Size; ++index)
                result[index] = -a[index];
            return result;
        }

        public static Vector operator +(Vector a, Vector b)
        {
            Vector result = new Vector(a.Size);
            for (int index = 0; index < a.Size; ++index)
                result[index] = a[index] + b[index];
            return result;
        }

        public static Vector operator -(Vector a, Vector b)
        {
            Vector result = new Vector(a.Size);
            for (int index = 0; index < a.Size; ++index)
                result[index] = a[index] - b[index];
            return result;
        }

        public static Vector operator *(Vector a, double k)
        {
            Vector result = new Vector(a.Size);
            for (int index = 0; index < a.Size; ++index)
                result[index] = k * a[index];
            return result;
        }

        public static Vector operator *(double k, Vector a)
        {
            return a * k;
        }

        public static double operator *(Vector a, Vector b)
        {
            double result = 0;
            for (int index = 0; index < a.Size; ++index)
                result += a[index] * b[index];
            return result;
        }

        public static Vector operator /(Vector a, double k)
        {
            return 1 / k * a;
        }
    }
}
