using System;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;

/*Comment section
    -   De event handlers voor de tekstboxes hebben nu als trigger TextChanged,
        maar is het niet handiger om ze te triggeren als je op de OK knop klikt?
    -   
*/
namespace Practicum2
{
    public partial class Mandelbrot : Form
    {

        public Mandelbrot()
        {
            InitializeComponent();

            this.Paint += this.Tekenaar;

        }

        void Tekenaar(object o, EventArgs e)
        {
            Bitmap bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            for (int x = 0; x < pictureBox1.Width; x++)
            {
                for (int y = 0; y < pictureBox1.Height; y++)
                {
                    double a = (double)(x - (pictureBox1.Width / 2)) / (double)(pictureBox1.Width / 4);
                    double b = (double)(y - (pictureBox1.Width / 2)) / (double)(pictureBox1.Width / 4);
                    Complex c = new Complex(a, b);
                    Complex z = new Complex(0, 0);
                    // hier wordt de iteratie geregeld. de iteratie stopt als de magnitude groter is dan 2, of als hij 100 keer heeft geitereerd. 
                    // als een punt meer dan 100 iteraties heeft, is hij buiten de Mandelbrot set
                    // als een punt minder dan 100 iteraties heeft, is hij binnen de Mandelbrot set
                    int it = 0;
                    do
                    {
                        it++;
                        z.Square();
                        z.Add(c);
                        if (z.Magnitude() > 2.0) break;
                    }
                    while (it < 100);
                    bm.SetPixel(x, y, it < 100 ? Color.DarkSlateBlue : Color.PaleGreen);
                }


                pictureBox1.Image = bm;

            }
        }

        void MiddenX_TextChanged(object sender, EventArgs ea)
        {

            this.Invalidate();
        }

        void MiddenY_TextChanged(object sender, EventArgs e)
        {


            this.Invalidate();

        }

        void MaxWaarde_TextChanged(object sender, EventArgs e)
        {
            //functie die maximum aantal iteraties van f instelt
            //dit moeten we 100 maken 

            this.Invalidate();

        }

        void SchaalWaarde_TextChanged(object sender, EventArgs e)
        {
            //functie die zoom instelt
            //evt ook functie die laat zoomen met scroll

            this.Invalidate();

        }

        // parse hier de input van x, y, max en schaal en return naar de formule 
        void Button1(object o, EventArgs ea)
        {
            // double MiddenX = double.Parse(MiddenX.Text); 
        }
    }

    public class Complex
    {
        public double a; //"echte" deel van het complexe getal. 
        public double b; //"denkbeeldige" deel van het complexe getal. 

        // constructor voor de complexe getallen
        public Complex(double a, double b)
        {
            this.a = a;
            this.b = b;
        }

        public void Square()
        {
            double temp = (a * a) - (b * b);
            b = 2.0 * a * b;
            a = temp;
        }

        public double Magnitude()
        {
            return Math.Sqrt((a * a) + (b * b));
        }

        public void Add(Complex c)
        {
            a += c.a;
            b += c.b;
        }
    }

}


        
   