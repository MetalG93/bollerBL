using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bollerBL
{
    class Guest
    {
        string name, phone, email;
        bool come;

        public Guest(string _name, string _phone, string _email, bool _come)
        {
            Name = _name;
            Phone = _phone;
            Email = _email;
            Come = _come;
        }

        public string Name { get => name; set => name = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public bool Come { get => come; set => come = value; }

        public override string ToString()
        {
            return string.Format("{0};{1};{2};{3}", name, phone, email, come);
        }
    }
}
