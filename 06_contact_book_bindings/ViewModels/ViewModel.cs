using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace _06_contact_book_bindings
{
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
                contacts.Add((Contact)SelectedContact.Clone());
        }
        public void RemoveSelected()
        {
            if (SelectedContact != null)
                contacts.Remove(SelectedContact);
        }
    }
}
