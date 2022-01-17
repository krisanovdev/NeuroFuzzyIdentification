using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustCalculateIt.Supplementary;

namespace JustCalculateIt.Logic
    
{
    class Subgradient
    {
        static MainFunction original;
        public static MainFunction mainFunction;
        public static Vector CalcSubgradient(Vector algoParams, MainFunction currentFunction)
        {
            // COPYING!
            Subgradient.original = currentFunction;
            List<List<MembershipFunction>> newMembershipFunctions = new List<List<MembershipFunction>>();
            int currentParamIndex = 0;
            for (int i = 0; i < currentFunction.termsFunctions.Count; i++)
            {
                var newList = new List<MembershipFunction>();
                newMembershipFunctions.Add(newList);

                var curListFunctions = currentFunction.termsFunctions[i];
                for (int j = 0; j < curListFunctions.Count; j++)
                {
                    var parametersCount = curListFunctions[j].type.parametersCount();
                    var parameters = new List<double>();
                    if (i != currentFunction.termsFunctions.Count - 1)
                    {
                        for (int p = 0; p < parametersCount; p++)
                        {
                            parameters.Add(algoParams[currentParamIndex]);
                            currentParamIndex++;
                        }
                        newList.Add(new MembershipFunction(curListFunctions[j].type, parameters));
                    }
                    else
                    {
                        newList.Add(new MembershipFunction(curListFunctions[j].type, curListFunctions[j].parameters));
                    }
                }
            }
            

            var terms = newMembershipFunctions.Select(list => list.Select((x, index) => new Term(x, index)).ToList()).ToList();
            List<Rule> rules = new List<Rule>();
            for (int i = 0; i < currentFunction.rules.Count; i++)
            {
                var oldRule = currentFunction.rules[i];
                var newTerms = oldRule.terms.Select((term, index) => terms[index][term.index]).ToList();
                var output = terms.Last()[oldRule.output.index];
                var newRule = new Rule(newTerms, output);
                newRule.weightKoefficient = algoParams[currentParamIndex];
                currentParamIndex++;
                rules.Add(newRule);
            }
            mainFunction = new MainFunction(currentFunction.dataLength, currentFunction.numberOfVariables, currentFunction.termsNumbers, newMembershipFunctions, currentFunction.experimentalData, rules);


            var coordinates = mainFunction.experimentalData.Select(list => list.Take(list.Count - 1).ToList()).ToList();
            var trueResults = mainFunction.experimentalData.Select(list => list.Last()).ToList();

            // END COPYING

            // CALCULATIONS! 
            var functionResults = new List<double>(); // игреки м-тые
            // считаем игреки м-тые чтоб посчитать оценки (с шапкой)
            for (int i = 0; i < coordinates.Count; i++)
            {
                functionResults.Add(mainFunction.resolve(coordinates[i]));
            }
            // закончили считать

            // считаем знаменатель
            double sumY_2 = 0;
            for (int i = 0; i < trueResults.Count; i++)
            {
                var substrY = functionResults[i] - trueResults[i];
                sumY_2 += Math.Pow(substrY, 2);
            }
            var denominator = Math.Sqrt(sumY_2);
            // закончили считать

            // щас будет мясо
            var derivatives = new List<double>();
            for (int iExact = 0; iExact < mainFunction.numberOfVariables - 1; iExact++)
            {
                var iTerms = mainFunction.variables[iExact].terms;
                for (int jExact = 0; jExact < iTerms.Count; jExact++)
                {
                    var parametersCount = iTerms[jExact].membershipFunction.parameters.Count;
                    var parameters = iTerms[jExact].membershipFunction.parameters;
                    var type = iTerms[jExact].membershipFunction.type;
                    for (int paramIndex = 0; paramIndex < parametersCount; ++paramIndex)
                    {
                        double sum = 0;
                        for (int l = 0; l < trueResults.Count; l++)
                        {
                            var derivative = dYPodParam(iExact, jExact, paramIndex, coordinates[l]);
                            var substrY = functionResults[l] - trueResults[l];
                            sum += substrY * derivative;
                        }
                        // PENALTIES?
                        double localPenalty = 0;
                        double limit = 500;
                        double penaltyLimit = 1e4;
                        switch (type)
                        {
                            case MembershipFunctionType.bell:
                                var b = parameters[0];
                                var c = parameters[1];
                                if (paramIndex == 0)
                                {
                                    /*if (b < 0)
                                    {
                                        localPenalty -= penaltyLimit;// * Math.Abs(b);
                                    }
                                    if (b > Math.PI * 2)
                                    {
                                        localPenalty += penaltyLimit;// * Math.Abs(b - Math.PI * 2); ;
                                    }*/
                                    //localPenalty = Math.Min(limit, Math.Max(-limit, localPenalty));
                                }
                                if (paramIndex == 1)
                                {
                                    if (c < 1e-2)
                                    {
                                        //localPenalty -= penaltyLimit;// * Math.Abs(c);
                                        localPenalty -= 1e2 * Math.Max(0, Math.Sign(1e-2 - c));
                                    }
                                        
                                    //if (c > 0.3)
                                    //{
                                    //    localPenalty += limit * Math.Abs(c - 10);
                                    //}
                                    //localPenalty = Math.Min(limit, Math.Max(-limit, localPenalty));
                                }
                                break;
                            case MembershipFunctionType.trapezoid:
                                var a1 = parameters[0];
                                var b1 = parameters[1];
                                var c1 = parameters[2];
                                var d1 = parameters[3];
                                if (paramIndex == 1)
                                {
                                    if (b1 < a1)
                                    {
                                        localPenalty -= 1e2 * (b1 - a1);
                                    }
                                }
                                if (paramIndex == 2)
                                {
                                    if (c1 < b1)
                                    {
                                        localPenalty -= 1e2 * (c1 - b1);
                                    }
                                }
                                if (paramIndex == 3)
                                {
                                    if (d1 < c1)
                                    {
                                        localPenalty -= 1e2 * (d1 - c1);
                                    }
                                }
                                break;
                            case MembershipFunctionType.generic_bell:
                                var b2 = parameters[0];
                                var c2 = parameters[1];
                                var t2 = parameters[2];
                                if (paramIndex == 0)
                                {
                                    if (b2 < 1e-2)
                                    {
                                        //localPenalty -= penaltyLimit;// * Math.Abs(c);
                                        localPenalty -= 1e2 * Math.Max(0, Math.Sign(1e-2 - b2));
                                    }
                                }
                                if (paramIndex == 1)
                                {
                                    if (c2 < 1e-2)
                                    {
                                        //localPenalty -= penaltyLimit;// * Math.Abs(c);
                                        localPenalty -= 1e2 * Math.Max(0, Math.Sign(1e-2 - c2));
                                    }
                                }
                                if (paramIndex == 2)
                                {

                                }
                                break;
                        }

                        
                        var countedDerivative = sum / denominator;
                   

                        var totalDerivative = countedDerivative + localPenalty;

                        // Heuristics 
                        // totalDerivative = Math.Min(limit, Math.Max(-limit, totalDerivative));

                        derivatives.Add(totalDerivative);
                    }
                }
            }


            for (int m = 0; m < mainFunction.rules.Count; m++)
            {
                double sumYw = 0;
                for (int l = 0; l < trueResults.Count; l++)
                {
                    var derivativeYw = dYPodW(m, coordinates[l]);
                    var substrY = functionResults[l] - trueResults[l];
                    sumYw += substrY * derivativeYw;
                }
                var val = sumYw / denominator;
                var curWeight = algoParams[derivatives.Count];
                if (curWeight < 0)
                {
                    val -= 1e3 * Math.Max(0, Math.Sign(-curWeight)); //1e3;
                }
                if (curWeight > 1)
                {
                    val += 1e3 * Math.Max(0, Math.Sign(curWeight - 1)); //1e3;
                }
                derivatives.Add(val);
                //derivatives.Add(0);
            }

            var vector = new Vector(derivatives.ToArray());
            return vector; 
        }

