using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
            Form1_Load();
        }

        private double start_x;
        private double end_x;

        public static double Function(double x)
        {
            return (Math.Pow(Math.Sin(x), 3));  // заданная функция
        }
        public  void DS()
        {

            double a = -6, b = 2.0, x_m = (a + b) / 2; // заданный по условию сегмент
            start_x = a;
            end_x = b;
            double y, z, f1, f2, f3, eps = 0.0001;
            double res_x;
            // данное поэтапное решение соответствует алгоритму из Пантелеева (стр. 112)  
            do
            {

                y = a + (b - a) / 4;
                z = b - (b - a) / 4;
                f1 = Function(y);
                f2 = Function(z);
                f3 = Function(x_m);
                // Согласно шагу 5 алгоритма, описанному в Пантелееве (стр. 11), выполняем действия при f(y_k) < f(x_m)
                if (f1 < f3)
                {
                    b = x_m;
                    x_m = y;
                }
                // Согласно шагу 6 алгоритма, описанному в Пантелееве (стр. 112), выполняем действия при f(z_k) < f(x_m)
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
            while (Math.Abs(b - a) > eps); // условие завершения программы
            res_x = (a + b) / 2; // в качестве приближённого решения берём середину последнего интервала

            textBox1.Text = "Результат: x = " + res_x;
            textBox2.Text = "Значение функции: F(x) = " + Function(res_x);

        }

        private void Form1_Load()
        {
            // Размер объекта "ClientSize" (область для рисования) по ширине.
            int bHeight = 600;
            // Размер объекта "ClientSize" (область для рисования) по высоте.
            int bWidth = 600;
          
            this.ClientSize = new Size(bWidth, bHeight);

            Bitmap bm = new Bitmap(bHeight, bWidth);
            // Создаём новый объект "Graphics" - локальная переменная "g".
            Graphics g = Graphics.FromImage(bm);
            // Перебрасываем изображение (посредством переменной "bm") в pictureBox1.
            this.pictureBox1.Image = bm;

            //Создаём объект "Pen", объявив локальную переменную "p", чёрного цвета и шириной 5 пикселов свойства -"Color.Black, 5".
            Pen p = new Pen(Color.Black, 5);
            // Для визуализации координатных осей создадим маркеры в форме стрелок на концах линий
            p.EndCap = LineCap.ArrowAnchor;
            //  Задаём расположение рисунка
            g.DrawLine(p, 20, bHeight / 2, bWidth - 20, bHeight / 2);
            
            g.DrawLine(p, bWidth / 2, bHeight - 20, bWidth / 2, 20);
           
            int x, y;
            // Реализация вывода графика циклом
            for (double i = (-2) * Math.PI; i <= 2 * Math.PI; i += 0.0001)
            {
                x = bWidth / 2 - Convert.ToInt32(40 * i);
                y = bHeight / 2 + Convert.ToInt32(200 * (Math.Pow(Math.Sin(i), 3)));
                bm.SetPixel(x, y, Color.Blue);
            }
        }
    }
}
