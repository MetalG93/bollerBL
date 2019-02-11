using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using fastJSON;

namespace bollerBL
{
    static class Misc
    {
        public static List<User> users = new List<User>();
        public static List<Artist> artists = new List<Artist>();
        public static List<Team> teams = new List<Team>();

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
                teams.Add(new Team(datas[0], datas[1], datas[2], datas[3], datas[4], int.Parse(datas[5]), bool.Parse(datas[6]), int.Parse(datas[7])));
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
