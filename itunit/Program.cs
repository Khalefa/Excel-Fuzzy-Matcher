using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Matching
{
    class Program
    {
  static void  printUsage()
        {
            Console.WriteLine("Match <first excel> <column> <second excel> <column> ");
        }
            static void Main(string[] args)
        {
            if (args.Length != 4)
            {
                printUsage();
                return;
            }
            // string dir= @"C:\Users\khalefa\Downloads\itunit-master\itunit-master\";
          //  Console.WriteLine(args[1]);//return;
          
            string n = args[0];
            string m = args[2];
            int col1 = int.Parse(args[1]);
            int col2 = int.Parse(args[3]);
            //get the dir
            string dir = "";
            if (n.Contains("\\"))
            {
                dir = n.Substring(0,n.LastIndexOf("\\"));
                dir = dir + "\\";
            }
            else
             if (n.Contains("/"))
            {
                dir = n.Substring(0,n.LastIndexOf("/"));
                dir = dir + "/";

            }
            else

            {
                dir = System.AppDomain.CurrentDomain.BaseDirectory;
                n = dir + n;
                m = dir + m;
            }
            Console.Write(dir);
           // return;
            var x = Matching.Matches( n,  m, col1, col2);
            ExcelUtil e = new ExcelUtil();
            //System.IO.Path p=new System.IO.Path()
            e.writeexcel(System.AppDomain.CurrentDomain.BaseDirectory + "output.xls", x);
        }
    }

}
