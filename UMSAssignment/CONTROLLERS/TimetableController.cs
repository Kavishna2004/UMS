using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.UI.MobileControls;
using System.Windows.Forms;
using System.Xml;
using UMSAssignment.ENUMS;
using UMSAssignment.MODELS;
using UMSAssignment.REPOSITORIE;

namespace UMSAssignment.CONTROLLERS
{
    internal class TimetableController
    {
        public string AddTimetable(Timetable t)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    string q = "INSERT INTO Timetables (SubjectId, Timeslot, RoomId) VALUES (@s,@ts,@r)";
                    using (var cmd = new SQLiteCommand(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@s", t.SubjectId.ToString());
                        cmd.Parameters.AddWithValue("@ts", t.Timeslot.ToString());
                        cmd.Parameters.AddWithValue("@r", t.RoomId.ToString());
                        cmd.ExecuteNonQuery();
                    }
                }
                return "Timetable added successfully.";
            }
            catch (Exception ex)
            {
                return "Add Error: " + ex.Message;
            }
        }

        public string UpdateTimetable(Timetable t)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    string q = "UPDATE Timetables SET SubjectId=@s, Timeslot=@ts, RoomId=@r WHERE TimetableId=@id";
                    using (var cmd = new SQLiteCommand(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@s", t.SubjectId.ToString());
                        cmd.Parameters.AddWithValue("@ts", t.Timeslot.ToString());
                        cmd.Parameters.AddWithValue("@r", t.RoomId.ToString());
                        cmd.Parameters.AddWithValue("@id", t.TimetableId);
                        cmd.ExecuteNonQuery();
                    }
                }
                return "Timetable updated successfully.";
            }
            catch (Exception ex)
            {
                return "Update Error: " + ex.Message;
            }
        }

        public string DeleteTimetable(int id)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    string q = "DELETE FROM Timetables WHERE TimetableId=@id";
                    using (var cmd = new SQLiteCommand(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                return "Timetable deleted successfully.";
            }
            catch (Exception ex)
            {
                return "Delete Error: " + ex.Message;
            }
        }

        public DataTable GetTimetableWithNames()
        {
            var dt = new DataTable();

            try
            {
                using (var conn = DbConfig.GetConnection())
                {

                    string query = @"
                SELECT 
                    t.TimetableId,
                    t.SubjectId,
                    s.SubjectName,
                    t.Timeslot,
                    t.RoomId,
                    r.RoomName
                FROM Timetables t
                JOIN Subjects s ON t.SubjectId = s.SubjectId
                JOIN Rooms r ON t.RoomId = r.RoomId";

                    using (var adapter = new SQLiteDataAdapter(query, conn))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Join Load Error: " + ex.Message);
            }

            return dt;
        }


    }
}

