using System;
using System.IO;
using System.Collections.Generic;

namespace PaperHangMan
{
    public class DatabaseManager
    {
        static string dbName = "dbHangman.sqlite";
        string dbPath = System.IO.Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), dbName);

        public DatabaseManager()
        {

        }
        public List<ListONames> ViewAllWords()
        {
            try
            {
                using (var conn = new SQLite.SQLiteConnection(dbPath))
                {
                    var cmd = new SQLite.SQLiteCommand(conn);
                    cmd.CommandText = "Select * from tbl_Words";
                    var WordList = cmd.ExecuteQuery<ListONames>();
                    return WordList;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error:" + e.Message);
                return null;
            }
        }
        public void AddLeaderboard(string name, int score, int letters)
        {
            try
            {
                using (var conn = new SQLite.SQLiteConnection(dbPath))
                {
                    var cmd = new SQLite.SQLiteCommand(conn);
                    cmd.CommandText = "insert into tblHangmanLeaderboard(HangName,HangScore, HangLetterAmt) values('" + name + "','" + score + "','" + letters + "')";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error:" + e.Message);
            }
        }
        public List<ListOScores> ViewLeaderboard()
        {
            try
            {
                using (var conn = new SQLite.SQLiteConnection(dbPath))
                {
                    var cmd = new SQLite.SQLiteCommand(conn);
                    cmd.CommandText = "Select * from tblHangmanLeaderboard ORDER BY HangScore DESC;";
                    var LeaderboardList = cmd.ExecuteQuery<ListOScores>();
                    return LeaderboardList;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error:" + e.Message);
                return null;
            }
        }
    }
}