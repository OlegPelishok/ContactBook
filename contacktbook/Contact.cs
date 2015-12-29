using System;
using System.Xml.Serialization;

namespace contacktbook
{
    /// <summary>
    /// Unit  of contact book
    /// </summary>
    [Serializable]
    public class Contact
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Tel1 { get; set; }
        public string Tel2 { get; set; }
        public string Email { get; set; }
        //public DateTime DateOfBirth { get; set; }

        public Contact()
        {}

        public Contact(string id, string firstname, string secondName, string tel1,
            string tel2, string email)
        {
            Id = id;
            FirstName = firstname;
            SecondName = secondName;
            Tel1 = tel1;
            Tel2 = tel2;
            Email = email;
        }
        public Contact(string firstName, string secondName, string tel1,
            string tel2, string email)
        {
            FirstName = firstName;
            SecondName = secondName;
            Tel1 = tel1;
            Tel2 = tel2;
            Email = email;
        }

        public Contact(string firstname, string secondName)
        {
            FirstName = firstname;
            SecondName = secondName;
        }
    }

}
