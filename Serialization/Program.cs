using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace Serialization
{
    class Program
    {
        private static List<Contact> contacts;

        static void AddContact(Contact contact)
        {
            contacts.Add(contact);
        }

        const string Path = "PhoneBook.txt";
        const string PathXML = "PhoneBookXML.txt";

        /*static void Save()
        {
            using (StreamWriter sw = new StreamWriter(Path))
            {
                foreach (Contact c in contacts)
                {
                    sw.WriteLine(c);
                }
            }
        }*/

        static void SaveToXml()
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Contact>));
            using (StreamWriter sw = new StreamWriter(PathXML))
            {
                xmlSerializer.Serialize(sw, contacts);
            }
        }

        static List<Contact> GetFromXml()
        {
            var xmlDeserializer = new XmlSerializer(typeof(List<Contact>));
            using (StreamReader sr = new StreamReader(PathXML))
            {
                var contacts = xmlDeserializer.Deserialize(sr);
            }
            return contacts;
        }

        static void Main(string[] args)
        {
            contacts = new List<Contact>();

            Contact IvanPetrovich;
            IvanPetrovich.Name = "Ivan Petrovich";
            IvanPetrovich.Number = "38028312381";
            AddContact(IvanPetrovich);
            SaveToXml();
            var contactsFromFile = GetFromXml();
            foreach (var VARIABLE in contactsFromFile)
            {
                Console.WriteLine(VARIABLE);
            }
        }
    }
}
