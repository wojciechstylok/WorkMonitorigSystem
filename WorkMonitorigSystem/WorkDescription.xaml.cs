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

namespace WorkMonitorigSystem
{
    public partial class WorkDescription : Window
    {
        public WorkDescription()
        {
            InitializeComponent();
        }
        private void Send_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string message = "Opis pracy: ";
            message += Description.Text;
            Logger.Log(Logger.path, message);
            this.Close();
        }
    }
}
