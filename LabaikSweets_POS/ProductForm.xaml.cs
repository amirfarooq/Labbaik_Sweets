using LabaikSweets_POS.DAL;
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

namespace LabaikSweets_POS
{
    /// <summary>
    /// Interaction logic for ProductForm.xaml
    /// </summary>
    public partial class ProductForm : UserControl
    {
        public ProductForm()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string id = Convert.ToString(cmbCategory.SelectedValue);
            string name = cmbCategory.Text;
            MessageBox.Show(string.Format("Selected Category Id {0} Category Name {1}", id, name));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var list = new CategoryDAL().GetAllCategories();
            if (list.Count > 0)
            {
                cmbCategory.ItemsSource = list;
                cmbCategory.SelectedIndex = 0;
            }

        }
    }
}
