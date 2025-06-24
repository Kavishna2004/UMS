using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMSAssignment.MODELS;
using System.Data.SQLite;
using UMSAssignment.REPOSITORIE;
using UMSAssignment.ENUMS;

namespace UMSAssignment.CONTROLLERS
{
    internal class AttendanceController
    {
        public string AddAttendance(Attendance attendance)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                   
                    string query = @"INSERT INTO Attendances (Timestamp, Status, StudentId, TimetableId)
                                     VALUES (@Timestamp, @Status, @StudentId, @TimetableId)";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Timestamp", attendance.Timestamp);
                        cmd.Parameters.AddWithValue("@Status", attendance.Status.ToString());
                        cmd.Parameters.AddWithValue("@StudentId", attendance.StudentId);
                        cmd.Parameters.AddWithValue("@TimetableId", attendance.TimetableId);
                        cmd.ExecuteNonQuery();
                    }
                    return "Attendance added successfully.";
                }
            }
            catch (Exception ex)
            {
                return "Failed to add attendance: " + ex.Message;
            }
        }

        public string UpdateAttendance(Attendance attendance)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    string query = @"UPDATE Attendances SET Timestamp=@Timestamp, Status=@Status, 
                                     StudentId=@StudentId, TimetableId=@TimetableId
                                     WHERE AttendanceId=@AttendanceId";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Timestamp", attendance.Timestamp);
                        cmd.Parameters.AddWithValue("@Status", attendance.Status.ToString());
                        cmd.Parameters.AddWithValue("@StudentId", attendance.StudentId);
                        cmd.Parameters.AddWithValue("@TimetableId", attendance.TimetableId);
                        cmd.Parameters.AddWithValue("@AttendanceId", attendance.AttendanceId);
                        cmd.ExecuteNonQuery();
                    }
                    return "Attendance updated.";
                }
            }
            catch (Exception ex)
            {
                return "Failed to update attendance: " + ex.Message;
            }
        }

        public string DeleteAttendance(int attendanceId)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                  
                    string query = "DELETE FROM Attendances WHERE AttendanceId=@AttendanceId";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@AttendanceId", attendanceId);
                        cmd.ExecuteNonQuery();
                    }
                    return "Attendance deleted.";
                }
            }
            catch (Exception ex)
            {
                return "Failed to delete attendance: " + ex.Message;
            }
        }

        public List<Attendance> GetAllAttendances()
        {
            var list = new List<Attendance>();
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                 
                    string query = "SELECT * FROM Attendances";
                    using (var cmd = new SQLiteCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Attendance
                            {
                                AttendanceId = Convert.ToInt32(reader["AttendanceId"]),
                                Timestamp = reader["Timestamp"].ToString(),
                                Status = (UserAttendance)Enum.Parse(typeof(UserAttendance), reader["Status"].ToString()),
                                StudentId = Convert.ToInt32(reader["StudentId"]),
                                TimetableId = Convert.ToInt32(reader["TimetableId"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
               Console.WriteLine("Error in GetAllAttendances: " + ex.Message); 
            }
            return list;
        }

        public Attendance GetAttendanceById(int id)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                   
                    string query = "SELECT * FROM Attendances WHERE AttendanceId = @id";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Attendance
                                {
                                    AttendanceId = Convert.ToInt32(reader["AttendanceId"]),
                                    Timestamp = reader["Timestamp"].ToString(),
                                    Status = (UserAttendance)Enum.Parse(typeof(UserAttendance), reader["Status"].ToString()),
                                    StudentId = Convert.ToInt32(reader["StudentId"]),
                                    TimetableId = Convert.ToInt32(reader["TimetableId"])
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetAttendanceById: " + ex.Message);
            }
            return null;
        }
    }
}
