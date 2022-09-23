namespace CalculatorLibrary
{
    public class Calculator // BL

    {
        public static int Sum(int a, int b) // BL - SRP
        {
            // find sum of non-zero positive even numbers
            if (a == 0 || b == 0)
                throw new System.Exception("Zero input provided");
            if (a < 0 || b < 0)
                throw new System.Exception("Negative input provided");
            if (a % 2 != 0 || b % 2 != 0)
                throw new System.Exception("Odd input provided");
            return a + b;
        }
    }
}
