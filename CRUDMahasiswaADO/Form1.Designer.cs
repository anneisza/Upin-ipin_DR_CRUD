namespace CRUDMahasiswaADO
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNIM = new System.Windows.Forms.TextBox();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.txtAlamat = new System.Windows.Forms.TextBox();
            this.txtKodeProdi = new System.Windows.Forms.TextBox();
            this.cmbJK = new System.Windows.Forms.ComboBox();
            this.dtpTanggalLahir = new System.Windows.Forms.DateTimePicker();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "NIM";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(333, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 16);
            this.label2.TabIndex = 1;
            // 
            // label_2
            // 
            this.label_2.AutoSize = true;
            this.label_2.Location = new System.Drawing.Point(61, 64);
            this.label_2.Name = "label_2";
            this.label_2.Size = new System.Drawing.Size(44, 16);
            this.label_2.TabIndex = 2;
            this.label_2.Text = "Nama";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(61, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tanggal Lahir";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Jenis Kelamin";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(61, 266);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Kode Prodi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Alamat";
            // 
            // txtNIM
            // 
            this.txtNIM.Location = new System.Drawing.Point(189, 16);
            this.txtNIM.Name = "txtNIM";
            this.txtNIM.Size = new System.Drawing.Size(328, 22);
            this.txtNIM.TabIndex = 7;
            // 
            // txtNama
            // 
            this.txtNama.Location = new System.Drawing.Point(189, 64);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(328, 22);
            this.txtNama.TabIndex = 8;
            this.txtNama.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // txtAlamat
            // 
            this.txtAlamat.Location = new System.Drawing.Point(189, 185);
            this.txtAlamat.Multiline = true;
            this.txtAlamat.Name = "txtAlamat";
            this.txtAlamat.Size = new System.Drawing.Size(328, 61);
            this.txtAlamat.TabIndex = 9;
            // 
            // txtKodeProdi
            // 
            this.txtKodeProdi.Location = new System.Drawing.Point(189, 266);
            this.txtKodeProdi.Name = "txtKodeProdi";
            this.txtKodeProdi.Size = new System.Drawing.Size(121, 22);
            this.txtKodeProdi.TabIndex = 10;
            // 
            // cmbJK
            // 
            this.cmbJK.AccessibleDescription = "";
            this.cmbJK.FormattingEnabled = true;
            this.cmbJK.Items.AddRange(new object[] {
            "L",
            "P"});
            this.cmbJK.Location = new System.Drawing.Point(189, 110);
            this.cmbJK.Name = "cmbJK";
            this.cmbJK.Size = new System.Drawing.Size(121, 24);
            this.cmbJK.TabIndex = 13;
            // 
            // dtpTanggalLahir
            // 
            this.dtpTanggalLahir.Location = new System.Drawing.Point(189, 150);
            this.dtpTanggalLahir.Name = "dtpTanggalLahir";
            this.dtpTanggalLahir.Size = new System.Drawing.Size(212, 22);
            this.dtpTanggalLahir.TabIndex = 14;
            this.dtpTanggalLahir.Value = new System.DateTime(2026, 4, 10, 0, 0, 0, 0);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(561, 16);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(138, 23);
            this.btnConnect.TabIndex = 15;
            this.btnConnect.Text = "Membuka Koneksi";
            this.btnConnect.UseVisualStyleBackColor = true;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(561, 64);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(138, 23);
            this.btnLoad.TabIndex = 16;
            this.btnLoad.Text = "Menampilkan Data";
            this.btnLoad.UseVisualStyleBackColor = true;
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(561, 111);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(138, 23);
            this.btnInsert.TabIndex = 17;
            this.btnInsert.Text = "Menambah Data";
            this.btnInsert.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(561, 147);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(138, 25);
            this.btnUpdate.TabIndex = 18;
            this.btnUpdate.Text = "Mengubah Data";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(561, 185);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(138, 29);
            this.btnDelete.TabIndex = 19;
            this.btnDelete.Text = "Menghapus Data";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(64, 301);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(635, 137);
            this.dataGridView1.TabIndex = 20;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.dtpTanggalLahir);
            this.Controls.Add(this.cmbJK);
            this.Controls.Add(this.txtKodeProdi);
            this.Controls.Add(this.txtAlamat);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.txtNIM);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label_2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNIM;
        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.TextBox txtAlamat;
        private System.Windows.Forms.TextBox txtKodeProdi;
        private System.Windows.Forms.ComboBox cmbJK;
        private System.Windows.Forms.DateTimePicker dtpTanggalLahir;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

