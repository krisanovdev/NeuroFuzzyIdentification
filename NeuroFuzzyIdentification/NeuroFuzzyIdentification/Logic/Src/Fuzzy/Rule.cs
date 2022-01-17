using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuroFuzzyIdentification;

namespace JustCalculateIt.Logic
{
    [Serializable()]
    public class Rule: ICloneable
    {
        public double weightKoefficient = 1;
        public List<Term> terms = new List<Term>();
        public Term output;

        public Rule(List<Term> terms, Term output)
        {
            this.terms = terms;
            this.output = output;
        }

        public double calculateValue(List<Double> variables)
        {
            // TODO: Insert logic for other functions for v 
            double product = 1;
            for (int j = 0; j < terms.Count; j++)
            {
                product = product * terms[j].calculate(variables[j]);
            }
            return weightKoefficient * product;
        }

        public override bool Equals(object obj)
        {
            Rule c = (Rule)obj;
            for (int i = 0; i < this.terms.Count; i++)
            {
                if (this.terms[i].Equals(c.terms[i]) == false)
                {
                    return false;
                }
            }
            if (this.output.Equals(c.output) == false) {
                return false;
            }
            return true;
        }

        public object Clone()
        {
            var rule = new Rule(this.terms.Clone(), (Term)this.output.Clone());
            rule.weightKoefficient = this.weightKoefficient;
            return rule;
        }
    }
}
