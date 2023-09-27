using CureWell.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CureWell.DAL
{
    public class CureWellRepositoryImpl: ICureWellRepository
    {
        private string connectionString = "server=INL623;database=CureWellDB;trusted_connection=yes";
        private SqlConnection conn;
        private SqlCommand cmd;

        public CureWellRepositoryImpl()
        {
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
        }

        public bool AddDoctor(Doctor dObj)
        {
            int rows;
            SqlCommand cmd = new SqlCommand(connectionString);
            cmd.Connection = conn;
            cmd.CommandText = string.Format("insert into Doctor values ('{0}')", dObj.DoctorName);
            conn.Open();
            try
            {
                rows = cmd.ExecuteNonQuery();
            }
            catch
            {
                conn.Close();
                return false;
            }
            conn.Close();
            return rows > 0;
        }

        public bool AddDoctorSpecialization(DoctorSpecialization dsObj)
        {
            int rows;
            SqlCommand cmd = new SqlCommand(connectionString);
            cmd.Connection = conn;
            cmd.CommandText = string.Format("insert into DoctorSpecialization values ({0},'{1}','{2}')", dsObj.DoctorId, dsObj.SpecializationCode, dsObj.SpecializationDate);
            conn.Open();
            try
            {
                rows = cmd.ExecuteNonQuery();
            }
            catch
            {
                conn.Close();
                return false;
            }
            conn.Close();
            return rows > 0;
        }

        public bool AddSpecialization(Specialization sObj)
        {
            int rows;
            SqlCommand cmd = new SqlCommand(connectionString);
            cmd.Connection = conn;
            cmd.CommandText = string.Format("insert into Specialization values ('{0}','{1}')", sObj.SpecializationCode, sObj.SpecializationName);
            conn.Open();
            try
            {
                rows = cmd.ExecuteNonQuery();
            }
            catch
            {
                conn.Close();
                return false;
            }
            conn.Close();
            return rows > 0;
        }

        public bool AddSurgery(Surgery sObj)
        {
            int rows;
            cmd.Connection = conn;
            cmd.CommandText = string.Format("insert into Surgery values ({0}, '{1}', {2}, {3}, '{4}');", sObj.DoctorId, sObj.SurgeryDate, sObj.StartTime, sObj.EndTime, sObj.SurgeryCategory);
            conn.Open();
            try
            {
                rows = cmd.ExecuteNonQuery();
            }
            catch
            {
                conn.Close();
                return false;
            }
            conn.Close();
            return rows > 0;
        }

        public bool DeleteDoctor(int doctorId)
        {
            int rows;
            cmd.Connection = conn;
            cmd.CommandText = string.Format("Delete from Doctor where DoctorId={0}", doctorId);
            conn.Open();
            try
            {
                rows = cmd.ExecuteNonQuery();
            }
            catch
            {
                conn.Close();
                return false;
            }
            conn.Close();
            return rows > 0;
        }

        public List<Doctor> GetAllDoctors()
        {
            List<Doctor> doctorList = new List<Doctor>();
            cmd.Connection = conn;
            cmd.CommandText = "select * from Doctor";
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int doctorId = Convert.ToInt32(reader["DoctorId"]);
                string doctorName = reader["DoctorName"].ToString();
                doctorList.Add(new Doctor(doctorId, doctorName));
            }
            conn.Close();
            return doctorList;
        }

        public List<Specialization> GetAllSpecializations()
        {
            List<Specialization> specializationList = new List<Specialization>();
            cmd.Connection = conn;
            cmd.CommandText = "select * from Specialization";
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string specializationCode = reader["SpecializationCode"].ToString();
                string specializationName = reader["SpecializationName"].ToString();
                specializationList.Add(new Specialization(specializationCode, specializationName));
            }
            conn.Close();
            return specializationList;
        }

        public List<Surgery> GetAllSurgeries()
        {
            List<Surgery> surgeryList = new List<Surgery>();
            cmd.Connection = conn;
            cmd.CommandText = string.Format("select * from Surgery");
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int doctorId = Convert.ToInt32(reader["DoctorId"]);
                decimal endTime = Convert.ToDecimal(reader["EndTime"]);
                decimal startTime = Convert.ToDecimal(reader["StartTime"]);
                string surgeryCategory = reader["SurgeryCategory"].ToString();
                DateTime surgeryDate = Convert.ToDateTime(reader["SurgeryDate"]);
                int surgeryId = Convert.ToInt32(reader["SurgeryId"]);
                surgeryList.Add(new Surgery(doctorId, endTime, startTime, surgeryCategory, surgeryDate, surgeryId));
            }
            conn.Close();
            return surgeryList;
        }

        public List<Surgery> GetAllSurgeryTypeForToday()
        {
            List<Surgery> surgeryList = new List<Surgery>();
            string today = DateTime.Now.ToString("yyyy'-'MM'-'dd");
            cmd.Connection = conn;
            cmd.CommandText = string.Format("select * from Surgery where SurgeryDate='{0}'", today);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int doctorId = Convert.ToInt32(reader["DoctorId"]);
                decimal endTime = Convert.ToDecimal(reader["EndTime"]);
                decimal startTime = Convert.ToDecimal(reader["StartTime"]);
                string surgeryCategory = reader["SurgeryCategory"].ToString();
                DateTime surgeryDate = Convert.ToDateTime(reader["SurgeryDate"]);
                int surgeryId = Convert.ToInt32(reader["SurgeryId"]);
                surgeryList.Add(new Surgery(doctorId, endTime, startTime, surgeryCategory, surgeryDate, surgeryId));
            }
            conn.Close();
            return surgeryList;
        }

        public Doctor GetDoctorById(int doctorId)
        {
            Doctor doctor = null;
            cmd.Connection = conn;
            cmd.CommandText = string.Format("select * from Doctor where DoctorId={0}", doctorId);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["DoctorId"]);
                string doctorName = reader["DoctorName"].ToString();
                doctor = new Doctor(id, doctorName);
            }
            conn.Close();
            return doctor;
        }

        public DoctorDetails GetDoctorDetails(int doctorId)
        {
            Doctor doctor = GetDoctorById(doctorId);
            List<Specialization> specializations = new List<Specialization>();
            List<Surgery> surgeries = new List<Surgery>();

            cmd.Connection = conn;
            cmd.CommandText = string.Format("select S.SpecializationCode, S.SpecializationName from Doctor D, Specialization S, DoctorSpecialization DS where D.DoctorId={0} and S.SpecializationCode=DS.SpecializationCode and D.DoctorID=DS.DoctorId", doctorId);
            conn.Open();
            SqlDataReader reader1 = cmd.ExecuteReader();
            while (reader1.Read())
            {
                string specializationCode = reader1["SpecializationCode"].ToString();
                string specializationName = reader1["SpecializationName"].ToString();
                specializations.Add(new Specialization(specializationCode,specializationName));
            }
            conn.Close();

            cmd.CommandText = string.Format("select * from Surgery where DoctorId={0}", doctorId);
            conn.Open();
            SqlDataReader reader2 = cmd.ExecuteReader();
            while (reader2.Read())
            {
                int dId = Convert.ToInt32(reader2["DoctorId"]);
                decimal endTime = Convert.ToDecimal(reader2["EndTime"]);
                decimal startTime = Convert.ToDecimal(reader2["StartTime"]);
                string surgeryCategory = reader2["SurgeryCategory"].ToString();
                DateTime surgeryDate = Convert.ToDateTime(reader2["SurgeryDate"]);
                int surgeryId = Convert.ToInt32(reader2["SurgeryId"]);
                surgeries.Add(new Surgery(dId, endTime, startTime, surgeryCategory, surgeryDate, surgeryId));
            }
            conn.Close();
            DoctorDetails doctorDetails = new DoctorDetails(doctorId, doctor.DoctorName, specializations, surgeries);
            return doctorDetails;
        }

        public List<DoctorSpecialization> GetDoctorsBySpecialization(string specializationCode)
        {
            List<DoctorSpecialization> doctorSpecializationList = new List<DoctorSpecialization>();
            cmd.Connection = conn;
            cmd.CommandText = string.Format("select * from DoctorSpecialization where SpecializationCode='{0}'", specializationCode);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int doctorId = Convert.ToInt32(reader["DoctorId"]);
                string spCode = reader["SpecializationCode"].ToString();
                DateTime specializationDate = Convert.ToDateTime(reader["Specializationdate"]);
                doctorSpecializationList.Add(new DoctorSpecialization(doctorId, spCode, specializationDate));
            }
            conn.Close();
            return doctorSpecializationList;
        }

        public Surgery GetSurgeryById(int surgeryId)
        {
            Surgery surgery = null;
            cmd.Connection = conn;
            cmd.CommandText = string.Format("select * from Surgery where SurgeryId={0}", surgeryId);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int doctorId = Convert.ToInt32(reader["DoctorId"]);
                decimal endTime = Convert.ToDecimal(reader["EndTime"]);
                decimal startTime = Convert.ToDecimal(reader["StartTime"]);
                string surgeryCategory = reader["SurgeryCategory"].ToString();
                DateTime surgeryDate = Convert.ToDateTime(reader["SurgeryDate"]);
                int id = Convert.ToInt32(reader["SurgeryId"]);
                surgery = new Surgery(doctorId, endTime, startTime, surgeryCategory, surgeryDate, surgeryId);
            }
            conn.Close();
            return surgery;
        }

        public bool UpdateDoctorDetails(Doctor dObj)
        {
            int rows;
            cmd.Connection = conn;
            cmd.CommandText = string.Format("update Doctor set DoctorName='{0}' where DoctorID={1}", dObj.DoctorName, dObj.DoctorId);
            conn.Open();
            try
            {
                rows = cmd.ExecuteNonQuery();
            }
            catch
            {
                conn.Close();
                return false;
            }
            conn.Close();
            return rows > 0;
        }

        public bool UpdateSurgery(Surgery sObj)
        {
            int rows;
            cmd.Connection = conn;
            cmd.CommandText = string.Format("update Surgery set DoctorId={0}, StartTime={1}, EndTime={2}, SurgeryDate='{3}', SurgeryCategory='{4}' where SurgeryId={5}", sObj.DoctorId, sObj.StartTime, sObj.EndTime, sObj.SurgeryDate, sObj.SurgeryCategory, sObj.SurgeryId);
            conn.Open();
            try
            {
                rows = cmd.ExecuteNonQuery();
            }
            catch
            {
                conn.Close();
                return false;
            }
            conn.Close();
            return rows > 0;
        }

    }
}
