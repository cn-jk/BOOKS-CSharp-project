using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using XM_books.Models;
using XM_books.Views;
using XM_books.EF_Repositories;

namespace XM_books.Presenters
{
    public interface IMainPresenter2 // 2022-09-24 -- malen`kie formal`nosti
    {
    }

    public class MainPresenter2: IMainPresenter2
    {
        //field(s) -------------------------------------------------------------
        private readonly Models.IMainFormModel _model;
        private readonly Views.IMainForm _view;

        private readonly BindingSource _books_BindingSource;
        private readonly BindingSource _junrs_BindingSource;

        private readonly BindingList<Models.IModel_genre>   _junrs_BindingList;
        private readonly BindingList<Models.IModel_vw_book> _books_BindingList;

        // konstruktor ---------------------------------------------------------
        public MainPresenter2(IMainForm view, IMainFormModel model) // mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
        {
            this._view  = view;
            this._model = model;

            this._junrs_BindingList   = new BindingList<Models.IModel_genre>();       // 2022-09-06
            this._junrs_BindingSource = new BindingSource(_junrs_BindingList, null);

            this._books_BindingList   = new BindingList<Models.IModel_vw_book>();     // 2022-09-06
            this._books_BindingSource = new BindingSource(_books_BindingList, null);

            //Subscribe event_handler methods to view events
            this._view.FilterEvent     += this._FilterBooks;
            this._view.btnAdd_Click    += this._Show_AddBookForm2;
/** <<-- -*/this._view.btnEdit_Click   += this._Show_EditBookForm2; // ****** new EventHandler(_Show_EditBookForm);
/** <<-- -*/this._view.btnDelete_Click += new EventHandler(_Delete_Book);
/** <<-- -*/this._view.btnExit_Click   += new EventHandler(_Cancel_Book);

            //Load  junrs,  books  to  list
            this._LoadAll_JunrsList(_junrs_BindingList);
            this._LoadAll_BooksList(_books_BindingList); //2022-09-30 nado pereOpisat' dgvBooks --

            //Set books bindind source this method it's o'key!
            this._view.Books_SetCollectionBindingSource(_books_BindingSource, _junrs_BindingSource);

            this._junrs_BindingSource.Position = (_junrs_BindingList.Count > 0) ? 0 : -1;
            this._books_BindingSource.Position = (_books_BindingList.Count > 0) ? 0 : -1;

            this._view.cmbJunrs_CurrentIndex = this._junrs_BindingSource.Position;

            this._view.txtSearchCurrentText = "";
        }

        // method(s) -----------------------------------------------------------
        private void _FilterBooks(object sender, EventArgs e)
        {
            //Off-Subscribe event_handler methods to view events
            this._view.FilterEvent              -= this._FilterBooks;
            this._view.btnAdd_Click             -= this._Show_AddBookForm2; // ****** this._view.btnAdd_Click  -= new EventHandler(_Show_AddBookForm);
            this._view.btnEdit_Click            -= this._Show_EditBookForm2; // ****** this._view.btnEdit_Click -= new EventHandler(_Show_EditBookForm);
            this._view.btnDelete_Click          -= new EventHandler(_Delete_Book);
            this._view.btnExit_Click            -= new EventHandler(_Cancel_Book);


            var str = this._txtSearch_Validation(this._view.txtSearchCurrentText); //2022-09-30 = this._view.cmbJunrs_CurrentItem["id_junr"];
            var i = this._view.cmbJunrs_CurrentIndex;
            short index = this._junrs_BindingList[i].id_junr;

            // ** this._filter_BooksList_EF(this._books_BindingList_EF, index, str);
            this._filter_BooksList(this._books_BindingList, index, str);

            //refresh dgvBooks
            this._view.Show();

            //On-Subscribe event_handler methods to view events
            this._view.FilterEvent              += this._FilterBooks;
            this._view.btnAdd_Click             += this._Show_AddBookForm2; // ****** this._view.btnAdd_Click  += new EventHandler(_Show_AddBookForm);
            this._view.btnEdit_Click            += this._Show_EditBookForm2; // ****** this._view.btnEdit_Click += new EventHandler(_Show_EditBookForm);
            this._view.btnDelete_Click          += new EventHandler(_Delete_Book);
            this._view.btnExit_Click            += new EventHandler(_Cancel_Book);

            return;
        }

        private string _txtSearch_Validation(string str)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(str);
            if (emptyValue == false) return str; // this.petList = repository.GetByValue(str).ToList();
            return "";
        }

/**-+-*/private void _filter_BooksList(IList<IModel_vw_book> list_, short id_junr, string txtSearch)
        {
            if (id_junr == Model_genre._id_junr_AllJunrs)
            {
                var bl = 
                (txtSearch.Equals("") == true) ? this._model.set_BooksList(list_) : _model.set_BooksList(list_, txtSearch); 
            }
            else
            {
                var bl =
                (txtSearch.Equals("") == true) ? this._model.set_BooksList(list_, id_junr) : _model.set_BooksList(list_, id_junr, txtSearch);
            }
            return;
        }

        private void _LoadAll_BooksList(BindingList<Models.IModel_vw_book> _booksList)
        {
            this._model.set_BooksList(_booksList);
            return;
        }

