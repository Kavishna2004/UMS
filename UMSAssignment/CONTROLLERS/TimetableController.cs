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
        public TimetableController()
        {

        }

        public static List<Timetable> GetAllTimetables()
        {
            var timetables = new List<Timetable>();
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    using (var cmd = new SQLiteCommand("SELECT * FROM Timetables", conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                timetables.Add(new Timetable
                                {
                                    TimetableId = reader.GetInt32(0),
                                    TimeSlot = (UserTimeslot)reader.GetInt32(1),
                                    SubjectId = reader.GetInt32(2),
                                    RoomId = (UserRoom)reader.GetInt32(3),


                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetAllTimetables: " + ex.Message);
            }
            return timetables;
        }


        public bool AddTimetable(Timetable timetable)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    string insertQuery = "INSERT INTO Timetables (TimeSlot, SubjectId, RoomId) VALUES (@TimeSlot, @SubjectId, @RoomId)";
                    using (var cmd = new SQLiteCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@TimeSlot", timetable.TimeSlot);
                        cmd.Parameters.AddWithValue("@SubjectId", timetable.TimetableId);
                        cmd.Parameters.AddWithValue("@RoomId", timetable.TimetableId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in AddTimetable: " + ex.Message);
                return false;
            }
        }
        public bool UpdateTimetable(Timetable timetable)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    string updateQuery = @"
                        UPDATE Timetables
                        SET TimeSlot = @TimeSlot,
                            SubjectId = @SubjectId,
                            RoomId = @RoomId
                        WHERE TimetableId = @TimetableId";
                    using (var cmd = new SQLiteCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@TimeSlot", timetable.TimeSlot);
                        cmd.Parameters.AddWithValue("@SubjectId", timetable.SubjectId);
                        cmd.Parameters.AddWithValue("@RoomId", timetable.RoomId);
                        cmd.Parameters.AddWithValue("@TimetableId", timetable.TimetableId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in UpdateTimetable: " + ex.Message);
                return false;
            }
        }
        public bool DeleteTimetable(int id)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    string deleteQuery = "DELETE FROM Timetables WHERE TimetableId = @Id";
                    using (var cmd = new SQLiteCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in DeleteTimetable: " + ex.Message);
                return false;
            }
        }
        public Timetable GetTimetableById(int timetableId)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    conn.Open(); // Ensure the connection is opened
                    var cmd = new SQLiteCommand("SELECT * FROM Timetables WHERE TimetableId = @Id", conn);
                    cmd.Parameters.AddWithValue("@Id", timetableId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Timetable
                            {
                                TimetableId = Convert.ToInt32(reader["TimetableId"]),
                                TimeSlot = (UserTimeslot)Enum.Parse(typeof(UserTimeslot), reader["TimeSlot"].ToString()),
                                SubjectId = Convert.ToInt32(reader["SubjectId"]),
                                RoomId = (UserRoom)Enum.Parse(typeof(UserRoom), reader["RoomId"].ToString())
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetTimetableById: " + ex.Message);
            }

            return null;
        }
    }
}

