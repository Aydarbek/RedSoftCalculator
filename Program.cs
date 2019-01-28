using System;

namespace RedSoftQuiz
{
    class Calculator
    {
        static void Main()
        {
            string inStr = Console.ReadLine();
            double Result = Calculate(inStr);
            
            Console.WriteLine(Result);
            Console.Read();
        }

        public static double Calculate (string inStr)
        {
            string[] RangOne;
            double[] RangTwoDouble;


            RangOne = inStr.Split('+', '-');
            string[] AddOrSubtr = inStr.Split(RangOne, StringSplitOptions.RemoveEmptyEntries);

            RangTwoDouble = new double[RangOne.Length];

            for (int i = 0; i < RangOne.Length; i++)
            {
                if (!double.TryParse(RangOne[i], out RangTwoDouble[i]))
                    RangTwoDouble[i] = MakeRang1Calculation(RangOne[i]);
            }

            for (int i = 0; i < AddOrSubtr.Length; i++)
            {
                RangTwoDouble[i + 1] = Arith(RangTwoDouble[i], RangTwoDouble[i + 1], AddOrSubtr[i]);
            }

            return RangTwoDouble[RangTwoDouble.Length - 1];

        }


        private static double MakeRang1Calculation(string rangOne)
        {
            string[] Nums = rangOne.Split('*', '/');
            string[] Opers = rangOne.Split(Nums, StringSplitOptions.RemoveEmptyEntries);
            double result = 1;
            
            for (int i = 0; i < Opers.Length; i++)
            {
                Nums[i + 1] = Arith(Nums[i], Nums[i + 1], Opers[i]).ToString();
            }

            return double.Parse(Nums[Nums.Length - 1]);
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
