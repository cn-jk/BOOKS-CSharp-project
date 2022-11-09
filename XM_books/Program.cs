using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using XM_books.Models;
using XM_books.Views;
using XM_books.Presenters;

namespace XM_books
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //klasik shema for MVP !

            /**
            /   2022-08-24 ?????
            /
            /   Models.IMainFormRepository
            /   _model     = new EF_Repositories.book_RJ_Repository();
            */

            IMainForm      view      = new MainForm();
/**- ??? -*/IMainFormModel model     = new MainFormModel();
            // IMainPresenter presenter = new MainPresenter(view, model);
            IMainPresenter2 presenter = new MainPresenter2(view, model);

            //It is 1-rst_run/General_start            
            Application.Run((Form)view);
        }

        #region FormText
      //private string strText = "Form1--btn_Add_Edit_Click--Проверка кириллицы"; // ????
        public static readonly string frm_titleMainForm = "КНИГИ/BOOKS";
        public static readonly string frm_titleNewEdit  = "/BOOKS";
        public static readonly string frm_Search  = "Искать";
        public static readonly string frm_Add     = "Добавить";
        public static readonly string frm_NewBook = "НОВАЯ КНИГА"; // "Новая книга";
        public static readonly string frm_NumBook = "**"; // "***";
        public static readonly string frm_NN      = "№"; // frm_Nomer   = "№";
        public static readonly string frm_Edit    = "РЕДАКТИРОВАНИЕ"; // КНИГА "Редактировать"; "Редактировать";
        public static readonly string frm_Kniga   = "КНИГА"; // "РЕДАКТИРОВАНИЕ"; // КНИГА "Редактировать"; "Редактировать";
        public static readonly string frm_Del     = "Удалить->";
        public static readonly string frm_DelBook = "Удалить->";
        public static readonly string frm_Cansel  = "Выйти";
        public static readonly string frm_Close   = "Выйти";
        public static readonly string frm_Save    = "Сохранить";
        public static readonly string frm_CountRows ="Всего строк:"; // ВСЕГО СТРОК: status_COUNT
        public static readonly string frm_CurrentRow = "Текущая строка:"; //(№)НОМЕР ТЕКУЩЕЙ СТРОКИ: status_NOMERSTROKI, status_TEKUSCHAISTROKI status_CURRENTROW
        public static readonly string frm_Nazvanie= "Название книги";
        public static readonly string frm_Avtor =   "Автор(ы)";
        public static readonly string frm_Genre =   "Жанр книги";
        public static readonly string frm_Genre_default = "другое";  // "другое"(20) == "жанр не указан" == "Жанр не указан"
        public static readonly string frm_YearPrint = "Год издания";
        public static readonly string frm_YearPrint2= "Год\nиздания";
        public static readonly string frm_Vse_junry = "все жанры";

        public static readonly string box_title = "ВНИМАНИЕ!";
        public static readonly string box_msg = "Будем удалять выбранную строку?";
        public static readonly string box_msg_2 = "Количество отобранных записей: ";
        public static readonly string box_msg_4 = "Выберите строку для удаления.";
        public static readonly string box_msg_6 = "Удалить строку № -> ";
        public static readonly string box_msg_nazvanie = "Укажите [Название книги]";
        public static readonly string box_msg_avtor = "Укажите [Автора(ов)] книги";
        public static readonly string box_msg_junr = "Укажите [Жанр] книги";
        // не_указан
        public static readonly string box_msg_book_Added = "Да! Данные успешно добавленыn";
        public static readonly string box_msg_book_Create2 = "Хотите добавить ещё одну новую книгу?";
        public static readonly string box_msg_book_No_added = "Нет! Не могу добавить эту книгу!";


        public static readonly string box_msg_book_Edit = "Эта книга успешно сохранена!";
        public static readonly string box_msg_book_No_edit = "Не могу сохранить эту книгу!";

        public static readonly string box_msg_book_Edit2= "Да! Данные успешно сохранены.";
        public static readonly string box_msg_book_No_edit2= "Нет! Данные не сохраненны.";

        public static readonly string box_msg_count_records = "Количество отобранных записей: ";
        public static readonly string box_msg20 = "";
        
        public static readonly string box_msg_tb_book_validation_erroe_01 = "Нет! Надо указать - [Название книги]";
        public static readonly string box_msg_tb_book_validation_erroe_02 = "Нет! В поле [Название книги] может быть от 3-ёх до 50 знаков";

        public static readonly string box_msg_tb_book_validation_erroe_03 = "Нет! Надо указать - [Автор(ы)]";
        public static readonly string box_msg_tb_book_validation_erroe_04 = "Нет! В поле [Автор(ы)] может быть от 3-ёх до 50 знаков";

        public static readonly string box_msg_tb_book_validation_erroe_05 = "Нет! Арабскими цифрами надо указать - [Год] издания книги]";
        public static readonly string box_msg_tb_book_validation_erroe_06 = "Нет! Год издания может быть от -32000(до н.э.) до 2500(н.э.)";

        #endregion

    }
}
