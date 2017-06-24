namespace SatHachB2
{
    partial class BaoCao
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btn_indsthisinh = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbb_dotthi = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.viewBcKetQuanamDatBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ThiB2DataSet = new SatHachB2.ThiB2DataSet();
            this.ThiSinhBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ThiSinhTableAdapter = new SatHachB2.ThiB2DataSetTableAdapters.ThiSinhTableAdapter();
            this.view_BcKetQuanamDatTableAdapter = new SatHachB2.ThiB2DataSetTableAdapters.view_BcKetQuanamDatTableAdapter();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.viewBcKetQuanamDatBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThiB2DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThiSinhBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.viewBcKetQuanamDatBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SatHachB2.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 55);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1268, 524);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // btn_indsthisinh
            // 
            this.btn_indsthisinh.Location = new System.Drawing.Point(0, 1);
            this.btn_indsthisinh.Name = "btn_indsthisinh";
            this.btn_indsthisinh.Size = new System.Drawing.Size(75, 23);
            this.btn_indsthisinh.TabIndex = 1;
            this.btn_indsthisinh.Text = "Thí sinh";
            this.btn_indsthisinh.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Kết quả";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBox3);
            this.panel1.Controls.Add(this.comboBox2);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.cbb_dotthi);
            this.panel1.Location = new System.Drawing.Point(81, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(402, 48);
            this.panel1.TabIndex = 3;
            // 
            // cbb_dotthi
            // 
            this.cbb_dotthi.FormattingEnabled = true;
            this.cbb_dotthi.Location = new System.Drawing.Point(132, 17);
            this.cbb_dotthi.Name = "cbb_dotthi";
            this.cbb_dotthi.Size = new System.Drawing.Size(121, 21);
            this.cbb_dotthi.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(274, 7);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 31);
            this.button2.TabIndex = 6;
            this.button2.Text = "Xem báo cáo";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Tất cả",
            "Nam",
            "Nữ"});
            this.comboBox2.Location = new System.Drawing.Point(3, 17);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(52, 21);
            this.comboBox2.TabIndex = 7;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "Tất cả",
            "Đạt",
            "Không đạt"});
            this.comboBox3.Location = new System.Drawing.Point(64, 17);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(52, 21);
            this.comboBox3.TabIndex = 8;
            // 
            // viewBcKetQuanamDatBindingSource
            // 
            this.viewBcKetQuanamDatBindingSource.DataMember = "view_BcKetQuanamDat";
            this.viewBcKetQuanamDatBindingSource.DataSource = this.ThiB2DataSet;
            // 
            // ThiB2DataSet
            // 
            this.ThiB2DataSet.DataSetName = "ThiB2DataSet";
            this.ThiB2DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ThiSinhBindingSource
            // 
            this.ThiSinhBindingSource.DataMember = "ThiSinh";
            this.ThiSinhBindingSource.DataSource = this.ThiB2DataSet;
            // 
            // ThiSinhTableAdapter
            // 
            this.ThiSinhTableAdapter.ClearBeforeFill = true;
            // 
            // view_BcKetQuanamDatTableAdapter
            // 
            this.view_BcKetQuanamDatTableAdapter.ClearBeforeFill = true;
            // 
            // BaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1268, 579);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_indsthisinh);
            this.Controls.Add(this.reportViewer1);
            this.Name = "BaoCao";
            this.Text = "BaoCao";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.BaoCao_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.viewBcKetQuanamDatBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThiB2DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThiSinhBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ThiSinhBindingSource;
        private ThiB2DataSet ThiB2DataSet;
        private ThiB2DataSetTableAdapters.ThiSinhTableAdapter ThiSinhTableAdapter;
        private System.Windows.Forms.Button btn_indsthisinh;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cbb_dotthi;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.BindingSource viewBcKetQuanamDatBindingSource;
        private ThiB2DataSetTableAdapters.view_BcKetQuanamDatTableAdapter view_BcKetQuanamDatTableAdapter;
    }
}