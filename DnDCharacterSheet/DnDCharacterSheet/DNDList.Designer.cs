namespace DnDCharacterSheet
{
    partial class DNDList
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            SarakstaTabula = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            userNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            characterRaceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            editDateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dNDListRowBindingSource = new BindingSource(components);
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            buttonAddDnd = new Button();
            tabPage2 = new TabPage();
            dataGridView1 = new DataGridView();
            userIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            userNameDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            IsAdmin = new DataGridViewCheckBoxColumn();
            Password = new DataGridViewButtonColumn();
            systemUsersBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)SarakstaTabula).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dNDListRowBindingSource).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)systemUsersBindingSource).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 15);
            label1.Name = "label1";
            label1.Size = new Size(121, 15);
            label1.TabIndex = 0;
            label1.Text = "Dungeons && Dragons";
            // 
            // SarakstaTabula
            // 
            SarakstaTabula.AllowUserToAddRows = false;
            SarakstaTabula.AllowUserToDeleteRows = false;
            SarakstaTabula.AllowUserToOrderColumns = true;
            SarakstaTabula.AllowUserToResizeRows = false;
            SarakstaTabula.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SarakstaTabula.AutoGenerateColumns = false;
            SarakstaTabula.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SarakstaTabula.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, userNameDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn, characterRaceDataGridViewTextBoxColumn, editDateDataGridViewTextBoxColumn });
            SarakstaTabula.DataSource = dNDListRowBindingSource;
            SarakstaTabula.Location = new Point(15, 42);
            SarakstaTabula.Name = "SarakstaTabula";
            SarakstaTabula.Size = new Size(896, 458);
            SarakstaTabula.TabIndex = 1;
            SarakstaTabula.CellContentClick += dataGridView1_CellContentClick;
            SarakstaTabula.CellDoubleClick += dataGridView1_CellContentClick;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.Visible = false;
            // 
            // userNameDataGridViewTextBoxColumn
            // 
            userNameDataGridViewTextBoxColumn.DataPropertyName = "UserName";
            userNameDataGridViewTextBoxColumn.HeaderText = "User name";
            userNameDataGridViewTextBoxColumn.Name = "userNameDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "Character name";
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.Width = 300;
            // 
            // characterRaceDataGridViewTextBoxColumn
            // 
            characterRaceDataGridViewTextBoxColumn.DataPropertyName = "CharacterRace";
            characterRaceDataGridViewTextBoxColumn.HeaderText = "Character race";
            characterRaceDataGridViewTextBoxColumn.Name = "characterRaceDataGridViewTextBoxColumn";
            characterRaceDataGridViewTextBoxColumn.Width = 300;
            // 
            // editDateDataGridViewTextBoxColumn
            // 
            editDateDataGridViewTextBoxColumn.DataPropertyName = "EditDate";
            editDateDataGridViewTextBoxColumn.HeaderText = "Edit date";
            editDateDataGridViewTextBoxColumn.Name = "editDateDataGridViewTextBoxColumn";
            // 
            // dNDListRowBindingSource
            // 
            dNDListRowBindingSource.DataSource = typeof(DNDListRow);
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(925, 534);
            tabControl1.TabIndex = 2;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(buttonAddDnd);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(SarakstaTabula);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(917, 506);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "D&&D";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonAddDnd
            // 
            buttonAddDnd.Location = new Point(195, 13);
            buttonAddDnd.Name = "buttonAddDnd";
            buttonAddDnd.Size = new Size(135, 23);
            buttonAddDnd.TabIndex = 2;
            buttonAddDnd.Text = "Add DND sheet";
            buttonAddDnd.UseVisualStyleBackColor = true;
            buttonAddDnd.Click += buttonAddDnd_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dataGridView1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(917, 506);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Users";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { userIdDataGridViewTextBoxColumn, userNameDataGridViewTextBoxColumn1, IsAdmin, Password });
            dataGridView1.DataSource = systemUsersBindingSource;
            dataGridView1.Location = new Point(6, 6);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(905, 494);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick_1;
            dataGridView1.CellValidated += dataGridView1_CellValidated;
            // 
            // userIdDataGridViewTextBoxColumn
            // 
            userIdDataGridViewTextBoxColumn.DataPropertyName = "UserId";
            userIdDataGridViewTextBoxColumn.HeaderText = "ID";
            userIdDataGridViewTextBoxColumn.Name = "userIdDataGridViewTextBoxColumn";
            userIdDataGridViewTextBoxColumn.ReadOnly = true;
            userIdDataGridViewTextBoxColumn.Width = 76;
            // 
            // userNameDataGridViewTextBoxColumn1
            // 
            userNameDataGridViewTextBoxColumn1.DataPropertyName = "UserName";
            userNameDataGridViewTextBoxColumn1.HeaderText = "User name";
            userNameDataGridViewTextBoxColumn1.Name = "userNameDataGridViewTextBoxColumn1";
            userNameDataGridViewTextBoxColumn1.ReadOnly = true;
            userNameDataGridViewTextBoxColumn1.Width = 150;
            // 
            // IsAdmin
            // 
            IsAdmin.DataPropertyName = "IsAdmin";
            IsAdmin.HeaderText = "Administrator";
            IsAdmin.Name = "IsAdmin";
            // 
            // Password
            // 
            Password.DataPropertyName = "Password";
            Password.HeaderText = "Password";
            Password.Name = "Password";
            Password.Text = "Change Password";
            Password.UseColumnTextForButtonValue = true;
            Password.Width = 150;
            // 
            // systemUsersBindingSource
            // 
            systemUsersBindingSource.DataSource = typeof(SystemUsers);
            // 
            // DNDList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(949, 558);
            Controls.Add(tabControl1);
            Name = "DNDList";
            Text = "DND entry list";
            Load += DNDList_Load;
            ((System.ComponentModel.ISupportInitialize)SarakstaTabula).EndInit();
            ((System.ComponentModel.ISupportInitialize)dNDListRowBindingSource).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)systemUsersBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private DataGridView SarakstaTabula;
        private BindingSource dNDListRowBindingSource;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn characterRaceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn editDateDataGridViewTextBoxColumn;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DataGridView dataGridView1;
        private BindingSource systemUsersBindingSource;
        private DataGridViewCheckBoxColumn isAdminDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn userIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn1;
        private DataGridViewCheckBoxColumn IsAdmin;
        private DataGridViewButtonColumn Password;
        private Button buttonAddDnd;

        

    }
}