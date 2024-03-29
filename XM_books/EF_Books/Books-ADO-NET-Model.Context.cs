﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace XM_books.EF_Books
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class BOOKSEntities : DbContext
    {
        public BOOKSEntities()
            : base("name=BOOKSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tb_books> tb_books { get; set; }
        public virtual DbSet<vw_books6> vw_books6 { get; set; }
        public virtual DbSet<vw_junrs_for_menu2> vw_junrs_for_menu2 { get; set; }
    
        public virtual ObjectResult<sp_book_delete_Result> sp_book_delete(string str_id_uniq)
        {
            var str_id_uniqParameter = str_id_uniq != null ?
                new ObjectParameter("str_id_uniq", str_id_uniq) :
                new ObjectParameter("str_id_uniq", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_book_delete_Result>("sp_book_delete", str_id_uniqParameter);
        }
    
        public virtual ObjectResult<sp_book_insert_Result> sp_book_insert(string str_nazvanie, string str_autor, string str_year_print, string str_id_junr)
        {
            var str_nazvanieParameter = str_nazvanie != null ?
                new ObjectParameter("str_nazvanie", str_nazvanie) :
                new ObjectParameter("str_nazvanie", typeof(string));
    
            var str_autorParameter = str_autor != null ?
                new ObjectParameter("str_autor", str_autor) :
                new ObjectParameter("str_autor", typeof(string));
    
            var str_year_printParameter = str_year_print != null ?
                new ObjectParameter("str_year_print", str_year_print) :
                new ObjectParameter("str_year_print", typeof(string));
    
            var str_id_junrParameter = str_id_junr != null ?
                new ObjectParameter("str_id_junr", str_id_junr) :
                new ObjectParameter("str_id_junr", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_book_insert_Result>("sp_book_insert", str_nazvanieParameter, str_autorParameter, str_year_printParameter, str_id_junrParameter);
        }
    
        public virtual ObjectResult<sp_book_update_Result> sp_book_update(string str_id_uniq, string str_nazvanie, string str_autor, string str_year_print, string str_id_junr)
        {
            var str_id_uniqParameter = str_id_uniq != null ?
                new ObjectParameter("str_id_uniq", str_id_uniq) :
                new ObjectParameter("str_id_uniq", typeof(string));
    
            var str_nazvanieParameter = str_nazvanie != null ?
                new ObjectParameter("str_nazvanie", str_nazvanie) :
                new ObjectParameter("str_nazvanie", typeof(string));
    
            var str_autorParameter = str_autor != null ?
                new ObjectParameter("str_autor", str_autor) :
                new ObjectParameter("str_autor", typeof(string));
    
            var str_year_printParameter = str_year_print != null ?
                new ObjectParameter("str_year_print", str_year_print) :
                new ObjectParameter("str_year_print", typeof(string));
    
            var str_id_junrParameter = str_id_junr != null ?
                new ObjectParameter("str_id_junr", str_id_junr) :
                new ObjectParameter("str_id_junr", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_book_update_Result>("sp_book_update", str_id_uniqParameter, str_nazvanieParameter, str_autorParameter, str_year_printParameter, str_id_junrParameter);
        }
    
        public virtual ObjectResult<sp_book_insert2_Result> sp_book_insert2(string str_nazvanie, string str_autor, string str_year_print, string str_id_junr)
        {
            var str_nazvanieParameter = str_nazvanie != null ?
                new ObjectParameter("str_nazvanie", str_nazvanie) :
                new ObjectParameter("str_nazvanie", typeof(string));
    
            var str_autorParameter = str_autor != null ?
                new ObjectParameter("str_autor", str_autor) :
                new ObjectParameter("str_autor", typeof(string));
    
            var str_year_printParameter = str_year_print != null ?
                new ObjectParameter("str_year_print", str_year_print) :
                new ObjectParameter("str_year_print", typeof(string));
    
            var str_id_junrParameter = str_id_junr != null ?
                new ObjectParameter("str_id_junr", str_id_junr) :
                new ObjectParameter("str_id_junr", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_book_insert2_Result>("sp_book_insert2", str_nazvanieParameter, str_autorParameter, str_year_printParameter, str_id_junrParameter);
        }
    }
}
