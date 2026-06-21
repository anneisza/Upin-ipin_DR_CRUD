using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CRUDMahasiswaADO
{
    public partial class Report : Form
    {
        DAL dbLogic = new DAL();
        static string connectionString = "Data Source=RIZA\\RIZAFI;Initial Catalog=DBAkademikADO;User ID=sa;Password=anneiszA1.";
        SqlConnection conn;
        SqlDataAdapter da;
        DataTable dtMahasiswa;

        CrystalReport1 listMahasiswa = new CrystalReport1();

        string prodi { get; set; }
        DateTime tglmasuk { get; set; }

        //diubah di pertemuan 15
        public Report(string Prodi, DateTime TglMasuk)
        {
            InitializeComponent();
            //conn = new SqlConnection(connectionString);

            prodi = Prodi;
            tglmasuk = TglMasuk;

            try
            {
                DataTable dtMahasiswa = dbLogic.getDataRekap(prodi, tglmasuk);

                listMahasiswa.SetDataSource(dtMahasiswa);
                crystalReportViewer1.ReportSource = listMahasiswa;
                crystalReportViewer1.Refresh();


                //if (conn.State == ConnectionState.Closed)
                //{
                //    conn.Open();
                //}

                //SqlCommand cmd = new SqlCommand("sp_Report", conn);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@inProdi", prodi);
                //cmd.Parameters.AddWithValue("@inTgLMsuk", tglmasuk.Year);

                //da = new SqlDataAdapter(cmd);
                //dtMahasiswa = new DataTable();
                //da.Fill(dtMahasiswa);

                //conn.Close();

                //// Mengirim data hasil query ke dalam Crystal Report
                //listMahasiswa.SetDataSource(dtMahasiswa);
                //crystalReportViewer1.ReportSource = listMahasiswa;
                //crystalReportViewer1.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal load data: " + ex.Message);
            }
        }

        private void CrystalReport14_InitReport(object sender, EventArgs e)
        {

        }
    }
}
