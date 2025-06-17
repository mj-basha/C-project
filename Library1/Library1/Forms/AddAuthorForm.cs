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
    public partial class AddAuthorForm : Form
    {
        public AddAuthorForm()
        {
            InitializeComponent();
        }

        private void btnAddAuthor_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("بيانات ناقصة","الرجاء إدخال الاسم الاول و الاخير",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            
            return;
            }

            Author newAuthor = new Author
            {
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                Age = (int)numAge.Value
            };

            using (AuthorDAL dal=new AuthorDAL())
            {
                if (dal.AddAuthor(newAuthor))
                {
                    MessageBox.Show("نجاح", "تمت اضافة المؤلف بنجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GlobalData.RefreshAuthorsList();
                    this.Close();
                }
                else {
                    MessageBox.Show("خطأ","فشلت عملية إضافة المؤلف",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }
    }
}
