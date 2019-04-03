using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bollerBL
{
    class User
    {
        string name, passWord;

        public string Name
        { get { return name; } }

        public string PassWord
        {
            get { return passWord; }
            set { passWord = value; }
        }

        public User(string _name, string _password)
        {
            name = _name;
            passWord = _password;
        }

        public override string ToString()
        {
            return string.Format("{0};{1}", name, passWord);
        }
    }
}
