using System;
using System.Collections.Generic;
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
        public string AddTimetable(Timetable timetable)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    string query = "INSERT INTO Timetables (Subject, Timeslot, Room) VALUES (@subject, @timeslot, @room)";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@subject", timetable.SubjectId.ToString());
                        cmd.Parameters.AddWithValue("@timeslot", timetable.Timeslot.ToString());
                        cmd.Parameters.AddWithValue("@room", timetable.RoomId.ToString());
                        cmd.ExecuteNonQuery();
                    }
                }
                return "Timetable added successfully.";
            }
            catch (Exception ex)
            {
                return $"DB Add Error: {ex.Message}";
            }
        }
        public string UpdateTimetable(Timetable timetable)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    string query = "UPDATE Timetables SET Subject = @subject, Timeslot = @timeslot, Room = @room WHERE TimetableId = @id";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@subject", timetable.SubjectId.ToString());
                        cmd.Parameters.AddWithValue("@timeslot", timetable.Timeslot.ToString());
                        cmd.Parameters.AddWithValue("@room", timetable.RoomId.ToString());
                        cmd.Parameters.AddWithValue("@id", timetable.TimetableId);
                        cmd.ExecuteNonQuery();
                    }
                }
                return "Timetable updated successfully.";
            }
            catch (Exception ex)
            {
                return $"DB Update Error: {ex.Message}";
            }
        }
        public string DeleteTimetable(int id)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    string query = "DELETE FROM Timetables WHERE TimetableId = @id";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                return "Timetable deleted successfully.";
            }
            catch (Exception ex)
            {
                return $"DB Delete Error: {ex.Message}";
            }
        }
        public Timetable GetTimetableById(int id)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    string query = "SELECT TimetableId, Subject, Timeslot, Room FROM Timetables WHERE TimetableId = @id";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Timetable
                                {
                                    TimetableId = reader.GetInt32(0),
                                    SubjectId = (UserSubject)Enum.Parse(typeof(UserSubject), reader.GetString(1)),
                                    Timeslot = (UserTimeslot)Enum.Parse(typeof(UserTimeslot), reader.GetString(2)),
                                    RoomId = (UserRoom)Enum.Parse(typeof(UserRoom), reader.GetString(3))
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB Fetch Error: " + ex.Message);
            }
            return null;
        }

        public List<Timetable> GetAllTimetables()
        {
            List<Timetable> list = new List<Timetable>();
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    string query = "SELECT TimetableId, Subject, Timeslot, Room FROM Timetables";
                    using (var cmd = new SQLiteCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Timetable
                            {
                                TimetableId = reader.GetInt32(0),
                                SubjectId = (UserSubject)Enum.Parse(typeof(UserSubject), reader.GetString(1)),
                                Timeslot = (UserTimeslot)Enum.Parse(typeof(UserTimeslot), reader.GetString(2)),
                                RoomId = (UserRoom)Enum.Parse(typeof(UserRoom), reader.GetString(3))
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB List Error: " + ex.Message);
            }
            return list;
        }
    }
}

