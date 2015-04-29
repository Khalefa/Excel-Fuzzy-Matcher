using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Matching
{
    class Program
    {
   
            static void Main(string[] args)
        {

            string dir=@"C:\Users\khalefa\Documents\Visual Studio 2012\Projects\itunit\itunit\bin\Debug\";
            string n = "cs.xls";
            string m = "cs_mis.xls";
            var x=Matching.Matches(dir, n, m);
            ExcelUtil e = new ExcelUtil();
            e.writeexcel(dir+"a.xlsx", x);
        }
    }

}
