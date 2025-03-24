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
using System.Security.Cryptography;
using DnD_character_sheet;

namespace DnD_Character_sheet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Metode paroles hashēšanai, izmantojot SHA256
        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // Poga "Pierakstīties" – notikuma apstrāde
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string passwordHash = HashPassword(password);

            using (SQLiteConnection con = new SQLiteConnection(DBHelper.connectionString))
            {
                con.Open();
                string query = "SELECT UserID FROM Users WHERE Username = @username AND PasswordHash = @passwordHash";
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@passwordHash", passwordHash);
                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                    // Pierakstīšanās veiksmīga – atver rakstura logu
                    int userId = Convert.ToInt32(result);
                    MessageBox.Show("Login veiksmīgs!");
                    Form2 characterForm = new Form2(userId);
                    characterForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Nepareizs lietotājvārds vai parole!");
                }
                con.Close();
            }
        }

        // Poga "Izveidot kontu" – notikuma apstrāde
        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string passwordHash = HashPassword(password);

            using (SQLiteConnection con = new SQLiteConnection(DBHelper.connectionString))
            {
                con.Open();
                string query = "INSERT INTO Users (Username, PasswordHash) VALUES (@username, @passwordHash)";
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@passwordHash", passwordHash);
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Konts izveidots veiksmīgi! Tagad varat pierakstīties.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kļūda: " + ex.Message);
                }
                con.Close();
            }
        }
    }
}
