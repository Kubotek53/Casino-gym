using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Casino_gym
{
    public partial class UserManagement : Form
    {
        public UserManagement()
        {
            InitializeComponent();
        }

        private void UserManagement_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                Database db = new Database();
                db.OpenConnection();

                string query = "SELECT id, username, role FROM users";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, db.GetConnection());
                DataTable table = new DataTable();
                adapter.Fill(table);

                dataGridViewUsers.DataSource = table;

                db.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd wczytywania użytkowników: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Wybierz użytkownika do usunięcia.");
                return;
            }

            int id = Convert.ToInt32(dataGridViewUsers.SelectedRows[0].Cells["id"].Value);

            try
            {
                Database db = new Database();
                db.OpenConnection();

                string query = "DELETE FROM users WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(query, db.GetConnection());
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

                db.CloseConnection();
                MessageBox.Show("Użytkownik usunięty.");
                LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd usuwania: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddUser addForm = new AddUser();
            addForm.ShowDialog();
            LoadUsers();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MainPage().Show();
        }
    }
}
