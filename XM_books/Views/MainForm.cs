using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XM_books.Presenters;

namespace XM_books.Views
{
    public partial class MainForm : Form, IMainForm
    {
        #region field(s) mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
        private int    _junr_CurrentIndex = -1; //mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
        private int    _book_CurrentIndex = -1; //mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
        private string message; //mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
        #endregion

        #region propertie(s) mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
        public string txtSearchCurrentText
        {
            get => this.txtSearch.Text;
            set => this.txtSearch.Text = value;
        }
        public int cmbJunrs_CurrentIndex
        {
            get => this.cmbJunrs.SelectedIndex;
            set => this.cmbJunrs.SelectedIndex = value;
        }
        public int dgvBooks_CurrentIndex
        {
            get
            {
                //
                // 2022-10-04
                // 1? skol'ko strok/rows v dgvBooks ... spisok pust(Empty) ?!!
                // 2? skol'ko strok/rows vydeleno ... t.e. budem rabotat_ s "current" strokoy/row !!
                //
                int check = dgvBooks.Rows.Count * dgvBooks.SelectedRows.Count;
                if ( check <= 0) return this._book_CurrentIndex = -1;

                return this._book_CurrentIndex = this.dgvBooks.CurrentRow.Index;
            }
            set => this.status_NomerTekuscheyStrokiNum.Text = "" + (this._book_CurrentIndex = value);
        }
        #endregion

        // eventHandler(s) mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
        public event EventHandler FilterEvent;
        public event EventHandler btnAdd_Click; /** <<<---- --- -- */
        public event EventHandler btnEdit_Click;
        public event EventHandler btnDelete_Click;
        public event EventHandler btnExit_Click;

        #region konstruktor(s) mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
        public MainForm()
        {
            //*MessageBox.Show("MainForm() ------- 60", Program.box_title);
            InitializeComponent();

            // AssociateAndRaiseViewEvents();
            btnExit.Click += delegate { this.Close(); }; // Look RJ-Code !!  --  //btnClose.Click += delegate { this.Close(); };

            // cmbJunrs -- OPISANIE
            this.cmbJunrs.DisplayMember = "name_junr";   // Look MainForm.Designer.cs --> InitializeComponent() --> line 332
            this.cmbJunrs.ValueMember = "id_junr";

            // dgvBooks -- OPISANIE VNESHNEGO VIDA
            this.StyleDatagridview_2(this.dgvBooks);
            this.InitializeDataGridView_2(this.dgvBooks);
        }
        #endregion

        #region methods private -- OnLoad(), Show(), InitializeDataGridView_2(), StyleDatagridview()

