using System;
using System.Collections.Generic;
using System.Linq;

namespace tryCatch
{
    class Program
    {
        public class Contact
        {
            public Contact()
            {
                this.FirstName = FirstName;
                this.LastName = LastName;
                this.Email = Email;
                this.Address = Address;
            }

            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string Email { get; set; }

            public string Address { get; set; }

            public string FullName
            {
                get
                {
                    return $"{FirstName} {LastName}";
                }
            }
        }

        public class AddressBook
        {
            Dictionary<string, Contact> Contacts = new Dictionary<string, Contact>();

            public void AddContact(Contact contact)
            {
                try
                {
                    if (!Contacts.ContainsKey(contact.Email))
                    {
                        Contacts.Add(contact.Email, contact);
                    }
                }
                catch (ArgumentException)
                {
                    Console.WriteLine($"{contact.Email} already exists");
                }
            }

            public Contact GetByEmail(string email)
            {
                {
                    var foundContact = Contacts.FirstOrDefault(contact => contact.Key == email);
                    return foundContact.Value;
                }
            }
        }

        static void Main(string[] args)
        {
            // Create a few contacts
            Contact bob = new Contact()
            {
                FirstName = "Bob",
                LastName = "Smith",
                Email = "bob.smith@email.com",
                Address = "100 Some Ln, Testville, TN 11111"
            };
            Contact sue = new Contact()
            {
                FirstName = "Sue",
                LastName = "Jones",
                Email = "sue.jones@email.com",
                Address = "322 Hard Way, Testville, TN 11111"
            };
            Contact juan = new Contact()
            {
                FirstName = "Juan",
                LastName = "Lopez",
                Email = "juan.lopez@email.com",
                Address = "888 Easy St, Testville, TN 11111"
            };


            // Create an AddressBook and add some contacts to it
            AddressBook addressBook = new AddressBook();
            addressBook.AddContact(bob);
            addressBook.AddContact(sue);
            addressBook.AddContact(juan);

            // Try to addd a contact a second time
            addressBook.AddContact(sue);


            // Create a list of emails that match our Contacts
            List<string> emails = new List<string>() {
            "sue.jones@email.com",
            "juan.lopez@email.com",
            "bob.smith@email.com",
        };

            // Insert an email that does NOT match a Contact
            emails.Insert(1, "not.in.addressbook@email.com");


            //  Search the AddressBook by email and print the information about each Contact
            foreach (string email in emails)
            {
                try
                {
                    Contact contact = addressBook.GetByEmail(email);
                    Console.WriteLine("----------------------------");
                    Console.WriteLine($"Name: {contact.FullName}");
                    Console.WriteLine($"Email: {contact.Email}");
                    Console.WriteLine($"Address: {contact.Address}");
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine($"The email {email} was not found.");
                }
            }
        }
    }
}
