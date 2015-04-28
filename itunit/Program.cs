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
        static void Main(string[] args)
        {
            string dir = @"C:\Users\khalefa\Documents\Visual Studio 2012\Projects\ConsoleApplication3\ConsoleApplication3\bin\Debug\";
            ExcelUtil e = new ExcelUtil();

            e.openexcel(dir + "cs.xls");
            ExcelUtil f = new ExcelUtil();
            f.openexcel(dir + "cs_mis.xls");
            var n1 = e.valueArray.Slice(3);
            var n2 = f.valueArray.Slice(2);
            for (int i=0;i<n1.Length;i++)
            {
                string s1=((string)n1[i]).Trim();
                int m = int.MaxValue;
                string s="";
                for(int j=0;j<n2.Length;j++)
                {
                    string s2=((string)n2[j]).Trim();
                    int ed=EditDistance.Compute(s1, s2, 10);
                    if (ed < m)
                    {
                        m = ed;
                        s = s2;
                    }
                    
                }
                Console.WriteLine(s1, s, m);
            }

        }
    }
}
