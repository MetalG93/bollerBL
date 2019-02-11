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
        int number, index;
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

            int max = 0;
            foreach (Team t in Misc.teams)
            {
                if (t.Index > max)
                    max = Index;
            }
            Index = max + 1;
        }

        public Team(int _index, string _name, string _leader, string _phone, string _email, string _address, int _num, bool _paid)
        {
            Name = _name;
            Leader = _leader;
            Phone = _phone;
            Email = _email;
            Address = _address;
            Number = _num;
            Paid = _paid;
            Index = _index;
        }

        public string Name { get => name; set => name = value; }
        public string Leader { get => leader; set => leader = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public string Address { get => address; set => address = value; }
        public int Number { get => Number1; set => Number1 = value; }
        public bool Paid { get => paid; set => paid = value; }
        public int Number1 { get => number; set => number = value; }
        public int Index { get => index; set => index = value; }

        public override string ToString()
        {
            return string.Format("{0};{1};{2};{3};{4};{5};{6};{7}", index, name, leader, phone, email, address, Number1, paid);
        }
    }
}
