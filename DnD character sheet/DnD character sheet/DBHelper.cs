using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Data.SQLite;
using System.IO;

namespace DnDCharacterSheetApp
{
    public static class DBHelper
    {
        public static string dbFile = "DnDCharacters.db";
        public static string connectionString = $"Data Source={dbFile};Version=3;";

        public static void InitializeDatabase()
        {
            if (!File.Exists(dbFile))
            {
                SQLiteConnection.CreateFile(dbFile);
            }

            using (var con = new SQLiteConnection(connectionString))
            {
                con.Open();
                // Izveido Users tabulu
                string sqlUsers = @"CREATE TABLE IF NOT EXISTS Users (
                    UserID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Username TEXT NOT NULL UNIQUE,
                    PasswordHash TEXT NOT NULL
                );";
                SQLiteCommand cmdUsers = new SQLiteCommand(sqlUsers, con);
                cmdUsers.ExecuteNonQuery();

                // Izveido Characters tabulu ar ārējo atslēgu uz Users tabulu
                string sqlCharacters = @"CREATE TABLE IF NOT EXISTS Characters (
                    CharacterID INTEGER PRIMARY KEY AUTOINCREMENT,
                    UserID INTEGER NOT NULL,
                    Name TEXT NOT NULL,
                    Class TEXT,
                    Level INTEGER,
                    FOREIGN KEY(UserID) REFERENCES Users(UserID)
                );";
                SQLiteCommand cmdCharacters = new SQLiteCommand(sqlCharacters, con);
                cmdCharacters.ExecuteNonQuery();

                con.Close();
            }
        }
    }
}

