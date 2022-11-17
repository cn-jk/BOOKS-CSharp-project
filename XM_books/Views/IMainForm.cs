using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XM_books.Models;
using XM_books.Presenters;

namespace XM_books.Views
{
    public interface IMainForm
    {
        string txtSearchCurrentText { get; set; }    /** Yes !! */
        int    cmbJunrs_CurrentIndex  { get; set; }

        /** events -- Pet -- RJ-Code ------------------------------------------- */
        event EventHandler FilterEvent;     /** <-- 2022-09-30 -- "Pet" event EventHandler SearchEvent; */
        event EventHandler btnAdd_Click;    /** <<<---- --- -- -- */
        event EventHandler btnEdit_Click;
        event EventHandler btnDelete_Click;
        event EventHandler btnExit_Click;   /** - 2022-09-04 - */
        
        // method(s) -----------------------------------------------------------
        void Books_SetCollectionBindingSource(BindingSource books_BindingSource, BindingSource junrs_BindingSource);
        void Show(); //Optional
    }
}


       /** Events -- Pet -- RJ-Code -------------------------------------------
       event EventHandler SearchEvent;
       event EventHandler AddNewEvent;
       event EventHandler EditEvent;
       event EventHandler DeleteEvent;
       event EventHandler SaveEvent;
       event EventHandler CancelEvent;
       */