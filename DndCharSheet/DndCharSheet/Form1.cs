using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json; // API datu parsçðanai

namespace DnDCharacterSheet
{
    public partial class MainForm : Form
    {
        private SQLiteConnection connection;
        private List<Character> characters = new List<Character>(); // Datu struktûra

        public MainForm()
        {
            InitializeComponent();
            InitializeDatabase();
            LoadCharacters();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void InitializeDatabase()
        {
            connection = new SQLiteConnection("Data Source=characters.db");
            connection.Open();

            string createUsers = "CREATE TABLE IF NOT EXISTS Users (Id INTEGER PRIMARY KEY, Username TEXT, PasswordHash TEXT)";
            string createCharacters = "CREATE TABLE IF NOT EXISTS Characters (Id INTEGER PRIMARY KEY, Name TEXT, Class TEXT, Level INTEGER, UserId INTEGER, FOREIGN KEY(UserId) REFERENCES Users(Id))";
            string createStats = "CREATE TABLE IF NOT EXISTS Stats (Id INTEGER PRIMARY KEY, CharacterId INTEGER, Strength INTEGER, Dexterity INTEGER, Constitution INTEGER, FOREIGN KEY(CharacterId) REFERENCES Characters(Id))";

            using (var cmd = new SQLiteCommand(createUsers, connection)) cmd.ExecuteNonQuery();
            using (var cmd = new SQLiteCommand(createCharacters, connection)) cmd.ExecuteNonQuery();
            using (var cmd = new SQLiteCommand(createStats, connection)) cmd.ExecuteNonQuery();
        }

        private void LoadCharacters()
        {
            characters.Clear();
            string query = "SELECT * FROM Characters";
            using (var cmd = new SQLiteCommand(query, connection))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    characters.Add(new Character
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Class = reader.GetString(2),
                        Level = reader.GetInt32(3)
                    });
                }
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        private async void FetchClassInfoFromAPI(string className)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync($"https://www.dnd5eapi.co/api/classes/{className.ToLower()}");
                var classInfo = JsonConvert.DeserializeObject<dynamic>(response);
                MessageBox.Show($"Hit Die: {classInfo.hit_die}");
            }
        }
    }

    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public int Level { get; set; }
    }
}

