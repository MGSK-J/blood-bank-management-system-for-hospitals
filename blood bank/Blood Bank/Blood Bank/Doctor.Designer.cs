
namespace Blood_Bank
{
    partial class Doctor
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.txtDonarNIC = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gpbExpression = new System.Windows.Forms.GroupBox();
            this.cblExpression = new System.Windows.Forms.CheckedListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblShowDonarToken = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblShowDonarID = new System.Windows.Forms.Label();
            this.lblToken = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblShowDonarIDResult = new System.Windows.Forms.Label();
            this.lblShowCount = new System.Windows.Forms.Label();
            this.lblShowDonarName = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.viewAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewAndEditAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backToTheMainMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewDonarsReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewDonarsReportsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.viewTokenWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutWhatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkUserManualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutSoftwareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.chkbConfirmByDoctor = new System.Windows.Forms.CheckBox();
            this.cbBloodType = new System.Windows.Forms.ComboBox();
            this.txtDbp = new System.Windows.Forms.TextBox();
            this.txtTemp = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtHemoglobin = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtSbp = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPluses = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gpbExpression.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCheck);
            this.groupBox1.Controls.Add(this.txtDonarNIC);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(389, 86);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Check Eligibility";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(294, 52);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 2;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // txtDonarNIC
            // 
            this.txtDonarNIC.Location = new System.Drawing.Point(178, 26);
            this.txtDonarNIC.Name = "txtDonarNIC";
            this.txtDonarNIC.Size = new System.Drawing.Size(191, 20);
            this.txtDonarNIC.TabIndex = 1;
            this.txtDonarNIC.TextChanged += new System.EventHandler(this.txtDonarNIC_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Donar NIC";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gpbExpression);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Location = new System.Drawing.Point(12, 27);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(405, 493);
            this.groupBox3.TabIndex = 32;
            this.groupBox3.TabStop = false;
            // 
            // gpbExpression
            // 
            this.gpbExpression.Controls.Add(this.cblExpression);
            this.gpbExpression.Controls.Add(this.groupBox4);
            this.gpbExpression.Location = new System.Drawing.Point(6, 112);
            this.gpbExpression.Name = "gpbExpression";
            this.gpbExpression.Size = new System.Drawing.Size(389, 370);
            this.gpbExpression.TabIndex = 37;
            this.gpbExpression.TabStop = false;
            this.gpbExpression.Text = "Expression The From Donar";
            // 
            // cblExpression
            // 
            this.cblExpression.FormattingEnabled = true;
            this.cblExpression.Items.AddRange(new object[] {
            "The following donar is having medicines for diabetes",
            "The following donar is having medicines for pressure",
            "Is the donar being treated HIV positive",
            "Is the donar being treated for heart disease?",
            "The donar was being treated for paralysis",
            "The donar was being treated for kidney disease",
            "Have you donated blood before?",
            "Has this donar had surgery?",
            "Does this donar have liver disease?",
            "Has this donar been a vaccinated?",
            "Has this donar had dengue before?",
            "Is this donar being treated for cancer?",
            "Is this donar being treated for another illness?"});
            this.cblExpression.Location = new System.Drawing.Point(19, 158);
            this.cblExpression.Name = "cblExpression";
            this.cblExpression.Size = new System.Drawing.Size(350, 199);
            this.cblExpression.TabIndex = 35;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblGender);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.lblShowDonarToken);
            this.groupBox4.Controls.Add(this.lblCount);
            this.groupBox4.Controls.Add(this.lblShowDonarID);
            this.groupBox4.Controls.Add(this.lblToken);
            this.groupBox4.Controls.Add(this.lblName);
            this.groupBox4.Controls.Add(this.lblShowDonarIDResult);
            this.groupBox4.Controls.Add(this.lblShowCount);
            this.groupBox4.Controls.Add(this.lblShowDonarName);
            this.groupBox4.Location = new System.Drawing.Point(19, 22);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(352, 127);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Donar Details";
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(135, 111);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(0, 13);
            this.lblGender.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Gender";
            // 
            // lblShowDonarToken
            // 
            this.lblShowDonarToken.AutoSize = true;
            this.lblShowDonarToken.Location = new System.Drawing.Point(6, 65);
            this.lblShowDonarToken.Name = "lblShowDonarToken";
            this.lblShowDonarToken.Size = new System.Drawing.Size(63, 13);
            this.lblShowDonarToken.TabIndex = 10;
            this.lblShowDonarToken.Text = "Token Num";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(135, 85);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(0, 13);
            this.lblCount.TabIndex = 9;
            // 
            // lblShowDonarID
            // 
            this.lblShowDonarID.AutoSize = true;
            this.lblShowDonarID.Location = new System.Drawing.Point(9, 21);
            this.lblShowDonarID.Name = "lblShowDonarID";
            this.lblShowDonarID.Size = new System.Drawing.Size(81, 13);
            this.lblShowDonarID.TabIndex = 8;
            this.lblShowDonarID.Text = "Donar Given ID";
            // 
            // lblToken
            // 
            this.lblToken.AutoSize = true;
            this.lblToken.Location = new System.Drawing.Point(135, 65);
            this.lblToken.Name = "lblToken";
            this.lblToken.Size = new System.Drawing.Size(0, 13);
            this.lblToken.TabIndex = 7;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(135, 43);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 13);
            this.lblName.TabIndex = 6;
            // 
            // lblShowDonarIDResult
            // 
            this.lblShowDonarIDResult.AutoSize = true;
            this.lblShowDonarIDResult.Location = new System.Drawing.Point(135, 21);
            this.lblShowDonarIDResult.Name = "lblShowDonarIDResult";
            this.lblShowDonarIDResult.Size = new System.Drawing.Size(0, 13);
            this.lblShowDonarIDResult.TabIndex = 3;
            // 
            // lblShowCount
            // 
            this.lblShowCount.AutoSize = true;
            this.lblShowCount.Location = new System.Drawing.Point(6, 85);
            this.lblShowCount.Name = "lblShowCount";
            this.lblShowCount.Size = new System.Drawing.Size(102, 13);
            this.lblShowCount.TabIndex = 2;
            this.lblShowCount.Text = " Previous Donations";
            // 
            // lblShowDonarName
            // 
            this.lblShowDonarName.AutoSize = true;
            this.lblShowDonarName.Location = new System.Drawing.Point(9, 43);
            this.lblShowDonarName.Name = "lblShowDonarName";
            this.lblShowDonarName.Size = new System.Drawing.Size(35, 13);
            this.lblShowDonarName.TabIndex = 0;
            this.lblShowDonarName.Text = "Name";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(733, 497);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 34;
            this.button2.Text = "Exit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewAccountToolStripMenuItem,
            this.aboutWhatToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(820, 24);
            this.menuStrip1.TabIndex = 36;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // viewAccountToolStripMenuItem
            // 
            this.viewAccountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewAndEditAccountToolStripMenuItem,
            this.backToTheMainMenuToolStripMenuItem,
            this.viewDonarsReportsToolStripMenuItem});
            this.viewAccountToolStripMenuItem.Name = "viewAccountToolStripMenuItem";
            this.viewAccountToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.viewAccountToolStripMenuItem.Text = "View Account";
            // 
            // viewAndEditAccountToolStripMenuItem
            // 
            this.viewAndEditAccountToolStripMenuItem.Name = "viewAndEditAccountToolStripMenuItem";
            this.viewAndEditAccountToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.viewAndEditAccountToolStripMenuItem.Text = "View And Edit Account";
            this.viewAndEditAccountToolStripMenuItem.Click += new System.EventHandler(this.viewAndEditAccountToolStripMenuItem_Click);
            // 
            // backToTheMainMenuToolStripMenuItem
            // 
            this.backToTheMainMenuToolStripMenuItem.Name = "backToTheMainMenuToolStripMenuItem";
            this.backToTheMainMenuToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.backToTheMainMenuToolStripMenuItem.Text = "Back To The Main Menu";
            this.backToTheMainMenuToolStripMenuItem.Click += new System.EventHandler(this.backToTheMainMenuToolStripMenuItem_Click);
            // 
            // viewDonarsReportsToolStripMenuItem
            // 
            this.viewDonarsReportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewDonarsReportsToolStripMenuItem1,
            this.viewTokenWindowToolStripMenuItem});
            this.viewDonarsReportsToolStripMenuItem.Name = "viewDonarsReportsToolStripMenuItem";
            this.viewDonarsReportsToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.viewDonarsReportsToolStripMenuItem.Text = "Open Forms";
            this.viewDonarsReportsToolStripMenuItem.Click += new System.EventHandler(this.viewDonarsReportsToolStripMenuItem_Click);
            // 
            // viewDonarsReportsToolStripMenuItem1
            // 
            this.viewDonarsReportsToolStripMenuItem1.Name = "viewDonarsReportsToolStripMenuItem1";
            this.viewDonarsReportsToolStripMenuItem1.Size = new System.Drawing.Size(182, 22);
            this.viewDonarsReportsToolStripMenuItem1.Text = "View Donars Reports";
            this.viewDonarsReportsToolStripMenuItem1.Click += new System.EventHandler(this.viewDonarsReportsToolStripMenuItem1_Click);
            // 
            // viewTokenWindowToolStripMenuItem
            // 
            this.viewTokenWindowToolStripMenuItem.Name = "viewTokenWindowToolStripMenuItem";
            this.viewTokenWindowToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.viewTokenWindowToolStripMenuItem.Text = "View Token Window";
            this.viewTokenWindowToolStripMenuItem.Click += new System.EventHandler(this.viewTokenWindowToolStripMenuItem_Click);
            // 
            // aboutWhatToolStripMenuItem
            // 
            this.aboutWhatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkUserManualToolStripMenuItem,
            this.aboutSoftwareToolStripMenuItem});
            this.aboutWhatToolStripMenuItem.Name = "aboutWhatToolStripMenuItem";
            this.aboutWhatToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.aboutWhatToolStripMenuItem.Text = "About What";
            // 
            // checkUserManualToolStripMenuItem
            // 
            this.checkUserManualToolStripMenuItem.Name = "checkUserManualToolStripMenuItem";
            this.checkUserManualToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.checkUserManualToolStripMenuItem.Text = "Doctor User Manual";
            this.checkUserManualToolStripMenuItem.Click += new System.EventHandler(this.checkUserManualToolStripMenuItem_Click);
            // 
            // aboutSoftwareToolStripMenuItem
            // 
            this.aboutSoftwareToolStripMenuItem.Name = "aboutSoftwareToolStripMenuItem";
            this.aboutSoftwareToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutSoftwareToolStripMenuItem.Text = "About Software";
            this.aboutSoftwareToolStripMenuItem.Click += new System.EventHandler(this.aboutSoftwareToolStripMenuItem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnUpdate);
            this.groupBox2.Controls.Add(this.chkbConfirmByDoctor);
            this.groupBox2.Controls.Add(this.cbBloodType);
            this.groupBox2.Controls.Add(this.txtDbp);
            this.groupBox2.Controls.Add(this.txtTemp);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.txtWeight);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtHemoglobin);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.txtSbp);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtPluses);
            this.groupBox2.Location = new System.Drawing.Point(443, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(365, 354);
            this.groupBox2.TabIndex = 62;
            this.groupBox2.TabStop = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(244, 299);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(97, 24);
            this.btnUpdate.TabIndex = 57;
            this.btnUpdate.Text = "Insert Data";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // chkbConfirmByDoctor
            // 
            this.chkbConfirmByDoctor.AutoSize = true;
            this.chkbConfirmByDoctor.Location = new System.Drawing.Point(42, 299);
            this.chkbConfirmByDoctor.Name = "chkbConfirmByDoctor";
            this.chkbConfirmByDoctor.Size = new System.Drawing.Size(156, 17);
            this.chkbConfirmByDoctor.TabIndex = 56;
            this.chkbConfirmByDoctor.Text = "I Here By The Confirm Data";
            this.chkbConfirmByDoctor.UseVisualStyleBackColor = true;
            this.chkbConfirmByDoctor.CheckedChanged += new System.EventHandler(this.chkbConfirmByDoctor_CheckedChanged);
            // 
            // cbBloodType
            // 
            this.cbBloodType.FormattingEnabled = true;
            this.cbBloodType.Items.AddRange(new object[] {
            "A+",
            "A-",
            "B+",
            "B-",
            "AB+",
            "AB-",
            "O+",
            "O-"});
            this.cbBloodType.Location = new System.Drawing.Point(191, 45);
            this.cbBloodType.Margin = new System.Windows.Forms.Padding(2);
            this.cbBloodType.Name = "cbBloodType";
            this.cbBloodType.Size = new System.Drawing.Size(110, 21);
            this.cbBloodType.TabIndex = 42;
            this.cbBloodType.SelectedIndexChanged += new System.EventHandler(this.cbBloodType_SelectedIndexChanged);
            // 
            // txtDbp
            // 
            this.txtDbp.Location = new System.Drawing.Point(262, 214);
            this.txtDbp.Margin = new System.Windows.Forms.Padding(2);
            this.txtDbp.Name = "txtDbp";
            this.txtDbp.Size = new System.Drawing.Size(38, 20);
            this.txtDbp.TabIndex = 51;
            this.txtDbp.TextChanged += new System.EventHandler(this.txtDbp_TextChanged);
            // 
            // txtTemp
            // 
            this.txtTemp.Location = new System.Drawing.Point(191, 108);
            this.txtTemp.Margin = new System.Windows.Forms.Padding(2);
            this.txtTemp.Name = "txtTemp";
            this.txtTemp.Size = new System.Drawing.Size(110, 20);
            this.txtTemp.TabIndex = 40;
            this.txtTemp.TextChanged += new System.EventHandler(this.txtTemp_TextChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(305, 181);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(28, 13);
            this.label17.TabIndex = 55;
            this.label17.Text = "/min\r\n";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 112);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 39;
            this.label6.Text = "Temperature";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(305, 248);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(38, 13);
            this.label16.TabIndex = 54;
            this.label16.Text = "gm/dL";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(41, 45);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 13);
            this.label11.TabIndex = 41;
            this.label11.Text = "Blood type";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(304, 212);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(37, 13);
            this.label15.TabIndex = 53;
            this.label15.Text = "mmHg";
            // 
            // txtWeight
            // 
            this.txtWeight.Location = new System.Drawing.Point(191, 75);
            this.txtWeight.Margin = new System.Windows.Forms.Padding(2);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(110, 20);
            this.txtWeight.TabIndex = 38;
            this.txtWeight.TextChanged += new System.EventHandler(this.txtWeight_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(245, 212);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(13, 20);
            this.label10.TabIndex = 52;
            this.label10.Text = "/";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 78);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "Weight";
            // 
            // txtHemoglobin
            // 
            this.txtHemoglobin.Location = new System.Drawing.Point(191, 244);
            this.txtHemoglobin.Margin = new System.Windows.Forms.Padding(2);
            this.txtHemoglobin.Name = "txtHemoglobin";
            this.txtHemoglobin.Size = new System.Drawing.Size(110, 20);
            this.txtHemoglobin.TabIndex = 50;
            this.txtHemoglobin.TextChanged += new System.EventHandler(this.txtHemoglobin_TextChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(305, 110);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(18, 13);
            this.label18.TabIndex = 43;
            this.label18.Text = "°C";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(41, 244);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 49;
            this.label9.Text = "Hemoglobin";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(305, 75);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(19, 13);
            this.label19.TabIndex = 44;
            this.label19.Text = "kg";
            // 
            // txtSbp
            // 
            this.txtSbp.Location = new System.Drawing.Point(191, 212);
            this.txtSbp.Margin = new System.Windows.Forms.Padding(2);
            this.txtSbp.Name = "txtSbp";
            this.txtSbp.Size = new System.Drawing.Size(48, 20);
            this.txtSbp.TabIndex = 48;
            this.txtSbp.TextChanged += new System.EventHandler(this.txtSbp_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(41, 179);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 45;
            this.label7.Text = "Pulses";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(41, 214);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 47;
            this.label8.Text = "Blood Pressure";
            // 
            // txtPluses
            // 
            this.txtPluses.Location = new System.Drawing.Point(191, 179);
            this.txtPluses.Margin = new System.Windows.Forms.Padding(2);
            this.txtPluses.Name = "txtPluses";
            this.txtPluses.Size = new System.Drawing.Size(110, 20);
            this.txtPluses.TabIndex = 46;
            this.txtPluses.TextChanged += new System.EventHandler(this.txtPluses_TextChanged);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(634, 497);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 63;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Doctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(820, 527);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Doctor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Doctor";
            this.Load += new System.EventHandler(this.Doctor_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.gpbExpression.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.TextBox txtDonarNIC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewAccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewAndEditAccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutWhatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkUserManualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutSoftwareToolStripMenuItem;
        private System.Windows.Forms.GroupBox gpbExpression;
        private System.Windows.Forms.CheckedListBox cblExpression;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblShowDonarToken;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblShowDonarID;
        private System.Windows.Forms.Label lblToken;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblShowDonarIDResult;
        private System.Windows.Forms.Label lblShowCount;
        private System.Windows.Forms.Label lblShowDonarName;
        private System.Windows.Forms.ToolStripMenuItem backToTheMainMenuToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.CheckBox chkbConfirmByDoctor;
        private System.Windows.Forms.ComboBox cbBloodType;
        private System.Windows.Forms.TextBox txtDbp;
        private System.Windows.Forms.TextBox txtTemp;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtHemoglobin;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtSbp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPluses;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem viewDonarsReportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewDonarsReportsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem viewTokenWindowToolStripMenuItem;
        private System.Windows.Forms.Button btnClear;
    }
}