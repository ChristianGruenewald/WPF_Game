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
    class GameObject
    {
        private double x;
        private double y;
        private double vx;
        private double vy;

        public double X{ get { return x; } set { x = value; } }
        public double Y{ get { return y; } set { y = value; } }
        public double Vx{ get { return vx; } set { vx = value; } }
        public double Vy{ get { return vy; } set { vy = value; } }  

        public GameObject(double in_x, double in_y)
        {
            this.x = in_x;
            this.y = in_y; 
        }

        public virtual void Render(Canvas Playground)
        {

        }

    }

    class asteroid:GameObject
    {
        static Random rand = new Random();
        public asteroid(Canvas Playground):base(rand.NextDouble()*Playground.ActualWidth,rand.NextDouble()*Playground.ActualHeight)
        {
            
        }
        public override void Render(Canvas Playground)
        {
            Ellipse elli=new Ellipse();

            Playground.Children.Add(elli);

            elli.Width = 10.0;
            elli.Height = 10.0;
            elli.Fill = Brushes.AliceBlue;

            Canvas.SetLeft(elli,X);
            Canvas.SetTop(elli,Y);
        }
    }

    //class spaceship:GameObject
    //{

    //}

    //class weapon:GameObject
    //{

    //}
}
