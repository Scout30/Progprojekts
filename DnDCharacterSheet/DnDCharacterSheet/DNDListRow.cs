using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DnDCharacterSheet
{
    public class DNDListRow
    {
        public int Id { get; set;}
        public string UserName { get; set; }
        public string Name { get; set;}
        public string CharacterRace { get; set; }
        public string EditDate { get; set; }        
    }



    public class DNDModel: DNDListRow
    {
        public string ClassName { get; set; }        
        public string PlayerName { get; set; }
        public int Level { get; set; }
        public int XP { get; set; }        
        public string BackgroundName { get; set; }
        public string Aligment { get; set; }

        public int MainStrength { get; set; }
        
        public int StrengthValue
        { 
            get {
                return MainStrength / 2 -5;
            } 
        }
        public int MainDexterity { get; set; }

        public int DexterityValue
        {
            get
            {
                return MainDexterity / 2 - 5;
            }
        }
        public int MainConstitution { get; set; }

        public int ConstitutionValue
        {
            get
            {
                return MainConstitution / 2 - 5;
            }
        }

        public int MainIntelligence { get; set; }

        public int IntelligenceValue
        {
            get
            {
                return MainIntelligence / 2 - 5;
            }
        }


        public int MainWisdom { get; set; }

        public int WisdomValue
        {
            get
            {
                return MainWisdom / 2 - 5;
            }
        }

        public int MainCharisma { get; set; }

        public int CharismaValue
        {
            get
            {
                return MainCharisma / 2 - 5;
            }
        }


        public int PasiveVisdom
        {
            get
            {
                return WisdomValue + 10;
            }
        }

      
        
        public int Proficiency
        {
            get
            {
                 var x= Math.Round((decimal)Level / 4 + 1.0m, 0, MidpointRounding.ToPositiveInfinity);
                return Convert.ToInt32(x);
            }
        }

        public bool SavingThrows_Strength { get; set; }
        public bool SavingThrows_Dexterity { get; set; }
        public bool SavingThrows_Constitution { get; set; }
        public bool SavingThrows_Intelligence { get; set; }
        public bool SavingThrows_Wisdom { get; set; }
        public bool SavingThrows_Charisma { get; set; }



        public int SavingThrows
        {
            get
            {
                var x = 0;
                if (SavingThrows_Strength) { x += StrengthValue; }
                if (SavingThrows_Dexterity) { x += DexterityValue; }
                if (SavingThrows_Constitution) { x += ConstitutionValue; }
                if (SavingThrows_Intelligence) { x += IntelligenceValue; }
                if (SavingThrows_Wisdom) { x += WisdomValue; }
                if (SavingThrows_Charisma) { x += CharismaValue; }

                return x;
            }
        }


        public bool Skills_Charisma { get; set; }


        public bool Skills_Acrobatic { get; set; }
        public bool Skills_Animal_handling { get; set; }
        public bool Skills_Arcana { get; set; }
        public bool Skills_Athletic { get; set; }
        public bool Skills_Deception { get; set; }
        public bool Skills_History { get; set; }
        public bool Skills_Insight { get; set; }
        public bool Skills_Intimidation { get; set; }
        public bool Skills_Investigation { get; set; }
        public bool Skills_Medicine { get; set; }
        public bool Skills_Nature { get; set; }
        public bool Skills_Perception { get; set; }
        public bool Skills_Performance { get; set; }
        public bool Skills_Persuasion { get; set; }
        public bool Skills_Religion { get; set; }
        public bool Skills_Sleight_of_hand { get; set; }
        public bool Skills_Stealth { get; set; }
        public bool Skills_Survival { get; set; }

        public int Skills
        {
            get
            {
                var x = 0;

                if (Skills_Acrobatic){ x += MainDexterity;  }
                if (Skills_Animal_handling) { x += MainWisdom; }
                if (Skills_Arcana) { x += MainIntelligence; }
                if (Skills_Athletic) { x += MainStrength; }
                if (Skills_Deception) { x += MainCharisma; }
                if (Skills_History) { x += MainIntelligence; }
                if (Skills_Insight) { x += MainWisdom; }
                if (Skills_Intimidation) { x += MainCharisma; }
                if (Skills_Investigation) { x += MainIntelligence; }
                if (Skills_Medicine) { x += MainWisdom; }
                if (Skills_Nature) { x += MainIntelligence; }
                if (Skills_Perception) { x += MainWisdom; }
                if (Skills_Performance) { x += MainCharisma; }
                if (Skills_Persuasion) { x += MainCharisma; }
                if (Skills_Religion) { x += MainIntelligence; }
                if (Skills_Sleight_of_hand) { x += MainDexterity; }
                if (Skills_Stealth) { x += MainDexterity; }
                if (Skills_Survival) { x += MainWisdom; }

                return x;
            }
        }


        public int ArmorClass { get; set; }

        public int Initiative
        {
            get
            {
                 return DexterityValue;
            }
        }
        public int Speed { get;set; }
        public int Inspiration { get; set; }
            
        public int HPMax { get; set; }
        public int CurrentHP { get; set; }
        public int TemporaryHP { get; set; }

        public int HitDice { get; set; }

        public bool Successes1 { get; set; }
        public bool Successes2 { get; set; }
        public bool Successes3 { get; set; }

        public bool Failures1 { get; set; }
        public bool Failures2 { get; set; }
        public bool Failures3 { get; set; }


        public string VeaponName1 { get; set; }
        public string VeaponName2 { get; set; }
        public string VeaponName3 { get; set; }


        public int AttackBonus1 { get; set; }
        public int AttackBonus2 { get; set; }
        public int AttackBonus3 { get; set; }



        public string DamageType1 { get; set; }
        public string DamageType2 { get; set; }
        public string DamageType3 { get; set; }

        public string Spellcasting { get; set; }

        public string PersonalityTraits { get; set; }
        public string Ideals { get; set; }
        public string Bonds { get; set; }
        public string Flaws { get; set; }

        public int Copper { get; set; }
        public int Silver { get; set; }
        public int Electrum { get; set; }
        public int Gold { get; set; }
        public int Platinum { get; set; }

        public string BackPack { get; set; }

        public string OtherProficienciesAndLanguages { get; set; }
        public string FeaturesAndTraits { get; set; }
        public int PassiveWisdom { get; set; }

        
    }


    public class DNDModelForBinding : DNDModel
    {
        
        public string _Level { 
            get { return Level.ToString(); } 
            set {
                if( int.TryParse(value, out int i))
                    {
                        Level = i;
                    }
            } }
        public string _XP
        {
            get { return XP.ToString(); }
            set
            {
                if (int.TryParse(value, out int i))
                {
                    XP = i;
                }
            }
        }
        public string _MainStrength
        {
            get { return MainStrength.ToString(); }
            set
            {
                if (int.TryParse(value, out int i))
                {
                    MainStrength = i;
                }
            }
        }
        public string _MainDexterity
        {
            get { return MainDexterity.ToString(); }
            set
            {
                if (int.TryParse(value, out int i))
                {
                    MainDexterity = i;
                }
            }
        }
        public string _MainConstitution
        {
            get { return MainConstitution.ToString(); }
            set
            {
                if (int.TryParse(value, out int i))
                {
                    MainConstitution = i;
                }
            }
        }
        public string _MainIntelligence
        {
            get { return MainIntelligence.ToString(); }
            set
            {
                if (int.TryParse(value, out int i))
                {
                    MainIntelligence = i;
                }
            }
        }
        public string _MainWisdom
        {
            get { return MainWisdom.ToString(); }
            set
            {
                if (int.TryParse(value, out int i))
                {
                    MainWisdom = i;
                }
            }
        }
        public string _MainCharisma
        {
            get { return MainCharisma.ToString(); }
            set
            {
                if (int.TryParse(value, out int i))
                {
                    MainCharisma = i;
                }
            }
        }
        public string _ArmorClass
        {
            get { return ArmorClass.ToString(); }
            set
            {
                if (int.TryParse(value, out int i))
                {
                    ArmorClass = i;
                }
            }
        }
        public string _Speed
        {
            get { return Speed.ToString(); }
            set
            {
                if (int.TryParse(value, out int i))
                {
                    Speed = i;
                }
            }
        }
        public string _Inspiration
        {
            get { return Inspiration.ToString(); }
            set
            {
                if (int.TryParse(value, out int i))
                {
                    Inspiration = i;
                }
            }
        }
        public string _HPMax
        {
            get { return HPMax.ToString(); }
            set
            {
                if (int.TryParse(value, out int i))
                {
                    HPMax = i;
                }
            }
        }
        public string _CurrentHP
        {
            get { return CurrentHP.ToString(); }
            set
            {
                if (int.TryParse(value, out int i))
                {
                    CurrentHP = i;
                }
            }
        }
        public string _TemporaryHP
        {
            get { return TemporaryHP.ToString(); }
            set
            {
                if (int.TryParse(value, out int i))
                {
                    TemporaryHP = i;
                }
            }
        }
        public string _HitDice
        {
            get { return HitDice.ToString(); }
            set
            {
                if (int.TryParse(value, out int i))
                {
                    HitDice = i;
                }
            }
        }
        public string _Copper
        {
            get { return Copper.ToString(); }
            set
            {
                if (int.TryParse(value, out int i))
                {
                    Copper = i;
                }
            }
        }
        public string _Silver
        {
            get { return Silver.ToString(); }
            set
            {
                if (int.TryParse(value, out int i))
                {
                    Silver = i;
                }
            }
        }

        public string _Electrum
        {
            get { return Electrum.ToString(); }
            set
            {
                if (int.TryParse(value, out int i))
                {
                    Electrum = i;
                }
            }
        }
        public string _Gold
        {
            get { return Gold.ToString(); }
            set
            {
                if (int.TryParse(value, out int i))
                {
                    Gold = i;
                }
            }
        }
        public string _Platinum
        {
            get { return Silver.ToString(); }
            set
            {
                if (int.TryParse(value, out int i))
                {
                    Silver = i;
                }
            }
        }
        public string _PassiveWisdom
        {
            get { return Silver.ToString(); }
            set
            {
                if (int.TryParse(value, out int i))
                {
                    Silver = i;
                }
            }
        }
       
        //public bool SavingThrows_Strength { get; set; }
        //public bool SavingThrows_Dexterity { get; set; }
        //public bool SavingThrows_Constitution { get; set; }
        //public bool SavingThrows_Intelligence { get; set; }
        //public bool SavingThrows_Wisdom { get; set; }
        //public bool SavingThrows_Charisma { get; set; } 
        //public bool Skills_Charisma { get; set; } 
        //public bool Skills_Acrobatic { get; set; }
        //public bool Skills_Animal_handling { get; set; }
        //public bool Skills_Arcana { get; set; }
        //public bool Skills_Athletic { get; set; }
        //public bool Skills_Deception { get; set; }
        //public bool Skills_History { get; set; }
        //public bool Skills_Insight { get; set; }
        //public bool Skills_Intimidation { get; set; }
        //public bool Skills_Investigation { get; set; }
        //public bool Skills_Medicine { get; set; }
        //public bool Skills_Nature { get; set; }
        //public bool Skills_Perception { get; set; }
        //public bool Skills_Performance { get; set; }
        //public bool Skills_Persuasion { get; set; }
        //public bool Skills_Religion { get; set; }
        //public bool Skills_Sleight_of_hand { get; set; }
        //public bool Skills_Stealth { get; set; }
        //public bool Skills_Survival { get; set; }




        //public bool Successes1 { get; set; }
        //public bool Successes2 { get; set; }
        //public bool Successes3 { get; set; }

        //public bool Failures1 { get; set; }
        //public bool Failures2 { get; set; }
        //public bool Failures3 { get; set; }


        //public int AttackBonus1 { get; set; }
        //public int AttackBonus2 { get; set; }
        //public int AttackBonus3 { get; set; }


         

    }

    public enum DiceTyps
    {
        D4=4,
        D6=6,
        D8=8,
        D10=10,
        D12=12,
        D20=20,
    }

    public enum SavingThrowChoises
    {
        Strength=1,
        Dexterity=2,
        Constitution=3,
        Intelligence=4,
        Wisdom=5,
        Charisma=6
    }
    public enum SkillChoises
    {
        Acrobatic = 1,
        Animal_handling = 2,
        Arcana = 3,
        Athletic = 4,
        Deception = 5,
        History = 6,
        Insight=7,
        Intimidation=8,
        Investigation=9,
        Medicine=10,
        Nature=11,
        Perception=12,
        Performance=13,
        Persuasion=14,
        Religion=15,
        Sleight_of_hand=16,
        Stealth=17,
        Survival=18,
    }


}
