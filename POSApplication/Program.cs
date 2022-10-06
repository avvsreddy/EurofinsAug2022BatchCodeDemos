namespace POSApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TaxCalculatorFactory factory = new TaxCalculatorFactory();
            ITaxCalculator calc = factory.CreateTaxCalculator("TN");
            BillingSystem billingSystem = new BillingSystem(calc);
            billingSystem.GenerateBill();
        }
    }


    public class TaxCalculatorFactory
    {
        public ITaxCalculator CreateTaxCalculator(string state)
        {

            if (state == "TN")
                return new TNTaxCalculator();
            else if (state == "KA")
                return new KATaxCalculator();
            return null;
        }
    }

    public class BillingSystem
    {
        ITaxCalculator calc = null;

        public BillingSystem(ITaxCalculator calc)
        {
            this.calc = calc;
        }

        public void GenerateBill()
        {
            // total amount
            int totAmount = 5000;
            // calculate tax
            //TNTaxCalculator calc = new TNTaxCalculator();
            double tax = calc.CalculateTax(totAmount);
            // bill amount
            double billAmt = totAmount + tax;
            // generate the bill


        }
    }

    public interface ITaxCalculator
    {
        double CalculateTax(double amount);
    }

    public class KATaxCalculator : ITaxCalculator
    {
        public double CalculateTax(double amount)
        {
            // KA tax calculator
            int cst = 120;
            int kst = 140;
            int sbt = 50;
            int kkt = 10;
            double tax = cst + kst + sbt + kkt;
            System.Console.WriteLine("Using KA Tax Calculator");
            return tax;
        }
    }

    public class TNTaxCalculator : ITaxCalculator
    {
        public double CalculateTax(double amount)
        {
            // TN tax calculator
            int cst = 120;
            int tst = 150;
            int es = 70;
            int abc = 10;
            double tax = cst + tst + es + abc;
            System.Console.WriteLine("Using TN Tax Calculator");
            return tax;
        }
    }


}