        // i, j - по чем берем производные, остальное - то что в числителе
        // Checked
        static double dMUPodParam(int i, int j, int paramIndex, int jm, double x)
        {
            if (j != jm)
            {
                return 0;
            }
            var term = mainFunction.variables[i].terms[j];
            return term.membershipFunction.derivativeByIndexedParam(paramIndex, x);
        }

        
        // Checked
        static double dMUkPodParam(int iExact, int jExact, int paramIndex, int k, List<double> x)
        {
            var rules = mainFunction.rules;
            double sum = 0;
            for (int m = 0; m < rules.Count; m++)
            {
                var curRule = rules[m];
                // curRule.output.inxed === k_m 
                if (curRule.output.index != k)
                {
                    continue;
                }
                double prod = 1;
                for (int i = 0; i < curRule.terms.Count; i++)
                {
                    if (i != iExact)
                    {
                        prod *= curRule.terms[i].calculate(x[i]);
                    }
                }
                prod *= dMUPodParam(iExact, jExact, paramIndex, curRule.terms[iExact].index, x[iExact]);
                sum += curRule.weightKoefficient * prod;
            }
            return sum;
        }


        // Checked
        static double dYPodParam(int iExact, int jExact, int paramIndex, List<double> x)
        {
            var y = mainFunction.variables.Last();
            var yMembershipFunction = mainFunction.yMembershipFunction(x);
            double sum1 = 0;
            double sum2 = 0;
            for (int k = 0; k < y.terms.Count; k++)
            {
                sum1 += dMUkPodParam(iExact, jExact, paramIndex, k, x) * y.terms[k].membershipFunction.typicalValue;

                // WTF - calculate?????
                // sum2 += y.terms[k].calculate(yMembershipFunction[y.terms[k]]);

                // Replaced by this:
                 sum2 += yMembershipFunction[y.terms[k]];
            }

            double sum3 = 0;
            double sum4 = 0;
            for (int k = 0; k < y.terms.Count; k++)
            {
                sum3 += dMUkPodParam(iExact, jExact, paramIndex, k, x);


                // WTF - calculate?????
                // sum4 += y.terms[k].calculate(yMembershipFunction[y.terms[k]]) * y.terms[k].membershipFunction.typicalValue;

                // Replaced by this:
                sum4 += yMembershipFunction[y.terms[k]] * y.terms[k].membershipFunction.typicalValue;
            }
            return ((sum1 * sum2 - sum3 * sum4) / (sum2 * sum2));
        }
        
