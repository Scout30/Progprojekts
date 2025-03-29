namespace DnDCharacterSheet
{
    partial class EditPassword
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tbPassword1 = new TextBox();
            tbPassword2 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            buttonSawe = new Button();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // tbPassword1
            // 
            tbPassword1.Location = new Point(132, 36);
            tbPassword1.Name = "tbPassword1";
            tbPassword1.PasswordChar = '*';
            tbPassword1.Size = new Size(143, 23);
            tbPassword1.TabIndex = 0;
            // 
            // tbPassword2
            // 
            tbPassword2.Location = new Point(132, 84);
            tbPassword2.Name = "tbPassword2";
            tbPassword2.PasswordChar = '*';
            tbPassword2.Size = new Size(143, 23);
            tbPassword2.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 39);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 2;
            label1.Text = "Password:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 87);
            label2.Name = "label2";
            label2.Size = new Size(102, 15);
            label2.TabIndex = 3;
            label2.Text = "Repeat password :";
            // 
            // buttonSawe
            // 
            buttonSawe.Location = new Point(42, 170);
            buttonSawe.Name = "buttonSawe";
            buttonSawe.Size = new Size(75, 23);
            buttonSawe.TabIndex = 4;
            buttonSawe.Text = "Save";
            buttonSawe.UseVisualStyleBackColor = true;
            buttonSawe.Click += buttonSawe_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(200, 170);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 5;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // EditPassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(310, 260);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSawe);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tbPassword2);
            Controls.Add(tbPassword1);
            Name = "EditPassword";
            Text = "Edit password";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbPassword1;
        private TextBox tbPassword2;
        private Label label1;
        private Label label2;
        private Button buttonSawe;
        private Button buttonCancel;
    }
}