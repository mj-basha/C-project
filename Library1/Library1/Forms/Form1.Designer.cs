namespace Library1
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
            this.dgvAuthors = new System.Windows.Forms.DataGridView();
            this.dgvBooks = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOpenAddAuthor = new System.Windows.Forms.Button();
            this.btnOpenAddBook = new System.Windows.Forms.Button();
            this.btnRefreshAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuthors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAuthors
            // 
            this.dgvAuthors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAuthors.Location = new System.Drawing.Point(12, 30);
            this.dgvAuthors.Name = "dgvAuthors";
            this.dgvAuthors.Size = new System.Drawing.Size(475, 292);
            this.dgvAuthors.TabIndex = 0;
            // 
            // dgvBooks
            // 
            this.dgvBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBooks.Location = new System.Drawing.Point(563, 30);
            this.dgvBooks.Name = "dgvBooks";
            this.dgvBooks.Size = new System.Drawing.Size(522, 292);
            this.dgvBooks.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(559, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Books:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.Location = new System.Drawing.Point(12, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Authors:";
            // 
            // btnOpenAddAuthor
            // 
            this.btnOpenAddAuthor.Location = new System.Drawing.Point(218, 368);
            this.btnOpenAddAuthor.Name = "btnOpenAddAuthor";
            this.btnOpenAddAuthor.Size = new System.Drawing.Size(117, 51);
            this.btnOpenAddAuthor.TabIndex = 4;
            this.btnOpenAddAuthor.Text = "add New Author";
            this.btnOpenAddAuthor.UseVisualStyleBackColor = true;
            this.btnOpenAddAuthor.Click += new System.EventHandler(this.btnOpenAddAuthor_Click);
            // 
            // btnOpenAddBook
            // 
            this.btnOpenAddBook.Location = new System.Drawing.Point(474, 368);
            this.btnOpenAddBook.Name = "btnOpenAddBook";
            this.btnOpenAddBook.Size = new System.Drawing.Size(109, 51);
            this.btnOpenAddBook.TabIndex = 5;
            this.btnOpenAddBook.Text = "Add New Book";
            this.btnOpenAddBook.UseVisualStyleBackColor = true;
            this.btnOpenAddBook.Click += new System.EventHandler(this.btnOpenAddBook_Click);
            // 
            // btnRefreshAll
            // 
            this.btnRefreshAll.Location = new System.Drawing.Point(786, 368);
            this.btnRefreshAll.Name = "btnRefreshAll";
            this.btnRefreshAll.Size = new System.Drawing.Size(111, 51);
            this.btnRefreshAll.TabIndex = 6;
            this.btnRefreshAll.Text = "Refresh Data ";
            this.btnRefreshAll.UseVisualStyleBackColor = true;
            this.btnRefreshAll.Click += new System.EventHandler(this.btnRefreshAll_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 450);
            this.Controls.Add(this.btnRefreshAll);
            this.Controls.Add(this.btnOpenAddBook);
            this.Controls.Add(this.btnOpenAddAuthor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvBooks);
            this.Controls.Add(this.dgvAuthors);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuthors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAuthors;
        private System.Windows.Forms.DataGridView dgvBooks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOpenAddAuthor;
        private System.Windows.Forms.Button btnOpenAddBook;
        private System.Windows.Forms.Button btnRefreshAll;
    }
}

