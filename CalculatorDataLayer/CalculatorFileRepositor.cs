using System.IO;

namespace CalculatorDataLayer
{
    public class CalculatorFileRepositor : ICalculatorRepository
    {
        public bool Save(string input)
        {
            StreamWriter sw = new StreamWriter("d:\\calculator.txt", true);
            sw.WriteLine(input);
            sw.Close();
            return true;
        }
    }
}
