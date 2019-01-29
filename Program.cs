using System;
using System.Data;
using System.Text.RegularExpressions;

namespace RedSoftQuiz
{
    public class Calculator
    {
        static void Main()
        {


            string inStr = " 8 *13 + 44 + 7 *4";
            double Result = Calculate(inStr);
            double Verify = 8 * 13 + 44 + 7 * 4;


            Console.WriteLine("Result: " + Result);
            Console.WriteLine("Verify: " +  Verify);
            Console.Read();
        }

        public static double CalcCS(string inStr)
        {
            DataTable dt = new DataTable();
            var v = dt.Compute(inStr, "");

            return double.Parse(v.ToString());
        }

        public static double Calculate (string inStr)
        {
            string[] RangOneString;
            double[] RangTwoDouble;

            


            RangOneString = inStr.Split('+', '-');
            string[] RangTwoOpers = Regex.Split(inStr, @"[\s/0-9*/]+");
            string[] RangTwoOpersNew = new string[RangTwoOpers.Length];
            int j = 0;
            for (int i = 0; i < RangTwoOpers.Length; i++)
            {
                
                if (RangTwoOpers[i] !="")                
                    RangTwoOpersNew[j++] = RangTwoOpers[i];
            }

                

            RangTwoDouble = new double[RangOneString.Length];
            
                        

            for (int i = 0; i < RangOneString.Length; i++)
                if (!double.TryParse(RangOneString[i], out RangTwoDouble[i]))
                    RangTwoDouble[i] = MakeRang1Calculation(RangOneString[i]);

            return SimpleCalc(RangTwoDouble, RangTwoOpersNew);
        }


        private static double SimpleCalc(string[] nums, string[] opers)
        {
            double result = double.Parse(nums[0]);

            for (int i = 1; i < nums.Length; i++)
                result = Arith(result.ToString(), nums[i], opers[i - 1]);

            return result;
        }

        private static double SimpleCalc(double[] nums, string[] opers)
        {
            double result = nums[0];

            for (int i = 1; i < nums.Length; i++)
                result = Arith(result.ToString(), nums[i].ToString(), opers[i - 1]);

            return result;
        }


        public static double MakeRang1Calculation(string rangOne)
        {
            string[] Nums = rangOne.Split('*', '/');
            string[] Opers = rangOne.Split(Nums, StringSplitOptions.RemoveEmptyEntries);

            return SimpleCalc(Nums, Opers);            
        }




        private static double Arith (string Num1, string Num2, string oper)
        {
            switch (oper)
            {
                case "+": return double.Parse(Num1) + double.Parse(Num2);
                case "-": return double.Parse(Num1) - double.Parse(Num2);
                case "*": return double.Parse(Num1) * double.Parse(Num2);
                case "/": return double.Parse(Num1) / double.Parse(Num2);
                default: return 0;
            }
        }

        private static double Arith(double Num1, double Num2, string oper)
        {
            switch (oper)
            {
                case "+": return Num1 + Num2;
                case "-": return Num1 - Num2;
                case "*": return Num1 * Num2;
                case "/": return Num1 / Num2;
                default: return 0;
            }
        }
    }
}
