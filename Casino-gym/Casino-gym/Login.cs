using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Casino_gym
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Powrót_Click(object sender, EventArgs e)
        {
            MainPage f1 = new MainPage();
            f1.Show();
            this.Hide();
        }
    }
}
