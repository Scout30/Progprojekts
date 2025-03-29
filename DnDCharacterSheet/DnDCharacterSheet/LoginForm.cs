namespace DnDCharacterSheet
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                VissSlikti();
                return;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                VissSlikti();
                return;
            }

            var user = DatuBāze.DabūtDbInstanci.GetUser(txtUsername.Text);
            if (user == null)
            {
                VissSlikti();
                return;
            }

            var parolesMD5 = DatuBāze.ParolesSakriptēšana(txtPassword.Text, user.UserId);
            if (parolesMD5 != user.Password)
            {
                VissSlikti();
                return;
            }
            Program.UserId = user.UserId;
            Program.IsAdmin = user.IsAdmin;

            this.Close();
        }

        private void VissSlikti()
        {

            MessageBox.Show("Nepareiz lietotāja vārds vai parole",
                "Neizdevās pieslēgties sistēmai",
                MessageBoxButtons.OK);

            btnLogin.Enabled = false;
            var timer = new System.Threading.Timer(new TimerCallback(timersPogasIeslegsanai), null, 10000, 0);

        }
        private void timersPogasIeslegsanai(object state)
        {
            Invoke(new Action(() =>
            {
                btnLogin.Enabled = true;
            }));
        }
      

        private void btnCreateNewAccount_Click(object sender, EventArgs e)
        {
            using(var account= new CreateAccount())
            {
                account.ShowDialog();
            }
        }
    }
}
