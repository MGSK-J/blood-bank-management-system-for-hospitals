
namespace Blood_Bank
{
    partial class Director_Form
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.viewAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewAdnEditAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backToTheMainMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutWhatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userManualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutSoftwareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.requestedBloodUnits = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbBloodType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbHospital = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bloodUnitChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.requestedBloodUnits)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bloodUnitChart)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewAccountToolStripMenuItem,
            this.aboutWhatToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1200, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // viewAccountToolStripMenuItem
            // 
            this.viewAccountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewAdnEditAccountToolStripMenuItem,
            this.backToTheMainMenuToolStripMenuItem});
            this.viewAccountToolStripMenuItem.Name = "viewAccountToolStripMenuItem";
            this.viewAccountToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.viewAccountToolStripMenuItem.Text = "View Account";
            // 
            // viewAdnEditAccountToolStripMenuItem
            // 
            this.viewAdnEditAccountToolStripMenuItem.Name = "viewAdnEditAccountToolStripMenuItem";
            this.viewAdnEditAccountToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.viewAdnEditAccountToolStripMenuItem.Text = "View Adn Edit Account";
            this.viewAdnEditAccountToolStripMenuItem.Click += new System.EventHandler(this.viewAdnEditAccountToolStripMenuItem_Click);
            // 
            // backToTheMainMenuToolStripMenuItem
            // 
            this.backToTheMainMenuToolStripMenuItem.Name = "backToTheMainMenuToolStripMenuItem";
            this.backToTheMainMenuToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.backToTheMainMenuToolStripMenuItem.Text = "Back To The Main Menu";
            this.backToTheMainMenuToolStripMenuItem.Click += new System.EventHandler(this.backToTheMainMenuToolStripMenuItem_Click);
            // 
            // aboutWhatToolStripMenuItem
            // 
            this.aboutWhatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userManualToolStripMenuItem,
            this.aboutSoftwareToolStripMenuItem});
            this.aboutWhatToolStripMenuItem.Name = "aboutWhatToolStripMenuItem";
            this.aboutWhatToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.aboutWhatToolStripMenuItem.Text = "About What";
            // 
            // userManualToolStripMenuItem
            // 
            this.userManualToolStripMenuItem.Name = "userManualToolStripMenuItem";
            this.userManualToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.userManualToolStripMenuItem.Text = "User Manual";
            this.userManualToolStripMenuItem.Click += new System.EventHandler(this.userManualToolStripMenuItem_Click);
            // 
            // aboutSoftwareToolStripMenuItem
            // 
            this.aboutSoftwareToolStripMenuItem.Name = "aboutSoftwareToolStripMenuItem";
            this.aboutSoftwareToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.aboutSoftwareToolStripMenuItem.Text = "About Software";
            this.aboutSoftwareToolStripMenuItem.Click += new System.EventHandler(this.aboutSoftwareToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnTransfer);
            this.groupBox1.Controls.Add(this.requestedBloodUnits);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbBloodType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbHospital);
            this.groupBox1.Location = new System.Drawing.Point(13, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1175, 64);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Transfer Data";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(1077, 25);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnTransfer
            // 
            this.btnTransfer.Location = new System.Drawing.Point(950, 25);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(75, 23);
            this.btnTransfer.TabIndex = 6;
            this.btnTransfer.Text = "Transfer";
            this.btnTransfer.UseVisualStyleBackColor = true;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // requestedBloodUnits
            // 
            this.requestedBloodUnits.Location = new System.Drawing.Point(779, 25);
            this.requestedBloodUnits.Name = "requestedBloodUnits";
            this.requestedBloodUnits.Size = new System.Drawing.Size(120, 20);
            this.requestedBloodUnits.TabIndex = 5;
            this.requestedBloodUnits.ValueChanged += new System.EventHandler(this.requestedBloodUnits_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(670, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Requested Units";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(401, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Blood Type";
            // 
            // cmbBloodType
            // 
            this.cmbBloodType.FormattingEnabled = true;
            this.cmbBloodType.Items.AddRange(new object[] {
            "A+",
            "A-",
            "B+",
            "B-",
            "AB+",
            "AB-",
            "O+",
            "O-"});
            this.cmbBloodType.Location = new System.Drawing.Point(510, 25);
            this.cmbBloodType.Name = "cmbBloodType";
            this.cmbBloodType.Size = new System.Drawing.Size(97, 21);
            this.cmbBloodType.TabIndex = 2;
            this.cmbBloodType.SelectedIndexChanged += new System.EventHandler(this.cmbBloodType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hospital";
            // 
            // cmbHospital
            // 
            this.cmbHospital.FormattingEnabled = true;
            this.cmbHospital.Items.AddRange(new object[] {
            "General Hospital Kandy",
            "Peradeniya General Hospital",
            "Asiri PVT Hospital  Kandy",
            "Suwasewana PVT Hospital Kandy ",
            "General Hospital Colombo"});
            this.cmbHospital.Location = new System.Drawing.Point(149, 25);
            this.cmbHospital.Name = "cmbHospital";
            this.cmbHospital.Size = new System.Drawing.Size(208, 21);
            this.cmbHospital.TabIndex = 0;
            this.cmbHospital.SelectedIndexChanged += new System.EventHandler(this.cmbHospital_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView2);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Controls.Add(this.bloodUnitChart);
            this.groupBox2.Location = new System.Drawing.Point(13, 108);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1175, 322);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(420, 20);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(174, 240);
            this.dataGridView2.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.GrayText;
            this.groupBox3.Location = new System.Drawing.Point(391, 20);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1, 282);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(610, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(559, 282);
            this.dataGridView1.TabIndex = 1;
            // 
            // bloodUnitChart
            // 
            chartArea1.Name = "ChartArea1";
            this.bloodUnitChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.bloodUnitChart.Legends.Add(legend1);
            this.bloodUnitChart.Location = new System.Drawing.Point(23, 19);
            this.bloodUnitChart.Name = "bloodUnitChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.IsValueShownAsLabel = true;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.bloodUnitChart.Series.Add(series1);
            this.bloodUnitChart.Size = new System.Drawing.Size(334, 300);
            this.bloodUnitChart.TabIndex = 0;
            this.bloodUnitChart.Text = "chart1";
            // 
            // Director_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1200, 451);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Director_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Director Form";
            this.Load += new System.EventHandler(this.Director_Form_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.requestedBloodUnits)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bloodUnitChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewAccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewAdnEditAccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutWhatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userManualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutSoftwareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backToTheMainMenuToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.NumericUpDown requestedBloodUnits;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbBloodType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbHospital;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataVisualization.Charting.Chart bloodUnitChart;
        private System.Windows.Forms.DataGridView dataGridView2;
    }
}