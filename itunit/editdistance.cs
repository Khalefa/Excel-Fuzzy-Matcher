using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{

    static class EditDistance
    {
        /// <summary>
        /// Compute the distance between two strings.
        /// </summary>
        public static int Compute(string s, string t)
        {
            s = s.Trim();
            t = t.Trim();

            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            // Step 1
            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            // Step 2
            for (int i = 0; i <= n; d[i, 0] = i++)
            {
            }

            for (int j = 0; j <= m; d[0, j] = j++)
            {
            }

            // Step 3
            for (int i = 1; i <= n; i++)
            {
                //Step 4
                for (int j = 1; j <= m; j++)
                {
                    // Step 5
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

                    // Step 6
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            // Step 7
            return d[n, m];
        }

        /// <summary>
        /// calcualte the edit distance between two strings with limit 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static int Compute(string s, string t,int limit)
        {
            int n = s.Length;
            int m = t.Length;
            if (Math.Abs(s.Length - t.Length) > limit) return Math.Abs(s.Length - t.Length);
            int[,] d = new int[n + 1, m + 1];

            // Step 1
            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            // Step 2
            for (int i = 0; i <= n; d[i, 0] = i++)
            {
            }

            for (int j = 0; j <= m; d[0, j] = j++)
            {
            }

            // Step 3
            for (int i = 1; i <= n; i++)
            {
                int min = int.MaxValue;
                //Step 4
                for (int j = 1; j <= m; j++)
                {
                    // Step 5
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

                    // Step 6
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                    min = Math.Min(min, d[i, j]);
                }
                if (min > limit) return min;
            }
            // Step 7
            return d[n, m];
        }
        public static float FuzzyCompute(string a, string b, int limit)
        {
            var A=a.Split(' ');
            var B = b.Split(' ');
            if (A.Count() > B.Count())
            {
                var C = A;
                A = B;
                B = C;
            }
            int i=0;
            int j=0;
            float dist=0;
            for( ;i<A.Count();i++){
                string si=A[i].Arabic();
                string sj=B[j].Arabic();
                int x = EditDistance.Compute(A[i].Arabic(), B[i].Arabic());
                if (x > 0.5 * Math.Min(si.Length, sj.Length))
                {
                    j++;
                    
                }
                else
                {
                    
                    j++;
                    i++;
                }
                dist+=x;
                if (dist > limit) return dist;
            }
            return dist;
        } 
    }
}