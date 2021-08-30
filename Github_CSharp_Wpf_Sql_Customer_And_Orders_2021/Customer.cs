using System;
using System.Collections.Generic;
using System.Text;

namespace WpfSsmsPizza
{
    class Customer
    {
        private int id;
        private static int idCount;
        private string name;
        private string userName;
        private string password;
        private string email;

        public Customer()
        {

        }//End C:*

        public Customer(int id, string name, string userName, string password, string email)
        {
            Id = id;
            Name = name;
            UserName = userName;
            Password = password;
            Email = email;
        }

        public int Id { get => id; set => id = value; }
        public static int IdCount { get => idCount; set => idCount = value; }
        public string Name { get => name; set => name = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
    }//End CL:*
}//End NS:*
