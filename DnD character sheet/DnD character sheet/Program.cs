using System;
using System.Windows.Forms;
using DnD_character_sheet;

namespace DnDCharacterSheetApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // Inicializç datu bâzi, ja tâ vçl nav izveidota
            DBHelper.InitializeDatabase();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}