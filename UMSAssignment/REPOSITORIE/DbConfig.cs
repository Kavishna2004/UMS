using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.Web.UI.MobileControls;
using UMSAssignment.DTOS;
using UMSAssignment.MAPPERS;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using System.Runtime.ConstrainedExecution;
using System.Windows.Forms;
using System.Xml.Linq;
using UMSAssignment.MODELS;
using System.Drawing;

namespace UMSAssignment.REPOSITORIE
{
    public static class DbConfig
    {
        private static string ConnectionString = "Data Source = unicomticDB.db;Version=3;";

        public static SQLiteConnection GetConnection()
        {
            var conn = new SQLiteConnection(ConnectionString);
            conn.Open();
            return conn;
        }
    }
}
