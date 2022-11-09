using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XM_books;
using XM_books.EF_Books;

namespace XM_books.EF_Repositories
{
    /**2022-07-28
    /
    / Dlia --REPOSITORIA--  vsio sdelal "static" !!
    / Chtoby ne sozdavat_  novye ob_ekty pri ispol_zovanii metadov !!
    /
    / IEnumerable<vw_junrs_for_menu2> XM_books.EF_Repositories.genre_RJ_Repository.getAllJunrs()
    */
    internal class book_RJ_Repository : base_RJ_Repository //, Models.IMainFormRepository //.IMainFormRepository //2022-08-24, Models.IBookRepository
    {
        readonly static EF_Books.BOOKSEntities db = new EF_Books.BOOKSEntities(); //2022-07-28 static -- STATIC

        /** Methods -- -- -- ALL methods is syatic !! */
        public static IEnumerable<vw_junrs_for_menu2>
        GetAllJunrs() => db.vw_junrs_for_menu2.AsNoTracking().ToList();

/**-1-*/public static IEnumerable<vw_books6>
        GetAllBooks() => db.vw_books6.AsNoTracking().ToList();

/**-2-*/public static IEnumerable<vw_books6>
        GetAllBooks(short id_junr) => GetAllBooks().Where(book => book.id_junr == id_junr).ToList();

/**-3-*/public static IEnumerable<vw_books6>
        GetAllBooks(string _search) => GetAllBooks().Where(book => vw_books6_ToString(book).Contains(_search)).ToList();

/**-4-*/public static IEnumerable<vw_books6>
        GetAllBooks(short id_junr, string _search) => GetAllBooks(id_junr).Where(book => vw_books6_ToString(book).Contains(_search));

        /**
        /
        /   2022-06-30
        /
        /   AsNoTracking() --
        /   smotri: "18-Ypoki C#.Entity Framework. chast' 3.mp4",  timing -- 15:54
        /
        /
        /   2022-07-14
        /
        /   LINQ by SQL
        /   result =
        /   (from Pet l in lst where (l.ToString().Contains(str)) select l).ToList<Pet>();
        /
        /   LINQ by API
        /
        / Poisk chuvstvitelen k registru(CaseSensetive), t.e. "B" <> "b"
        */
        public static void Create_Book(Models.IModel_tb_book bk)
        {
            //*System.Windows.Forms.MessageBox.Show("CREATE/ADD/INSERT -- XM_books.EF_Repositories.book_RJ_Repository---56");
            List<sp_book_insert_Result> result;
            string str2;

            result =
            db.sp_book_insert(
                /** bk.Id_uniq.ToString(), */
                bk.Nazvanie,
                bk.Autor,
                bk.Year_print.ToString(),
                bk.Id_junr.ToString()
            ).ToList();

            str2 =
            (result[0].Out_result_error == 0) ? Program.box_msg_book_Edit : Program.box_msg_book_No_edit;

            db.SaveChanges();
            return;
        }
 
        public static Guid Create_Book2(Models.IModel_tb_book bk) //2022-10-24 New(!)
        {
            //*System.Windows.Forms.MessageBox.Show("CREATE/ADD/INSERT -->EF_Repositories.book_RJ_Repository-->80");
            List<sp_book_insert2_Result> result;

            result =
            db.sp_book_insert2(
                /** bk.Id_uniq.ToString(), */
                bk.Nazvanie,
                bk.Autor,
                bk.Year_print.ToString(),
                bk.Id_junr.ToString()
            ).ToList();

            string str2 = (result[0].Out_result_error == 0) ? Program.box_msg_book_Edit : Program.box_msg_book_No_edit;
            Guid id_uniq = (Guid)result[0].id_uniq;

            db.SaveChanges();
            return id_uniq; // result[0].id_uniq;
        }

        public static void Update_Book(Models.IModel_tb_book bk)  // O'key !!  2022-10-26
        {
            //*System.Windows.Forms.MessageBox.Show("UPDATE/Edit -->EF_Repositories.book_RJ_Repository--->101");

            List<sp_book_update_Result> result;

            result =
            db.sp_book_update(
                bk.Id_uniq.ToString(),
                bk.Nazvanie,
                bk.Autor,
                bk.Year_print.ToString(),
                bk.Id_junr.ToString()
            ).ToList();

            string str2 =
            (result[0].Out_result_error == 0) ? Program.box_msg_book_Edit : Program.box_msg_book_No_edit;

            db.SaveChanges();
            return; // O'key !!  2022-10-26
        }

        public static void Delete_Book(Guid id_book)
        {
            var bk = db.tb_books.Where(bo => bo.id_uniq == id_book).First();
            var rslt = db.tb_books.Remove(bk).ToString();
            db.SaveChanges();
        }

        /**Service */
        public static string vw_books6_ToString(XM_books.EF_Books.vw_books6 book)
        {
            return String.Format("{0}~{1}~{2}~{3}", book.nazvanie, book.autor, book.PublicYear, book.name_junr);
        }
    }
}
/** ----------------------------------------------------------------------------
getAllBooks(short id_junr) =>
db.vw_books6.AsNoTracking().Where(book => book.id_junr == id_junr).ToList();

var iEnum = getAllBooks(id_junr);
*/

/**
=>
db.vw_books6.AsNoTracking().Where(book =>
(book.id_junr == id_junr) && (vw_books6_ToString(book).Contains(_search))).ToList();
*/

/**
=>
db.vw_books6.AsNoTracking().Where(book =>
(book.id_junr == id_junr) && (vw_books6_ToString(book).Contains(_search))).ToList();
*/

/**
/  STATIC(!) methods 
/          
/  public static IEnumerable<vw_junrs_for_menu2> getAllJunrs()
/  {
/      using (db = new BOOKSEntities())
/      {
/          return db.vw_junrs_for_menu2.AsNoTracking().ToList();
/      }
/  }
*/