using CalculatorLibrary;
using System;
using System.Windows.Forms;

namespace SimpleCalculatorWindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int fno = int.Parse(textBox1.Text);
            int sno = int.Parse(textBox2.Text);
            Calculator calc = new Calculator();
            int sum = calc.Sum(fno, sno);
            MessageBox.Show($"The sum {fno} and {sno} is {sum}");
        }
    }
}
