using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library1.DAL;
using Library1.Data;
using Library1.Models;

namespace Library1.Forms
{
    public partial class AddBookForm : Form
    {
        public AddBookForm()
        {
            InitializeComponent();
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text)) {
                MessageBox.Show("بيانات ناقصة", "الرجاء إدخال عنوان الكتاب", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (cmbAuthors.SelectedItem == null) {
                MessageBox.Show("بيانات ناقصة", "الرجاء اختيار مؤلف الكتاب ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            Book newBook = new Book
            {
                Title = txtTitle.Text.Trim(),
                AuthorID = (int)cmbAuthors.SelectedValue,
                PublicationYear=(int)numYear.Value
            };

            using (BookDAL dal = new BookDAL())
            {
                if (dal.AddBook(newBook))
                {
                    MessageBox.Show("نجاح","تمت اضافة الكتاب بنجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GlobalData.RefreshBooksList();
                    this.Close();
                }
                else 
                {
                    MessageBox.Show("خطأ", "فشلت عملية اضافة الكتاب", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                
                }
        }

        private void AddBookForm_Load(object sender, EventArgs e)
        {
            LoadAuthorsComboBox();
        }

        private void LoadAuthorsComboBox()
        {
            cmbAuthors.DataSource=null;
            cmbAuthors.DataSource=GlobalData.AuthorsList;
            cmbAuthors.DisplayMember = "ToString";
            cmbAuthors.ValueMember= "AuthorID";
            if (cmbAuthors.Items.Count > 0)
            {
                cmbAuthors.SelectedIndex = 0;
            }
        }
    }
}
