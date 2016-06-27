using System;
using SQLite;

namespace PaperHangMan
{
    public class ListOScores
    {
        [PrimaryKey, AutoIncrement]
        public string HangName { get; set; }
        public double HangScore { get; set; }
        public int HangLetterAmt { get; set; }

        public ListOScores()
        {
        }
    }
}