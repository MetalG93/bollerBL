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
        string name, leader, phone, email, address, plateNumber;
        int number, index, gardenNumber;
        bool paid, entryPermissionSent;

        #region Constructors
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

            entryPermissionSent = false;
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
            entryPermissionSent = false;
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
            entryPermissionSent = false;
        }

        public Team(int _index, string _name, string _leader, string _phone, string _email, string _address, int _num, bool _paid, string _plateNum, bool _entryPermission)
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
            entryPermissionSent = _entryPermission;
        }

        public Team(int _index, string _name, string _leader, string _phone, string _email, string _address, int _num, bool _paid, string _plateNum, bool _entryPermission, int _gardenNumber)
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
            entryPermissionSent = _entryPermission;
            GardenNumber = _gardenNumber;
        }
        #endregion

        public string Name { get => Name1; set => Name1 = value; }
        public string Leader { get => Leader1; set => Leader1 = value; }
        public string Phone { get => Phone1; set => Phone1 = value; }
        public string Email { get => Email1; set => Email1 = value; }
        public string Address { get => Address1; set => Address1 = value; }
        public int Number { get => Number1; set => Number1 = value; }
        public bool Paid { get => paid; set => paid = value; }
        public int Number1 { get => Number2; set => Number2 = value; }
        public int Index { get => Index1; set => Index1 = value; }
        public string Name1 { get => name; set => name = value; }
        public string Leader1 { get => leader; set => leader = value; }
        public string Phone1 { get => phone; set => phone = value; }
        public string Email1 { get => email; set => email = value; }
        public string Address1 { get => address; set => address = value; }
        public string PlateNumber { get => plateNumber; set => plateNumber = value; }
        public int Number2 { get => number; set => number = value; }
        public int Index1 { get => index; set => index = value; }
        public int GardenNumber { get => gardenNumber; set => gardenNumber = value; }

        public override string ToString()
        {
            return string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10}", Index1, Name1, Leader1, Phone1, Email1, Address1, Number1, paid, entryPermissionSent, PlateNumber, GardenNumber);
        }

        //A behajtási engedély elkészítésée
        public void createEntryPermit()
        {
            if (PlateNumber != "")
            {
                if (paid)
                {
                    if (!entryPermissionSent)
                    {
                        try
                        {
                            Font yearFont = FontFactory.GetFont("Arial", 50);
                            Font plateFont = FontFactory.GetFont("Arial", 125, Font.BOLD);

                            Document doc = new Document();
                            doc.SetPageSize(PageSize.A4.Rotate());
                            string filename = string.Format(@"{0}\{1}_{2}.pdf", Misc.PDFpath, Name, PlateNumber);
                            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filename, FileMode.Create));
                            writer.Open();
                            doc.Open();

                            PdfPTable icon = new PdfPTable(1);

                            PdfPCell iconCell = new PdfPCell(Image.GetInstance("ikon.png"));
                            iconCell.Border = PdfPCell.NO_BORDER;
                            iconCell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                            icon.AddCell(iconCell);
                            doc.Add(icon);

                            PdfPTable yearTable = new PdfPTable(1);

                            PdfPCell yerarNum = new PdfPCell(new Phrase(string.Format("BÖLLÉR BL {0}", (DateTime.Now.Month < 5) ? DateTime.Today.Year : DateTime.Now.Year + 1), yearFont));
                            yerarNum.Border = PdfPCell.NO_BORDER;
                            yerarNum.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                            yearTable.AddCell(yerarNum);
                            doc.Add(yearTable);


                            PdfPTable emptyTable = new PdfPTable(1);

                            PdfPCell emptyCell = new PdfPCell(new Phrase(" ", plateFont));
                            emptyCell.Border = PdfPCell.NO_BORDER;

                            emptyTable.AddCell(emptyCell);
                            doc.Add(emptyTable);


                            PdfPTable plateTable = new PdfPTable(1);
                            plateTable.PaddingTop = PageSize.A4.Width / (float)1.5;
                                                        
                            PdfPCell plateNum = new PdfPCell(new Phrase(PlateNumber, plateFont));
                            plateNum.Border = PdfPCell.NO_BORDER;
                            plateNum.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                            plateTable.AddCell(plateNum);
                            doc.Add(plateTable);

                            doc.Close();
                            writer.Close();
                            //MessageBox.Show("PDF készítése sikeres!");
                            System.Diagnostics.Process.Start(filename);
                            entryPermissionSent = true;
                        }
                        catch (FieldAccessException)
                        {
                            MessageBox.Show("");
                        }
                    }
                    else
                        MessageBox.Show("Már el lett küldve a behajtási engedély!");
                }
                else
                    MessageBox.Show("Nincs befizetve a nevezési díj!");
            }
            else
                MessageBox.Show("Nincs megadva rendszám!");
        }
    }
}
