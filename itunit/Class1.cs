using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Diagnostics;

namespace NameMatching
{

    class ExcelUtil
    {

        public object[,] valueArray;
        public  void openexcel(string fileName)
        {
            Application _excelApp = new Microsoft.Office.Interop.Excel.Application();
            _excelApp.Visible = true;
            Workbook workbook = _excelApp.Workbooks.Open(fileName,
       Type.Missing, Type.Missing, Type.Missing, Type.Missing,
       Type.Missing, Type.Missing, Type.Missing, Type.Missing,
       Type.Missing, Type.Missing, Type.Missing, Type.Missing,
       Type.Missing, Type.Missing);
            Worksheet worksheet = (Worksheet)workbook.Worksheets[1];

            Range excelRange = worksheet.UsedRange;

            //get an object array of all of the cells in the worksheet (their values)
             valueArray = (object[,])excelRange.get_Value(
                        XlRangeValueDataType.xlRangeValueDefault);
            for (int row = 1; row <= worksheet.UsedRange.Rows.Count; ++row)
            {
                for (int col = 1; col <= worksheet.UsedRange.Columns.Count; ++col)
                {
                    //access each cell
                    //Debug.Print(valueArray[row, col].ToString());
                    if (valueArray[row, col] != null)
                        Console.WriteLine(valueArray[row, col].ToString());
                }
            }

            //clean up stuffs
            workbook.Close(false, Type.Missing, Type.Missing);
            //      Marshal.ReleaseComObject(workbook);

            _excelApp.Quit();
            //    Marshal.FinalReleaseComObject(_excelApp);
            //excelApp.Quit();
        }
    }
}