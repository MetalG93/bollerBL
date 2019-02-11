using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace bollerBL
{
    class Team
    {
        string name, leader, phone, email, address, plateNumber = "";
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

        public Team(int _index, string _name, string _leader, string _phone, string _email, string _address, int _num, bool _paid, string _plateNum)
        {
            Name = _name;
            Leader = _leader;
            Phone = _phone;
            Email = _email;
            Address = _address;
            Number = _num;
            Paid = _paid;
            Index = _index;
            PlateNumber = _plateNum;
        }

        public string Name { get => Name1; set => Name1 = value; }
        public string Leader { get => Leader1; set => Leader1 = value; }
        public string Phone { get => Phone1; set => Phone1 = value; }
        public string Email { get => Email1; set => Email1 = value; }
        public string Address { get => Address1; set => Address1 = value; }
        public int Number { get => Number1; set => Number1 = value; }
        public bool Paid { get => paid; set => paid = value; }
        public int Number1 { get => number; set => number = value; }
        public int Index { get => index; set => index = value; }
        public string Name1 { get => name; set => name = value; }
        public string Leader1 { get => leader; set => leader = value; }
        public string Phone1 { get => phone; set => phone = value; }
        public string Email1 { get => email; set => email = value; }
        public string Address1 { get => address; set => address = value; }
        public string PlateNumber { get => plateNumber; set => plateNumber = value; }

        public override string ToString()
        {
            return string.Format("{0};{1};{2};{3};{4};{5};{6};{7}", index, Name1, Leader1, Phone1, Email1, Address1, Number1, paid);
        }

        public void createEntryPermit()
        {
            Document doc = new Document();
            doc.SetPageSize(PageSize.A4.Rotate());
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(string.Format("{0}\\{1}.pdf", Misc.PDFpath, PlateNumber), FileMode.Create));

            if (PlateNumber != "")
            {
                try
                {
                    writer.Open();
                    doc.Open();

                    PdfPTable icon = new PdfPTable(1);
                    PdfPCell iconCell = new PdfPCell(Image.GetInstance("ikon.png"));
                    iconCell.Border = PdfPCell.NO_BORDER;
                    iconCell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    icon.AddCell(iconCell);
                    doc.Add(icon);

                    doc.Close();
                    writer.Close();
                    MessageBox.Show("PDF készítése sikeres!");
                }
                catch (FieldAccessException)
                {
                    MessageBox.Show("");
                }
            }
            else
                MessageBox.Show("Nincs megadva rendszám!");
        }
    }
}
