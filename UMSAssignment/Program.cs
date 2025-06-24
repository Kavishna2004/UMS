using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMSAssignment.CONTROLLERS;
using UMSAssignment.REPOSITORIE;
using UMSAssignment.VIEWS;

namespace UMSAssignment
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DatabaseManager.CreateTables(); 

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);

            //// Admin check and insert
            //var controller = new LoginController();
            //controller.EnsureAdminExists(); 

            // Show Login form
            //Application.Run(new LoginForm());
            //Application.Run(new LecturerForm());

            //Application.Run(new StudentForm());
            //Application.Run(new StaffForm());
            //Application.Run(new CourseForm());
            //Application.Run(new AttendanceForm());

        }
    }
}
