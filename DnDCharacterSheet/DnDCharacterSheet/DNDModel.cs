namespace DnDCharacterSheet
{
    public class DNDModel: DNDListRow
    {
        private string className;
        private string _PlayerName ;
        private int _Level ;
        private int _XP ;
        private string _BackgroundName ;
        private string _Aligment;
        private int _MainStrength ;
        private int _MainDexterity ;
        private int _MainConstitution ;
        private int _MainIntelligence ;
        private int _MainWisdom ;
        private int _MainCharisma ;
        private bool _SavingThrows_Strength ;
        private bool _SavingThrows_Dexterity ;
        private bool _SavingThrows_Constitution ;
        private bool _SavingThrows_Intelligence ;
        private bool _SavingThrows_Wisdom ;
        private bool _SavingThrows_Charisma ;
        private bool _Skills_Charisma ;
        private bool _Skills_Acrobatic ;
        private bool _Skills_Animal_handling ;
        private bool _Skills_Arcana ;
        private bool _Skills_Athletic ;
        private bool _Skills_Deception ;
        private bool _Skills_History ;
        private bool _Skills_Insight ;
        private bool _Skills_Intimidation ;
        private bool _Skills_Investigation ;
        private bool _Skills_Medicine ;
        private bool _Skills_Nature ;
        private bool _Skills_Perception ;
        private bool _Skills_Performance ;
        private bool _Skills_Persuasion ;
        private bool _Skills_Religion ;
        private bool _Skills_Sleight_of_hand ;
        private bool _Skills_Stealth ;
        private bool _Skills_Survival;

        private int _ArmorClass ;

    
        private int _Speed ;
        private int _Inspiration ;

        private int _HPMax ;
        private int _CurrentHP ;
        private int _TemporaryHP ;

        private int _HitDice ;

        private bool _Successes1 ;
        private bool _Successes2 ;
        private bool _Successes3 ;

        private bool _Failures1 ;
        private bool _Failures2 ;
        private bool _Failures3 ;


        private string _VeaponName1 ;
        private string _VeaponName2 ;
        private string _VeaponName3 ;


        private int _AttackBonus1 ;
        private int _AttackBonus2 ;
        private int _AttackBonus3 ;



        private string _DamageType1 ;
        private string _DamageType2 ;
        private string _DamageType3 ;

        private string _Spellcasting ;

        private string _PersonalityTraits ;
        private string _Ideals ;
        private string _Bonds ;
        private string _Flaws ;

        private int _Copper ;
        private int _Silver ;
        private int _Electrum ;
        private int _Gold ;
        private int _Platinum ;

        private string _BackPack ;

        private string _OtherProficienciesAndLanguages ;
        private string _FeaturesAndTraits ;
        private int _PassiveWisdom ;



        public string ClassName { get => className; set { if (className != value) { className = value; OnPropertyChanged(nameof(ClassName)); } } }
        public string PlayerName { get => _PlayerName; set { if (_PlayerName != value) { _PlayerName = value; OnPropertyChanged(nameof(PlayerName)); } } }
        public int Level { get => _Level; set { if (_Level != value) { _Level = value; OnPropertyChanged(nameof(Level),nameof(Proficiency)); } } }
        public int XP { get => _XP; set { if (_XP != value) { _XP = value; OnPropertyChanged(nameof(XP)); } } }        
        public string BackgroundName { get => _BackgroundName; set { if (_BackgroundName != value) { _BackgroundName = value; OnPropertyChanged(nameof(BackgroundName)); } } }
        public string Aligment { get => _Aligment; set { if (_Aligment != value) { _Aligment = value; OnPropertyChanged(nameof(Aligment)); } } }

        public int MainStrength { get => _MainStrength; set { if (_MainStrength != value) { _MainStrength = value; OnPropertyChanged(nameof(MainStrength), nameof(StrengthValue), nameof(Skills),nameof(SavingThrows)); } } }
        
        public int StrengthValue
        { 
            get {
                return MainStrength / 2 -5;
            } 
        }
        public int MainDexterity { get => _MainDexterity; set { if (_MainDexterity != value) { _MainDexterity = value; OnPropertyChanged( nameof(MainDexterity), nameof(MainDexterity), nameof(DexterityValue), nameof(Initiative), nameof(Skills), nameof(SavingThrows));   } } }

        public int DexterityValue
        {
            get
            {
                return MainDexterity / 2 - 5;
            }
        }
        public int MainConstitution { get => _MainConstitution; set { if (_MainConstitution != value) { _MainConstitution = value; OnPropertyChanged(nameof(MainConstitution),nameof(ConstitutionValue), nameof(Skills), nameof(SavingThrows)); } } }

        public int ConstitutionValue
        {
            get
            {
                return MainConstitution / 2 - 5;
            }
        }

        public int MainIntelligence { get => _MainIntelligence; set { if (_MainIntelligence != value) { _MainIntelligence = value; OnPropertyChanged(nameof(MainIntelligence), nameof(IntelligenceValue), nameof(Skills), nameof(SavingThrows)); } } }

        public int IntelligenceValue
        {
            get
            {
                return MainIntelligence / 2 - 5;
            }
        }


        public int MainWisdom { get => _MainWisdom; set { if (_MainWisdom != value) { _MainWisdom = value; OnPropertyChanged(nameof(MainWisdom),nameof(WisdomValue),  nameof(Skills), nameof(SavingThrows) ); } } }

        public int WisdomValue
        {
            get
            {
                return MainWisdom / 2 - 5;
            }
        }

        public int MainCharisma { get => _MainCharisma; set { if (_MainCharisma != value) { _MainCharisma = value; OnPropertyChanged(nameof(MainCharisma), nameof(CharismaValue), nameof(Skills), nameof(SavingThrows)); } } }

        public int CharismaValue
        {
            get
            {
                return MainCharisma / 2 - 5;
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

        public bool SavingThrows_Strength { get => _SavingThrows_Strength; set { if (_SavingThrows_Strength != value) { _SavingThrows_Strength = value; OnPropertyChanged(nameof(SavingThrows_Strength), nameof(SavingThrows)); } } }
        public bool SavingThrows_Dexterity { get => _SavingThrows_Dexterity; set { if (_SavingThrows_Dexterity != value) { _SavingThrows_Dexterity = value; OnPropertyChanged(nameof(SavingThrows_Dexterity), nameof(SavingThrows)); } } }
        public bool SavingThrows_Constitution { get => _SavingThrows_Constitution; set { if (_SavingThrows_Constitution != value) { _SavingThrows_Constitution = value; OnPropertyChanged(nameof(SavingThrows_Constitution), nameof(SavingThrows)); } } }
        public bool SavingThrows_Intelligence { get => _SavingThrows_Intelligence; set { if (_SavingThrows_Intelligence != value) { _SavingThrows_Intelligence = value; OnPropertyChanged(nameof(SavingThrows_Intelligence), nameof(SavingThrows)); } } }
        public bool SavingThrows_Wisdom { get => _SavingThrows_Wisdom; set { if (_SavingThrows_Wisdom != value) { _SavingThrows_Wisdom = value; OnPropertyChanged(nameof(SavingThrows_Wisdom), nameof(SavingThrows)); } } }
        public bool SavingThrows_Charisma { get => _SavingThrows_Charisma; set { if (_SavingThrows_Charisma != value) { _SavingThrows_Charisma = value; OnPropertyChanged(nameof(SavingThrows_Charisma), nameof(SavingThrows)); } } }



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


        public bool Skills_Charisma { get => _Skills_Charisma; set { if (_Skills_Charisma != value) { _Skills_Charisma = value; OnPropertyChanged(nameof(Skills_Charisma), nameof(Skills)); } } }


        public bool Skills_Acrobatic { get => _Skills_Acrobatic; set { if (_Skills_Acrobatic != value) { _Skills_Acrobatic = value; OnPropertyChanged(nameof(Skills_Acrobatic), nameof(Skills)); } } }
        public bool Skills_Animal_handling { get => _Skills_Animal_handling; set { if (_Skills_Animal_handling != value) { _Skills_Animal_handling = value; OnPropertyChanged(nameof(Skills_Animal_handling), nameof(Skills)); } } }
        public bool Skills_Arcana { get => _Skills_Arcana; set { if (_Skills_Arcana != value) { _Skills_Arcana = value; OnPropertyChanged(nameof(Skills_Arcana), nameof(Skills)); } } }
        public bool Skills_Athletic { get => _Skills_Athletic; set { if (_Skills_Athletic != value) { _Skills_Athletic = value; OnPropertyChanged(nameof(Skills_Athletic), nameof(Skills)); } } }
        public bool Skills_Deception { get => _Skills_Deception; set { if (_Skills_Deception != value) { _Skills_Deception = value; OnPropertyChanged(nameof(Skills_Deception), nameof(Skills)); } } }
        public bool Skills_History { get => _Skills_History; set { if (_Skills_History != value) { _Skills_History = value; OnPropertyChanged(nameof(Skills_History), nameof(Skills)); } } }
        public bool Skills_Insight { get => _Skills_Insight ; set { if (_Skills_Insight  != value) { _Skills_Insight  = value; OnPropertyChanged(nameof(Skills_Insight ), nameof(Skills)); } } }
        public bool Skills_Intimidation { get => _Skills_Intimidation; set { if (_Skills_Intimidation != value) { _Skills_Intimidation = value; OnPropertyChanged(nameof(Skills_Intimidation), nameof(Skills)); } } }
        public bool Skills_Investigation { get => _Skills_Investigation; set { if (_Skills_Investigation != value) { _Skills_Investigation = value; OnPropertyChanged(nameof(Skills_Investigation), nameof(Skills)); } } }
        public bool Skills_Medicine { get => _Skills_Medicine; set { if (_Skills_Medicine != value) { _Skills_Medicine = value; OnPropertyChanged(nameof(Skills_Medicine), nameof(Skills)); } } }
        public bool Skills_Nature { get => _Skills_Nature; set { if (_Skills_Nature != value) { _Skills_Nature = value; OnPropertyChanged(nameof(Skills_Nature), nameof(Skills)); } } }
        public bool Skills_Perception { get => _Skills_Perception; set { if (_Skills_Perception != value) { _Skills_Perception = value; OnPropertyChanged(nameof(Skills_Perception), nameof(Skills)); } } }
        public bool Skills_Performance { get => _Skills_Performance; set { if (_Skills_Performance != value) { _Skills_Performance = value; OnPropertyChanged(nameof(Skills_Performance), nameof(Skills)); } } }
        public bool Skills_Persuasion { get => _Skills_Persuasion; set { if (_Skills_Persuasion != value) { _Skills_Persuasion = value; OnPropertyChanged(nameof(Skills_Persuasion), nameof(Skills)); } } }
        public bool Skills_Religion { get => _Skills_Religion; set { if (_Skills_Religion != value) { _Skills_Religion = value; OnPropertyChanged(nameof(Skills_Religion), nameof(Skills)); } } }
        public bool Skills_Sleight_of_hand { get => _Skills_Sleight_of_hand; set { if (_Skills_Sleight_of_hand != value) { _Skills_Sleight_of_hand = value; OnPropertyChanged(nameof(Skills_Sleight_of_hand), nameof(Skills)); } } }
        public bool Skills_Stealth { get => _Skills_Stealth; set { if (_Skills_Stealth != value) { _Skills_Stealth = value; OnPropertyChanged(nameof(Skills_Stealth), nameof(Skills)); } } }
        public bool Skills_Survival { get => _Skills_Survival; set { if (_Skills_Survival != value) { _Skills_Survival = value; OnPropertyChanged(nameof(Skills_Survival), nameof(Skills)); } } }

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


        public int ArmorClass { get => _ArmorClass; set { if (_ArmorClass != value) { _ArmorClass = value; OnPropertyChanged(nameof(ArmorClass)); } } }

        public int Initiative
        {
            get
            {
                 return DexterityValue;
            }
        }
        public int Speed { get => _Speed; set { if (_Speed != value) { _Speed = value; OnPropertyChanged(nameof(Speed)); } } }
        public int Inspiration { get => _Inspiration; set { if (_Inspiration != value) { _Inspiration = value; OnPropertyChanged(nameof(Inspiration)); } } }
            
        public int HPMax { get => _HPMax; set { if (_HPMax != value) { _HPMax = value; OnPropertyChanged(nameof(HPMax)); } } }
        public int CurrentHP { get => _CurrentHP; set { if (_CurrentHP != value) { _CurrentHP = value; OnPropertyChanged(nameof(CurrentHP)); } } }
        public int TemporaryHP { get => _TemporaryHP; set { if (_TemporaryHP != value) { _TemporaryHP = value; OnPropertyChanged(nameof(TemporaryHP)); } } }

        public int HitDice { get => _HitDice; set { if (_HitDice != value) { _HitDice = value; OnPropertyChanged(nameof(HitDice)); } } }

        public bool Successes1 { get => _Successes1; set { if (_Successes1 != value) { _Successes1 = value; OnPropertyChanged(nameof(Successes1)); } } }
        public bool Successes2 { get => _Successes2; set { if (_Successes2 != value) { _Successes2 = value; OnPropertyChanged(nameof(Successes2)); } } }
        public bool Successes3 { get => _Successes3; set { if (_Successes3 != value) { _Successes3 = value; OnPropertyChanged(nameof(Successes3)); } } }

        public bool Failures1 { get => _Failures1; set { if (_Failures1 != value) { _Failures1 = value; OnPropertyChanged(nameof(Failures1)); } } }
        public bool Failures2 { get => _Failures2; set { if (_Failures2 != value) { _Failures2 = value; OnPropertyChanged(nameof(Failures2)); } } }
        public bool Failures3 { get => _Failures3; set { if (_Failures3 != value) { _Failures3 = value; OnPropertyChanged(nameof(Failures3)); } } }


        public string VeaponName1 { get => _VeaponName1; set { if (_VeaponName1 != value) { _VeaponName1 = value; OnPropertyChanged(nameof(VeaponName1)); } } }
        public string VeaponName2 { get => _VeaponName2; set { if (_VeaponName2 != value) { _VeaponName2 = value; OnPropertyChanged(nameof(VeaponName2)); } } }
        public string VeaponName3 { get => _VeaponName3; set { if (_VeaponName3 != value) { _VeaponName3 = value; OnPropertyChanged(nameof(VeaponName3)); } } }


        public int AttackBonus1 { get => _AttackBonus1; set { if (_AttackBonus1 != value) { _AttackBonus1 = value; OnPropertyChanged(nameof(AttackBonus1)); } } }
        public int AttackBonus2 { get => _AttackBonus2; set { if (_AttackBonus2 != value) { _AttackBonus2 = value; OnPropertyChanged(nameof(AttackBonus2)); } } }
        public int AttackBonus3 { get => _AttackBonus3; set { if (_AttackBonus3 != value) { _AttackBonus3 = value; OnPropertyChanged(nameof(AttackBonus3)); } } }



        public string DamageType1 { get => _DamageType1; set { if (_DamageType1 != value) { _DamageType1 = value; OnPropertyChanged(nameof(DamageType1)); } } }
        public string DamageType2 { get => _DamageType2; set { if (_DamageType2 != value) { _DamageType2 = value; OnPropertyChanged(nameof(DamageType2)); } } }
        public string DamageType3 { get => _DamageType3; set { if (_DamageType3 != value) { _DamageType3 = value; OnPropertyChanged(nameof(DamageType3)); } } }

        public string Spellcasting { get => _Spellcasting; set { if (_Spellcasting != value) { _Spellcasting = value; OnPropertyChanged(nameof(Spellcasting)); } } }

        public string PersonalityTraits { get => _PersonalityTraits; set { if (_PersonalityTraits != value) { _PersonalityTraits = value; OnPropertyChanged(nameof(PersonalityTraits)); } } }
        public string Ideals { get => _Ideals; set { if (_Ideals != value) { _Ideals = value; OnPropertyChanged(nameof(Ideals)); } } }
        public string Bonds { get => _Bonds; set { if (_Bonds != value) { _Bonds = value; OnPropertyChanged(nameof(Bonds)); } } }
        public string Flaws { get => _Flaws; set { if (_Flaws != value) { _Flaws = value; OnPropertyChanged(nameof(Flaws)); } } }

        public int Copper { get => _Copper; set { if (_Copper != value) { _Copper = value; OnPropertyChanged(nameof(Copper)); } } }
        public int Silver { get => _Silver; set { if (_Silver != value) { _Silver = value; OnPropertyChanged(nameof(Silver)); } } }
        public int Electrum { get => _Electrum; set { if (_Electrum != value) { _Electrum = value; OnPropertyChanged(nameof(Electrum)); } } }
        public int Gold { get => _Gold; set { if (_Gold != value) { _Gold = value; OnPropertyChanged(nameof(Gold)); } } }
        public int Platinum { get => _Platinum; set { if (_Platinum != value) { _Platinum = value; OnPropertyChanged(nameof(Platinum)); } } }

        public string BackPack { get => _BackPack; set { if (_BackPack != value) { _BackPack = value; OnPropertyChanged(nameof(BackPack)); } } }

        public string OtherProficienciesAndLanguages { get => _OtherProficienciesAndLanguages; set { if (_OtherProficienciesAndLanguages != value) { _OtherProficienciesAndLanguages = value; OnPropertyChanged(nameof(OtherProficienciesAndLanguages)); } } }
        public string FeaturesAndTraits { get => _FeaturesAndTraits; set { if (_FeaturesAndTraits != value) { _FeaturesAndTraits = value; OnPropertyChanged(nameof(FeaturesAndTraits)); } } }
        public int PassiveWisdom { get => _PassiveWisdom; set { if (_PassiveWisdom != value) { _PassiveWisdom = value; OnPropertyChanged(nameof(PassiveWisdom)); } } }

        
    }

    public class DNDModelForBinding : DNDModel
    {

    }
}
