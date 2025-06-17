using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library1.Forms;
using Library1.Data;




namespace Library1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void DisplayData()
        {
            dgvAuthors.DataSource = null;
            dgvAuthors.DataSource=GlobalData.AuthorsList.ToList();

            dgvBooks.DataSource = null;
            dgvBooks.DataSource = GlobalData.BooksList.ToList();

            if (dgvBooks.Columns.Contains("AuthorID"))
                dgvBooks.Columns["AuthorID"].Visible =false;
            if (dgvBooks.Columns.Contains("Author"))
            {
                dgvBooks.Columns["Author"].HeaderText = "Author Name";
            }
                
        }

        private void btnOpenAddAuthor_Click(object sender, EventArgs e)
        {
            AddAuthorForm addAuthorForm = new AddAuthorForm();
            addAuthorForm.ShowDialog();
            DisplayData();
        }

        private void btnOpenAddBook_Click(object sender, EventArgs e)
        {
            AddBookForm addBookForm = new AddBookForm();
            addBookForm.ShowDialog();
            DisplayData();
        }

        private void btnRefreshAll_Click(object sender, EventArgs e)
        {
            GlobalData.RefreshAuthorsList();
            GlobalData.RefreshBooksList();
            DisplayData();
            MessageBox.Show("تحديث","تم تحديث البيانات",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
