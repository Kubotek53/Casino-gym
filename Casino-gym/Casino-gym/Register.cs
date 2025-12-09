using System;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;
using System.Data.SQLite;

namespace Casino_gym
{
    public partial class Register : Form
    {
        Database db = new Database();

        public Register()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = textboxUsername.Text.Trim().ToLower();
            string password = textboxPassword.Text.Trim();
            string ageText = textboxAge.Text.Trim();

            // Sprawdzenie poprawności danych
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(ageText))
            {
                MessageBox.Show("Proszę wypełnić wszystkie pola.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(ageText, System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture, out int age))
            {
                 MessageBox.Show($"Wiek musi być liczbą. Wpisano: '{ageText}'", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 return;
            }

            if (age < 18)
            {
                MessageBox.Show("Musisz miec 18 lat by zagrac", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hashowanie hasła
            string hashedPassword = GetSHA256(password);

            try
            {
                db.OpenConnection();
                SQLiteConnection conn = db.GetConnection();

                // 1️⃣ Sprawdzenie, czy użytkownik już istnieje
                using (var checkCmd = new SQLiteCommand("SELECT COUNT(*) FROM users WHERE LOWER(username)=@username", conn))
                {
                    checkCmd.Parameters.AddWithValue("@username", username);
                    int userExists = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (userExists > 0)
                    {
                        MessageBox.Show("Ten użytkownik już istnieje. Wybierz inny login.",
                            "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // 2️⃣ Dodanie użytkownika (domyślna rola = "Użytkownik")
                using (var insertCmd = new SQLiteCommand(
                    "INSERT INTO users (username, password, role, balance, age) VALUES (@username, @password, @role, 100, @age)", conn))
                {
                    insertCmd.Parameters.AddWithValue("@username", username);
                    insertCmd.Parameters.AddWithValue("@password", hashedPassword);
                    insertCmd.Parameters.AddWithValue("@role", "Użytkownik");
                    insertCmd.Parameters.AddWithValue("@age", age);

                    int rowsAffected = insertCmd.ExecuteNonQuery();

                    if (rowsAffected == 1)
                    {
                        MessageBox.Show("Rejestracja zakończona pomyślnie!", "Sukces",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        new Login().Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Nie udało się utworzyć konta. Spróbuj ponownie.",
                            "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                db.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd bazy danych: " + ex.Message,
                    "SQLite Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Close();
        }

        // Hashowanie SHA256
        private static string GetSHA256(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder sb = new StringBuilder();

                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2"));

                return sb.ToString();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}
