using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDMahasiswaADO
{
    public class DAL
    {
        //static string connectionString = "Data Source=RIZA\\RIZAFI;Initial Catalog=DBAkademikADO;User ID=sa;Password=anneiszA1.";

        SqlDataAdapter da;
        DataTable dtMahasiswa;
        DataTable dtProdi;

        public static string GetConnectionString()
        {
            string connectionString = $"Data Source={GetLoacalIPAddress()};Initial Catalog=DBAkademikADO;User ID=sa;Password=anneiszA1.;";
            return connectionString;
        }
        SqlConnection conn = new SqlConnection(GetConnectionString());

        public int CountMhs()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            SqlCommand cmd = new SqlCommand("sp_CountMahasiswa", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter outputParam = new SqlParameter("@Total", SqlDbType.Int);
            outputParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outputParam);

            cmd.ExecuteNonQuery();

            return Convert.ToInt32(outputParam.Value);
        }

        public DataTable GetMhs()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            SqlCommand cmd = new SqlCommand("sp_GetMahasiswa", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            da = new SqlDataAdapter(cmd);

            dtMahasiswa = new DataTable();
            da.Fill(dtMahasiswa);

            return dtMahasiswa;

        }

        public void InsertMhs(string nim, string nama, string alamat, string jenisKelamin, DateTime tanggalLahir, string kodeProdi, byte[] foto)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            SqlTransaction trans = conn.BeginTransaction();
            try
            {

                SqlCommand command = new SqlCommand("sp_InsertMahasiswa", conn, trans);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@pNIM", nim);
                command.Parameters.AddWithValue("@pNama", nama);
                command.Parameters.AddWithValue("@pAlamat", alamat);
                command.Parameters.AddWithValue("@pTanggalLahir", tanggalLahir);
                command.Parameters.AddWithValue("@pJenisKelamin", jenisKelamin);
                command.Parameters.AddWithValue("@pKodeProdi", kodeProdi);
                command.Parameters.AddWithValue("@pFoto", foto);
                // Di DAL.cs InsertMhs() | Tambah sendiri
                //command.Parameters.AddWithValue("@pFoto", foto != null ? (object)foto : DBNull.Value);

                command.ExecuteNonQuery();
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw ex;
            }
            finally
            {
                conn.Close();
            }

        }

        public void UpdateMhs(string nim, string nama, string alamat, string jenisKelamin, DateTime tanggalLahir, string kodeProdi, byte[] foto)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand command = new SqlCommand("sp_UpdateMahasiswa", conn);

            command.Parameters.AddWithValue("@pNIM", nim);
            command.Parameters.AddWithValue("@pNama", nama);
            command.Parameters.AddWithValue("@pAlamat", alamat);
            command.Parameters.AddWithValue("@pTanggalLahir", tanggalLahir);
            command.Parameters.AddWithValue("@pJenisKelamin", jenisKelamin);
            command.Parameters.AddWithValue("@pKodeProdi", kodeProdi);
            command.Parameters.AddWithValue("@pFoto", foto);
            //  Handle null foto | sendiri
            //command.Parameters.AddWithValue("@pFoto", foto != null ? (object)foto : DBNull.Value);

            command.CommandType = CommandType.StoredProcedure;

            command.ExecuteNonQuery();
        }

        public void DeleteMhs(string nim)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand command = new SqlCommand("sp_DeleteMahasiswa", conn);
            command.Parameters.AddWithValue("@NIM", nim);
            command.CommandType = CommandType.StoredProcedure;

            command.ExecuteNonQuery();
        }

        public void resetData()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            string deleteQuery = "DELETE FROM Mahasiswa";
            SqlCommand cmdDelete = new SqlCommand(deleteQuery, conn);
            cmdDelete.ExecuteNonQuery();

            string insertQuery = @"
                    INSERT INTO Mahasiswa
                    SELECT * FROM Mahasiswa_Backup";
            SqlCommand cmdInsert = new SqlCommand(insertQuery, conn);
            cmdInsert.ExecuteNonQuery();
        }

        public void testInject(string nim)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            string query = "UPDATE Mahasiswa SET Nama='HACKED' where NIM = " + nim;

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
        }

        public DataTable GetMhsByNIM(string nim)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            SqlCommand cmd = new SqlCommand("sp_GetMahasiswaByNIM", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@pNIM", nim);
            da = new SqlDataAdapter(cmd);

            dtMahasiswa = new DataTable();
            da.Fill(dtMahasiswa);

            return dtMahasiswa;
        }

        public void InsertLog(string message)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand command = new SqlCommand("sp_LogMessage", conn);

            command.Parameters.AddWithValue("psn", message);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
        }

        public DataTable getProdi()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            SqlCommand cmd = new SqlCommand("select NamaProdi from ProgramStudi", conn);
            cmd.CommandType = CommandType.Text;
            dtProdi = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dtProdi);

            return dtProdi;
        }
    }
}
