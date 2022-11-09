using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace XM_books.Models
{
    public interface IMainFormModel //: INotifyPropertyChanged <--- ??
    {
        bool mdl_isSuccessful { get; set; }
        string mdl_Message { get; set; }

        bool set_BooksList(IList<Models.IModel_vw_book> books);
        bool set_BooksList(IList<Models.IModel_vw_book> books, short index);
        bool set_BooksList(IList<Models.IModel_vw_book> books, string txtSearch);
        bool set_BooksList(IList<Models.IModel_vw_book> books, short index, string txtSearch);

        void set_JunrsList(IList<Models.IModel_genre> junrs);

        // ** bool Books_GetList(IList<Model_vw_book> books, short index);
        // ** bool Books_GetList(IList<Model_vw_book> books, string txtSearch);
        // ** bool Books_GetList(IList<Model_vw_book> books, short index, string txtSearch);

        void mdl_CreateBook(Models.IModel_tb_book bk);
        void mdl_UpdateBook(Models.IModel_tb_book bk);
        void mdl_DeleteBook(Guid id_book);
        void mdl_Cancel();
    }

    public class MainFormModel : IMainFormModel
    {
        //fields ---------------------------------------------------------------
        private readonly string _mdl_Text_default= "";
        private string          _mdl_SearchTxt= "";

        public  string mdl_SearchTxt { get { return _mdl_SearchTxt; } set { _mdl_SearchTxt = value; } }

/**-+-*/private List<IModel_genre>   mdl_JunrsList { get; }
/**-+-*/private List<IModel_vw_book> mdl_BooksList { get; }

        public  bool  mdl_isCreateOrUpdate { get; set; }
        public  bool  mdl_isSuccessful { get; set; }
        public string mdl_Message { get; set; }

        //konstruktor ----------------------------------------------------------
        public MainFormModel()
        {
            /**2022-07-28
            / Sohranit_(!!)  posledovatel_nost_  operatotorov
            */

            /*1*/
            this.mdl_JunrsList = new List<IModel_genre>();
            /*2*/
            this.set_JunrsList(mdl_JunrsList);

            /*3*/
/**-+-*/    this.mdl_BooksList = new List<IModel_vw_book>();
            /*4*/
/**-+-*/    this.set_BooksList(mdl_BooksList);

            /*5*/
            this.mdl_isCreateOrUpdate = false;
            /*6*/
            this.mdl_isSuccessful = false;

            /*7*/
            this.mdl_Message = this._mdl_Text_default; ;
        }

        //business logic
/**-+-*/public  void set_JunrsList(IList<Models.IModel_genre> junrs)
        {
            var lst = XM_books.EF_Repositories.book_RJ_Repository.GetAllJunrs();
            if (junrs != null) junrs.Clear();
            foreach (var j in lst) { junrs.Add(new Models.Model_genre(j)); }
            return;
        }
//
// mmmmmm Start mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
//
/**-1-*/public bool set_BooksList
        (IList<IModel_vw_book> books)
        {
            var lst = XM_books.EF_Repositories.book_RJ_Repository.GetAllBooks();
            if (books != null) books.Clear();
            foreach (var bk in lst) { books.Add(new Model_vw_book(bk)); }
            return true;
        }
/**-2-*/public bool set_BooksList
        (IList<IModel_vw_book> books, short id_junr)
        {
            if (id_junr == Model_genre._id_junr_AllJunrs)
            {
                this.set_BooksList(books); // o'key
                return true;
            }
            var lst = XM_books.EF_Repositories.book_RJ_Repository.GetAllBooks(id_junr);
            if (books != null) books.Clear();
            foreach (var bk in lst) { books.Add(new Models.Model_vw_book(bk)); }
            return true;
        }
/**-3-*/public bool set_BooksList
        (IList<IModel_vw_book> books, string txtSearch)
        {
            var lst = XM_books.EF_Repositories.book_RJ_Repository.GetAllBooks(txtSearch);
            if (books != null) books.Clear();
            foreach (var bk in lst) { books.Add(new Model_vw_book(bk)); }
            return true;
        }
/**-4-*/public bool set_BooksList
        (IList<IModel_vw_book> books, short id_junr, string search_str)
        {
            if (string.IsNullOrEmpty(search_str) == true)
            {
                this.set_BooksList(books, id_junr);
                return true;
            }
            var id = id_junr;

            //2022-08-14 -- Look to -->  public class Model_genre --- (id != 10) --
            var lst = (id != Model_genre._id_junr_AllJunrs)
                    ? XM_books.EF_Repositories.book_RJ_Repository.GetAllBooks(id, search_str)
                    : XM_books.EF_Repositories.book_RJ_Repository.GetAllBooks(search_str);

            if (books != null) { books.Clear(); }

            foreach (var bk in lst) { books.Add(new Model_vw_book(bk)); } // <----------- ??? 'b'  ()
            return true;
        }
//
// mmmmmm End mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
//
        public void mdl_CreateBook(IModel_tb_book book)
        {
            //*System.Windows.Forms.MessageBox.Show("MainFormModel-->mdl_CreateBook(Model_vw_books6 bk)------140", Program.box_title);
            XM_books.EF_Repositories.book_RJ_Repository.Create_Book(book);
         
            var x2_junr = book.Id_junr;

            var count = this.mdl_BooksList.Select(bk => bk.Id_junr).Distinct(); // .Count(); //.Distinct(bk => (bk.Id_junt > 0)).Count(); // (bk => (bk.Id_junr));
           
            var x6 = this.mdl_BooksList.Distinct().Count(); // (bk => (bk.Id_junr));
            
            var x8 = this.mdl_BooksList.Find(bk => (bk.Id_book == book.Id_uniq));

            return;
        }
        public void mdl_UpdateBook(IModel_tb_book book)
        {
            //*System.Windows.Forms.MessageBox.Show("MainFormModel-->mdl_UpdateBook(Model_vw_book bk)--------157", Program.box_title);
            XM_books.EF_Repositories.book_RJ_Repository.Update_Book(book);
            {
            var
            x2 = this.mdl_BooksList.Find(bk => (bk.Id_book == book.Id_uniq));
            x2.Nazvanie = book.Nazvanie;
            x2.Autor = book.Autor;
            x2.Year_print = book.Year_print;
            x2.Id_junr = book.Id_junr;
            x2.Name_junr = this.mdl_JunrsList.Find(jn => (jn.id_junr == book.Id_junr)).name_junr;
            }
            return;
        }
        public void mdl_DeleteBook(Guid id_book)
        {
            /** 1st delete a book from db */
            XM_books.EF_Repositories.book_RJ_Repository.Delete_Book(id_book);

            /** 2nd delete/remove a book from List of book */
            this.Remove_Book_from_BookList(mdl_BooksList, id_book);

            // ''''' var bk = this.mdl_BooksList.Where(b => b.Id_book == id_book).FirstOrDefault();
            // ''''' var rslt = this.mdl_BooksList.Remove(bk);      // ..Remove2; from Entity Framework

            return;
        }
        private void Remove_Book_from_BookList(IList<IModel_vw_book> books, Guid id_guid)
        {
            var bk = books.Where(b => b.Id_book == id_guid).FirstOrDefault();
            var rslt = books.Remove(bk);
            return;
        }
        public void mdl_Cancel() => throw new NotImplementedException();

        //services method(s) ---------------------------------------------------
    }
}

