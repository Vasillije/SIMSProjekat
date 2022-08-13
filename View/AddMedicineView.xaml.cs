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
    /// Interaction logic for AddMedicineView.xaml
    /// </summary>
    public partial class AddMedicineView : Window
    {
        public AddMedicineView()
        {
            InitializeComponent();
        }

        public bool validation()
        {
            if (id.Text == null || name.Text == null || manufacturer.Text == null || quantity.Text == null || ingredients.Text == null)
            {
                MessageBox.Show("you must fill in all fields");
                return false;
            }
            //else if (yes1 is checked || yes2 is checked)
            //{
            //    MessageBox.Show("Medicine must not be accepted or deleted when it is created");
            //}
            return true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            var s = new MedicineView();
            s.Show();
            Close();
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
