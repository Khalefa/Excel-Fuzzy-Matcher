using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matching
{

    public enum matchtype
    {
        Exact,
        SemiMatch,
        NoMatch
    };
    public class Match
    {
        public string A;
        public string B;
        public float match;
        public matchtype type;
    }
    static class Matching
    {
        static public List<Match> Matches(string dir, string stud, string mis)
        {
            /*            List<Match> exact = new List<Match>();
                        List<Match> semiexact = new List<Match>();
                        List<Match> noexact = new List<Match>();*/
            HashSet<int> matched = new HashSet<int>();
            List<Match> n = new List<Match>();

            ExcelUtil e = new ExcelUtil();
            ExcelUtil f = new ExcelUtil();

            e.openexcel(dir + stud);
            f.openexcel(dir + mis);

            var n1 = e.valueArray.Slice(3);
            var n2 = f.valueArray.Slice(2);
            for (int i = 0; i < n1.Length; i++)
            {
                string s1 = ((string)n1[i]).Trim();
                s1 = s1.Space();
                float m = int.MaxValue;
                int j_indx = 0;
                string s = "";
                for (int j = 0; j < n2.Length; j++)
                {
                    if (matched.Contains(j)) continue;
                    string s2 = ((string)n2[j]).Trim();
                    s2 = s2.Space();
                    float edn = EditDistance.FuzzyCompute(s1.Arabic(), s2.Arabic(), 10);
                    if (edn < m)
                    {
                        m = edn;
                        s = s2;
                        j_indx = j;
                    }
                }


                matchtype mt = matchtype.SemiMatch;
                if (m == 0)
                {
                    if (EditDistance.Compute(s1, s) == 0)
                        mt = matchtype.Exact;
                    else
                        mt = matchtype.Exact;
                }
                else
                {
                    if (m > 0.5)
                        mt = matchtype.NoMatch;
                    else
                        mt = matchtype.SemiMatch;
                }
                if (m < 0.5)
                {
                    matched.Add(j_indx);
                }
                n.Add(new Match { A = s1, B = s, match = m, type = mt });
                //Console.WriteLine(s1, s, m);
            }

            return n;
        }
    }
}
