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
        public static string PDFpath=@"D:\";

        public static int adultPrice = 600;
        public static int childrenPrice = 400;

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
            /*StreamReader sr = new StreamReader("");

            while (!sr.EndOfStream)
            {

            }

            sr.Close();*/
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
                teams.Add(new Team(int.Parse(datas[0]), datas[1], datas[2], datas[3], datas[4], datas[5], int.Parse(datas[6]), bool.Parse(datas[7]), datas[9],bool.Parse(datas[8])));
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
    }
}
