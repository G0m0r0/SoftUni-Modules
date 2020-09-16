using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.KeyVault.Models;


namespace Phonebook.Data
{
    public class DataAccess
    {
        public static List<Contact> Contacts { get; set; } = new List<Contact>();

       // public DataAccess()
       // {
       //     Contacts = new List<Contact>();
       // }
       // public static List<Contact> Contacts { get; set; }
    }
}
