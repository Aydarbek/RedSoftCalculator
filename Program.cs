using System;
using System.Text.RegularExpressions;

namespace RedSoftQuiz
{
    public class Calculator
    {
        static void Main()
        {
           
                string inStr = Console.ReadLine();
                string Result = Calculate(inStr);

                Console.WriteLine(Result);
                Console.Read();
        }
        

        public static string Calculate (string inStr)
        {
            try
            {
                string RangOneString;
                string[] RangTwoString;
                string[] RangThreeString;
                string[] RangThreeOpers;

                RangOneString = RangOneCalculate(inStr.TrimEnd('='));

                RangTwoString = RangOneString.Split('+', '-');

                RangThreeString = RangTwoCalculate(RangTwoString);
                RangThreeOpers = RemoveNulls(Regex.Split(RangOneString, @"[\s/0-9*/,]+"));

                return RangThreeCalculate(RangThreeString, RangThreeOpers);
            } catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.Read();
                }
            return "";
        }


        private static string RangOneCalculate(string input)
        {
            string brackets = @"\(.*?\)";
            string[] Expr = new string[Regex.Matches(input, brackets).Count];
            int i = 0;

            foreach (var x in Regex.Matches(input, brackets))
                Expr[i++] = x.ToString();

            foreach (string s in Expr)
                if (s != null)
                {
                    string num = Calculate(s.Trim('(', ')'));
                    input = input.Replace(s, num);
                }

            return input;
        }

        private static string[] RangTwoCalculate(string[] input)
        {
            double[] ResultsDouble = new double[input.Length];
            string[] ResultsString = new string [ResultsDouble.Length];
            for (int i = 0; i < input.Length; i++)
                if (!double.TryParse(input[i], out ResultsDouble[i]))
                    ResultsDouble[i] = RangTwoSimpleCalculate(input[i]);

            for (int i = 0; i < ResultsDouble.Length; i++)
                ResultsString[i] = ResultsDouble[i].ToString();

            return ResultsString;
        }

        private static double RangTwoSimpleCalculate(string input)
        {
            string[] Nums = input.Split('*', '/');
            string[] Opers = input.Split(Nums, StringSplitOptions.RemoveEmptyEntries);

            return SimpleCalc(Nums, Opers);
        }

        private static string RangThreeCalculate(string[] rangThreeDouble, string[] rangThreeOpers)
        {
            return SimpleCalc(rangThreeDouble, rangThreeOpers).ToString();
        }

        private static double SimpleCalc(string[] nums, string[] opers)
        {
            double result = double.Parse(nums[0]);

            for (int i = 1; i < nums.Length; i++)
                result = Arith(result.ToString(), nums[i], opers[i - 1]);

            return result;
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
        private static string[] RemoveNulls(string[] input)
        {
            string[] output = new string[input.Length];
            int j = 0;
            for (int i = 0; i < input.Length; i++)
                if (input[i] != "")
                    output[j++] = input[i];

            return output;
        }
    }
}
