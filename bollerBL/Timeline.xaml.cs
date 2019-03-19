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
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Threading;

namespace bollerBL
{
    /// <summary>
    /// Interaction logic for Timeline.xaml
    /// </summary>
    public partial class Timeline : Window
    {
        Rectangle actualTime;
        DispatcherTimer timer;
        double top;
        int per = 150;

        public Timeline()
        {
            if (Misc.artists.Count == 0)
                Misc.loadArtist();

            InitializeComponent();
            actualTime = new Rectangle();

            timer = new DispatcherTimer();
            timer.Tick += timer_Tick;
            timer.Start();
            timer.Interval = new TimeSpan(0, 5, 0);

            fillTime();
            fillArtist();

            actualLine();
            actualTime.Fill = new SolidColorBrush(Color.FromRgb(0, 0, 255));
            grid.Children.Add(actualTime);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.Minute % 5 == 0)
                actualTime.Margin = new Thickness();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            timer.Stop();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            actualLine();
        }

        private void actualLine()
        {
            top = (this.Height - 25) / 1440;
            actualTime.Margin = new Thickness(0, top * (DateTime.Now.Hour * 60 + DateTime.Now.Minute / 5), 0, 0);
            actualTime.Height = this.Height / per;
            actualTime.Width = this.Width;
        }

        private void fillTime()
        {
            top = (this.Height - 25) / 1440;
            for (int i = 0; i < 24; i++)
            {
                Rectangle rect = new Rectangle();
                rect.Margin = new Thickness(0, top * i * 60, 0, 0);
                rect.Height = 10;
                rect.Width = this.Width;
                rect.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                grid.Children.Add(rect);
            }
        }

        private void fillArtist()
        {
            foreach (Grid g in grid.Children)
                grid.Children.Remove(g);

            if (Misc.artists.Count == 0)
                Misc.loadArtist();

            foreach (Artist art in Misc.artists)
            {
                Grid rectangle = new Grid();
                rectangle.Background = new SolidColorBrush(Color.FromRgb(179, 225, 247));
                rectangle.Margin = new Thickness(0, 0, 0, 0);
                rectangle.Height = (double)(art.Length.TotalMinutes / 5);

                TextBlock tb = new TextBlock();
                tb.Margin = new Thickness(10, 10, 0, 0);
                tb.Text = art.Name;

                rectangle.Children.Add(tb);
                grid.Children.Add(rectangle);
            }
        }
    }
}