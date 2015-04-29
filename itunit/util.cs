using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matching
{
    static class util
    {/*
        */
        public static string Space(this string x)
        {
            string s = "";
            bool inspace=false;
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] == ' ')
                {
                    if (inspace) continue;
                    else
                    {
                        inspace = true;
                    }

                }
                else inspace = false;
                s = s + x[i];
            }
            return s;
        }
        public static string Arabic(this string x)
        {
            String m = x.Replace('إ', 'ا');
            m = m.Replace('آ', 'ا');
            m = m.Replace('أ', 'ا');
            //m=m.Replace( 'اا','ا');
            m = m.Replace('إ', 'ا');
            m = m.Replace('ي', 'ى');
            m = m.Replace('ه', 'ة');
            m = m.Replace('ة', 'ة');

            return m;
        }
        
        public static T[] Slice<T>(this T[,] arr, int d)
        {
            List<T> x = new List<T>();
            for (int i = 1; i < arr.GetLength(0); i++)
                if (arr[i, d] != null)
                {
                    x.Add(arr[i, d]);
                }
            return x.ToArray();
        }

    }
}
