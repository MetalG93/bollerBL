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
    }
}
