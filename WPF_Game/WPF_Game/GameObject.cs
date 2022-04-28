using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Wpf_Game
{
    abstract class GameObject
    {
        private double x;
        private double y;
        private double vx;
        private double vy;
        private bool period=true;

        public double X{ get { return x; } set { x = value; } }
        public double Y{ get { return y; } set { y = value; } }
        public double Vx{ get { return vx; } set { vx = value; } }
        public double Vy{ get { return vy; } set { vy = value; } }  

        public GameObject(double in_x, double in_y)
        {
            this.x = in_x;
            this.y = in_y; 
        }

        public GameObject(double in_x, double in_y, double in_vx, double in_vy)
        {
            this.x = in_x;
            this.y = in_y;
            this.vx = in_vx;
            this.vy = in_vy;
        }

        public abstract void Render(Canvas Playground);

        public void ChangedPos(TimeSpan intervall, Canvas Playground)
        {
            x += vx * intervall.TotalSeconds;
            y += vy*intervall.TotalSeconds;

            if(period)
            {
                if(x < 0)
                {
                    x = Playground.ActualWidth;
                }
                else if(x>Playground.ActualWidth)
                {
                    x = 0;
                }
                if (y < 0)
                {
                    y = Playground.ActualHeight;
                }
                else if (y>Playground.ActualHeight)
                {
                    y= 0;
                }
            }
        }

    }

    class asteroid:GameObject
    {
        static Random rand = new Random();
        public asteroid(Canvas Playground):base(rand.NextDouble()*Playground.ActualWidth,
            rand.NextDouble()*Playground.ActualHeight, 
            (rand.NextDouble()-0.5)*100, 
            (rand.NextDouble()-0.5) * 100)
        {
            
        }
        public override void Render(Canvas Playground)
        {
            Polygon poly=new Polygon();

            for(int i = 0; i < 20; i++)
            {
                double alpha = 2.0 * Math.PI / 20.0 * i;
                double r = (rand.NextDouble() * 4.0) + 8.0;
                poly.Points.Add(new System.Windows.Point(r*Math.Cos(alpha),r*Math.Sin(alpha)));
            }

            Playground.Children.Add(poly);

            poly.Fill = Brushes.Black;

            Canvas.SetLeft(poly,X);
            Canvas.SetTop(poly,Y);
        }

    }

    //class spaceship:GameObject
    //{

    //}

    //class weapon:GameObject
    //{

    //}
}
