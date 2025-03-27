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
            ((System.ComponentModel.ISupportInitialize)SarakstaTabula).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dNDListRowBindingSource).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(121, 15);
            label1.TabIndex = 0;
            label1.Text = "Dungeons && Dragons";
            // 
            // SarakstaTabula
            // 
            SarakstaTabula.AllowUserToOrderColumns = true;
            SarakstaTabula.AllowUserToResizeRows = false;
            SarakstaTabula.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SarakstaTabula.AutoGenerateColumns = false;
            SarakstaTabula.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SarakstaTabula.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, userNameDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn, characterRaceDataGridViewTextBoxColumn, editDateDataGridViewTextBoxColumn });
            SarakstaTabula.DataSource = dNDListRowBindingSource;
            SarakstaTabula.Location = new Point(12, 37);
            SarakstaTabula.Name = "SarakstaTabula";
            SarakstaTabula.Size = new Size(915, 459);
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
            // DNDList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(949, 558);
            Controls.Add(SarakstaTabula);
            Controls.Add(label1);
            Name = "DNDList";
            Text = "DND entry list";
            Load += DNDList_Load;
            ((System.ComponentModel.ISupportInitialize)SarakstaTabula).EndInit();
            ((System.ComponentModel.ISupportInitialize)dNDListRowBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
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

        public List<DNDListRow> ListData { get; set; }

    }
}