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

namespace Matching
{

    class ExcelUtil
    {

        public object[,] valueArray;
        public static int ConvertColour(int R, int G, int B)
        {
            int r = R;
            int g = G * 256;
            int b = B * 65536;

            return r + g + b;
        }
        int Color(Match m)
        {
            int c=0;
            if (m.type == matchtype.Exact)
                c = ConvertColour(255, 255, 1);
            else
                if (m.type == matchtype.SemiMatch)
                    c = ConvertColour(124, 185, 232);
                else if (m.type == matchtype.NoMatch)
                    c = ConvertColour(232, 123, 166);
            return c;
        }
        public void openexcel(string fileName)
        {
            Application _excelApp = new Microsoft.Office.Interop.Excel.Application();
            _excelApp.Visible = false;
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
           /* for (int row = 1; row <= worksheet.UsedRange.Rows.Count; ++row)
            {
                for (int col = 1; col <= worksheet.UsedRange.Columns.Count; ++col)
                {
                    //access each cell
                    //Debug.Print(valueArray[row, col].ToString());
                    if (valueArray[row, col] != null)
                        Console.WriteLine(valueArray[row, col].ToString());
                }
            }
            */
            //clean up stuffs
            workbook.Close(false, Type.Missing, Type.Missing);
            //      Marshal.ReleaseComObject(workbook);

            _excelApp.Quit();
            //    Marshal.FinalReleaseComObject(_excelApp);
            //excelApp.Quit();
        }

        public void writeexcel(string fileName, List<Match> data)
        {
            Application _excelApp = new Microsoft.Office.Interop.Excel.Application();
            _excelApp.Visible = false;
            object misValue = System.Reflection.Missing.Value;

            Workbook workbook = _excelApp.Workbooks.Add(misValue);
            Worksheet        
            worksheet = (Worksheet)workbook.Worksheets.get_Item(1);
            

            
            int column=1;
            int row=1;
            foreach(Match m in data){
            var cell = (Range)worksheet.Cells[row, column];
            cell.Value2 = m.A;

            cell.Interior.Color = Color(m);
            if (m.type != matchtype.NoMatch)
            {
                cell = (Range)worksheet.Cells[row, column + 1];
                cell.Value2 = m.B;
                cell.Interior.Color = Color(m);
            }
            row++;
            }
            //workbook.Save();
            //clean up stuffs
            //workbook.Close(false, Type.Missing, Type.Missing);
            workbook.SaveAs(fileName, XlFileFormat.xlWorkbookNormal, misValue,
                misValue, misValue, misValue, XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            workbook.Close(true, misValue, misValue);
            
            _excelApp.Quit();            
        }
    }
}