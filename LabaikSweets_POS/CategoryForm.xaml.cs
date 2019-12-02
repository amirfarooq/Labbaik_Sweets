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
    /// Interaction logic for CategoryForm.xaml
    /// </summary>
    public partial class CategoryForm : UserControl
    {
        public CategoryForm()
        {
            InitializeComponent();
            GetAllCategories();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int result = new CategoryDAL().ManageCategory(txtCategoryName.Text);
            if (result > 0)
            {
                MessageBox.Show("Succeeded", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (result == -1)
            {
                MessageBox.Show("Category name already exists", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            clearcontrol();
        }

        private void GetAllCategories()
         {

           
        }

       

        //Method for clear data from control
        private void clearcontrol()
        {
            txtCategoryName.Text = string.Empty;

        }
    }
}
