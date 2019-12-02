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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      
        public DateTime DateTime { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DateTime = DateTime.Now;
            TBB.SetBinding(TextBlock.TextProperty, new Binding("DateTime"));
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.WindowState = WindowState.Minimized;
            window.WindowState = WindowState.Normal;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Maximized;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void TextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            TBB.Text = DateTime.Now.ToString("   TODAY             dd-MM-yyyy              hh:mm:ss tt");
        }

      

      

        private void ClearControls()
        {
            nam.Children.Clear();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            ClearControls();
            CategoryForm dv = new CategoryForm();
            Grid.SetRowSpan(dv, 4);
            Grid.SetColumnSpan(dv, 4);
            nam.Children.Add(dv);
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            ClearControls();
            ProductForm dv = new ProductForm();
            Grid.SetRowSpan(dv, 4);
            Grid.SetColumnSpan(dv, 4);
            nam.Children.Add(dv);
        }

    }
}
