using System;
using System.Windows.Forms;

namespace LesGraphingCalc
{
    static class Program
    {
        [STAThread]
        static void Main() // Entry point
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CalcForm());
        }
    }
}
