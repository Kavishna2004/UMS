using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMSAssignment.MODELS;
using System.Data.SQLite;
using UMSAssignment.REPOSITORIE;

namespace UMSAssignment.CONTROLLERS
{
    internal class AttendanceController
    {
        public AttendanceController()
        {

        }
        public List<Attendance> GetAllAttendance()
        {
            var attendances = new List<Attendance>();

            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    string sql = "SELECT * FROM Attendance";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            attendances.Add(new Attendance
                            {
                                Id = Convert.ToInt32(reader["AttendanceId"]),
                                Timestamp = reader["Timestamp"].ToString(),
                                Status = reader["Status"].ToString(),
                                StudentId = Convert.ToInt32(reader["StudentId"]),
                                TimetableId = Convert.ToInt32(reader["TimetableId"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching attendance: " + ex.Message);
            }

            return attendances;
        }
        public string AddAttendance(Attendance attendance)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    string sql = @"INSERT INTO Attendance (Timestamp, Status, StudentId, TimetableId)
                                   VALUES (@Timestamp, @Status, @StudentId, @TimetableId)";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Timestamp", attendance.Timestamp);
                        cmd.Parameters.AddWithValue("@Status", attendance.Status);
                        cmd.Parameters.AddWithValue("@StudentId", attendance.StudentId);
                        cmd.Parameters.AddWithValue("@TimetableId", attendance.TimetableId);

                        cmd.ExecuteNonQuery();
                        return "Attendance added successfully.";
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Error adding attendance: {ex.Message}";
            }
        }

        public string UpdateAttendance(int attendanceId, string newStatus)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    conn.Open();
                    string sql = "UPDATE Attendance SET Status = @Status WHERE AttendanceId = @AttendanceId";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Status", newStatus);
                        cmd.Parameters.AddWithValue("@AttendanceId", attendanceId);
                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0 ? "Attendance updated successfully." : "Attendance not found.";
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Error updating attendance: {ex.Message}";
            }
        }

        public string DeleteAttendance(int attendanceId)
        {
            try
            {
                using (var conn = DbConfig.GetConnection())
                {
                    conn.Open();
                    string sql = "DELETE FROM Attendance WHERE AttendanceId = @AttendanceId";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@AttendanceId", attendanceId);
                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0 ? "Attendance deleted." : "Record not found.";
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Error deleting attendance: {ex.Message}";
            }
        }
    }
}


