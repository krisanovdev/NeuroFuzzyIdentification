using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCalculateIt.Logic
{

    public enum MembershipFunctionType
    {
        bell,
        trapezoid,
        generic_bell
    }
    static public class MembershipFunctionTypeExtensions
    {
        public static int parametersCount(this MembershipFunctionType type)
        {
            switch (type)
            {
                case MembershipFunctionType.bell:
                    return 2;
                case MembershipFunctionType.trapezoid:
                    return 4;
                case MembershipFunctionType.generic_bell:
                    return 3;
                default:
                    return 0;
            }
        }

        public static string DisplayName(this MembershipFunctionType type)
        {
            switch (type)
            {
                case MembershipFunctionType.bell:
                    return "дзвоноподібна";
                case MembershipFunctionType.trapezoid:
                    return "трапецієвидна";
                case MembershipFunctionType.generic_bell:
                    return "узагальнена дзоноподібна";
                default:
                    return "";
            }
        }

        public static string DisplayProgramName(this MembershipFunctionType type)
        {
            switch (type)
            {
                case MembershipFunctionType.bell:
                    return "bell";
                case MembershipFunctionType.trapezoid:
                    return "trapezoid";
                case MembershipFunctionType.generic_bell:
                    return "generic_bell";
                default:
                    return "";
            }
        }
    }
    public class MembershipFunction: ICloneable
    {
        public object Clone()
        {
            return new MembershipFunction(this.type, this.parameters);
        }

        public MembershipFunction(MembershipFunctionType type, List<Double> parameters)
        {   
            this.parameters = parameters;
            this.type = type;
            var limit = 500;
            switch (type) {
                case MembershipFunctionType.bell:
                    {
                        var b = parameters[0];
                        var c = parameters[1];
                        typicalValue = b;
                        membershipFunction = x => 1 / (1 + Math.Pow((b - x) / c, 2));
                        derivativeByIndexedParam = (index, x) =>
                        {
                            //if (b < 0)
                            //{
                            //    b = 0;
                            //}
                            //if (b > Math.PI * 2)
                            //{
                            //    b = Math.PI * 2;
                            //}
                            //if (c < 1e-2)
                            //{
                            //    c = 1e-2;
                            //}
                            if (index == 0)
                            {
                                var val = 2 * c * c * (x - b) / Math.Pow(Math.Pow(b - x, 2) + c * c, 2);
                                return val;
                            }
                            if (index == 1)
                            {
                                var val = 2 * Math.Pow((x - b), 2) * c / Math.Pow((c * c + Math.Pow(x - b, 2)), 2);
                                return val;
                            }
                            return 0;
                        };
                    }
                    break;
                case MembershipFunctionType.trapezoid:
                    {
                        var a = parameters[0];
                        var b = parameters[1];
                        var c = parameters[2];
                        var d = parameters[3];
                        typicalValue = (c + b) / 2;
                        membershipFunction = x =>
                        {
                            if (x < a)
                            {
                                return 0;
                            }
                            if (a <= x && x < b)
                            {
                                return (x - a) / (b - a);
                            }
                            if (b <= x && x <= c)
                            {
                                return 1;
                            }
                            if (b <= x && x <= c)
                            {
                                return 1;
                            }
                            if (c <= x && x < d)
                            {
                                return (d - x) / (d - c);
                            }
                            if (d <= x)
                            {
                                return 0;
                            }
                            return 0;
                        };
                        // TODO: DO MATH FOR Derivatives
                        derivativeByIndexedParam = (index, x) =>
                        {
                            if (index == 0)
                            {
                                if (x < a)
                                {
                                    return 0;
                                }
                                if (a <= x && x < b)
                                {
                                    return 1/ (b - a);
                                }
                                if (b <= x && x <= c)
                                {
                                    return 0;
                                }
                                if (b <= x && x <= c)
                                {
                                    return 0;
                                }
                                if (c <= x && x < d)
                                {
                                    return 0;
                                }
                                if (d <= x)
                                {
                                    return 0;
                                }
                                return 0;


                                double val = 0;
                                if (b - a == 0 || b - a < 0) {
                                    val = 1.0 / (0.00001);
                                } else {
                                 val= 1.0 / (b - a);
                                }
                                return val;
                            }
                            if (index == 1)
                            {
                                if (x < a)
                                {
                                    return 0;
                                }
                                if (a <= x && x < b)
                                {
                                    return 1 / (b - a);
                                }
                                if (b <= x && x <= c)
                                {
                                    return 0;
                                }
                                if (b <= x && x <= c)
                                {
                                    return 0;
                                }
                                if (c <= x && x < d)
                                {
                                    return 0;
                                }
                                if (d <= x)
                                {
                                    return 0;
                                }
                                return 0;
                            }
                            if (index == 2)
                            {
                                if (x < a)
                                {
                                    return 0;
                                }
                                if (a <= x && x < b)
                                {
                                    return 0;
                                }
                                if (b <= x && x <= c)
                                {
                                    return 0;
                                }
                                if (b <= x && x <= c)
                                {
                                    return 0;
                                }
                                if (c <= x && x < d)
                                {
                                    return (-1.0) / (c - d); ;
                                }
                                if (d <= x)
                                {
                                    return 0;
                                }
                                return 0;
                            }
                            if (index == 3)
                            {

                                if (x < a)
                                {
                                    return 0;
                                }
                                if (a <= x && x < b)
                                {
                                    return 0;
                                }
                                if (b <= x && x <= c)
                                {
                                    return 0;
                                }
                                if (b <= x && x <= c)
                                {
                                    return 0;
                                }
                                if (c <= x && x < d)
                                {
                                    return (-1.0) / (c - d);
                                }
                                if (d <= x)
                                {
                                    return 0;
                                }
                                return 0;
                            }
                            return 0;
                        };
                    }
                    break;
                case MembershipFunctionType.generic_bell:
                    {
                        var a = parameters[0];
                        var b = parameters[1];
                        var c = parameters[2];
                        typicalValue = parameters[2];
                        membershipFunction = x => 1 / (1 + Math.Pow(Math.Abs((x - c) / a), 2 * b));
                        derivativeByIndexedParam = (index, x) =>
                             {
                                 if (index == 0)
                                 {
                                     var val = (2 * b / a) * Math.Pow((x - c) / a, 2) * Math.Pow(Math.Abs((x - c) / a), 2 * b - 2) * membershipFunction(x) * membershipFunction(x);
                                     if (a < 0)
                                         val -= limit * Math.Abs(a);
                                     val = Math.Min(limit, Math.Max(-limit, val));
                                     return val;
                                 }
                                 if (index == 1)
                                 {
                                     double val;
                                     if (x != c)
                                     {
                                         val = -2 * (Math.Pow(Math.Abs((x - c) / a), 2 * b)) * Math.Log(Math.Abs((x - c) / a)) * membershipFunction(x) * membershipFunction(x);
                                     }
                                     else
                                     {
                                         val = 0;
                                     }
                                     if (b <= 0)
                                         val -= limit * Math.Abs(b);
                                     val = Math.Min(limit, Math.Max(-limit, val));
                                     return val;
                                 }
                                 if (index == 2)
                                 {
                                     var val = (2 * b / a) * ((x - c) / a) * Math.Pow(Math.Abs((x - c) / a), 2 * b - 2) * membershipFunction(x) * membershipFunction(x);
                                     val = Math.Min(limit, Math.Max(-limit, val));
                                     return val;
                                 }
                                 return 0;
                             };
                    }
                    break;
            }
        }

        public override bool Equals(object obj)
        {
            var c = (MembershipFunction)obj;
            if (this.typicalValue != c.typicalValue)
            {
                return false;
            }
            if (this.parameters.Count == c.parameters.Count)
            {
                for (int i = 0; i < this.parameters.Count; i++)
                {
                    if (this.parameters[i] != c.parameters[i])
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
            return true;
        }

        public List<Double> parameters;

        public Func<double, double> membershipFunction;

        public Func<int, double, double> derivativeByIndexedParam;

        public MembershipFunctionType type;

        public double typicalValue;

        public double Fuzzify(double x)
        {
            return membershipFunction(x);
        }
    }
}
