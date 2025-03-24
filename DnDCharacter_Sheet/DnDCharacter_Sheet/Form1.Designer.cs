namespace DnDCharacterSheet
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label lblStatus;

        private void InitializeComponent()
        {
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();


            // lblStatus
            this.lblStatus.Location = new System.Drawing.Point(50, 120);
            this.lblStatus.Size = new System.Drawing.Size(200, 30);
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
        }
    }
}
