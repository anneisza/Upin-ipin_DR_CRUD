using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CRUDMahasiswaADO
{
    public partial class FormMahasiswa : Form
    {
        //pertemuan 15
        DAL dbLogic = new DAL();

        private readonly SqlConnection conn;
        private readonly string connectionString =
            "Data Source=RIZA\\RIZAFI;Initial Catalog=DBAkademikADO;Integrated Security=True";

        //tambah binding source dan data table
        private BindingSource bindingSource = new BindingSource();
        private DataTable dtMahasiswa = new DataTable();

        public FormMahasiswa()
        {
            InitializeComponent();
            conn = new SqlConnection(DAL.GetConnectionString());
            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
        }

        //DIUBAH DI PERTEMUAN 15
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DAL.GetConnectionString()))
                {
                    conn.Open();
                    MessageBox.Show("Koneksi berhasil!");
                }
                //using (SqlConnection conn = new SqlConnection(connectionString))
                //{
                //    conn.Open();
                //    MessageBox.Show("Koneksi berhasil!");
                //}
            }
            catch (SqlException ex)
            {
                SimpanLog(ex.Message);
                MessageBox.Show("SQL Error : " + ex.Message);
            }
            catch (Exception ex)
            {
                SimpanLog(ex.Message);
                MessageBox.Show("General Error : " + ex.Message);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
            //try
            //{
            //    if (conn.State == System.Data.ConnectionState.Closed)
            //    {
            //        conn.Open();
            //    }

            //    dataGridView1.Rows.Clear();
            //    dataGridView1.Columns.Clear();

            //    dataGridView1.Columns.Add("NIM", "NIM");
            //    dataGridView1.Columns.Add("Nama", "Nama");
            //    dataGridView1.Columns.Add("JenisKelamin", "Jenis Kelamin");
            //    dataGridView1.Columns.Add("Tanggallahir", "Tanggal Lahir");
            //    dataGridView1.Columns.Add("Alamat", "Alamat");
            //    dataGridView1.Columns.Add("KodeProdi", "Kode Prodi");

            //    string query = "SELECT * FROM Mahasiswa";

            //    SqlCommand cmd = new SqlCommand(query, conn);
            //    SqlDataReader reader = cmd.ExecuteReader();

            //    while (reader.Read())
            //    {
            //        dataGridView1.Rows.Add(
            //            reader["NIM"].ToString(),
            //            reader["Nama"].ToString(),
            //            reader["JenisKelamin"].ToString(),
            //            Convert.ToDateTime(reader["Tanggallahir"]).ToShortDateString(),
            //            reader["Alamat"].ToString(),
            //            reader["KodeProdi"].ToString()
            //        );
            //    }

            //    reader.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Gagal menampilkan data: " + ex.Message);
            //}
        }

        //DIUBAH DI PERTEMUAN 15
        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] ConvertImageToBytes(PictureBox pb)
                {     
                    using (MemoryStream ms = new MemoryStream())
                    {
                        pb.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg  );
                        return ms.ToArray();
                    }
                 }
                //// Di btnInsert_Click FormMahasiswa.cs | tambah sendiri
                byte[] imgBytes = fotoMhs.Image != null ? ConvertImageToBytes(fotoMhs) : null;
                //byte[] imgBytes = ConvertImageToBytes(fotoMhs);
                dbLogic.InsertMhs(txtNIM.Text, txtNama.Text, txtAlamat.Text,cmbJK.Text, dtpTanggalLahir.Value.Date, txtKodeProdi.Text,  imgBytes);
                MessageBox.Show("Data mahasiswa berhasil ditambahkan");
                ClearForm();
                LoadData();
            }
            catch (SqlException ex)
            {
                SimpanLog("Rollback Insert :" + ex.Message);
                MessageBox.Show("SQL Error : " + ex.Message);
            }
            catch (Exception ex)
            {
                SimpanLog("General Error :" + ex.Message);
                MessageBox.Show("General Error : " + ex.Message);
            }


            //       SqlConnection conn =
            //           new SqlConnection(connectionString);
            //       conn.Open();

            //       SqlTransaction trans =
            //           conn.BeginTransaction();
            //       try
            //       {

            //           SqlCommand cmd =
            //new SqlCommand(
            //    "sp_InsertMahasiswa",
            //    conn,
            //    trans);

            //           cmd.CommandType =
            //               CommandType.StoredProcedure;

            //           cmd.Parameters.AddWithValue(
            //               "@NIM",
            //               txtNIM.Text);
            //           cmd.Parameters.AddWithValue(
            //               "@Nama",
            //               txtNama.Text);
            //           cmd.Parameters.AddWithValue(
            //               "@JenisKelamin",
            //               cmbJK.Text);
            //           cmd.Parameters.AddWithValue(
            //               "@TanggalLahir",
            //               dtpTanggalLahir.Value.Date);
            //           cmd.Parameters.AddWithValue(
            //               "@Alamat",
            //               txtAlamat.Text);
            //           cmd.Parameters.AddWithValue(
            //               "@KodeProdi",
            //               txtKodeProdi.Text);
            //           cmd.Parameters.AddWithValue(
            //               "@TanggalDaftar",
            //               DateTime.Now);

            //           cmd.ExecuteNonQuery();

            //           SqlCommand cmdLog =
            //               new SqlCommand(
            //                   @"INSERT INTO LogAktivitasSalah(aktivitas,waktu) VALUES(@aktivitas, GETDATE())", conn, trans);

            //           cmdLog.Parameters.AddWithValue(
            //               "@aktivitas",
            //               "INSERT MAHASISWA: " +
            //               txtNIM.Text);

            //           cmdLog.ExecuteNonQuery();

            //           trans.Commit();

            //           MessageBox.Show(
            //               "Data berhasil ditambahkan");

            //           LoadData();
            //       }//Praktikum 3 | di pertemuan 12 yg online || ganti ke prak pert 13
            //catch (SqlException ex)
            //{
            //    trans.Rollback();

            //    SimpanLog(
            //        "ROLLBACK INSERT : " +
            //        ex.Message);

            //    MessageBox.Show(ex.Message);
            //}
            //catch (Exception ex)
            //{
            //    trans.Rollback();

            //    SimpanLog(
            //        "GENERAL ERROR : " +
            //        ex.Message);

            //    MessageBox.Show(ex.Message);
            //}
            //finally
            //{
            //    conn.Close();
            //}


            //try
            //{
            //    using (SqlConnection conn = new SqlConnection(connectionString))
            //    {
            //        //praktikum 10 ini gantinya pakai stored procedure
            //        using (SqlCommand cmd = new SqlCommand("sp_InsertMahasiswa", conn))
            //        {
            //            cmd.CommandType = CommandType.StoredProcedure;

            //            cmd.Parameters.AddWithValue("@NIM", txtNIM.Text);
            //            cmd.Parameters.AddWithValue("@Nama", txtNama.Text);
            //            cmd.Parameters.AddWithValue("@JenisKelamin", cmbJK.Text);
            //            cmd.Parameters.AddWithValue("@Tanggallahir", dtpTanggalLahir.Value.Date);
            //            cmd.Parameters.AddWithValue("@Alamat", txtAlamat.Text);
            //            cmd.Parameters.AddWithValue("@KodeProdi", txtKodeProdi.Text);
            //            cmd.Parameters.AddWithValue("@TanggalDaftar", DateTime.Now);

            //            conn.Open();
            //            cmd.ExecuteNonQuery();
            //        }

            //    }

            //    MessageBox.Show("Data berhasil ditambahkan");
            //    LoadData();
            //} //Praktikum 3 | di pertemuan 12 yg online
            //catch (SqlException ex)
            //{
            //    SimpanLog(ex.Message);

            //    MessageBox.Show("SQL Error : " + ex.Message);
            //}
            //catch (Exception ex)
            //{
            //    SimpanLog(ex.Message);

            //    MessageBox.Show("General Error : " + ex.Message);
            //}
        }


        // Diubah di pertemuan 15
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] ConvertImageToBytes(PictureBox pb)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        pb.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        return ms.ToArray();
                    }
                }
                // ✅ Cek dulu apakah foto null | tambahan sendiri
                byte[] imgBytes = fotoMhs.Image != null ? ConvertImageToBytes(fotoMhs) : null;
                //byte[] imgBytes = ConvertImageToBytes(fotoMhs);
                dbLogic.UpdateMhs(txtNIM.Text, txtNama.Text, txtAlamat.Text, cmbJK.Text, dtpTanggalLahir.Value.Date, txtKodeProdi.Text, imgBytes);
                MessageBox.Show("Data mahasiswa berhasil diubah");
                ClearForm();
                btnLoad.PerformClick();
                //using (SqlConnection conn = new SqlConnection(connectionString))
                //{
                //    using (SqlCommand cmd = new SqlCommand("sp_UpdateMahasiswa", conn))
                //    {
                //        cmd.CommandType = CommandType.StoredProcedure;

                //        cmd.Parameters.AddWithValue("@NIM", txtNIM.Text);
                //        cmd.Parameters.AddWithValue("@Nama", txtNama.Text);
                //        cmd.Parameters.AddWithValue("@JenisKelamin", cmbJK.Text);
                //        cmd.Parameters.AddWithValue("@TanggalLahir", dtpTanggalLahir.Value.Date);
                //        cmd.Parameters.AddWithValue("@Alamat", txtAlamat.Text);
                //        cmd.Parameters.AddWithValue("@KodeProdi", txtKodeProdi.Text);

                //        conn.Open();
                //        int result = cmd.ExecuteNonQuery();

                //        //

                //        if (result < 0)
                //        {
                //            MessageBox.Show("Data berhasil diupdate");
                //            ClearForm();
                //            btnLoad.PerformClick();
                //        }
                //        else
                //        {
                //            MessageBox.Show("Data tidak ditemukan");
                //        }

                //    }
                //}

            }
            catch (SqlException ex)
            {
                SimpanLog(ex.Message);
                MessageBox.Show("SQL Error : " + ex.Message);
            }
            catch (Exception ex)
            {
                SimpanLog(ex.Message);
                MessageBox.Show("General Error : " + ex.Message);
            }
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            //}
        }

        //DIubah di pertemuan 15
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dg = MessageBox.Show(
                    "Yakin ingin menghapus data?",
                    "Konfirmasi",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (dg == DialogResult.Yes)
                {
                    dbLogic.DeleteMhs(txtNIM.Text);
                    MessageBox.Show("Data mahasiswa berhasil dihapus");
                    ClearForm();
                    btnLoad.PerformClick();
                }

                //DialogResult resultConfirm = MessageBox.Show(
                //    "Yakin ingin menghapus data?",
                //    "Konfirmasi",
                //    MessageBoxButtons.YesNo,
                //    MessageBoxIcon.Question);

                //if (resultConfirm == DialogResult.Yes)
                //{
                //using (SqlConnection conn = new SqlConnection(connectionString))
                //{
                //    //praktikum 10 ini gantinya pakai stored procedure
                //    using (SqlCommand cmd = new SqlCommand("sp_DeleteMahasiswa", conn))
                //    {
                //        cmd.CommandType = CommandType.StoredProcedure;

                //        cmd.Parameters.Add("@NIM", SqlDbType.Char, 11).Value = txtNIM.Text;

                //        conn.Open();
                //        int rowAffected = cmd.ExecuteNonQuery();


                //        if (rowAffected < 0)
                //        {
                //            MessageBox.Show("Data berhasil dihapus");
                //            LoadData();
                //        }
                //        else
                //        {
                //            MessageBox.Show("Data tidak ditemukan");
                //        }
                //    }
                //}
                //}


            }
            catch (SqlException ex)
            {
                SimpanLog(ex.Message);
                MessageBox.Show("SQL Error : " + ex.Message);
            }
            catch (Exception ex)
            {
                SimpanLog(ex.Message);
                MessageBox.Show("General Error : " + ex.Message);
            }
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            //}
        }


        //Diubah di pertemuan 15
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataRow row = ((DataRowView)bindingSource[e.RowIndex]).Row;
                txtNIM.Text = row[0].ToString();
                txtNama.Text = row[1].ToString();
                cmbJK.Text = row[2].ToString();
                dtpTanggalLahir.Value = Convert.ToDateTime(row[3]);
                txtAlamat.Text = row[4].ToString();
                txtKodeProdi.Text = row[6].ToString();

                // Mapping NamaProdi ke KodeProdi | Sendiri
                string namaProdi = row[6].ToString().Trim();
                string kodeProdi;
                // ✅ Mapping NamaProdi ke KodeProdi
                switch (namaProdi)
                {
                    case "Teknik Informatika":
                    case "Teknologi Informasi":
                        kodeProdi = "TI01"; break;
                    case "Sistem Informasi":
                        kodeProdi = "SI01"; break;
                    case "Manajemen Informatika":
                        kodeProdi = "MI01"; break;
                    default:
                        kodeProdi = namaProdi; // fallback
                        break;
                }

                if (row[5] != DBNull.Value)
                {
                    byte[] imgBytes = (byte[])row[5];
                    using (MemoryStream ms = new MemoryStream(imgBytes))
                    {
                        //ganti sendiri
                        //fotoMhs.Image = Image.FromStream(ms);
                        fotoMhs.Image = new Bitmap(Image.FromStream(ms));

                        fotoMhs.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
                else
                {
                    fotoMhs.Image = null;
                }

                txtNIM.Enabled = false;
            }
            //if (e.RowIndex >= 0)
            //{
            //    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            //    txtNIM.Text = row.Cells["NIM"].Value.ToString();
            //    txtNama.Text = row.Cells["Nama"].Value.ToString();
            //    cmbJK.Text = row.Cells["JenisKelamin"].Value.ToString();
            //    dtpTanggalLahir.Value = Convert.ToDateTime(row.Cells["Tanggallahir"].Value);
            //    txtAlamat.Text = row.Cells["Alamat"].Value.ToString();
            //    txtKodeProdi.Text = row.Cells["NamaProdi"].Value.ToString();
            //}
        }

        private void ClearForm()
        {
            //PERTEMUAN 15
            txtNIM.Enabled = true;
            txtNIM.Clear();
            txtNama.Clear();
            cmbJK.SelectedIndex = -1;
            txtAlamat.Clear();
            txtKodeProdi.Clear();
            dtpTanggalLahir.Value = DateTime.Now;
            fotoMhs.Image = null;
            txtNIM.Focus();
        }

        private void FormMahasiswa_Load(object sender, EventArgs e)
        {
            cmbJK.Items.Clear();
            cmbJK.Items.Add("L");
            cmbJK.Items.Add("P");

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.CellClick += dataGridView1_CellClick;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormMahasiswa_Load_1(object sender, EventArgs e)
        {
            // ComboBox JK manual
            cmbJK.DataSource = new string[] { "L", "P" };

            // setting Grid
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // BindingNavigator
            bindingNavigator1.BindingSource = bindingSource;

            LoadData();

            // TODO: This line of code loads data into the 'dBAkademikADODataSet.Mahasiswa' table. You can move, or remove it, as needed.
            this.mahasiswaTableAdapter.Fill(this.dBAkademikADODataSet.Mahasiswa);

        }


        //Ada diganti soalnya ada prakikum 10 | Load Data
        private void LoadData()
        {
            //PERTEMUAN 15
            try
            {
                bindingSource.DataSource = dbLogic.GetMhs();
                dataGridView1.DataSource = bindingSource;
                DataGridViewImageColumn fotoColoumn = (DataGridViewImageColumn)dataGridView1.Columns["Foto"];
                fotoColoumn.ImageLayout = DataGridViewImageCellLayout.Stretch;

                HitungTotal();

                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    Console.WriteLine("Name: " + col.Name + " | DataPropertyName: " + col.DataPropertyName);
                }

                dataGridView1.Enabled = true;
                btnImpDB.Enabled = false;
                btnInsert.Enabled = true;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnCari.Enabled = true;
                btnLoad.Enabled = true;
                btnResetData.Enabled = true;
                btnTestInjection.Enabled = true;
            }
            catch (Exception ex)
            {
                SimpanLog(ex.Message);
                MessageBox.Show("Gagal load data: " + ex.Message);
            }


            //PRAKTIKUM SEBELUMNYA
            //using (SqlConnection conn = new SqlConnection(connectionString))
            //{
            //    using (SqlCommand cmd = new SqlCommand("sp_GetMahasiswa", conn))
            //    {
            //        cmd.CommandType = CommandType.StoredProcedure;

            //        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            //        {
            //            dtMahasiswa = new DataTable();
            //            da.Fill(dtMahasiswa);

            //            bindingSource.DataSource = dtMahasiswa;
            //            dataGridView1.DataSource = bindingSource;

            //            BindControls();
            //        }
            //    }
            //}


            //try
            //{
            //    using (SqlConnection conn = new SqlConnection(connectionString))
            //    {
            //        conn.Open();

            //        string query = "SELECT * FROM vwMahasiswaPublic";

            //        using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
            //        {
            //            dtMahasiswa = new DataTable();
            //            da.Fill(dtMahasiswa);

            //            bindingSource.DataSource = dtMahasiswa;
            //            dataGridView1.DataSource = bindingSource;

            //            BindControls();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Gagal load data: " + ex.Message);
            //}
        }

        private void BindControls()
        {
            txtNIM.DataBindings.Clear();
            txtNama.DataBindings.Clear();
            cmbJK.DataBindings.Clear();
            dtpTanggalLahir.DataBindings.Clear();
            txtAlamat.DataBindings.Clear();
            txtKodeProdi.DataBindings.Clear();

            txtNIM.DataBindings.Add("Text", bindingSource, "NIM");
            txtNama.DataBindings.Add("Text", bindingSource, "Nama");
            cmbJK.DataBindings.Add("Text", bindingSource, "JenisKelamin");
            dtpTanggalLahir.DataBindings.Add("Value", bindingSource, "Tanggallahir");
            txtAlamat.DataBindings.Add("Text", bindingSource, "Alamat");
            txtKodeProdi.DataBindings.Add("Text", bindingSource, "NamaProdi");
        }

        //Diuabh di pertemuan 15
        private void btnResetData_Click(object sender, EventArgs e)
        {
            try
            {
                dbLogic.resetData();
                MessageBox.Show("Data berhasil direset");
                LoadData();
                //using (SqlConnection conn = new SqlConnection(connectionString))
                //{
                //    conn.Open();

                //    string query = @"
                //IF OBJECT_ID('dbo.Mahasiswa_Backup') IS NOT NULL
                //BEGIN
                //    DELETE FROM dbo.Mahasiswa;
                //    INSERT INTO dbo.Mahasiswa
                //    SELECT * FROM dbo.Mahasiswa_Backup;
                //END";

                //    using (SqlCommand cmd = new SqlCommand(query, conn))
                //    {
                //        cmd.ExecuteNonQuery();
                //    }
                //}

                //MessageBox.Show("Data berhasil direset");
                //LoadData();
            }
            catch (SqlException ex)
            {
                SimpanLog(ex.Message);
                MessageBox.Show("SQL Error : " + ex.Message);
            }
            catch (Exception ex)
            {
                SimpanLog(ex.Message);
                MessageBox.Show("General Error : " + ex.Message);
            }
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Reset gagal: " + ex.Message);
            //}

        }

        //private void btnTestInjection_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        using (SqlConnection conn =
        //            new SqlConnection(connectionString))
        //        {
        //            string query =
        //                "UPDATE Mahasiswa SET Nama='" +
        //                txtNama.Text +
        //                "' WHERE NIM='" +
        //                txtNIM.Text + "'";

        //            SqlCommand cmd =
        //                new SqlCommand(query, conn);

        //            conn.Open();

        //            cmd.ExecuteNonQuery();

        //            MessageBox.Show("Update berhasil");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //diubah di pertemuan 15
        private void btnTestInjection_Click(object sender, EventArgs e)
        {
            try
            {
                dbLogic.testInject(txtNIM.Text);
                LoadData();
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("safe"))
                {
                    SimpanLog(ex.Message);
                    MessageBox.Show("SQL Error : Unsafe UPDATE operation not allowed");
                }
                else
                {
                    SimpanLog(ex.Message);
                    MessageBox.Show("SQL Error : " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                SimpanLog(ex.Message);
                MessageBox.Show("General Error : " + ex.Message);
            }
            //try
            //{
            //    using (SqlConnection conn =
            //        new SqlConnection(connectionString))
            //    {
            //        string query =
            //            "UPDATE Mahasiswa SET Nama='" +
            //            txtNama.Text +
            //            "' WHERE NIM='" +
            //            txtNIM.Text + "'";

            //        SqlCommand cmd =
            //            new SqlCommand(query, conn);

            //        conn.Open();

            //        cmd.ExecuteNonQuery();

            //        MessageBox.Show("Update berhasil");
            //    }
            //}
            //catch (SqlException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        /* PRAKTIKUM 10 | */
        //Hitung Total(Output Parameter)
        private void HitungTotal()
        {
            try
            {
                // pertemuan 15
                int total = (dbLogic.CountMhs().Equals(DBNull.Value)) ? 0 : dbLogic.CountMhs();
                lblTotal.Text = "Total Mahasiswa: " + total;


                //INI PERTEMUAN SEBELUMNYA
                //using (SqlConnection conn = new SqlConnection(connectionString))
                //{
                //    using (SqlCommand cmd = new SqlCommand("sp_CountMahasiswa", conn))
                //    {
                //        cmd.CommandType = CommandType.StoredProcedure;

                //        SqlParameter outputParam = new SqlParameter("@Total", SqlDbType.Int);
                //        outputParam.Direction = ParameterDirection.Output;
                //        cmd.Parameters.Add(outputParam);

                //        conn.Open();
                //        cmd.ExecuteNonQuery();

                //        lblTotal.Text = "Total Mahasiswa: " + outputParam.Value.ToString();


                //    }
                //}
            }
            catch (Exception ex)
            {
                SimpanLog(ex.Message);
                MessageBox.Show("Gagal load data: " + ex.Message);
            }
        }

        //PRAKTIKUM 2 | di Pertemuan 12
        //DIUBAH DI PERTEMUAN 15
        private void SimpanLog(string message)
        {
            dbLogic.InsertLog(message);
            //using (SqlConnection conn = new SqlConnection(connectionString))
            //{
            //    string query = @"INSERT INTO LogError 
            //                VALUES(GETDATE(), @pesan)";
            //    using (SqlCommand cmd = new SqlCommand(query, conn))
            //    {
            //        cmd.Parameters.AddWithValue("@pesan", message);

            //        conn.Open();
            //        cmd.ExecuteNonQuery();
            //    }
            //}
        }

        private void btnRekap_Click(object sender, EventArgs e)
        {
            RekapData fm3 = new RekapData();
            fm3.Show();
            this.Hide();
        }

        //pertemuan 15
        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fotoMhs.Image = Image.FromFile(ofd.FileName);
                fotoMhs.SizeMode = PictureBoxSizeMode.StretchImage;
            }

        }

        private void btnImpExcel_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog { Filter = "Excel Workbook|*.xlsx" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                    {
                        using (var reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                                {
                                    UseHeaderRow = true
                                }
                            });

                            DataTable dt = result.Tables[0];
                            dataGridView1.DataSource = dt;
                            dataGridView1.Enabled = false;

                            btnImpDB.Enabled = true;
                            btnInsert.Enabled = false;
                            btnUpdate.Enabled = false;
                            btnDelete.Enabled = false;
                            btnCari.Enabled = false;
                            btnLoad.Enabled = false;
                            btnResetData.Enabled = false;
                            btnTestInjection.Enabled = false;
                        }
                    }
                }
            }

        }

        private void btnImpDB_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)dataGridView1.DataSource;

                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Tidak ada data untuk diimport.");
                    return;
                }

                int sukses = 0;

                foreach (DataRow row in dt.Rows)
                {
                    string nim = row["NIM"].ToString().Trim();
                    string nama = row["Nama"].ToString().Trim();
                    string jk = row["JenisKelamin"].ToString().Trim();
                    string alamat = row["Alamat"].ToString().Trim();
                    string kodeProdi = row["NamaProdi"].ToString().Trim();
                    string fotoPath = row.Table.Columns.Contains("FotoPath")
                        ? row["FotoPath"].ToString().Trim()
                        : string.Empty;

                    if (string.IsNullOrEmpty(nim) || string.IsNullOrEmpty(nama))
                        continue;

                    DateTime tglLahir;
                    if (!DateTime.TryParse(row["TanggalLahir"].ToString(), out tglLahir))
                        continue;

                    byte[] ConvertImagePath(string path)
                    {
                        if (string.IsNullOrWhiteSpace(path))
                            return null;

                        if (!File.Exists(path))
                            return null;

                        return File.ReadAllBytes(path);
                    }

                    byte[] fotoBytes = ConvertImagePath(fotoPath);

                    //Tambahan sendiri mapping NamaProdi ke KodeProdi
                    string namaProdi = row["NamaProdi"].ToString().Trim();

                    // ✅ Mapping NamaProdi ke KodeProdi
                    switch (namaProdi)
                    {
                        case "Teknik Informatika":
                        case "Teknologi Informasi":
                            kodeProdi = "TI01"; break;
                        case "Sistem Informasi":
                            kodeProdi = "SI01"; break;
                        case "Manajemen Informatika":
                            kodeProdi = "MI01"; break;
                        default:
                            kodeProdi = namaProdi; // fallback
                            break;
                    }
                    dbLogic.InsertMhs(nim, nama, alamat, jk, tglLahir.Date, kodeProdi, fotoBytes);
                    sukses++;
                }

                MessageBox.Show("Data mahasiswa berhasil ditambahkan");
                ClearForm();
                LoadData();
            }
            catch (SqlException ex)
            {
                SimpanLog("Rollback Insert : " + ex.Message);
                MessageBox.Show("SQL Error : " + ex.Message);
            }
            catch (Exception ex)
            {
                SimpanLog("General Error : " + ex.Message);
                MessageBox.Show("General Error : " + ex.Message);
            }
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = dbLogic.GetMhsByNIM(txtNIM.Text);
                if (dt.Rows.Count > 0)
                {
                    // --- BAGIAN FILTER DATA GRID VIEW ---
                    // Mengarahkan DataSource bindingSource ke data hasil pencarian agar dgv ter-filter
                    bindingSource.DataSource = dt;
                    dataGridView1.DataSource = bindingSource;
                    //
                    DataRow row = dt.Rows[0];
                    txtNama.Text = row["Nama"].ToString();
                    cmbJK.Text = row["JenisKelamin"].ToString();
                    dtpTanggalLahir.Value = Convert.ToDateTime(row["TanggalLahir"]);
                    txtAlamat.Text = row["Alamat"].ToString();
                    txtKodeProdi.Text = row["NamaProdi"].ToString();
                    txtNIM.Enabled = false;

                    // Mapping NamaProdi ke KodeProdi | Sendiri
                    string namaProdi = row["NamaProdi"].ToString().Trim();
                    string kodeProdi;
                    // ✅ Mapping NamaProdi ke KodeProdi
                    switch (namaProdi)
                    {
                        case "Teknik Informatika":
                        case "Teknologi Informasi":
                            kodeProdi = "TI01"; break;
                        case "Sistem Informasi":
                            kodeProdi = "SI01"; break;
                        case "Manajemen Informatika":
                            kodeProdi = "MI01"; break;
                        default:
                            kodeProdi = namaProdi; // fallback
                            break;
                    }
                    //string namaProdi = row["NamaProdi"].ToString().Trim();

                    //if (namaProdi == "Teknik Informatika")
                    //{
                    //    txtKodeProdi.Text = "TI01";
                    //}
                    //else if (namaProdi == "Sistem Informasi")
                    //{
                    //    txtKodeProdi.Text = "SI01";
                    //}
                    //else if (namaProdi == "Manajemen Informatika")
                    //{
                    //    txtKodeProdi.Text = "MI01"; // Sesuaikan dengan kode di databasemu
                    //}
                    //else
                    //{
                    //    // Jika tidak ada yang cocok, tampilkan nama prodi aslinya atau kosongkan
                    //    txtKodeProdi.Text = namaProdi;
                    //}
                }
                else
                {
                    MessageBox.Show("Data dengan NIM tersebut tidak ditemukan");
                }

            }
            catch (Exception ex)
            {
                SimpanLog(ex.Message);
                MessageBox.Show("Gagal mencari data: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadData();
        }
    }
}