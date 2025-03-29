using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DnDCharacterSheet
{
    public partial class EditPassword : Form
    {
        public EditPassword()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSawe_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(tbPassword1.Text))
            {
                MessageBox.Show("Username is required!");
                return;
            }
            if (string.IsNullOrEmpty(tbPassword2.Text))
            {
                MessageBox.Show("Password is required!");
                return;
            }

            if (tbPassword1.Text != tbPassword2.Text)
            {
                MessageBox.Show("Password not maching!");
                return;
            }

         
            DatuBāze.DabūtDbInstanci.UserPasswordEdit(UserId, tbPassword1.Text);
           
            MessageBox.Show("User password changed!");

            this.Close();
        }

        public int UserId { get; set; }

    }
}