        private void InitializeDataGridView_2(DataGridView _dGrid)
        {
            // Bind the DataGridView to its own Columns collection.
            //*MessageBox.Show("MainForm --> InitializeDataGridView_2 ------- 80", Program.box_title);

            // _dGrid.AutoGenerateColumns = false;

            List<IDictionary<string, string>> dgbBooks_Opisanie = new List<IDictionary<string, string>>();

dgbBooks_Opisanie.Add(new Dictionary<string, string>() {{"DataPropertyName", "Nn" },      { "HeaderText", "№№" },           { "Name", "nn" }        });
dgbBooks_Opisanie.Add(new Dictionary<string, string>() {{"DataPropertyName", "Nazvanie" },{ "HeaderText", "Название" },     { "Name", "nazvanie" }  });
dgbBooks_Opisanie.Add(new Dictionary<string, string>() {{"DataPropertyName", "Autor" },   { "HeaderText", "Автор(ы)" },     { "Name", "autor" }     });
dgbBooks_Opisanie.Add(new Dictionary<string, string>() {{"DataPropertyName", "Year_print" },{ "HeaderText", "Год\nиздания" },{ "Name", "Year_print" }});
/**
dgbBooks_Opisanie.Add(new Dictionary<string, string>() {{"DataPropertyName", "PublicYear"},{ "HeaderText", "Год\nиздания" },{ "Name", "Year_print" }});
*/
dgbBooks_Opisanie.Add(new Dictionary<string, string>() {{"DataPropertyName", "Name_junr"},{ "HeaderText", "Жанр" },         { "Name", "name_junr" } });
dgbBooks_Opisanie.Add(new Dictionary<string, string>() {{"DataPropertyName", "" },        { "HeaderText", "Примечания" },   { "Name", "comment" }   });
dgbBooks_Opisanie.Add(new Dictionary<string, string>() {{"DataPropertyName", "id_book" }, { "HeaderText", "id_book" },      { "Name", "id_book" }   });
dgbBooks_Opisanie.Add(new Dictionary<string, string>() {{"DataPropertyName", "id_junr" }, { "HeaderText", "id_junr" },      { "Name", "id_junr" }   });


            _dGrid.ColumnCount = dgbBooks_Opisanie.Count;  //2022-09-30. VAzhno zadaju/settig kolichestvo stolbstov/column(s) !!

            var i = 0;
            foreach (Dictionary<string, string> _column in dgbBooks_Opisanie)
            {
            _dGrid.Columns[i].DataPropertyName = _column["DataPropertyName"]; //2022-09-30 Year_print
            _dGrid.Columns[i].HeaderText       = _column["HeaderText"];       //2022-09-30
            _dGrid.Columns[i++].Name           = _column["Name"];             //2022-09-30
            }

            _dGrid.AutoSizeColumnsMode     = DataGridViewAutoSizeColumnsMode.None;
            _dGrid.Columns["nn"        ].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader; //.AllCells;
            _dGrid.Columns["nazvanie"  ].Width = 350;
            _dGrid.Columns["autor"     ].Width = 250;
            _dGrid.Columns["Year_print"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader; //.AllCells;
            _dGrid.Columns["name_junr" ].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            _dGrid.Columns["comment"   ].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _dGrid.Columns["id_book"   ].Visible = false;
            _dGrid.Columns["id_junr"   ].Visible = false;

            return;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            //*MessageBox.Show("MainForm --> OnLoad ------- 145", Program.box_title);

            this.dgvBooks_SelectionChanged();
            this.dgvBooks.Select();
            this.AssociateAndRaiseViewEvents();
            this.status_NomerTekuscheyStrokiTxt.Text = String.Format("{0}{0} ТЕКУЩЕЙ СТРОКИ:", Program.frm_NN); // String.Format("НОМЕР ТЕКУЩЕЙ СТРОКИ:");
            return;
        }

        public void Show()
        {
            //*MessageBox.Show("MainForm --> Show ------- 155", Program.box_title);

            this.dgvBooks_SelectionChanged();
            this.dgvBooks.Select();                        //AssociateAndRaiseViewEvents();

            return;
        }

        private void StyleDatagridview_2(DataGridView _dGrid)
        {
            //_dGrid.Name = "dbgBooks";
            //_dGrid.TabIndex = 7;
            //_dGrid.Size = new System.Drawing.Size(720, 240);
            //_dGrid.Location = new System.Drawing.Point(24, 77);

            _dGrid.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);

            _dGrid.ScrollBars = ScrollBars.Both;
            _dGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _dGrid.DefaultCellStyle.SelectionBackColor = Color.DarkSeaGreen; //.Honeydew; //.Red; //.DarkTurquoise;
            //
            //Generale
            _dGrid.AllowDrop                = false;
            _dGrid.AllowUserToAddRows       = false;
            _dGrid.AllowUserToDeleteRows    = false;
            _dGrid.AllowUserToOrderColumns  = true;
            _dGrid.AllowUserToResizeColumns = true;
            _dGrid.AllowUserToResizeRows    = false;

            _dGrid.BackgroundColor = System.Drawing.Color.DarkGreen; //.Gainsboro; // -<<---- Red;
            _dGrid.BorderStyle = BorderStyle.None;
            _dGrid.EditMode = DataGridViewEditMode.EditOnEnter;
            _dGrid.MultiSelect = false;
            _dGrid.ReadOnly = true;
            //
            //Header
            _dGrid.EnableHeadersVisualStyles = false;
            _dGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            _dGrid.ColumnHeadersHeight = 40;
            _dGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            _dGrid.ColumnHeadersDefaultCellStyle.Font = new Font("MS Reference Sans Serif", 12, FontStyle.Bold);
            _dGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGreen; //.FromArgb(37, 37, 38);
            _dGrid.ColumnHeadersDefaultCellStyle.ForeColor          = Color.White;
            _dGrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(37, 37, 38);
            _dGrid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            //
            //Table
            _dGrid.SelectionMode   = DataGridViewSelectionMode.FullRowSelect;
            _dGrid.AlternatingRowsDefaultCellStyle.BackColor          = Color.FromArgb(238, 239, 249);
            _dGrid.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.DarkSeaGreen; // BlueViolet;
            _dGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            _dGrid.DefaultCellStyle.SelectionBackColor = Color.DarkSeaGreen;  //.BlueViolet //.Honeydew; //.Red; //.DarkTurquoise;
            _dGrid.DefaultCellStyle.SelectionForeColor = Color.DarkViolet; //.BlueViolet; //.Yellow;

            /**
             Left column or cell
             2022-11-16
             stackoverflow.com -- c# Gridview удалить левый столбец Элемент управления Windows Forms?
             Это заголовок строки.
             Его можно удалить.
             С помощью конструктора (или кода) задает свойство:
             datagridview.RowHeadersVisible = False
            */
            _dGrid.RowHeadersVisible = false;
            _dGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            //_dGrid.RowHeadersWidth = 62;

            return;
        }
        #endregion

