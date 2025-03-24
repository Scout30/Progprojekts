namespace DnD_character_sheet
{
    partial class Form2
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
            label1 = new Label();
            txtCharacterName = new TextBox();
            txtClass = new TextBox();
            label2 = new Label();
            label3 = new Label();
            numLevel = new NumericUpDown();
            btnSaveCharacter = new Button();
            lstAbilities = new ListBox();
            ((System.ComponentModel.ISupportInitialize)numLevel).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 21);
            label1.Name = "label1";
            label1.Size = new Size(116, 20);
            label1.TabIndex = 0;
            label1.Text = "Character Name";
            // 
            // txtCharacterName
            // 
            txtCharacterName.Location = new Point(25, 44);
            txtCharacterName.Name = "txtCharacterName";
            txtCharacterName.Size = new Size(125, 27);
            txtCharacterName.TabIndex = 1;
            // 
            // txtClass
            // 
            txtClass.Location = new Point(25, 97);
            txtClass.Name = "txtClass";
            txtClass.Size = new Size(125, 27);
            txtClass.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 74);
            label2.Name = "label2";
            label2.Size = new Size(42, 20);
            label2.TabIndex = 3;
            label2.Text = "Class";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 127);
            label3.Name = "label3";
            label3.Size = new Size(43, 20);
            label3.TabIndex = 4;
            label3.Text = "Level";
            // 
            // numLevel
            // 
            numLevel.Location = new Point(25, 150);
            numLevel.Name = "numLevel";
            numLevel.Size = new Size(150, 27);
            numLevel.TabIndex = 5;
            // 
            // btnSaveCharacter
            // 
            btnSaveCharacter.Location = new Point(25, 207);
            btnSaveCharacter.Name = "btnSaveCharacter";
            btnSaveCharacter.Size = new Size(94, 52);
            btnSaveCharacter.TabIndex = 6;
            btnSaveCharacter.Text = "Save Character";
            btnSaveCharacter.UseVisualStyleBackColor = true;
            // 
            // lstAbilities
            // 
            lstAbilities.FormattingEnabled = true;
            lstAbilities.Location = new Point(237, 43);
            lstAbilities.Name = "lstAbilities";
            lstAbilities.Size = new Size(212, 144);
            lstAbilities.TabIndex = 7;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lstAbilities);
            Controls.Add(btnSaveCharacter);
            Controls.Add(numLevel);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtClass);
            Controls.Add(txtCharacterName);
            Controls.Add(label1);
            Name = "Form2";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)numLevel).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtCharacterName;
        private TextBox txtClass;
        private Label label2;
        private Label label3;
        private NumericUpDown numLevel;
        private Button btnSaveCharacter;
        private ListBox lstAbilities;
    }
}