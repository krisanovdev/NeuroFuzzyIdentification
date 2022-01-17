using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCalculateIt.Logic
{
    [Serializable()]	
    public class Term: ICloneable
    {
        public MembershipFunction membershipFunction;

        public int index = 0;
        public Term(MembershipFunction membershipFunction, int index)
        {
            this.membershipFunction = membershipFunction;
            this.index = index;
        }

        public override bool Equals(object obj)
        {
            return this.membershipFunction.Equals(((Term)obj).membershipFunction);
        }

        public override int GetHashCode()
        {
            return index.GetHashCode();
        }

        public double calculate(double x)
        {
            return membershipFunction.Fuzzify(x);
        }

        public object Clone()
        {
            return new Term((MembershipFunction)this.membershipFunction.Clone(), this.index);
        }
    }
}
