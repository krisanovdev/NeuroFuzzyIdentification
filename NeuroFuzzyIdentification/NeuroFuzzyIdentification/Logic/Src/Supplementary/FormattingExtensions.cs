using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCalculateIt.Supplementary
{
    public static class FormattingExtensions
    {
        public static string ToFormattedString(this double[] array)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("(");
            for (int index = 0; index < array.Length; ++index)
            {
                if (index > 0)
                    stringBuilder.Append("; ");
                stringBuilder.Append(String.Format("{0:0.00000000}", array[index]));
            }
            stringBuilder.Append(")");
            return stringBuilder.ToString();
        }
    }
}
