namespace DnDCharacterSheet
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());

            if (UserId != null)
            {
                Application.Run(new DNDList());
            }

        }
        private static int? userId = 0;//null;        
        private static bool userIsAdmin = true;      
        internal static int? UserId { get {return userId;} set {userId = value;}}
        internal static bool IsAdmin { get { return userIsAdmin; } set { userIsAdmin = value; } }
    }
}