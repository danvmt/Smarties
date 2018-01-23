using System;
using SQLite;

namespace Smarties
{
    public class Room
    {
        //public Room()
        //{
        //}

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string RoomName { get; set; }
        public string Beacon { get; set; }
        public string Hue { get; set; }
        //public string Image { get; set; }

    }
}
