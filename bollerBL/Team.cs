using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bollerBL
{
    class Team
    {
        string name, leader, phone, email, address;
        int number;
        bool paid;

        public Team(string _name, string _leader, string _phone, string _email, string _address, int _num, bool _paid)
        {
            Name = _name;
            Leader = _leader;
            Phone = _phone;
            Email = _email;
            Address = _address;
            Number = _num;
            Paid = _paid;
        }

        public string Name { get => name; set => name = value; }
        public string Leader { get => leader; set => leader = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public string Address { get => address; set => address = value; }
        public int Number { get => number; set => number = value; }
        public bool Paid { get => paid; set => paid = value; }
    }
}
