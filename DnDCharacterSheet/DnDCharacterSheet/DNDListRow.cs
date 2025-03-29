using System.ComponentModel;

namespace DnDCharacterSheet
{
    public class DNDListRow: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(params string[] propertyName)
        {
            foreach (var x in propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(x));
            }
        }   
        int id;
        string userName;
        string name;
        string characterRace;
        string editDate;


        public int Id { get { return id; } set { if (id != value) { id = value; OnPropertyChanged(nameof(Id)); } } }
        public string UserName   { get { return userName; } set { if (userName != value) { userName = value; OnPropertyChanged(nameof(UserName)); } } }
        public virtual string Name   { get { return name; } set { if (name != value) { name = value; OnPropertyChanged(nameof(Name)); } } }
        public virtual string CharacterRace   { get { return characterRace; } set { if (characterRace != value) { characterRace = value; OnPropertyChanged(nameof(CharacterRace)); } } }
        public virtual string EditDate   { get { return editDate; } set { if (editDate != value) { editDate = value; OnPropertyChanged(nameof(EditDate)); } } }   
             
    }


   
}
