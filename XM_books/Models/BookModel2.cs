using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

using XM_books.EF_Repositories;
using System.Windows.Forms;

namespace XM_books.Models
{
    /**
    /  2022-10-20
    */
    public interface IBookModel2 // mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
    {
        //BindingSource junrsBinding { get; }

        bool               IsEdit     { get; }
        string             TxtSearch  { get; }
        IModel_vw_book     Vw_book    { get; } // set; } // Book  or new(Add),  or update(Edit current)

        IDictionary<short, string> Junrs_getdictionary();

        bool Book_SaveCreateNew(IModel_tb_book tb_book);
        bool Book_SaveUpdateEdit(IModel_tb_book bk);
    }
    /**
    /  2022-10-20
    /  Models:  Model_book <> Model_vw_books6 !!
    */
    public class BookModel2 : IBookModel2 // mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
    {
        //field(s) (pole(ia)) mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm

        private readonly BindingSource _junrs_BindingSource;
        private readonly BindingSource _vw_book_BindingSource;

        private readonly bool _is_edit;
        private readonly string _txtSearch;
        private          IModel_vw_book _vw_book;

        //propertie(s) (svoystvo(a)) mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm

        public bool IsEdit { get => _is_edit; }
        public string TxtSearch { get => _txtSearch; }
        public IModel_vw_book Vw_book { get => _vw_book; }

        //konstruktor(y) mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
        /// <summary>
        /// for added/created new a book
        /// </summary>
        public BookModel2(BindingSource x_junrs_bs, BindingSource x_books_bs, string x_txt, bool is_edit)
        {
            this._is_edit   = is_edit;
            this._vw_book_BindingSource = x_books_bs;
            this._junrs_BindingSource   = x_junrs_bs;

            if (_is_edit == true)                                    // edit
            {
                this._vw_book = (Model_vw_book)(x_books_bs.Current);
            }
            else                                                     // add
            {
                this._vw_book = (new Model_vw_book());
                this._vw_book.Get_vw_book_default2();
            }

            this._txtSearch = x_txt;
        }

        //method(s) mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
        public bool Book_SaveUpdateEdit(IModel_tb_book book)          // O'key !!  2022-10-26
        {
            //*MessageBox.Show("BookModel2-->Book_UpdateEdit---------------------------75", Program.box_title);

            /** 1.Save update in DB */
            EF_Repositories.book_RJ_Repository.Update_Book(book);

            /** 2.Save update  in  Book_List,  Book_BindingSource  and  BindingList */
            {
                /** 2.1. */
                var position = this._vw_book_BindingSource.List.IndexOf(this._vw_book);
                this._vw_book_BindingSource.Position = position;
                var x2 = this._vw_book_BindingSource.Current as Model_vw_book;
                
                /** 2.2.
                / 2022-10-26:
                / var x2 = this._junrs_BindingSource.List[position] as Model_vw_book;
                / This is NOT correct(!)
                */
                {
                x2.Nazvanie = book.Nazvanie;
                x2.Autor = book.Autor;
                x2.Year_print = book.Year_print;
                x2.Id_junr = book.Id_junr;

                var x3 = this._junrs_BindingSource.List;
                foreach (var x6 in x3)
                {
                    var x7 = ((IModel_genre)x6);
                    if (x2.Id_junr == x7.id_junr)
                    {
                        x2.Name_junr = x7.name_junr;
                        break;
                    }
                }
                }

                this._vw_book = this._vw_book_BindingSource.Current as Model_vw_book;

                /** 2.3. My know-how refresh Datagridview after change(edit/update) the book -- 2022-10-26 */
                {
                this._vw_book_BindingSource.Add(this._vw_book);
                this._vw_book_BindingSource.Position = 0;
                this._vw_book_BindingSource.Position = this._vw_book_BindingSource.Count - 1;
                this._vw_book_BindingSource.RemoveCurrent();
                this._vw_book_BindingSource.Position = position;
                }
            }
            return true; // O'key !!  2022-10-26
        }
        
        public bool Book_SaveCreateNew(IModel_tb_book tb_book)
        {
            //*MessageBox.Show("BookModel2-->Book_CreateNew--------------------------130", Program.box_title);

            /** 1.Save create in DB */
                Guid id_uniq = EF_Repositories.book_RJ_Repository.Create_Book2(tb_book);

            /** 2.Save create  in  Book_List,  Book_BindingSource  and  BindingList */
            {
                this._vw_book.Nn = (-1) * (this._vw_book_BindingSource.Count + 1);
                this._vw_book.Nazvanie = tb_book.Nazvanie;
                this._vw_book.Autor = tb_book.Autor;
                this._vw_book.Year_print = tb_book.Year_print;
                this._vw_book.Id_book = id_uniq;
                {
                var junrs= this._junrs_BindingSource.List as IList<IModel_genre>;
                var junr = junrs.Where(j => ((IModel_genre)j).id_junr == tb_book.Id_junr).First();
                this._vw_book.Name_junr = junr.name_junr;
                }
                //-//-//-//-//  this._vw_book_BindingSource.Add(_vw_book.Clone_vw_book()); /** xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx */
                //-//-//-//-//   Model_vw_book -> Clone_vw_book -> line: 085, 200          /** xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx */

                this._vw_book_BindingSource.Add(new Model_vw_book(_vw_book)); 
                /**
                / 2022-10-30 --
                / this._vw_book.Get_vw_book_default2();
                /
                / Chistit' ob'ekt "_vw_book" HE obiazatel'no !!
                / Glavnoe(!) sdelat' klon ot ob'ekta "_vw_book" i
                / sohranit' klona, a HE sam ob'ekt "_vw_book"
                */
            }

            var position = (this._vw_book_BindingSource.Count - 1);

            /** 3.My know-how refresh Datagridview after change(edit/update) the book -- 2022-10-26 */
            {
                this._vw_book_BindingSource.Add(this._vw_book);
                this._vw_book_BindingSource.Position = 0;
                this._vw_book_BindingSource.Position = this._vw_book_BindingSource.Count - 1;
                this._vw_book_BindingSource.RemoveCurrent();
                this._vw_book_BindingSource.Position = position;
            }
            return true; // O'key !!  2022-10-28
        }

        //service(s) mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm

        public IDictionary<short, string> Junrs_getdictionary()
        {
            var _junrs_list = (IList<IModel_genre>)this._junrs_BindingSource.List;

            var junrsDictionary = Model_genre.Junrs_getdictionary(_junrs_list);

            var id_AllJunrs = Model_genre._id_junr_AllJunrs; // _id_junr_AllJunrs == 10

            var id_junr_current = (this._junrs_BindingSource.Current as IModel_genre).id_junr;

            if (this._is_edit == true) // edit(update) - mode
            {
            }
            else                       // add(create)  - mode
            {
                if (id_junr_current == id_AllJunrs)
                {
                }
                else
                {
                    return junrsDictionary.Where(j => j.Key == id_junr_current).ToDictionary(k => k.Key, k => k.Value);
                }
            }
            return junrsDictionary.Where(j => j.Key != id_AllJunrs).ToDictionary(k => k.Key, k => k.Value);
        }

    }
}

// // SortedDictionary<short, string> Junrs_getdictionary();
// // KeyValuePair<short, string>[] Junrs_getarrray();
// // public KeyValuePair<Int16, string>[] Junrs_getarrray()
