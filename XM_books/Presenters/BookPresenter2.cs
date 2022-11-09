using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using XM_books.Models;
using XM_books.Views;

namespace XM_books.Presenters
{
    internal interface IBookPresenter2
    {
    }
    
    internal class BookPresenter2 : IBookPresenter2
    {
        //field(s) -------------------------------------------------------------
        private readonly IBookModel2 _model;        // // private readonly IMainFormModel _model;
        private readonly IBookForm2 _view;          // <---------- !!!  private IBookForm2 _view;

        //propertie(s) ---------------------------------------------------------

        //konstruktor(s) -------------------------------------------------------
        public BookPresenter2(IBookModel2 md, IBookForm2 vw) //, BindingSource junrs) //public BookPresenter2(IBookModel2 md, IBookForm vw, BindingSource junrs)
        {
            /**=-1-=*/ // add  -- konstruktor(s) --
            this._model            = md;
            this._view             = vw;
            this._view.IsEdit      = md.IsEdit;
            //this._view.IsCreatedNextNewBook = true; // false; --<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<----------

            /**=-2-=*/ //Set books bindind source this method it's o'key!
            var junrs = this._model.Junrs_getdictionary();
            this._view.Junrs_SetCollectionBindingSource(junrs);

            /**=-3-=*/
            //-//-//-//-// var bk_dictionary = md.Vw_book.Book_to_dictionary();
            var bk_dictionary = Model_vw_book.Book_to_dictionary(md.Vw_book);
            this._view.Set_Book_dictionary(bk_dictionary);

            /**=-4-=*/ //Subscribe event_handler methods to view events
            this._view.btnSave_Click += this.SaveBook;     // this._view.btnSave_Click += new EventHandler(SaveBook);

            this._view.Show();
        }

        // method(s) -----------------------------------------------------------

        private void SaveBook(object sender, EventArgs ev)
        {
            //*MessageBox.Show("BookPresenter_2-->SaveBook--------------------------55", Program.box_title);

            var bk_dictionary = this._view.Get_Book_dictionary();
            var tb_book = new Model_tb_book(bk_dictionary); //var model = new PetModel();;

            try
            {
                /**-1-*/
                new Common.ModelDataValidation().Validate(tb_book);

                /**-2a-*/
                _view.IsSuccessful = true;      // yes !!
                _view.Message = "";

                /**-3-*/
                if (this._model.IsEdit == true) // --- edit/update book
                {
                    var result = this._model.Book_SaveUpdateEdit(tb_book); // --> goto-forward "BookModel2.cs" --> line: 85
                    return;                                                // --> goto-back    "BookForm2.cs"  --> line: 64
                }
                else                            // --- add/create book
                {
                    var result = this._model.Book_SaveCreateNew(tb_book);  // --> goto-forward "BookModel2.cs" --> line:130 
                    return;                                                // --> goto-back    "BookForm2.cs"  --> line: 64
                }
            }
            catch (Exception ex)
            {
                /**-2b-*/
                _view.IsSuccessful = false;
                _view.Message = ex.Message;

            }
            return;                                                        // --> goto-back    "BookForm2.cs"  --> line: 64
        }
    }
}
                // ////// var message = (this._view.IsEdit == true)
                // //////     ? "BookPresenter-->_UPDATE__Book---------------------------61"
                // //////     : "BookPresenter-->_INSERT__Book---------------------------61";
                // ////// 
                // ////// message = String.Format("{0}\n{1}", message, ex);
                // ////// MessageBox.Show(message, Program.box_title);
