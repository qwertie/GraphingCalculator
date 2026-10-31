using System;
using System.Windows.Forms;
using Loyc;

namespace LesGraphingCalc
{
    static class Program
    {
        [STAThread]
        static void Main() // Entry point
        {
            // Loyc 30 formats with string.Format by default; FormatCore also supports named {placeholders}
            Localize.GlobalDefaultFormatter = StringExt.FormatCore;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CalcForm());
        }
    }
}
