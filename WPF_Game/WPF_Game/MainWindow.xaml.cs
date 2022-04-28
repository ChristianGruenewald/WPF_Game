using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Wpf_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(0.1);
            timer.Tick += AniRender;
     
        }

        List<asteroid> asteroids = new List<asteroid>();
        DispatcherTimer timer= new DispatcherTimer();
        private void AniRender(object sender, EventArgs e)
        {
            for (int i = 0; i < asteroids.Count; i++)
            {
                asteroids[i].ChangedPos(timer.Interval, Playground);
            }
            Playground.Children.Clear();
            for (int i = 0; i < asteroids.Count; i++)
            {
                asteroids[i].Render(Playground);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i <10; i++)
            {
                asteroids.Add(new asteroid(Playground));
            }
            timer.Start();

        }
    }
}
