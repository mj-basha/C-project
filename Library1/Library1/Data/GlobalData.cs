using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library1.DAL;
using Library1.Models;

namespace Library1.Data
{
    public static class GlobalData
    {
        public static List<Author> AuthorsList { get; private set; }
        public static List<Book> BooksList { get; private set; }

        // تحميل البيانات عند تشغيل البرنامج لأول مرة
        static GlobalData()
        {
            AuthorsList = new List<Author>();
            BooksList = new List<Book>();

            RefreshAuthorsList();
            RefreshBooksList();
        }

        public static void RefreshAuthorsList()
        {
            AuthorDAL authorDAL = new AuthorDAL();
            AuthorsList = authorDAL.GetAllAuthors();
        }

        public static void RefreshBooksList()
        {
            BookDAL bookDAL = new BookDAL();
            BooksList = bookDAL.GetAllBooksWithAuthors();
        }
    }
}
