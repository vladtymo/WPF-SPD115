using PropertyChanged;
using System;

namespace _06_contact_book_bindings
{
    // TODO: implement INotifyPropertyChanged
    [AddINotifyPropertyChangedInterface]
    public class Contact : ICloneable
    {
        public string Name { get; set; } // OnPropertyChanged "Name" | "ShortInfo" 
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public bool IsBlocked { get; set; }

        public object Clone()
        {
            var copy = (Contact)MemberwiseClone();

            copy.Name = (string)Name.Clone();
            copy.Surname = (string)Surname.Clone();
            copy.Phone = (string)Phone.Clone();

            return copy;
        }

        [DependsOn("Name", "Surname", "Phone")]
        public string ShortInfo => ToString();

        public override string ToString()
        {
            return $"{Name} {Surname} : {Phone}";
        }
    }
}
