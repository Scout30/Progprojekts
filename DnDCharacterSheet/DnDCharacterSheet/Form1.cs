using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DnDCharacterSheet
{
    public partial class CharacterSheet : Form
    {
        public CharacterSheet()
        {
            InitializeComponent();
            SavingThrows.Items.Clear();
            foreach (var x in Enum.GetNames(typeof(SavingThrowChoises)))
            {
                SavingThrows.Items.Add(x);
            }

            Skills.Items.Clear();
            foreach (var x in Enum.GetNames(typeof(SkillChoises)))
            {
                Skills.Items.Add(x);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //SavingThrows.CheckedItems;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }



        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown12_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void CharacterSheet_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDown20_ValueChanged(object sender, EventArgs e)
        {

        }



        public void UzstādaDatus(DNDModelForBinding dati)
        {
            bindingSourceDND.DataSource = typeof(DNDModelForBinding);
            bindingSourceDND.Add(dati);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var dati = bindingSourceDND.Current as DNDModelForBinding;
            if (dati != null)
            {

                DatuBāze.DabūtDbInstanci.SaglabātDNDIerakstu(Program.UserId ?? 1, dati);
                MessageBox.Show("Data saved!");
                SarakstaForma.IelasītDatus();
                this.Close();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var dati = bindingSourceDND.Current as DNDModelForBinding;
            if (dati == null || dati.Id == 0)
            {
                this.Close();
                return;
            }
            if (MessageBox.Show("Are you sure to delete this record?", "Data deletion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DatuBāze.DabūtDbInstanci.DzēstDNDIerakstu(dati.Id);
                SarakstaForma.IelasītDatus();
            }
            this.Close();
        }

        private void buttonClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SavingThrows_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var dati = bindingSourceDND.Current as DNDModelForBinding;
            if (dati == null)
            {
                return;
            }
            foreach (var x in Enum.GetValues(typeof(SavingThrowChoises)))
            {
                var xText = Enum.GetName(typeof(SavingThrowChoises), x);
                if (SavingThrows.Items[e.Index].ToString().EndsWith(xText))
                {
                    switch ((SavingThrowChoises)x)
                    {
                        case SavingThrowChoises.Strength:
                            dati.SavingThrows_Strength = e.NewValue == CheckState.Checked;
                            break;
                        case SavingThrowChoises.Dexterity:
                            dati.SavingThrows_Dexterity = e.NewValue == CheckState.Checked;
                            break;

                        case SavingThrowChoises.Constitution:
                            dati.SavingThrows_Constitution = e.NewValue == CheckState.Checked;
                            break;

                        case SavingThrowChoises.Intelligence:
                            dati.SavingThrows_Intelligence = e.NewValue == CheckState.Checked;
                            break;

                        case SavingThrowChoises.Wisdom:
                            dati.SavingThrows_Wisdom = e.NewValue == CheckState.Checked;
                            break;

                        case SavingThrowChoises.Charisma:
                            dati.SavingThrows_Charisma = e.NewValue == CheckState.Checked;
                            break;
                    }

                }
            }
            //if (e.NewValue != e.CurrentValue)
            //{
            //    bindingSourceDND.ResetBindings(false);
            //}
        }
        private void bindingSourceDND_CurrentItemChanged(object sender, EventArgs e)
        {
            var dati = bindingSourceDND.Current as DNDModelForBinding;
            if (dati == null)
            {
                return;
            }

            foreach (var x in Enum.GetValues(typeof(SavingThrowChoises)))
            {
                var xText = Enum.GetName(typeof(SavingThrowChoises), x);
                for (var y = 0; y < SavingThrows.Items.Count; y++)
                {
                    if (SavingThrows.Items[y].ToString().EndsWith(xText))
                    {
                        int cipars = 0;
                        switch ((SavingThrowChoises)x)
                        {
                            case SavingThrowChoises.Strength:
                                cipars = dati.StrengthValue + (dati.SavingThrows_Strength ?dati.Proficiency:0);
                                SavingThrows.SetItemChecked(y, dati.SavingThrows_Strength);
                                break;
                            case SavingThrowChoises.Dexterity:
                                cipars = dati.DexterityValue + (dati.SavingThrows_Dexterity ? dati.Proficiency : 0);
                                SavingThrows.SetItemChecked(y, dati.SavingThrows_Dexterity);
                                break;

                            case SavingThrowChoises.Constitution:
                                cipars = dati.ConstitutionValue + (dati.SavingThrows_Constitution ? dati.Proficiency : 0);
                                SavingThrows.SetItemChecked(y, dati.SavingThrows_Constitution);
                                break;

                            case SavingThrowChoises.Intelligence:
                                cipars = dati.IntelligenceValue + (dati.SavingThrows_Intelligence ? dati.Proficiency : 0);
                                SavingThrows.SetItemChecked(y, dati.SavingThrows_Intelligence);
                                break;

                            case SavingThrowChoises.Wisdom:
                                cipars = dati.WisdomValue + (dati.SavingThrows_Wisdom ? dati.Proficiency : 0);
                                SavingThrows.SetItemChecked(y, dati.SavingThrows_Wisdom);
                                break;

                            case SavingThrowChoises.Charisma:
                                cipars = dati.CharismaValue + (dati.SavingThrows_Charisma ? dati.Proficiency : 0);
                                SavingThrows.SetItemChecked(y, dati.SavingThrows_Charisma);
                                break;
                        }

                        SavingThrows.Items[y] = string.Format("({0}) {1}", cipars , xText);
                        
                        continue;
                    }
                }
             
            }

            foreach (var x in Enum.GetValues(typeof(SkillChoises)))
            {
                var xText = Enum.GetName(typeof(SkillChoises), x);
                for (var y = 0; y < Skills.Items.Count; y++)
                {
                    if (Skills.Items[y].ToString().EndsWith(xText))
                    {
                        int cipars = 0;
                        switch ((SkillChoises)x)
                        {
                            case SkillChoises.Acrobatic:
                                cipars = dati.DexterityValue + (dati.Skills_Acrobatic ? dati.Proficiency : 0);
                                Skills.SetItemChecked(y, dati.Skills_Acrobatic);
                                break;
                            case SkillChoises.Animal_handling:
                                cipars = dati.WisdomValue + (dati.Skills_Animal_handling ? dati.Proficiency : 0);
                                Skills.SetItemChecked(y, dati.Skills_Animal_handling);
                                break;
                            case SkillChoises.Arcana:
                                cipars = dati.IntelligenceValue + (dati.Skills_Arcana ? dati.Proficiency : 0);
                                Skills.SetItemChecked(y, dati.Skills_Arcana);
                                break;
                            case SkillChoises.Athletic:
                                cipars = dati.StrengthValue + (dati.Skills_Athletic ? dati.Proficiency : 0);
                                Skills.SetItemChecked(y, dati.Skills_Athletic);
                                break;
                            case SkillChoises.Deception:
                                cipars = dati.CharismaValue + (dati.Skills_Deception ? dati.Proficiency : 0);
                                Skills.SetItemChecked(y, dati.Skills_Deception);
                                break;
                            case SkillChoises.History:
                                cipars = dati.IntelligenceValue + (dati.Skills_History ? dati.Proficiency : 0);
                                Skills.SetItemChecked(y, dati.Skills_History);
                                break;
                            case SkillChoises.Insight:
                                cipars = dati.WisdomValue + (dati.Skills_Insight ? dati.Proficiency : 0);
                                Skills.SetItemChecked(y, dati.Skills_Insight);
                                break;
                            case SkillChoises.Intimidation:
                                cipars = dati.CharismaValue + (dati.Skills_Intimidation ? dati.Proficiency : 0);
                                Skills.SetItemChecked(y, dati.Skills_Intimidation);
                                break;
                            case SkillChoises.Investigation:
                                cipars = dati.IntelligenceValue + (dati.Skills_Investigation ? dati.Proficiency : 0);
                                Skills.SetItemChecked(y, dati.Skills_Investigation);
                                break;
                            case SkillChoises.Medicine:
                                cipars = dati.WisdomValue + (dati.Skills_Medicine ? dati.Proficiency : 0);
                                Skills.SetItemChecked(y, dati.Skills_Medicine);
                                break;
                            case SkillChoises.Nature:
                                cipars = dati.IntelligenceValue + (dati.Skills_Nature ? dati.Proficiency : 0);
                                Skills.SetItemChecked(y, dati.Skills_Nature);
                                break;
                            case SkillChoises.Perception:
                                cipars = dati.WisdomValue + (dati.Skills_Perception ? dati.Proficiency : 0);
                                Skills.SetItemChecked(y, dati.Skills_Perception);
                                break;
                            case SkillChoises.Performance:
                                cipars = dati.CharismaValue + (dati.Skills_Performance ? dati.Proficiency : 0);
                                Skills.SetItemChecked(y, dati.Skills_Performance);
                                break;
                            case SkillChoises.Persuasion:
                                cipars = dati.CharismaValue + (dati.Skills_Persuasion ? dati.Proficiency : 0);
                                Skills.SetItemChecked(y, dati.Skills_Persuasion);
                                break;
                            case SkillChoises.Religion:
                                cipars = dati.IntelligenceValue + (dati.Skills_Religion ? dati.Proficiency : 0);
                                Skills.SetItemChecked(y, dati.Skills_Religion);
                                break;
                            case SkillChoises.Sleight_of_hand:
                                cipars = dati.DexterityValue + (dati.Skills_Sleight_of_hand ? dati.Proficiency : 0);
                                Skills.SetItemChecked(y, dati.Skills_Sleight_of_hand);
                                break;
                            case SkillChoises.Stealth:
                                cipars = dati.DexterityValue + (dati.Skills_Stealth ? dati.Proficiency : 0);
                                Skills.SetItemChecked(y, dati.Skills_Stealth);
                                break;
                            case SkillChoises.Survival:
                                cipars = dati.WisdomValue + (dati.Skills_Survival ? dati.Proficiency : 0);
                                Skills.SetItemChecked(y, dati.Skills_Survival);
                                break;
                        }

                        Skills.Items[y] = string.Format("({0}) {1}", cipars, xText);
                        continue;
                    }
                }
            }
        }

        private void Skills_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var dati = bindingSourceDND.Current as DNDModelForBinding;
            if (dati == null)
            {
                return;
            }
            foreach (var x in Enum.GetValues(typeof(SkillChoises)))
            {
                var xText = Enum.GetName(typeof(SkillChoises), x);
                if (Skills.Items[e.Index].ToString().EndsWith(xText))
                {
                    switch ((SkillChoises)x)
                    {
                        case SkillChoises.Acrobatic:
                            dati.Skills_Acrobatic = e.NewValue == CheckState.Checked;
                            break;
                        case SkillChoises.Animal_handling:
                            dati.Skills_Animal_handling = e.NewValue == CheckState.Checked;
                            break;
                        case SkillChoises.Arcana:
                            dati.Skills_Arcana = e.NewValue == CheckState.Checked;
                            break;
                        case SkillChoises.Athletic:
                            dati.Skills_Athletic = e.NewValue == CheckState.Checked;
                            break;
                        case SkillChoises.Deception:
                            dati.Skills_Deception = e.NewValue == CheckState.Checked;
                            break;
                        case SkillChoises.History:
                            dati.Skills_History = e.NewValue == CheckState.Checked;
                            break;
                        case SkillChoises.Insight:
                            dati.Skills_Insight = e.NewValue == CheckState.Checked;
                            break;
                        case SkillChoises.Intimidation:
                            dati.Skills_Intimidation = e.NewValue == CheckState.Checked;
                            break;
                        case SkillChoises.Investigation:
                            dati.Skills_Investigation = e.NewValue == CheckState.Checked;
                            break;
                        case SkillChoises.Medicine:
                            dati.Skills_Medicine = e.NewValue == CheckState.Checked;
                            break;
                        case SkillChoises.Nature:
                            dati.Skills_Nature = e.NewValue == CheckState.Checked;
                            break;
                        case SkillChoises.Perception:
                            dati.Skills_Perception = e.NewValue == CheckState.Checked;
                            break;
                        case SkillChoises.Performance:
                            dati.Skills_Performance = e.NewValue == CheckState.Checked;
                            break;
                        case SkillChoises.Persuasion:
                            dati.Skills_Persuasion = e.NewValue == CheckState.Checked;
                            break;
                        case SkillChoises.Religion:
                            dati.Skills_Religion = e.NewValue == CheckState.Checked;
                            break;
                        case SkillChoises.Sleight_of_hand:
                            dati.Skills_Sleight_of_hand = e.NewValue == CheckState.Checked;
                            break;
                        case SkillChoises.Stealth:
                            dati.Skills_Stealth = e.NewValue == CheckState.Checked;
                            break;
                        case SkillChoises.Survival:
                            dati.Skills_Survival = e.NewValue == CheckState.Checked;
                            break;

                    }
                    continue;
                }
            }
          // bindingSourceDND.ResetCurrentItem();
            //if (e.NewValue != e.CurrentValue)
            //{
            //    bindingSourceDND.ResetBindings(false);
            //}
        }

        private void buttonSave_Click_1(object sender, EventArgs e)
        {

        }

        public DNDList SarakstaForma { get; set; }
    }
}
