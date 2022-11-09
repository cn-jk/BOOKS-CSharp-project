using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XM_books.Views
{
    public partial class BookForm2 : Form, IBookForm2
    {
        #region field(s) mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
        private   bool _isSuccessful;
        private string _message;
        private   bool _isEdit;
        private string _id_book;
        #endregion

        #region propertie(s) mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
        public   bool IsSuccessful
        {
            get => this._isSuccessful;
            set => _isSuccessful = value;
        }
        public string Message
        {
            get => this._message;
            set => this._message = value;
        }
        public   bool IsEdit
        { 
            get => this._isEdit;
            set => _isEdit = value;
        }
        #endregion

        #region eventHandler(s) mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
        public event EventHandler btnSave_Click;
        //2022-10-12 public event EventHandler ExitEvent; // ???????????????????
        //2022-10-12 public event EventHandler btnCancel_Click; // ???????????????????
        #endregion

        #region konstruktor(s) #region KOHCTPUKTOP publik(!) mmmmmmmmmmmmmmmmmmm
        public BookForm2()
        {
            InitializeComponent();
        }
        #endregion

        #region Services private mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm

        private void AssociateAndRaiseViewEvents()
        {
            this.btnSave.Click += delegate { this.Delegate_SaveClick(); };

            this.btnExit.Click += (s, e) => { this.Close(); }; // goto OnFormClosing(..) -- 2022-10-12 --> this.btnExit_Click; }

            this.FormClosing += this.OnFormClosing;

            return;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            //*MessageBox.Show("BookForm_2 --> OnLoad --------------------------- 65", Program.box_title);

            var Title_Form = this.Text;
            Title_Form = (IsEdit == true)
                ? String.Format("{0} {1}{1} {2}", Program.frm_Kniga, Program.frm_NN, Title_Form)
                : String.Format("{0} {1}{1} {2}", Program.frm_NewBook, Program.frm_NN, Program.frm_NumBook);

            this.Text = Title_Form;

            this.btnSave.Text = (IsEdit == true)
                ? String.Format("{0}", Program.frm_Save)
                : String.Format("{0}", Program.frm_Add);

            // delegate event(s) -----------------------------------------------
            this.AssociateAndRaiseViewEvents();
            return;
        }

        private void OnFormClosing(object sender, EventArgs e)
        {
            //*MessageBox.Show("BookForm_2 --> OnFormClosing --------------------------- 85", Program.box_title);
            /**
            / 2022-10-12
            / handler(обробник) for this.Close() and for "[X] - cancel_button" in title_bar on Form/Window 
            */
            return;
        }

        private void txtPrintYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            /**
            / https://www.youtube.com/watch?v=4dItiM75iOQ
            / "Как принимать только числа в TextBox С#"
            */
            e.Handled = !char.IsNumber(e.KeyChar);
            return;
        }

        private void Delegate_SaveClick()
        {
            this.btnSave_Click?.Invoke(this, EventArgs.Empty);         // go to "BookPresenter.cs" line: 50

            if (this._isEdit == true) // edit/update eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee
            {
                if (this._isSuccessful == true)
                {
                    this.Message = String.Format("-- {0} --", Program.box_msg_book_Edit2);
                    MessageBox.Show((this.Message));
                    this.Close();
                    return;
                }
                else
                {
                    MessageBox.Show((this.Message));
                    return;
                }
            }
            else // add/create/new aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
            {
                if (this._isSuccessful == true)
                {
                    this.Message =
                    String.Format("-- {0} --\n-- {1} --", Program.box_msg_book_Added, Program.box_msg_book_Create2);

                    var result =
                    MessageBox.Show((this.Message), "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                    if (result == DialogResult.No)
                    {
                        this.Close();
                        return;
                    }
                    else // result == DialogResult.Yes -- Yes! -- Will be ADDED NEXT new book.
                    {
                        this._isSuccessful = false; /** Cleare the fields */
                        this.txtNazvanie.Text = "";
                        this.txtAvtor.Text = "";
                        this.txtPrintYear.Text = "0";
                        return;
                    }
                }
                else
                {
                    MessageBox.Show((this.Message));
                    return;
                }
            }
        }
        #endregion

        #region RJ-Code -- SINGLETON pattern (Open a single form instance) -- SPISOK LITERATURY: YOUTUBE -- RJ_Code CRUD-MVP
        private static BookForm2 instance;  /** public  static BookForm2 GetInstace(Form parentContainer) */
        public  static BookForm2 GetInstace() 
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new BookForm2();
            }
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;

                instance.BringToFront();
            }
            return instance;
        }
        #endregion

        #region method(s) publik mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm

        public void Junrs_SetCollectionBindingSource(IDictionary<short, string> junrsDictionary)
        {
            //*MessageBox.Show("BookForm_2-->Junrs_SetCollectionBindingSource-444444----180", Program.box_title);

            this.cmbJunrs.DataSource = new BindingSource(junrsDictionary.ToArray(), null);

            //2022-10-12    ---    cmbJunrs -- OPISANIE - look to konstruktor !!
            this.cmbJunrs.DisplayMember = "Value";
            this.cmbJunrs.ValueMember = "Key";
            return;
        }

        public IDictionary<string, string> Get_Book_dictionary()
        {
            var book_dictionary = new Dictionary<string, string>();

            book_dictionary["Id_book"] = this._id_book;
            book_dictionary["Nazvanie"] = this.txtNazvanie.Text;
            book_dictionary["Autor"] = this.txtAvtor.Text;
            book_dictionary["Year_print"] = this.txtPrintYear.Text;
            book_dictionary["Id_junr"] = this.cmbJunrs.SelectedValue.ToString();

            return book_dictionary;
        }

        public void Set_Book_dictionary(IDictionary<string, string> tb_book_dictionary)
        {
            /**
            /   1.
            */
            {
            this._id_book = tb_book_dictionary["Id_book"];
            this.Text = tb_book_dictionary["Nn"];
            this.txtNazvanie.Text = tb_book_dictionary["Nazvanie"];
            this.txtAvtor.Text = tb_book_dictionary["Autor"];
            this.txtPrintYear.Text = tb_book_dictionary["Year_print"];
            }
            /**
            /   2. Define index for comboBox this.cmbJunrs.SelectedIndex. 2022-10-30
            /   this.cmbJunrs.SelectedIndex = ...... defined !!
            */
            {
            if (this.IsEdit == true)                                 // if edit
            {
                string id_junr = tb_book_dictionary["Id_junr"];

                for (int i = 0; i < this.cmbJunrs.Items.Count; i++)
                {
                    var y1 = this.cmbJunrs.Items[i].ToString();

                    if (y1.Contains(id_junr) == true)
                    {
                        this.cmbJunrs.SelectedIndex = i;
                        break;
                    };
                }
            }
            else                                                     // if add
            {
                this.cmbJunrs.SelectedIndex = 0;
            }
            }
            return;
        }
        #endregion
    }
}
