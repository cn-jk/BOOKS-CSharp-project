using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using XM_books.EF_Repositories;
using XM_books.EF_Books;

namespace XM_books.Models
{
    public interface IModel_tb_book
    {
        Guid   Id_uniq    { get; set; }
        string Nazvanie   { get; set; }
        string Autor      { get; set; }
        short  Year_print { get; set; }
        short  Id_junr    { get; set; }

        //EF_Books.tb_books convert_to_EF_Books_tb_books();   2022-11-06
        //IModel_tb_book    Get_tb_book_default();            2022-11-06

        string            ToSting();
        string            ToStingForSort();
        int               CompareTo(IModel_tb_book other);
    }
    /**
    /  2022-08-26
    /  Models:  Model_book <> Model_vw_books6 !!
    */
    public class Model_tb_book : IModel_tb_book, IComparable<IModel_tb_book>
    {
        #region fields(polia) mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
        private EF_Books.tb_books tb_book;
        #endregion


        #region properties(svoystva) -- plus Validations mmmmmmmmmmmmmmmmmmmmmmm
        [DisplayName("ID_Book")]
        public System.Guid Id_uniq { get { return this.tb_book.id_uniq; } set { this.tb_book.id_uniq = value; } }

        [DisplayName("Hazvanie")]
        [Required(ErrorMessage = "Нет! Надо указать - [Название книги]")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Нет! В поле [Название книги] может быть от 3-ёх до 50 знаков")]
        public string Nazvanie  { get { return this.tb_book.nazvanie; } set { this.tb_book.nazvanie = value; } }

        [DisplayName("Autor(y)")]
        [Required(ErrorMessage = "Нет! Надо указать - [Автор(ы)]")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Нет! В поле [Автор(ы)] может быть от 3-ёх до 50 знаков")]
        public string Autor     { get { return tb_book.autor; } set { tb_book.autor = value; } }

        [DisplayName("God Izdania")]
        [Required(ErrorMessage = "Нет! Арабскими цифрами надо указать - [Год] издания книги]")]
        [Range(-32000, 2100, ErrorMessage = "Нет! Год издания может быть от -32000(до н.э.) до 2500(н.э.)")]
        public short Year_print { get { return tb_book.year_print; } set { tb_book.year_print = value; } }

        [DisplayName("ID_Zhanr")]
        public short Id_junr    { get { return tb_book.id_junr; } set { tb_book.id_junr = value; } }
        #endregion


        #region konstruktor(y) mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
        public Model_tb_book()                                        //2022-10-14
        {
            this.tb_book = new EF_Books.tb_books();
        }
        public Model_tb_book(EF_Books.tb_books bk)                    //2022-10-14
            : this()
        {
            this.tb_book = bk;
        }
        public Model_tb_book(Models.Model_vw_book vw)                 //2022-10-14
            : this()
        {
            this.tb_book.id_uniq    = vw.Id_book;
            this.tb_book.nazvanie   = vw.Nazvanie;
            this.tb_book.autor      = vw.Autor;
            this.tb_book.year_print = vw.Year_print;
            this.tb_book.id_junr    = vw.Id_junr;
        }
        public Model_tb_book(IDictionary<string, string> bd)          //2022-10-26
            : this()
        {
            this.tb_book.id_uniq    = Guid.Parse(bd["Id_book"]);
            this.tb_book.nazvanie   = bd["Nazvanie"].Trim();
            this.tb_book.autor      = bd["Autor"].Trim();
            this.tb_book.id_junr    = Int16.Parse(bd["Id_junr"]);
            try
            {
                this.tb_book.year_print = Int16.Parse(bd["Year_print"]);
            }
            catch (Exception ex)
            {
                this.tb_book.year_print = 0;
            }
        }
        #endregion


        #region service(s) mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm

        public string ToSting()                     /** 2022-08-26 */
        {
            return string.Format("{0} ~ {1} ~ {2} ~ {3} ~ {4}", Id_uniq, Nazvanie, Autor, Year_print, Id_junr);
        }

        public string ToStingForSort()              /** 2022-08-26 */
        {
            return string.Format("{0} ~ {1} ~ {2} ~ {3}", Id_junr, Autor, Nazvanie, Year_print);
        }

        public int CompareTo(IModel_tb_book other)  /** 2022-08-26 */
        {
            return this.ToStingForSort().CompareTo(other.ToStingForSort());
        }

        #endregion

        #region Service(s) mmmmm static method(s) mmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
        public static IModel_tb_book Get_tb_book_default(IModel_tb_book bk)            // 2022-10-14
        {
            // var tb = new Model_tb_book();
            bk.Id_uniq = Guid.Empty;                    // Id_uniq
            bk.Nazvanie = "";                           // Nazvanie
            bk.Autor = "";                              // Autor
            bk.Year_print = 0;                          // (short)System.DateTime.Now.Year; // Year_print
            bk.Id_junr = Model_genre._id_junr_Default;  // Id_junr
            return bk;
        }

        public static EF_Books.tb_books convert_to_EF_Books_tb_books(IModel_tb_book bk)
        {
            var
            ef_tb = new tb_books();

            ef_tb.id_uniq = bk.Id_uniq;
            ef_tb.nazvanie = bk.Nazvanie;
            ef_tb.autor = bk.Autor;
            ef_tb.year_print = bk.Year_print;
            ef_tb.id_junr = bk.Id_junr;
            return ef_tb;
        }
        #endregion
    }
}
