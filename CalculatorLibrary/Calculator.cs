using CalculatorDataLayer;

namespace CalculatorLibrary
{
    public class Calculator // BL

    {
        private ICalculatorRepository repo = null;

        public Calculator(ICalculatorRepository repo)
        {
            this.repo = repo;
        }

        public Calculator()
        {
            repo = new CalculatorFileRepositor();
        }

        public int Sum(int a, int b) // BL - SRP
        {
            // find sum of non-zero positive even numbers and save
            if (a == 0 || b == 0)
                throw new System.Exception("Zero input provided");
            if (a < 0 || b < 0)
                throw new System.Exception("Negative input provided");
            if (a % 2 != 0 || b % 2 != 0)
                throw new System.Exception("Odd input provided");

            int sum = a + b;
            // save 
            string result = $"{a}+{b}={sum}";
            //CalculatorFileRepositor re = new CalculatorFileRepositor();
            //re.Save("sdfsdf");
            repo.Save(result);
            return sum;
        }
    }



}
