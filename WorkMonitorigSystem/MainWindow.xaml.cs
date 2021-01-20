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

namespace WorkMonitorigSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isStartClicked = false;
        private bool isBreakClicked = false;
        private bool isAwayClicked = false;
        public MainWindow()
        {            
            InitializeComponent();
        }

        private void Start_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!isStartClicked)
            {
                Start.Background = new SolidColorBrush(Colors.DarkGreen);
                Start.Foreground = new SolidColorBrush(Colors.Aqua);
            }
            if (isStartClicked)
            {
                Start.Background = new SolidColorBrush(Colors.DarkRed);
                Start.Foreground = new SolidColorBrush(Colors.Aqua);
            }
        }

        private void Start_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!isStartClicked)
            {
                Start.Background = new SolidColorBrush(Colors.Green);
                Start.Foreground = new SolidColorBrush(Colors.Black);
            }
            if (isStartClicked)
            {
                Start.Background = new SolidColorBrush(Colors.Red);
                Start.Foreground = new SolidColorBrush(Colors.Aqua);
            }
        }

        private void Break_MouseEnter(object sender, MouseEventArgs e)
        {
            Break.Background = new SolidColorBrush(Colors.Yellow);
            Break.Foreground = new SolidColorBrush(Colors.Aqua);
        }

        private void Break_MouseLeave(object sender, MouseEventArgs e)
        {
            Break.Background = new SolidColorBrush(Colors.LightYellow);
            Break.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void Away_MouseEnter(object sender, MouseEventArgs e)
        {
            Away.Background = new SolidColorBrush(Colors.DarkOrange);
            Away.Foreground = new SolidColorBrush(Colors.Aqua);
        }

        private void Away_MouseLeave(object sender, MouseEventArgs e)
        {
            Away.Background = new SolidColorBrush(Colors.Orange);
            Away.Foreground = new SolidColorBrush(Colors.Black);
        }
        private static DateTime date = new DateTime();
        private void Start_MouseDown(object sender, MouseButtonEventArgs e)
        {
            date = DateTime.Now;

            if (!isStartClicked)
            {
                string dateStr = date.Year.ToString() + "-" + date.Month.ToString() + "-" + date.Day.ToString() + "_" + date.Hour.ToString() + "-" + date.Minute.ToString() + "-" + date.Second.ToString();
                Logger.currentDate += dateStr;
                dateStr = "";
                Logger.path = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/workLog_{Logger.currentDate}.csv";
                isStartClicked = true;
                Start.Background = new SolidColorBrush(Colors.Red);
                Start.Content = "Zakończ pracę";
                Logger.Log(Logger.path, $"{date:dd.mm.yyyy_HH:mm:ss};Rozpoczecie pracy");
                this.WindowState = WindowState.Minimized;
            }
            else
            {
                WorkDescription wd = new WorkDescription();
                wd.Show();
                isStartClicked = false;
                Start.Background = new SolidColorBrush(Colors.Green);
                Start.Content = "Zacznij pracę";
                Logger.path = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/workLog_{Logger.currentDate}.csv";
                Logger.Log(Logger.path, $"{date:dd.mm.yyyy_HH:mm:ss};Zakonczenie pracy");
                Logger.currentDate = "";
            }
        }
        private void Break_MouseDown(object sender, MouseButtonEventArgs e)
        {
            date = DateTime.Now;

            if (!isBreakClicked)
            {
                isBreakClicked = true;
                Break.Content = "Koniec przerwy";
                Logger.Log(Logger.path, $"{date:dd.mm.yyyy_HH:mm:ss};Rozpoczecie przerwy");
            }
            else
            {
                isBreakClicked = false;
                Break.Content = "Przerwa";
                Logger.Log(Logger.path, $"{date:dd.mm.yyyy_HH:mm:ss};Zakonczenie przerwy");
                this.WindowState = WindowState.Minimized;
            }
        }
        private void Away_MouseDown(object sender, MouseButtonEventArgs e)
        {
            date = DateTime.Now;

            if (!isAwayClicked)
            {
                isAwayClicked = true;
                Away.Content = "Jestem z powrotem";
                Logger.Log(Logger.path, $"{date:dd.mm.yyyy_HH:mm:ss};Zaraz wracam");
            }
            else
            {
                isAwayClicked = false;
                Away.Content = "Zaraz wracam";
                Logger.Log(Logger.path, $"{date:dd.mm.yyyy_HH:mm:ss};Jestem z powrotem");
                this.WindowState = WindowState.Minimized;
            }
        }
    }
}