        private void _LoadAll_JunrsList(BindingList<Models.IModel_genre> _junrsList)
        {
            this._model.set_JunrsList(_junrsList);
            /**
            / 2022-09-30 -- Added punkt:"vse junry" v List dlja comboBox:"cmbJunr".
            / 2022-09-30 -- by static method not instanse dbject (new Models.Model_genre()).Get_DefaultJunr();
            */
            var junr_all = Models.Model_genre.Get_junr_AllJunrs();

            _junrsList.Insert(0, junr_all);   // 2022-10-02

            _junrs_BindingSource.Position = 0;// 2022-10-04 !! .ResetCurrentItem(); //.Current as Models.Model_genre;
            return;
        }

        #region EVENTS

/**>+<*/private void _Cancel_Book(object sender, EventArgs ev) { } /** 2022-09-04 */

/**>+<*/private void _Delete_Book(object sender, EventArgs ev)
        {
            var position = this._books_BindingSource.Position;
            var nn = this._books_BindingList[position].Nn;

            var message = Program.box_msg_6;
            message = String.Format("{0} {1}", message, nn);

            var result = MessageBox.Show(message, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.No) return; //CHAOO --> NATHYNE ACTION COMMEBACK TO DATAGRIDVIEW

            try                                    //delete book
            {
                Guid id_book = this._books_BindingList[position].Id_book; //Guid id_book = Guid.Parse(_view.dgvBooks_CurrentRow_["id_book"]);
                _model.mdl_DeleteBook(id_book);

                this._books_BindingSource.RemoveAt(position);             //this._books_BindingSource.List.RemoveAt(position);
            }
            catch (Exception ex)
            {
                message = String.Format("{0} {1}", ex, "MainPresenter >>>> _Delete_Book--------- 86");
                MessageBox.Show(message, Program.box_title);
            }
        }

/** <<*/private void _Show_AddBookForm2(object sender, EventArgs ev)
        {     
            //*MessageBox.Show("MainPresenter_2 >>> _Show_AddBookForm-2222----------170", Program.box_title);
            /**
            /
            / SINGLETON pattern (Open a single form instance) -- SPISOK LITERATURY: YOUTUBE -- RJ_Code CRUD-MVP
            /
            / first variant of konstruktor: IBookForm view = new BookForm();
            / IBookForm view = BookForm.GetInstace((MainForm)_view);
            /
            */

            // 2-nd 2222222222222222222222222222222222222222222222222222222222

            IBookForm2 view = BookForm2.GetInstace();

            var x1 = this._junrs_BindingSource;
            var x2 = this._books_BindingSource;
            var x3 = this._view.txtSearchCurrentText;
            var x4 = view.IsEdit = false;

            IBookModel2 model2 = new BookModel2(x1, x2, x3, x4);

            new Presenters.BookPresenter2(model2, view);
            return;
        }

/** <<*/private void _Show_EditBookForm2(object sender, EventArgs ev)
        { 
            //*MessageBox.Show("MainPresenter_2 >>> _Show_EditBookForm-2222----------198", Program.box_title);
            /**
            /
            / SINGLETON pattern (Open a single form instance) -- SPISOK LITERATURY: YOUTUBE -- RJ_Code CRUD-MVP
            /
            / first variant of konstruktor: IBookForm view = new BookForm();
            / IBookForm view = BookForm.GetInstace((MainForm)_view);
            /
            */

            // 2-nd

            IBookForm2 view = BookForm2.GetInstace();

            var x1 = this._junrs_BindingSource;
            var x2 = this._books_BindingSource;
            var x3 = this._view.txtSearchCurrentText;
            var x4 = view.IsEdit = true;

            IBookModel2 model2 = new BookModel2(x1, x2, x3, x4);

            new Presenters.BookPresenter2(model2, view);            
            return;
        }

        #endregion
    }
}

// **** private void OnSearchButtonClick() => this.model.mdl_Search();
// **** private void OnJunrIndexChange(int junrsIndex) => this.model.mdl_JunrsIndex = (short)junrsIndex;
// **** private void OnUpdateButtonClick(object sender, EventArgs e) => throw new NotImplementedException();
// **** private void OnDeleteButtonClick(object sender, EventArgs e) => throw new NotImplementedException();
// **** private void OnCancelButtonClick(object sender, EventArgs e) => throw new NotImplementedException();
// **** //MessageBox.my_Show("MainPresenters-->CreateNewBook" + sender + e, Program.box_title);

// var gh = this._books_BindingSource.SupportsFiltering; //2022-09-30 --> KASTYL_ --> false => filtering not work !!


// )))))))) this._view.dgvBooks_CurrentIndex = this._books_BindingSource.Position;

// ====== ))))))) private void Book_CurrentChanged(object sender, EventArgs e)
// ====== ))))))) {
// ====== )))))))     var position = this._view.dgvBooks_CurrentIndex;
// ====== )))))))     this._view.dgvBooks_CurrentIndex = ++position;
// ====== )))))))     return;
// ====== ))))))) }

// ======= this._view.Book_CurrentChangedEvent += this.Book_CurrentChanged;
// ======= this._view.Book_CurrentChangedEvent -= this.Book_CurrentChanged;
