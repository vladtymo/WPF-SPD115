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

namespace _06_contact_book_bindings
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

            // Window -> ViewModel
            this.DataContext = viewModel;
        }

        private void CreateBtnClick(object sender, RoutedEventArgs e)
        {
            viewModel.CopySelected();
        }

        private void RemoveBtnClick(object sender, RoutedEventArgs e)
        {
            viewModel.RemoveSelected();
        }
    }

    public class ViewModel
    {
        private ObservableCollection<Contact> contacts = new();

        // ! We can bind only to public properties
        public IEnumerable<Contact> Contacts => contacts;
        public Contact SelectedContact { get; set; }

        public ViewModel()
        {
            contacts.Add(new Contact() { Name = "Vova", Age = 30, Surname = "Pupkin", Phone = "+3807575828", IsBlocked = true });
            contacts.Add(new Contact() { Name = "Marusia", Age = 25, Surname = "Shishik", Phone = "+380771244", IsBlocked = false });
            contacts.Add(new Contact() { Name = "Olga", Age = 33, Surname = "Shelesh", Phone = "+38067285792", IsBlocked = false });
        }

        // ! ViewModel should contains business logic methods
        public void CopySelected()
        {
            if (SelectedContact != null)
                this.contacts.Add((Contact)SelectedContact.Clone());
        }
        public void RemoveSelected()
        {
            if (SelectedContact != null)
                this.contacts.Remove(SelectedContact);
        }
    }

    // TODO: implement INotifyPropertyChanged
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class Contact : ICloneable
    {
        public string Name { get; set; } // OnPropertyChanged "Name" | "ShortInfo" 
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public bool IsBlocked { get; set; }

        public object Clone()
        {
            var copy = (Contact)this.MemberwiseClone();

            copy.Name = (string)this.Name.Clone();
            copy.Surname = (string)this.Surname.Clone();
            copy.Phone = (string)this.Phone.Clone();

            return copy;
        }

        [PropertyChanged.DependsOn("Name", "Surname", "Phone")]
        public string ShortInfo => ToString();

        public override string ToString()
        {
            return $"{Name} {Surname} : {Phone}";
        }
    }
}
