using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
//-//-//-//-// using XM_books.EF_Repositories;

namespace XM_books.Models
{
    public interface IModel_vw_book
    {
        long?  Nn         { get; set; }
        string Nazvanie   { get; set; }
        string Autor      { get; set; }
        short  Year_print { get; set; }
        string Name_junr  { get; set; } /** set => ef_book.name_junr = value; } */
        short  Id_junr    { get; set; }
        Guid   Id_book    { get; set; }

        void Get_vw_book_default2();
        void book_model_UpdateBook(Model_vw_book book);
        void book_model_DeleteBook(Guid id_book);
    }

    public class Model_vw_book : IModel_vw_book
    {
        #region fields(polia) mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
        private EF_Books.vw_books6 ef_book;
      //private EF_Books.vw_books6 vw_book;
        #endregion

        #region Properties(svoystva) -- plus Validations mmmmmmmmmmmmmmmmmmmmmmm
        public long?  Nn         { get => ef_book.nn;     set => ef_book.nn = value; }
        public string Nazvanie   { get => ef_book.nazvanie;   set => ef_book.nazvanie = value;   }
        public string Autor      { get => ef_book.autor;      set => ef_book.autor = value;      }
        public short  Year_print { get => ef_book.PublicYear; set => ef_book.PublicYear = value; }
        public string Name_junr  { get => ef_book.name_junr;  set => ef_book.name_junr = value;  } /** set => ef_book.name_junr = value; } */
        public short  Id_junr    { get => ef_book.id_junr;    set => ef_book.id_junr = value;    }
        public Guid   Id_book    { get => ef_book.id_book; set => ef_book.id_book = value; }
        #endregion

        #region konstruktor(y) mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
        public Model_vw_book()
        {
        }
        public Model_vw_book(XM_books.EF_Books.vw_books6 vw6)
        : this()
        {
            this.ef_book = vw6;
        }
        public Model_vw_book(IModel_vw_book vw)
        : this()
        {
            this.ef_book = new EF_Books.vw_books6();

            this.ef_book.nn        = vw.Nn;
            this.ef_book.nazvanie  = vw.Nazvanie;
            this.ef_book.autor     = vw.Autor;
            this.ef_book.PublicYear= vw.Year_print;
            this.ef_book.name_junr = vw.Name_junr;
            this.ef_book.id_book   = vw.Id_book;
            this.ef_book.id_junr   = vw.Id_junr;
        }
        public Model_vw_book(Dictionary<string, string> dc)
        : this()
        {
            this.Nn        = long.Parse(dc["Nn"]);
            this.Nazvanie  = dc["Nazvanie"];
            this.Autor     = dc["Autor"];
            this.Year_print= short.Parse(dc["Year_print"]);
            this.Name_junr = dc["Name_junr"];
            this.Id_book   = Guid.Parse(dc["Id_book"]);
            this.Id_junr   = short.Parse(dc["Id_junr"]);
        }
        #endregion

        #region Services mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
        public void Get_vw_book_default2() // <<<<<<<<<<<<<<<---------- static ---------
        {
            var tb_book_default = Model_tb_book.Get_tb_book_default(new Models.Model_tb_book());
            //-//-//-//-//  2022-11-06 var tb_book_default = (new Models.Model_tb_book()).Get_tb_book_default();

            this.ef_book = new EF_Books.vw_books6();

            this.Nn       = -5; // or  may be better - "0" ??
            this.Nazvanie = tb_book_default.Nazvanie;
            this.Autor    = tb_book_default.Autor;
            this.Id_book  = tb_book_default.Id_uniq;
            this.Year_print=tb_book_default.Year_print;
            this.Id_junr  = tb_book_default.Id_junr;
            this.Name_junr= Model_genre.Get_junr_default().name_junr;

            return;
        }


        public void book_model_UpdateBook(Model_vw_book book)
        {
            //*System.Windows.Forms.MessageBox.Show("MainFormModel-->mdl_UpdateBook(Model_vw_books6 bk)---------------------------101", Program.box_title);
            //-//-//-//-//  XM_books.EF_Repositories.book_RJ_Repository.Update_Book(book.convert_to_Model_tb_book());
            XM_books.EF_Repositories.book_RJ_Repository.Update_Book(new Model_tb_book(book)); // 2022-10-18

            {
                var db = new XM_books.EF_Books.BOOKSEntities();

                var result =
                db.sp_book_update(
                                  book.Id_junr.ToString(),
                                  book.Nazvanie,
                                  book.Autor,
                                  book.Year_print.ToString(),
                                  book.Id_junr.ToString()      ).ToArray();

                var Out_result_error = result[0].Out_result_error;

                string str1 =
                (Out_result_error == 0) ? Program.box_msg_book_Edit : Program.box_msg_book_No_edit;
            }
        }

        public void book_model_DeleteBook(Guid id_book)
        {
            XM_books.EF_Repositories.book_RJ_Repository.Delete_Book(id_book); // Look MainFormModel--->mdl_DeleteBook(Guid id_book)

            // 0000 000 00 var ty = this.mdl_BooksList.Where(bk => bk.id_book == id_book).FirstOrDefault();
            // 0000 000 00 var rslt = this.mdl_BooksList.Remove(ty);      // ..Remove2; from Entity Framework        
            // 0000 000 00 this.Remove_Book_from_BookList(mdl_BooksList, id_book);  // ..Remove4; from List
            return;
        }
        #endregion

        #region Service(s) mmmmm static method(s) mmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
        public static IDictionary<string, string> Book_to_dictionary(IModel_vw_book vw_bk)
        {
            var book = new Dictionary<string, string>();
            book.Add("Nn",         vw_bk.Nn.ToString());
            book.Add("Nazvanie",   vw_bk.Nazvanie);
            book.Add("Autor",      vw_bk.Autor);
            book.Add("Year_print", vw_bk.Year_print.ToString());
            book.Add("Name_junr",  vw_bk.Name_junr);
            book.Add("Id_book",    vw_bk.Id_book.ToString());
            book.Add("Id_junr",    vw_bk.Id_junr.ToString());
            return book;
        }
        #endregion
    }
}
