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

namespace VasilijeSIMS.View
{
    /// <summary>
    /// Interaction logic for homepage.xaml
    /// </summary>
    public partial class homepage : Window
    {
        public homepage()
        {
            InitializeComponent();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            var s = new MainWindow();
            s.Show();
            Close();
        }

        private void Users_Click(object sender, RoutedEventArgs e)
        {
            var s = new UserView();
            s.Show();
            Close();
        }

        private void Ingredients_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Medicines_Click(object sender, RoutedEventArgs e)
        {
            var s = new MedicineView();
            s.Show();
            Close();
        }
    }
}