/**
//
//
//

private bool Books_GetList
(IList<Model_vw_book> books)
{
    var lst = XM_books.EF_Repositories.book_RJ_Repository.GetAllBooks();
    if (books != null) books.Clear();
    foreach (var bk in lst) { books.Add(new Model_vw_book(bk)); }
    return true;
}

private bool Books_GetList
(IList<Model_vw_book> books, short id_junr) // set_BooksList_EF(IList<EF_Repositories.vw_books6> books)
{
    var lst = XM_books.EF_Repositories.book_RJ_Repository.GetAllBooks(id_junr);
    if (books != null) books.Clear();
    foreach (var bk in lst) { books.Add(new Model_vw_book(bk)); }
    return true;
}

private bool Books_GetList
(IList<Model_vw_book> books, string txtSearch) // set_BooksList_EF(IList<EF_Repositories.vw_books6> books)
{
    var lst = XM_books.EF_Repositories.book_RJ_Repository.GetAllBooks(txtSearch);
    if (books != null) books.Clear();
    foreach (var bk in lst) { books.Add(new Model_vw_book(bk)); }
    return true;
}

private bool Books_GetList
(IList<Model_vw_book> books, short id_junr, string txtSearch) // set_BooksList_EF(IList<EF_Repositories.vw_books6> books)
{
    var lst = XM_books.EF_Repositories.book_RJ_Repository.GetAllBooks(id_junr, txtSearch);
    if (books != null) books.Clear();
    foreach (var bk in lst) { books.Add(new Model_vw_book(bk)); }
    return true;
}

*/
