using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace XM_books.Models
{
    public interface IModel_genre
    {
        string name_junr { get; set; }
        short id_junr { get; set; }

        int CompareTo(IModel_genre other); //2022-08-12
    }
    /**
    /  2022-08-26
    /  Models:  Model_genre === Model_junr === Model_vw_junrs_for_menu2 !!
    */
    public class Model_genre : IModel_genre, IComparable<IModel_genre>
    {

        //field(s) mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
        private short  _id_junr;
        private string _name_junr;

        public static readonly short  _id_junr_AllJunrs  = 10;                        //mmmmmmmm--TIPA KASTYL_ ??--mmmmmmmmmmmmmm
        public static readonly string _name_junr_AllJunrs=Program.frm_Vse_junry;      //mmmmmmmm--TIPA KASTYL_??--mmmmmmmmmmmmmmm

        public static readonly short  _id_junr_Default   = 20;                        //mmmmmmmm--TIPA KASTYL_ ??--mmmmmmmmmmmmmm
        public static readonly string _name_junr_Default = Program.frm_Genre_default; //mmmmmmmm--TIPA KASTYL_??--mmmmmmmmmmmmmmm
        /**
        /  "другое" <--> "20"  <-->  "жанр не указан"  <-->  "Жанр не указан"
        */

        //properties mmmmmmmmmmmmmm (svoystva) -- plus Validations mmmmmmmmmmmmm
        [DisplayName("Zhanr")]
        [Required(ErrorMessage = "Hado ukazat_ nazvanie ...")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Hazvanie dolzhno byt_ po dline ot 1 do 50 bukv")]
        public string name_junr { get => _name_junr; set => _name_junr = value; }

        public short id_junr { get { return _id_junr; } set { _id_junr = value; } }


        //konstruktor(y) mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
        public Model_genre()
        {
        }
        public Model_genre(XM_books.EF_Books.vw_junrs_for_menu2 vw)
        {
            this.name_junr = vw.nazvanie;
            this.id_junr = vw.id_value;
        }        
        public Model_genre(string id, string name)
        {
            this.name_junr = name;
            this.id_junr = short.Parse(id);
        }
        public Model_genre(short id, string name)
        {
            this.name_junr = name;
            this.id_junr = id;
        }        
        public Model_genre(IDictionary<string, string> vw)
        {
            this.name_junr = vw["name_junr"];
            this.id_junr = short.Parse(vw["id_junr"]);
        }

        public int CompareTo(IModel_genre other) //2022-08-12
        {
            if (other == null)  return -1;
            if (this.id_junr == other.id_junr) return 0;
            if (this.id_junr >  other.id_junr) return 1;
            return -1;
        }

        #region Service(s) mmmmm static method(s) mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
        public static IModel_genre Get_junr_default()
        {
            var junr_Default = new Model_genre(_id_junr_Default, _name_junr_Default);
            return junr_Default;
        }
        public static IModel_genre Get_junr_AllJunrs()
        {
            var junr_AllJunrs = new Model_genre(_id_junr_AllJunrs, _name_junr_AllJunrs);
            return junr_AllJunrs;
        }
        public static KeyValuePair<Int16, string>[] Junrs_getarrray(IList<IModel_genre> _junrs_list)
        {
            var junrsArray = new KeyValuePair<short, string>[_junrs_list.Count];
            var junrsList2 = new List<KeyValuePair<short, string>>();
            foreach (IModel_genre j in _junrs_list)
            {
                junrsList2.Add(new KeyValuePair<short, string>(j.id_junr, j.name_junr));
            }
            junrsList2.CopyTo(junrsArray, 0); // <<-----  _junrs_list.CopyTo(junrsArray, 0); <<-- NOT WORK - NO CAST
            return junrsArray;
        }
        public static IDictionary<Int16, string> Junrs_getdictionary(IList<IModel_genre> _junrs_list)
        {
            var junrsDictionary = new SortedDictionary<short, string>();

            foreach (IModel_genre j in _junrs_list)
            {
                junrsDictionary.Add(j.id_junr, j.name_junr);
            }

            return junrsDictionary;
        }
        #endregion
    }
}
