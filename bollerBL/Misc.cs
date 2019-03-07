using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using fastJSON;
using System.Collections.ObjectModel;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace bollerBL
{
    static class Misc
    {
        public static List<User> users = new List<User>();
        public static List<Artist> artists = new List<Artist>();
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

        public static void loadArtist()
        {
            StreamReader sr = new StreamReader("artists.csv");

            while (!sr.EndOfStream)
            {
                string[] datas = sr.ReadLine().Split(';');
                artists.Add(new Artist(datas[0], datas[1], datas[2], int.Parse(datas[3]), DateTime.Parse(datas[4]), DateTime.Parse(datas[5])));
            }

            sr.Close();
        }

        public static void saveArtist()
        { }

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
                teams.Add(new Team(datas[0], datas[1], datas[2], datas[3], datas[4], int.Parse(datas[5]), bool.Parse(datas[6]), datas[7], bool.Parse(datas[9]), int.Parse(datas[8])));
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

            sr.Close();

            adultPrice = int.Parse(datas[0]);
            childrenPrice = int.Parse(datas[1]);
            taseTicketPrice = int.Parse(datas[2]);
            rafflePrice = int.Parse(datas[3]);
        }

        public static void savePrices()
        {
            StreamWriter sr = new StreamWriter("prices.csv", false);

            sr.WriteLine(string.Format("{0};{1};{2};{3}", adultPrice, childrenPrice, taseTicketPrice, rafflePrice));

            sr.Close();
        }
    }
}