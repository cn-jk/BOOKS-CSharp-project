using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XM_books.EF_Books;

namespace XM_books.Views
{
    public interface IBookForm2
    {
        // field(s) & properties publik -----------------------------------------------
        bool   IsSuccessful  { get; set; }
        string Message       { get; set; }
        bool   IsEdit        { get; set; }


        // event(s) publik ------------------------------------------------------------
        event EventHandler btnSave_Click;


        // method(s) publik -----------------------------------------------------------
        void Junrs_SetCollectionBindingSource(IDictionary<short, string> junrsDictionary);
        void Set_Book_dictionary(IDictionary<string, string> book_dictionary);
        void Show(); //Optional
        IDictionary<string, string>  Get_Book_dictionary();
    }
}

        //-//-//-//-//  bool IsCreatedNextNewBook { get; set; }

        // Exit/Close
        // btnClose ?????
        // 2022-10-12 this event must be internal !!   --->   event EventHandler ExitEvent;

        //void Junrs_SetCollectionBindingSource(BindingSource junrsBinding);
        //void Books_SetCollectionBindingSource(BindingSource booksBinding);