using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace _05_bindings
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ViewModel viewModel = new();
        public MainWindow()
        {
            InitializeComponent();

            // Connect View -> ViewModel
            this.DataContext = viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(viewModel.CurrentUser.ToString());
        }
    }

    public class ViewModel
    {
        public User CurrentUser { get; set; }
        public ObservableCollection<string> Colors { get; set; }

        // ... other properties

        public ViewModel()
        {
            CurrentUser = new("example@gmail.com");
            Colors = new ObservableCollection<string>()
            {
                "Red", "Yellow", "Brown", "Magenta", "Coral", "White"
            };
        }
    }

    public class User
    {
        public string Email { get; set; }
        public int Score { get; set; }

        public User(string email)
        {
            this.Email = email;
            Score = 0;
        }

        public override string ToString()
        {
            return $"User: {Email}, Score: {Score}";
        }
    }
}
