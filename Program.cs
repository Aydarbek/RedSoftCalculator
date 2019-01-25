using System;
using System.Data;

namespace RedSoftQuiz
{
    class Calculator
    {
        static void Main(string[] args)
        {
            string inStr = Console.ReadLine();
            DataTable dt = new DataTable();
            var result = dt.Compute(inStr, "");
            Console.WriteLine(result);
            Console.Read();
        }
    }
}
