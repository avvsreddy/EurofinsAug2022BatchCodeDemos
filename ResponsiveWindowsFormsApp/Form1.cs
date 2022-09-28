using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResponsiveWindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // draw red rectangles
            Thread t1 = new Thread(() =>
            {
                Graphics red = panel1.CreateGraphics();
                Random rnd = new Random();
                for (int i = 1; i <= 1000; i++)
                {
                    int x = rnd.Next(panel1.Height);
                    int y = rnd.Next(panel1.Width);
                    red.DrawRectangle(Pens.Red, x, y, 20, 20);
                    Thread.Sleep(10);
                }
            });
            t1.Start();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // draw blue rectangles
            new Task(() =>
            {
                Graphics red = panel2.CreateGraphics();
                Random rnd = new Random();
                for (int i = 1; i <= 1000; i++)
                {
                    int x = rnd.Next(panel2.Height);
                    int y = rnd.Next(panel2.Width);
                    red.DrawRectangle(Pens.Blue, x, y, 20, 20);
                    Thread.Sleep(10);
                }
            }).Start();
        }
    }
}
