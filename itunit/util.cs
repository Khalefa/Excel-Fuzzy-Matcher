using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    static class util
    {/*
       set ret= replace(ret,'إ','ا');
set ret= replace(ret,'آ','ا');
set ret= replace(ret,'أ','ا');
set ret= replace(ret,'اا','ا');
set ret= replace(ret,'إ','ا');
set ret= replace(ret,'ي','ى');
set ret= replace(ret,'ه','ة');
set ret= replace(ret,'ة','ة');
        */

        

            public static T[] Slice<T>(this T[,] arr, int d)
            {
                List<T>  x=new List<T>();
                for(int i=1;i<arr.GetLength(0);i++)
                    if(arr[i,d] !=null)
                    {
                        x.Add(arr[i,d]);
                    }
                return x.ToArray();
            }
       
    }
}
