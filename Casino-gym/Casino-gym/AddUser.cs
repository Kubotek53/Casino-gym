using System;
using System.Windows.Forms;

namespace Casino_gym
{
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            string username = textboxUsername.Text.Trim();
            string password = textboxPassword.Text.Trim();
            string role = comboRole.SelectedItem?.ToString() ?? "";

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(role))
            {
                MessageBox.Show("Wypełnij wszystkie pola!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // TODO: tu dodaj kod zapisujący użytkownika do bazy
            MessageBox.Show($"Użytkownik '{username}' o roli '{role}' został dodany!", "Sukces",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
