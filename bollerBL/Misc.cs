﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.IO;
using System.Collections.ObjectModel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Security.Cryptography;

namespace bollerBL
{
    static class Misc
    {
        public static bool firstStart = true;
        public static List<User> users = new List<User>();
        public static ObservableCollection<Artist> artists = new ObservableCollection<Artist>();
        public static ObservableCollection<Guest> guests = new ObservableCollection<Guest>();
        public static ObservableCollection<Team> teams = new ObservableCollection<Team>();
        public static string PDFpath = @"D:\";

        public static int adultPrice;
        public static int childrenPrice;
        public static int taseTicketPrice;
        public static int rafflePrice;

        public static void loadUsers()
        {
            users.Clear();
            StreamReader sr = new StreamReader("users.csv");

            while (!sr.EndOfStream)
            {
                string[] datas = sr.ReadLine().Split(';');
                users.Add(new User(datas[0], datas[1]));
            }

            sr.Close();
        }

        public static void saveUsers()
        {
            StreamWriter sw = new StreamWriter("users.csv", false);

            foreach (User u in users)
            {
                sw.WriteLine(u.ToString());
            }

            sw.Close();
        }

        public static void loadArtist()
        {
            artists.Clear();
            StreamReader sr = new StreamReader("artists.csv");

            while (!sr.EndOfStream)
            {
                string[] datas = sr.ReadLine().Split(';');
                artists.Add(new Artist(datas[0], datas[1], datas[2], datas[3], int.Parse(datas[4]), DateTime.Parse(datas[5]), DateTime.Parse(datas[6])));
            }

            sr.Close();
        }

        public static void saveArtist()
        {
            StreamWriter sw = new StreamWriter("artists.csv", false);

            foreach (Artist a in artists)
            {
                sw.WriteLine(a.ToString());
            }

            sw.Close();
        }

        public static void placeWindow(Window window)
        {

        }

        public static void loadTeams()
        {
            teams.Clear();
            StreamReader sr = new StreamReader("teams.csv");

            while (!sr.EndOfStream)
            {
                string[] datas = sr.ReadLine().Split(';');
                teams.Add(new Team(datas[0], datas[1], datas[2], datas[3], datas[4], int.Parse(datas[5]), bool.Parse(datas[6]), datas[8], bool.Parse(datas[7]), int.Parse(datas[9])));
            }

            sr.Close();
        }

        public static void saveTeams()
        {
            StreamWriter sw = new StreamWriter("teams.csv", false);

            foreach (Team t in teams)
                sw.WriteLine(t.ToString());

            sw.Close();
        }

        public static void loadPrices()
        {
            StreamReader sr = new StreamReader("prices.csv");

            string[] datas = sr.ReadLine().Split(';');

            adultPrice = int.Parse(datas[0]);
            childrenPrice = int.Parse(datas[1]);
            taseTicketPrice = int.Parse(datas[2]);
            rafflePrice = int.Parse(datas[3]);

            PDFpath = sr.ReadLine();

            sr.Close();
        }

        public static void savePrices()
        {
            StreamWriter sr = new StreamWriter("prices.csv", false);

            sr.WriteLine(string.Format("{0};{1};{2};{3}", adultPrice, childrenPrice, taseTicketPrice, rafflePrice));
            sr.WriteLine(PDFpath);

            sr.Close();
        }

        public static void loadGuests()
        {
            try
            {
                StreamReader sr = new StreamReader("guests.csv");

                while (!sr.EndOfStream)
                {
                    string[] datas = sr.ReadLine().Split(';');
                    Misc.guests.Add(new Guest(datas[0], datas[1], datas[2], bool.Parse(datas[3])));
                }

                sr.Close();
            }
            catch (FileNotFoundException)
            { MessageBox.Show("Nem találom a vendégeket tartalmazó fájlt!"); }
        }

        public static void saveGuests()
        {
            StreamWriter sw = new StreamWriter("guests.csv", false);

            foreach (Guest g in guests)
            {
                sw.WriteLine(g.ToString());
            }

            sw.Close();
        }

        public static void logging(string message)
        {
            StreamWriter sw = new StreamWriter("log.txt", true);

            sw.WriteLine(string.Format("{0}\t{1}", DateTime.Now.ToString("yyyy-mm-dd hh:mm"), message));

            sw.Close();
        }

        public static void createEntryPermit(string palteNum)
        {
            try
            {
                Font yearFont = FontFactory.GetFont("Arial", 50);
                Font plateFont = FontFactory.GetFont("Arial", 125, Font.BOLD);

                Document doc = new Document();
                doc.SetPageSize(PageSize.A4.Rotate());
                string filename = string.Format(@"{0}\{1}.pdf", PDFpath, palteNum);
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
                //plateTable.PaddingTop = PageSize.A4.Width / (float)1.5;
                plateTable.PaddingTop = PageSize.A4.Width / calculatePadding(palteNum);
                plateFont.Size = calculateFontSize(palteNum);

                PdfPCell plateNum = new PdfPCell(new Phrase(palteNum, plateFont));
                plateNum.Border = PdfPCell.NO_BORDER;
                plateNum.HorizontalAlignment = PdfPCell.ALIGN_CENTER;

                plateTable.AddCell(plateNum);
                doc.Add(plateTable);

                doc.Close();
                writer.Close();
                MessageBox.Show(string.Format("PDF készítése sikeres!{0}Elmenteve a {1} mappába", Environment.NewLine, Misc.PDFpath));
                //System.Diagnostics.Process.Start(filename);
            }
            catch (FieldAccessException)
            {
                MessageBox.Show("");
            }

        }

        private static float calculatePadding(string text)
        {

            int multiplier = 1, calc = 0;

            while (calc < text.Length)
            {
                multiplier++;
                calc += 8;
            }

            return ((float)(multiplier + 1) / multiplier);
        }

        private static float calculateFontSize(string text)
        {
            int size = 125, calc = 0;

            while (calc < text.Length)
            {
                size -= 20;
                calc += 8;
            }

            return size;
        }
        public static string CalculateMD5(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}