using System;
using SQLite;

namespace PaperHangMan
{
    public class ListONames
    {
        [PrimaryKey, AutoIncrement]
        public int Word_ID { get; set; }
        public string Word { get; set; }

        public ListONames()
        {
        }
    }
}