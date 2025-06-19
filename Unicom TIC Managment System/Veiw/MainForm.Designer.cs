namespace Unicom_TIC_Managment_System.Veiw
{
    partial class UserView
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
            this.butcs = new System.Windows.Forms.Button();
            this.btnst = new System.Windows.Forms.Button();
            this.btnsub = new System.Windows.Forms.Button();
            this.btnmk = new System.Windows.Forms.Button();
            this.btnem = new System.Windows.Forms.Button();
            this.btntm = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboRole = new System.Windows.Forms.ComboBox();
            this.button8 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // butcs
            // 
            this.butcs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butcs.Location = new System.Drawing.Point(80, 135);
            this.butcs.Name = "butcs";
            this.butcs.Size = new System.Drawing.Size(179, 23);
            this.butcs.TabIndex = 0;
            this.butcs.Text = "MANAGE COURSES";
            this.butcs.UseVisualStyleBackColor = true;
            this.butcs.Click += new System.EventHandler(this.butcs_Click);
            // 
            // btnst
            // 
            this.btnst.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnst.Location = new System.Drawing.Point(304, 135);
            this.btnst.Name = "btnst";
            this.btnst.Size = new System.Drawing.Size(174, 23);
            this.btnst.TabIndex = 1;
            this.btnst.Text = "MANAGE STUDENTS";
            this.btnst.UseVisualStyleBackColor = true;
            this.btnst.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnsub
            // 
            this.btnsub.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsub.Location = new System.Drawing.Point(526, 135);
            this.btnsub.Name = "btnsub";
            this.btnsub.Size = new System.Drawing.Size(164, 23);
            this.btnsub.TabIndex = 2;
            this.btnsub.Text = "MANAGE SUBJECTS";
            this.btnsub.UseVisualStyleBackColor = true;
            this.btnsub.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnmk
            // 
            this.btnmk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnmk.Location = new System.Drawing.Point(80, 228);
            this.btnmk.Name = "btnmk";
            this.btnmk.Size = new System.Drawing.Size(179, 23);
            this.btnmk.TabIndex = 3;
            this.btnmk.Text = "MANAGE MARKS";
            this.btnmk.UseVisualStyleBackColor = true;
            this.btnmk.Click += new System.EventHandler(this.btnmk_Click);
            // 
            // btnem
            // 
            this.btnem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnem.Location = new System.Drawing.Point(304, 228);
            this.btnem.Name = "btnem";
            this.btnem.Size = new System.Drawing.Size(174, 23);
            this.btnem.TabIndex = 4;
            this.btnem.Text = "MANAGE EXAMS";
            this.btnem.UseVisualStyleBackColor = true;
            this.btnem.Click += new System.EventHandler(this.btnem_Click);
            // 
            // btntm
            // 
            this.btntm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntm.Location = new System.Drawing.Point(526, 228);
            this.btntm.Name = "btntm";
            this.btntm.Size = new System.Drawing.Size(164, 23);
            this.btntm.TabIndex = 5;
            this.btntm.Text = "MANAGE TIMTABLES";
            this.btntm.UseVisualStyleBackColor = true;
            this.btntm.Click += new System.EventHandler(this.btntm_Click);
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(545, 32);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 6;
            this.button7.Text = "LOG OUT";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(104, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 46);
            this.label1.TabIndex = 7;
            this.label1.Text = "WELCOME \r\n\r\n";
            // 
            // comboRole
            // 
            this.comboRole.FormattingEnabled = true;
            this.comboRole.Items.AddRange(new object[] {
            "Admin",
            "Student",
            "Lecturer",
            "Staff"});
            this.comboRole.Location = new System.Drawing.Point(294, 32);
            this.comboRole.Name = "comboRole";
            this.comboRole.Size = new System.Drawing.Size(193, 21);
            this.comboRole.TabIndex = 8;
            this.comboRole.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Location = new System.Drawing.Point(80, 310);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(99, 23);
            this.button8.TabIndex = 9;
            this.button8.Text = "<- BACK";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // UserView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.comboRole);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.btntm);
            this.Controls.Add(this.btnem);
            this.Controls.Add(this.btnmk);
            this.Controls.Add(this.btnsub);
            this.Controls.Add(this.btnst);
            this.Controls.Add(this.butcs);
            this.Name = "UserView";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.UserView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butcs;
        private System.Windows.Forms.Button btnst;
        private System.Windows.Forms.Button btnsub;
        private System.Windows.Forms.Button btnmk;
        private System.Windows.Forms.Button btnem;
        private System.Windows.Forms.Button btntm;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboRole;
        private System.Windows.Forms.Button button8;
    }
}