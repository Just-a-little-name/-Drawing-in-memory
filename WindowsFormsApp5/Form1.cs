using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {

        Bitmap      Background;
        Bitmap      AirCraft;

        int         AirCraftX;
        int         Delta;


        public Form1()
        {
            InitializeComponent();

            Background = new Bitmap(@"C:\PNGhi\background.jpg");
            AirCraft = new Bitmap(@"C:\PNGhi\Tarelka.png");

            AirCraftX = 0;
            Delta = +5;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //  Вычислить новые координаты всех объектов, которые могут двигаться.

            if(   Delta   >   0   )
            {
                if(   AirCraftX   +   Delta   >   Background.Width   -   AirCraft.Width   )     Delta = -5;
            }
            else
            {
                if(   AirCraftX   +   Delta   <   0                                     )     Delta = +5;
            }


            AirCraftX   +=   Delta;

            //  Нарисовать в памяти новую картинку.

            using (Bitmap Memory_Bitmap = new Bitmap(Background))
            {

                using (Graphics Memory_Graphics = Graphics.FromImage(Memory_Bitmap))
                {

                    Memory_Graphics.DrawImage(AirCraft, AirCraftX, 50 );


                    //  Скопировать картинку на экран.

                    using (Graphics Window_Graphics = CreateGraphics())
                    {
                        Window_Graphics.DrawImage(Memory_Bitmap, ClientRectangle);
                    }

                }

            }


        }

    }
}
