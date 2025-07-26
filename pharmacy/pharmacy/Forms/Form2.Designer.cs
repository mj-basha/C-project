namespace pharmacy
{
    partial class Form2
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnMedicine = new System.Windows.Forms.Button();
            this.btnInvoice = new System.Windows.Forms.Button();
            this.btnSupplier = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLogs = new System.Windows.Forms.Button();
            this.btnAboutUs = new System.Windows.Forms.Button();
            this.btnCallUs = new System.Windows.Forms.Button();
            this.btnGetMess = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "Employees";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnMedicine
            // 
            this.btnMedicine.Location = new System.Drawing.Point(3, 95);
            this.btnMedicine.Name = "btnMedicine";
            this.btnMedicine.Size = new System.Drawing.Size(98, 41);
            this.btnMedicine.TabIndex = 1;
            this.btnMedicine.Text = "Medicine";
            this.btnMedicine.UseVisualStyleBackColor = true;
            this.btnMedicine.Click += new System.EventHandler(this.btnMedicine_Click);
            // 
            // btnInvoice
            // 
            this.btnInvoice.Location = new System.Drawing.Point(3, 142);
            this.btnInvoice.Name = "btnInvoice";
            this.btnInvoice.Size = new System.Drawing.Size(98, 41);
            this.btnInvoice.TabIndex = 3;
            this.btnInvoice.Text = "Invoice";
            this.btnInvoice.UseVisualStyleBackColor = true;
            this.btnInvoice.Click += new System.EventHandler(this.btnInvoice_Click);
            // 
            // btnSupplier
            // 
            this.btnSupplier.Location = new System.Drawing.Point(3, 189);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.Size = new System.Drawing.Size(98, 43);
            this.btnSupplier.TabIndex = 4;
            this.btnSupplier.Text = "Supplire";
            this.btnSupplier.UseVisualStyleBackColor = true;
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(3, 431);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(98, 39);
            this.button5.TabIndex = 5;
            this.button5.Text = "  Logout";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.Location = new System.Drawing.Point(3, 48);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(98, 41);
            this.btnUsers.TabIndex = 7;
            this.btnUsers.Text = "Users";
            this.btnUsers.UseVisualStyleBackColor = true;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(107, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(740, 468);
            this.panel1.TabIndex = 8;
            // 
            // btnLogs
            // 
            this.btnLogs.Location = new System.Drawing.Point(3, 238);
            this.btnLogs.Name = "btnLogs";
            this.btnLogs.Size = new System.Drawing.Size(98, 43);
            this.btnLogs.TabIndex = 9;
            this.btnLogs.Text = "Logs";
            this.btnLogs.UseVisualStyleBackColor = true;
            this.btnLogs.Click += new System.EventHandler(this.btnLogs_Click);
            // 
            // btnAboutUs
            // 
            this.btnAboutUs.Location = new System.Drawing.Point(3, 287);
            this.btnAboutUs.Name = "btnAboutUs";
            this.btnAboutUs.Size = new System.Drawing.Size(98, 44);
            this.btnAboutUs.TabIndex = 10;
            this.btnAboutUs.Text = "About us";
            this.btnAboutUs.UseVisualStyleBackColor = true;
            this.btnAboutUs.Click += new System.EventHandler(this.btnAboutUs_Click);
            // 
            // btnCallUs
            // 
            this.btnCallUs.Location = new System.Drawing.Point(3, 337);
            this.btnCallUs.Name = "btnCallUs";
            this.btnCallUs.Size = new System.Drawing.Size(98, 42);
            this.btnCallUs.TabIndex = 11;
            this.btnCallUs.Text = "Call us";
            this.btnCallUs.UseVisualStyleBackColor = true;
            this.btnCallUs.Click += new System.EventHandler(this.btnCallUs_Click);
            // 
            // btnGetMess
            // 
            this.btnGetMess.Location = new System.Drawing.Point(3, 385);
            this.btnGetMess.Name = "btnGetMess";
            this.btnGetMess.Size = new System.Drawing.Size(98, 40);
            this.btnGetMess.TabIndex = 12;
            this.btnGetMess.Text = "Messages";
            this.btnGetMess.UseVisualStyleBackColor = true;
            this.btnGetMess.Click += new System.EventHandler(this.btnGetMess_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 475);
            this.Controls.Add(this.btnGetMess);
            this.Controls.Add(this.btnCallUs);
            this.Controls.Add(this.btnAboutUs);
            this.Controls.Add(this.btnLogs);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnUsers);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.btnSupplier);
            this.Controls.Add(this.btnInvoice);
            this.Controls.Add(this.btnMedicine);
            this.Controls.Add(this.button1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnMedicine;
        private System.Windows.Forms.Button btnInvoice;
        private System.Windows.Forms.Button btnSupplier;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLogs;
        private System.Windows.Forms.Button btnAboutUs;
        private System.Windows.Forms.Button btnCallUs;
        private System.Windows.Forms.Button btnGetMess;
    }
}