        #region method(s) private mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
        private void AssociateAndRaiseViewEvents()
        {
            //*MessageBox.Show("MainForm --> AssociateAndRaiseViewEvents()-------170", Program.box_title);

            //Junr_Changed
            cmbJunrs.SelectedIndexChanged += delegate { this.FilterEvent?.Invoke(this, EventArgs.Empty); };

            //Search_Filter
            txtSearch.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) FilterEvent?.Invoke(this, EventArgs.Empty); };
            btnSearch.Click   += delegate { this.FilterEvent?.Invoke(this, EventArgs.Empty); };

            //Edit Update Redaktirovanie stroki/row
            this.dgvBooks.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) btnEdit_Click?.Invoke(this, EventArgs.Empty); };
            this.btnEdit.Click += delegate { this.btnEdit_Click?.Invoke(this, EventArgs.Empty); };

            this.btnDel.Click += delegate
            {
                if (btnDelete_Click != null)
                {
                    btnDelete_Click(this, EventArgs.Empty);
                }
            };
            this.btnExit.Click += delegate { this.Close(); };
/**-<<----*/this.btnAddNew.Click += delegate
            {
                //*MessageBox.Show("MainForm-->btnAddNew.Click----190", Program.box_title);
                if (btnAdd_Click != null)
                {
                    btnAdd_Click(this, EventArgs.Empty);
                }
            };
        }

        private void dgvBooks_SelectionChanged(object sender, EventArgs e)
        {
            dgvBooks_SelectionChanged();
            return;
        }

        private void dgvBooks_SelectionChanged()
        {
            int dgvBooks_CountRows = dgvBooks.Rows.Count;
            this.status_VsegoStrokNum.Text = "" + dgvBooks.Rows.Count;

            if (dgvBooks_CountRows > 0)
            {
                this.status_NomerTekuscheyStrokiNum.Text = "" + (dgvBooks.CurrentRow.Index + 1);
                this.status_NomerTekuscheyStrokiNum.Text = "" + (dgvBooks.CurrentRow.Cells[1].Value);

                this.btnDel.Enabled    = true;
                this.btnEdit.Enabled   = true;
            }
            else
            {
                this.status_NomerTekuscheyStrokiNum.Text = "" + 0;

                this.btnDel.Enabled    = false;
                this.btnEdit.Enabled   = false;
            }
            return;
        }
        #endregion

        #region method(s) public  2022-09-04  -->  it is o'key mmmmmmmmmmmmmmmmm
        public void Books_SetCollectionBindingSource(BindingSource booksBinding, BindingSource junrsBinding)
        {
            //*MessageBox.Show("MainForm-->Books_SetCollectionBindingSource---------235", Program.box_title);

            this.cmbJunrs.DataSource    = junrsBinding;
            this.dgvBooks.DataSource    = booksBinding;  //this.nvgBooks.BindingSource = booksBinding;

            return;
        }
        #endregion
    }
}
