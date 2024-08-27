using Zoo_App_again.Screens;
using Zoo_App_again.Screens.Animals;
using Zoo_App_again.Screens.Cafes;
using Zoo_App_again.Screens.Exports;
using Zoo_App_again.Screens.Imports;
using Zoo_App_again.Screens.Museums;
using Zoo_App_again.Screens.Sales;
using Zoo_App_again.Screens.Ticket_Reservations.Reservations_Guidelines;
using Zoo_App_again.Screens.Workers;

namespace Zoo_App_again
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
            Application.Run(new MainForm());
        }
    }
}