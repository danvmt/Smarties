using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using System.Net.Http;

namespace Smarties
{
    public class RoomDatabase
    {

        static SQLiteAsyncConnection dbConnection;

        public RoomDatabase(string dbPath)
        {
            dbConnection = new SQLiteAsyncConnection(dbPath);
            dbConnection.CreateTableAsync<Room>().Wait();
        }

        public Task<List<Room>> GetItemsAsync()
        {
            return dbConnection.Table<Room>().ToListAsync();
        }

        public async Task<List<Room>> GetByNameAsync(string roomName)
        {
            //return dbConnection.Table<Room>().Where(i => i.RoomName == roomName).FirstOrDefaultAsync();
            var roomID = await dbConnection.QueryAsync<Room>(
            "select * from Room where RoomName = ?", roomName);
            return roomID;
        }

        public Task<Room> GetByIdAsync(int id)
        {
            return dbConnection.Table<Room>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Room item)
        {
            if (item.ID != 0)
            {
                return dbConnection.UpdateAsync(item);
            }
            else
            {
                return dbConnection.InsertAsync(item);
            }
        }

        //public async Task<int> AlterTableAsync(string colNew)
        //{

        //    return dbConnection.QueryAsync<Room>(
        //        "ALTER TABLE Room ADD COLUMN ? CHAR", colNew);
        //}

        public Task<int> DeleteItemAsync(Room item)
        {
            return dbConnection.DeleteAsync(item);
        }

        public Task<int> DropTable()
        {
            return dbConnection.DropTableAsync<Room>();
        }
    }
}
