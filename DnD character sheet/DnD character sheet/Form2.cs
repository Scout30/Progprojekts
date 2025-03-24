using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Formats.Asn1;

namespace DnD_Character_sheet
{
    public partial class Form2 : Form
    {
        private int userId;
        // Dictionary datu struktūra rakstura spējībām – atbilst prasībai par datu struktūru izmantošanu
        private Dictionary<string, int> abilities = new Dictionary<string, int>();

        public Form2(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            InitializeAbilities();
            LoadCharacterData();
        }

        // Inicializē spējības un parāda tās ListBox kontrolē
        private void InitializeAbilities()
        {
            abilities["Strength"] = 10;
            abilities["Dexterity"] = 10;
            abilities["Constitution"] = 10;
            abilities["Intelligence"] = 10;
            abilities["Wisdom"] = 10;
            abilities["Charisma"] = 10;

            lstAbilities.Items.Clear();
            foreach (var ability in abilities)
            {
                lstAbilities.Items.Add($"{ability.Key}: {ability.Value}");
            }
        }

        // Ielādē rakstura datus no datu bāzes (šajā piemērā ielādējam pirmo raksturu, ja tas eksistē)
        private void LoadCharacterData()
        {
            using (SQLiteConnection con = new SQLiteConnection(DBHelper.connectionString))
            {
                con.Open();
                string query = "SELECT CharacterID, Name, Class, Level FROM Characters WHERE UserID = @userId LIMIT 1";
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                cmd.Parameters.AddWithValue("@userId", userId);
                SQLiteDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtCharacterName.Text = reader["Name"].ToString();
                    txtClass.Text = reader["Class"].ToString();
                    numLevel.Value = Convert.ToInt32(reader["Level"]);
                }
                con.Close();
            }
        }

        // Saglabā rakstura datus datu bāzē
        private void btnSaveCharacter_Click(object sender, EventArgs e)
        {
            string characterName = txtCharacterName.Text.Trim();
            string characterClass = txtClass.Text.Trim();
            int level = (int)numLevel.Value;

            using (SQLiteConnection con = new SQLiteConnection(DBHelper.connectionString))
            {
                con.Open();
                // Pārbauda, vai raksturs jau eksistē lietotājam
                string queryCheck = "SELECT CharacterID FROM Characters WHERE UserID = @userId";
                SQLiteCommand cmdCheck = new SQLiteCommand(queryCheck, con);
                cmdCheck.Parameters.AddWithValue("@userId", userId);
                var result = cmdCheck.ExecuteScalar();

                if (result != null)
                {
                    // Ja raksturs eksistē – atjauno datus
                    int characterId = Convert.ToInt32(result);
                    string queryUpdate = "UPDATE Characters SET Name = @name, Class = @class, Level = @level WHERE CharacterID = @characterId";
                    SQLiteCommand cmdUpdate = new SQLiteCommand(queryUpdate, con);
                    cmdUpdate.Parameters.AddWithValue("@name", characterName);
                    cmdUpdate.Parameters.AddWithValue("@class", characterClass);
                    cmdUpdate.Parameters.AddWithValue("@level", level);
                    cmdUpdate.Parameters.AddWithValue("@characterId", characterId);
                    cmdUpdate.ExecuteNonQuery();
                }
                else
                {
                    // Ja raksturs vēl nepastāv – ievieto jaunu ierakstu
                    string queryInsert = "INSERT INTO Characters (UserID, Name, Class, Level) VALUES (@userId, @name, @class, @level)";
                    SQLiteCommand cmdInsert = new SQLiteCommand(queryInsert, con);
                    cmdInsert.Parameters.AddWithValue("@userId", userId);
                    cmdInsert.Parameters.AddWithValue("@name", characterName);
                    cmdInsert.Parameters.AddWithValue("@class", characterClass);
                    cmdInsert.Parameters.AddWithValue("@level", level);
                    cmdInsert.ExecuteNonQuery();
                }
                con.Close();
                MessageBox.Show("Raksturs saglabāts veiksmīgi!");
            }
        }
    }
}
