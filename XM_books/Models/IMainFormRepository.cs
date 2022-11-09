using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XM_books.Models
{
    //2022-08-24 --- Only one !!
    //internal interface IBookRepository   NO !!    // >>>> public
    //internal interface IGenreRepository  NO !!    // >>>> public

    internal interface IMainFormRepository // >>>> public
    {
        /**
        /  CRUD  from  Entity_Framework(Books-ADO-NET-Model)
        /  
        /  IPetRepository.cs
        /  
        /  Add    == Create == Insert
        /  GetAll == READ   == Select
        /  Get    == READ   == Select by "WHERE"
        /  Edit   == Update == 
        /  Del    == Delete == 
        */
        void  Create_Book(IModel_tb_book bookModel);
        void  Update_Book(IModel_tb_book bookModel);
        void  Delete_Book(Guid value);
        /**
        /  CRUD --> R_E_A_D
        */
        IEnumerable<XM_books.EF_Books.vw_junrs_for_menu2> GetAllJunrs();
        IEnumerable<XM_books.EF_Books.vw_books6> GetAllBooks();
        IEnumerable<XM_books.EF_Books.vw_books6> GetAllBooks(short id_junr);
        IEnumerable<XM_books.EF_Books.vw_books6> GetAllBooks(short id_junr, string _search);
        IEnumerable<XM_books.EF_Books.vw_books6> GetAllBooks(string _search);

        /**  Services */
        string vw_books6_ToString(XM_books.EF_Books.vw_books6 book);
    }
}
        //IEnumerable<Models.Model_vw_books6>  GetAllBooks();
        //IEnumerable<Models.Model_vw_books6>  GetAllBooks(short value);
        //IEnumerable<Models.Model_genre> GetAllJunrs();
        //IEnumerable<Model_vw_books6> GetByValue(string value);
