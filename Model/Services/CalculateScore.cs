using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Services
{
    public class CalculateScore
    {
        public double CalculateScoreForExam(int IsTrueTrue, int IsTrueFalse, int IsRightTrue, int IsRightFalse,
            int QuantityQuestion)
        {
            double result = 0;
            double scorePerQuestion = 10.0 / QuantityQuestion;

                if( IsTrueTrue == IsRightTrue)
                {
                    if (IsRightFalse <= IsTrueFalse && IsRightFalse > 0)
                    {
                        result += 0;
                    }
                    else
                        result += scorePerQuestion;
                }
            return result;
        }
    }
}
