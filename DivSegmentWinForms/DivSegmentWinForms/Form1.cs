using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DivSegmentWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DS();
        }

  
        public static double Function(double x)
        {
            return ((x * x * x * x) + 8 * (x * x * x) - 6 * (x * x) - 72 * x + 90);  
        }
        public  void DS()
        {

            double a = -6, b = 2.0, x_m = (a + b) / 2; 
            double y, z, f1, f2, f3, eps = 0.0001;
            double res_x;
           
            do
            {
                

                y = a + (b - a) / 4;
                z = b - (b - a) / 4;
                f1 = Function(y);
                f2 = Function(z);
                f3 = Function(x_m);
                
                if (f1 < f3)
                {
                    b = x_m;
                    x_m = y;
                }
           
                else if (f2 < f3)
                {
                    a = x_m;
                    x_m = z;
                }
                else if (f2 >= f3)
                {
                    a = y;
                    b = z;
                }
            }
            while (Math.Abs(b - a) > eps); 
            res_x = (a + b) / 2; 

            textBox1.Text = "Результат: x = " + res_x;
            textBox2.Text = "Значение функции: F(x) = " + Function(res_x);

        }
    }
}
