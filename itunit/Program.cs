using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NameMatching;
namespace ConsoleApplication3
{
    class Program
    {
        public class Match
        {
            public string str;
            public string str1;
            public float match;
        }
        static void Main(string[] args)
        {
            List<Match> exact = new List<Match>();
            List<Match> semiexact = new List<Match>();
            List<Match> noexact = new List<Match>();
            string dir = @"C:\Users\khalefa\Documents\Visual Studio 2012\Projects\itunit\itunit\bin\Debug\";
            ExcelUtil e = new ExcelUtil();

            e.openexcel(dir + "cs.xls");
            ExcelUtil f = new ExcelUtil();
            f.openexcel(dir + "cs_mis.xls");
            var n1 = e.valueArray.Slice(3);
            var n2 = f.valueArray.Slice(2);
            for (int i = 0; i < n1.Length; i++)
            {
                string s1 = ((string)n1[i]).Trim();
                s1 = s1.Space();
                float m = int.MaxValue;
                string s = "";
                for (int j = 0; j < n2.Length; j++)
                {
                    string s2 = ((string)n2[j]).Trim();
                    s2 = s2.Space();
                    float edn = EditDistance.FuzzyCompute(s1.Arabic(), s2.Arabic(), 10);
                    //int ed = EditDistance.Compute(s1, s2, 10);
                    if (edn < m)
                    {
                        m = edn;
                        s = s2;
                    }

                }

                if (m == 0)
                {
                    if (EditDistance.Compute(s1, s) == 0)
                        exact.Add(new Match { str = s1, str1 = s, match = m });
                    else
                        semiexact.Add(new Match { str = s1, str1 = s, match = m });
                }
                else
                    if (m > 10)
                        noexact.Add(new Match { str = s1 });
                    else
                        semiexact.Add(new Match { str = s1, str1 = s, match = m });
                Console.WriteLine(s1, s, m);
            }
        }
    }

}
