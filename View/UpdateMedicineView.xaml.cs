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
    /// Interaction logic for UpdateMedicineView.xaml
    /// </summary>
    public partial class UpdateMedicineView : Window
    {
        public UpdateMedicineView()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            var  s = new MedicineView();
            s.Show();
            Close();
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