        // Производная у по w
        // x - текущая точка в которой считаем
        // Checked
        static double dYPodW(int m, List<double> x)
        {
            var y = mainFunction.variables.Last();
            var yMembershipFunction = mainFunction.yMembershipFunction(x);
            double sum1 = 0;
            double sum2 = 0;
            for (int k = 0; k < y.terms.Count; k++)
            {
                sum1 += dMUkPodW(m, k, x) * y.terms[k].membershipFunction.typicalValue;
                // WTF - calculate?????
                //sum2 += y.terms[k].calculate(yMembershipFunction[y.terms[k]]);

                sum2 += yMembershipFunction[y.terms[k]];
            }

            double sum3 = 0;
            double sum4 = 0;
            for (int k = 0; k < y.terms.Count; k++)
            {
                sum3 += dMUkPodW(m, k, x);

                // WTF - calculate?????
                //sum4 += y.terms[k].calculate(yMembershipFunction[y.terms[k]]) * y.terms[k].membershipFunction.typicalValue;

                sum4 += yMembershipFunction[y.terms[k]] * y.terms[k].membershipFunction.typicalValue;
            }
            return ((sum1 * sum2 - sum3 * sum4) / (sum2 * sum2));
        }

        // Checked
        static double dMUkPodW(int m, int k, List<double> x)
        {
            var rules = mainFunction.rules;
            var curRule = rules[m];
            if (rules[m].output.index == k)
            {
                double prod = 1;
                for (int i = 0; i < curRule.terms.Count; i++)
                {
                    prod *= curRule.terms[i].calculate(x[i]);
                }
                return prod;
            }
            else
            {
                return 0;
            }
        }
    }
}
