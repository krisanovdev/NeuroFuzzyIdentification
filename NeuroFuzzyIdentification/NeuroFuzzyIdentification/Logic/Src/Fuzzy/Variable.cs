using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCalculateIt.Logic
{
    [Serializable()]
    public class Variable
    {
        public int termNumber = 0;
        public List<Term> terms = new List<Term>();
        public Variable(int termNumber, List<MembershipFunction> membershipFunctions)
        {
            this.termNumber = termNumber;
            for (int i = 0; i < termNumber; i++)
            {
                terms.Add(new Term(membershipFunctions[i], i));
            }
        }
    }
}
