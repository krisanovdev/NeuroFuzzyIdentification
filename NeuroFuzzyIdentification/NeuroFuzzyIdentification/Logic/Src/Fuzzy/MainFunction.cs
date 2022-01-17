using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustCalculateIt.Supplementary;

namespace JustCalculateIt.Logic
{
    [Serializable()]	
    public class MainFunction
    {
        public int numberOfVariables = 0;
        public List<Variable> variables = new List<Variable>();

        public int dataLength = 0;
        public List<List<Double>> experimentalData;
        public List<Rule> rules;


        public List<int> termsNumbers { get; private set; }
        public List<List<MembershipFunction>> termsFunctions { get; private set; }
        

        public Tuple<double, double> findMinMaxFor(int index) {
            double min = double.MaxValue;
            double max = double.MinValue;
            for (int i = 0; i < experimentalData.Count; i++)
            {
                if (experimentalData[i][index] > max)
                {
                    max = experimentalData[i][index];
                }
                if (experimentalData[i][index] < min)
                {
                    min = experimentalData[i][index];
                }
            }
            return Tuple.Create<double, double>(min, max);
        }
        public MainFunction(int dataLength, int numberOfVariables, List<int> termsNumbers, List<List<MembershipFunction>> termsFunctions, List<List<Double>> experimentalData, List<Rule> rules)
        {
            this.dataLength = dataLength;
            this.numberOfVariables = numberOfVariables;
            this.termsNumbers = termsNumbers.ConvertAll(x => x);
            this.termsFunctions = termsFunctions;
            for (int i = 0; i < numberOfVariables; i++)
            {
                variables.Add(new Variable(termsNumbers[i], termsFunctions[i]));
            }
            this.experimentalData = experimentalData;
            this.rules = rules;
        }

        public static MainFunction defaultMainFunction()
        {
            var defaultExperimentsLength = 5;
            var defaultNumberOfVariables = 3;
            var defaultTermsNumberPerValue = 3;
            var termsNumber = new List<int>();
            for (var i = 0; i < defaultNumberOfVariables; i++) {
                termsNumber.Add(defaultTermsNumberPerValue);
            }
            List<Rule> rules = new List<Rule>();

            List<List<Double>> experimentalData = new List<List<Double>>();
            for (var i = 0; i < defaultExperimentsLength; i++)
            {
                var newDataRecord = new List<Double>();
                for (var j = 0; j < defaultNumberOfVariables; j++)
                {
                    newDataRecord.Add(0);
                }
                experimentalData.Add(newDataRecord);
            }
            List<List<MembershipFunction>> termsFunctions = new List<List<MembershipFunction>>();
            for (var i = 0; i < defaultNumberOfVariables; i++)
            {
                var terms = new List<MembershipFunction>();
                for (var j = 0; j < defaultTermsNumberPerValue; j++)
                {
                    var parameters = new List<double>();
                    parameters.Add(1);
                    parameters.Add(1);
                    var membershipFunction = new MembershipFunction(MembershipFunctionType.bell, parameters);
                    terms.Add(membershipFunction);
                }
                termsFunctions.Add(terms);
            }
            return new MainFunction(defaultExperimentsLength, defaultNumberOfVariables, termsNumber, termsFunctions, experimentalData, rules);
        }

        public Vector paramsVector()
        {
            var vector = new List<double>();
            for (int i = 0; i < variables.Count - 1; i++)
            {
                for (int j = 0; j < variables[i].terms.Count; j++)
                {
                    vector.AddRange(variables[i].terms[j].membershipFunction.parameters);
                }
            }
            for (int i = 0; i < rules.Count; i++)
            {
                vector.Add(rules[i].weightKoefficient);
            }
            return new Vector(vector.ToArray());
        }

        public double resolve(List<double> variables)
        {
            return defazification(yMembershipFunction(variables));
        }

        public Dictionary<Term, double> yMembershipFunction(List<double> variables)
        {
            var assosiatedResults = new Dictionary<Term, double>();
            for (int i = 0; i < rules.Count; i++)
            {
                var ruleValue = rules[i].calculateValue(variables);
                if (!assosiatedResults.ContainsKey(rules[i].output))
                {
                    assosiatedResults[rules[i].output] = ruleValue;
                }
                else
                {
                    var currentValue = assosiatedResults[rules[i].output];
                    var newValue = Math.Min(1, currentValue + ruleValue);
                    assosiatedResults[rules[i].output] = newValue;
                }
            }
            return assosiatedResults;
        }

        private double defazification(Dictionary<Term, double> assosiatedResults)
        {
            double sumValues = 0;
            double weightSumValue = 0;
            foreach (var key in assosiatedResults.Keys)
            {
                weightSumValue += assosiatedResults[key] * key.membershipFunction.typicalValue;
                sumValues += assosiatedResults[key];
            }
            return weightSumValue / sumValues;
        }
    }
}
