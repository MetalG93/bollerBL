using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bollerBL
{
    class Artist
    {
        string name, contact_name, contact_phone, contact_mail;
        int fee;
        DateTime begin, end;
        TimeSpan length;

        public Artist(string _name, string _contactName, string _contactPhone, string _contactMail, int _fee, DateTime _begin, DateTime _end)
        {
            Name = _name;
            Contact_name = _contactName;
            Contact_phone = _contactPhone;
            Contact_mail = _contactMail;
            Fee = _fee;
            Begin = _begin;
            End = _end;
            Length = _end - _begin;
        }

        public Artist(string _name, string _contactName, string _contactPhone, string _contactMail, int _fee, DateTime _begin, TimeSpan _length)
        {
            Name = _name;
            Contact_name = _contactName;
            Contact_phone = _contactPhone;
            Contact_mail = _contactMail;
            Fee = _fee;
            Begin = _begin;
            Length = _length;
            End = _begin + _length;
        }

        public string Name { get => Name1; set => Name1 = value; }
        public string Contact_phone { get => contact_phone; set => contact_phone = value; }
        public string Contact_mail { get => contact_mail; set => contact_mail = value; }
        public int Fee { get => fee; set => fee = value; }
        public DateTime Begin { get => begin; set => begin = value; }
        public string sBegin { get => begin.ToString("hh:mm"); }
        public DateTime End { get => end; set => end = value; }
        public TimeSpan Length { get => length; set => length = value; }
        public string Name1 { get => name; set => name = value; }
        public string Contact_name { get => contact_name; set => contact_name = value; }

        public override string ToString()
        {
            return string.Format("{0};{1};{2};{3};{4};{5};{6}", name, contact_name, contact_phone, contact_mail, fee, begin, end);
        }
    }
}
